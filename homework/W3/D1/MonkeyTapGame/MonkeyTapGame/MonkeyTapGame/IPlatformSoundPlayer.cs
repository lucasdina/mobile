using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeyTapGame
{
    public interface IPlatformSoundPlayer
    {
        void PlaySound(int samplingRate, byte[] pcmData);

    }
}
