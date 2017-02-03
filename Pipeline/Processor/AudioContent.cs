﻿using System.Diagnostics.CodeAnalysis;
using System.IO;
using engenious.Audio;

namespace engenious.Pipeline
{
    public class AudioContent
    {
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public enum Format:ushort
        {
            PCM = 0x0001,
            MS_ADPCM = 0x0002,
            IEEE_FLOAT = 0x0003,
            IBM_CVSD = 0x0005,
            ALAW = 0x0006,
            MULAW = 0x0007,
            OKI_ADPCM = 0x0010,
            DVI_IMA_ADPCM = 0x0011,
            MEDIASPACE_ADPCM = 0x0012,
            SIERRA_ADPCM = 0x0013,
            G723_ADPCM = 0x0014,
            DIGISTD = 0x0015,
            DIGIFIX = 0x0016,
            DIALOGIC_OKI_ADPCM = 0x0017,
            YAMAHA_ADPCM = 0x0020,
            SONARC = 0x0021,
            DSPGROUP_TRUESPEECH = 0x0022,
            ECHOSC1 = 0x0023,
            AUDIOFILE_AF36 = 0x0024,
            APTX = 0x0025,
            AUDIOFILE_AF10 = 0x0026,
            DOLBY_AC2 = 0x0030,
            GSM610 = 0x0031,
            ANTEX_ADPCME = 0x0033,
            CONTROL_RES_VQLPC = 0x0034,
            CONTROL_RES_VQLPC_ = 0x0035,
            DIGIADPCM = 0x0036,
            CONTROL_RES_CR10 = 0x0037,
            NMS_VBXADPCM = 0x0038,
            CS_IMAADPCM = 0x0039,
            G721_ADPCM = 0x0040,
            MPEG1_Layer_I_II = 0x0050,
            MPEG1_Layer_III = 0x0055,
            Xbox_ADPCM = 0x0069,
            CREATIVE_ADPCM = 0x0200,
            CREATIVE_FASTSPEECH8 = 0x0202,
            CREATIVE_FASTSPEECH10 = 0x0203,
            FM_TOWNS_SND = 0x0300,
            OLIGSM = 0x1000,
            OLIADPCM = 0x1001,
            OLICELP = 0x1002,
            OLISBC = 0x1003,
            OLIOPR = 0x1004
        }

        public SoundEffect.AudioFormat OutputFormat { get; }
        public MemoryStream Data { get; }
        public AudioContent(SoundEffect.AudioFormat outputFormat, Stream inputStream, bool closeStream = true)
        {
            OutputFormat = outputFormat;
            Data = new MemoryStream();
            byte[] buffer = new byte[1024 * 1024];
            while (true)
            {
                int read = inputStream.Read(buffer, 0, buffer.Length);
                if (read == 0)
                    break;
                Data.Write(buffer,0,read);
            }
            Data.Position = 0;
        }
    }
}

