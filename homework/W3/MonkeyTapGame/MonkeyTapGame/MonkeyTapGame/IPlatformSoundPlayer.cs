using System;
using System.Collections.Generic;
using System.Text;

namespace MonkeyTapGame
{
    class IPlatformSoundPlayer
    {
        void PlaySound(int samplingRate, byte[] pcmData);

    }
}
