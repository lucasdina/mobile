﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonkeyTapGame
{
    class SoundPlayer
    {
        const int samplingRate = 22050;

        public static byte[] MakeBuffer(double frequency = 400, int duration = 250)
        {
            short[] shortBuffer = new short[samplingRate * duration / 1000];
            double angleIncrement = frequency / samplingRate;
            double angle = 0.0;
            for (int i = 0; i < shortBuffer.Length; i++)
            {
                double sample;
                if (angle < 0.25)
                {
                    sample = 4 * angle;
                } else if (angle < 0.75)
                {
                    sample = 4 * (0.5 - angle);
                } else
                {
                    sample = 4 * (angle - 1);
                }
                shortBuffer[i] = (short)(32767 * sample);
                angle += angleIncrement;
                 while (angle > 1)
                {
                    angle -= 1;
                }
            }
            byte[] byteBuffer = new byte[2 * shortBuffer.Length];
            Buffer.BlockCopy(shortBuffer, 0, byteBuffer, 0, byteBuffer.Length);
            return byteBuffer;
        }

        // Hard-coded for monaural, 16-bit-per-sample PCM
        public static void PlaySound(double frequency = 400, int duration = 250)
        {
            short[] shortBuffer = new short[samplingRate * duration / 1000];
            double angleIncrement = frequency / samplingRate;
            double angle = 0.0;

            for (int i = 0; i < shortBuffer.Length; i++)
            {
                // Define triangel wave
                double sample;

                // 0 to 1
                if (angle < 0.25)
                    sample = 4 * angle;

                // 1 to -1
                else if (angle < 0.75)
                    sample = 4 * (0.5 - angle);

                // -1 to 0
                else sample = 4 * (angle - 1);

                shortBuffer[i] = (short)(32767 * sample);
                angle += angleIncrement;

                while (angle > 1)
                    angle -= 1;
            }

            byte[] byteBuffer = new byte[2 * shortBuffer.Length];
            Buffer.BlockCopy(shortBuffer, 0, byteBuffer, 0, byteBuffer.Length);

            DependencyService.Get<IPlatformSoundPlayer>().PlaySound(samplingRate, byteBuffer);
        }
    }
}
