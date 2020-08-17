using System;
using System.Runtime.InteropServices;
using System.Text;

namespace extremeBassBoost
{
    class SoundRecorder
    {
        private uint bufferLength;
        private uint sampleRate;
        private ushort bitsPerSample;
        private ushort channels;

        public event EventHandler<NewDataEventArgs> NewDataPresent;

        private SoundCallbackDelegate soundCallbackDelegate;
        private IntPtr waveInHandle = IntPtr.Zero;

        public IntPtr[] bufferIP = new IntPtr[2];

        private bool finishing = false;

        public SoundRecorder(ushort bitsPerSample, ushort channels, uint sampleRate, uint bufferLength)
        {
            this.bitsPerSample = bitsPerSample;
            this.channels = channels;
            this.sampleRate = sampleRate;
            this.bufferLength = bufferLength;
        }

        public void Start()
        {
            if (waveInHandle != IntPtr.Zero)
            {
                return;
            }

            WAVEFORMATEX waveFormatEx = new WAVEFORMATEX();
            waveFormatEx.wFormatTag = WAVE_FORMAT_PCM;
            waveFormatEx.nChannels = channels;
            waveFormatEx.nSamplesPerSec = sampleRate;
            waveFormatEx.wBitsPerSample = bitsPerSample;
            waveFormatEx.cbSize = 0;

            waveFormatEx.nBlockAlign = (ushort)(waveFormatEx.nChannels * waveFormatEx.wBitsPerSample / 8);
            waveFormatEx.nAvgBytesPerSec = waveFormatEx.nSamplesPerSec * waveFormatEx.nBlockAlign;

            soundCallbackDelegate = SoundCallback;

            //1 for virtual audio cable, WAVE_MAPPER for microphone
            CheckError(waveInOpen(ref waveInHandle, 1, ref waveFormatEx, soundCallbackDelegate, this, CALLBACK_FUNCTION));
            //CheckError(waveInOpen(ref waveInHandle, WAVE_MAPPER, ref waveFormatEx, soundCallbackDelegate, this, CALLBACK_FUNCTION));

            for (int i = 0; i < 2; ++i)
            {
                unsafe
                {
                    bufferIP[i] = Marshal.AllocHGlobal(32); // to prevent GC from deleting

                    WAVEHDR* bufptr = (WAVEHDR*)bufferIP[i].ToPointer();

                    bufptr->lpData = Marshal.AllocHGlobal((int)bufferLength);
                    bufptr->dwBufferLength = bufferLength;
                    bufptr->dwFlags = 0;

                    CheckError(waveInPrepareHeader(waveInHandle, ref *bufptr, 32));
                    CheckError(waveInAddBuffer(waveInHandle, ref *(WAVEHDR*)bufferIP[i].ToPointer(), 32));
                }
            }

            CheckError(waveInStart(waveInHandle));
        }

        public void Stop()
        {
            if (waveInHandle == IntPtr.Zero)
            {
                return;
            }

            finishing = true;
            CheckError(waveInStop(waveInHandle));
            CheckError(waveInReset(waveInHandle));

            for (int i = 0; i < 2; ++i)
            {
                unsafe
                {
                    WAVEHDR* bufptr = (WAVEHDR*)bufferIP[i].ToPointer();

                    CheckError(waveInUnprepareHeader(waveInHandle, ref *bufptr, 32));

                    Marshal.FreeHGlobal(bufptr->lpData);
                    Marshal.FreeHGlobal(bufferIP[i]);
                }
            }

            CheckError(waveInClose(waveInHandle));
            waveInHandle = IntPtr.Zero;
            finishing = false;
        }

        private void CheckError(uint errorCode)
        {
            if (errorCode != 0)
            {
                const int maxLength = 256;
                StringBuilder sb = new StringBuilder(maxLength);
                waveInGetErrorText(errorCode, sb, maxLength);

                throw new Exception(sb.ToString());
            }
        }

        public class NewDataEventArgs : EventArgs
        {
            public short[] data;

            public NewDataEventArgs(short[] data)
            {
                this.data = data;
            }
        }

        public struct WAVEFORMATEX
        {
            public ushort wFormatTag;
            public ushort nChannels;
            public uint nSamplesPerSec;
            public uint nAvgBytesPerSec;
            public ushort nBlockAlign;
            public ushort wBitsPerSample;
            public ushort cbSize;
        }

        public struct WAVEHDR
        {
            public IntPtr lpData;
            public uint dwBufferLength;
            public uint dwBytesRecorded;
            public uint dwUser;
            public uint dwFlags;
            public uint dwLoops;
            public IntPtr lpNext;
            public uint reserved;
        }

        private const uint WAVE_MAPPER = 0xffffffff;
        private const ushort WAVE_FORMAT_PCM = 1;
        private const uint CALLBACK_FUNCTION = 0x00030000;
        public const uint WIM_OPEN = 0x3BE;
        public const uint WIM_CLOSE = 0x3BF;
        public const uint WIM_DATA = 0x3C0;

        [DllImport("winmm.dll")]
        public static extern uint waveInOpen(ref IntPtr phwi, uint deviceID, ref WAVEFORMATEX wfx, SoundCallbackDelegate dwCallback, SoundRecorder dwInstance, uint dwFlags);
        [DllImport("winmm.dll")]
        public static extern uint waveInPrepareHeader(IntPtr phwi, ref WAVEHDR pwh, uint cbwh);
        [DllImport("winmm.dll")]
        public static extern uint waveInAddBuffer(IntPtr phwi, ref WAVEHDR pwh, uint cbwh);
        [DllImport("winmm.dll")]
        public static extern uint waveInStart(IntPtr phwi);
        [DllImport("winmm.dll")]
        public static extern uint waveInGetErrorText(uint mmrError, StringBuilder pszText, uint cchText);
        [DllImport("winmm.dll")]
        public static extern uint waveInReset(IntPtr phwi);
        [DllImport("winmm.dll")]
        public static extern uint waveInStop(IntPtr phwi);
        [DllImport("winmm.dll")]
        public static extern uint waveInClose(IntPtr phwi);
        [DllImport("winmm.dll")]
        public static extern uint waveInUnprepareHeader(IntPtr phwi, ref WAVEHDR pwh, uint cbwh);

        public delegate void SoundCallbackDelegate(IntPtr hwi, uint uMsg, SoundRecorder dwInstance, uint dwParam1, uint dwParam2);

        public static unsafe void SoundCallback(IntPtr hwi, uint uMsg, SoundRecorder dwInstance, uint dwParam1, uint dwParam2)
        {
            if (uMsg == WIM_DATA)
            {
                WAVEHDR* bufptr = (WAVEHDR*)dwParam1;

                short[] data = new short[dwInstance.bufferLength / 2];
                Marshal.Copy(bufptr->lpData, data, 0, (int)(bufptr->dwBytesRecorded / 2));

                if (!dwInstance.finishing)
                {
                    uint retval = waveInUnprepareHeader(dwInstance.waveInHandle, ref *bufptr, 32);
                    uint retval2 = waveInPrepareHeader(dwInstance.waveInHandle, ref *bufptr, 32);
                    uint retval3 = waveInAddBuffer(dwInstance.waveInHandle, ref *bufptr, 32);

                    if (retval != 0 || retval2 != 0 || retval3 != 0)
                    {
                        System.Windows.Forms.MessageBox.Show(string.Format("error in WIM_DATA: {0} {1} {2}\n", retval, retval2, retval3));
                    }
                }

                dwInstance.OnNewDataPresent(data);
            }
        }

        private void OnNewDataPresent(short[] data)
        {
            if (NewDataPresent != null)
            {
                NewDataPresent(this, new NewDataEventArgs(data));
            }
        }
    }
}
