using System.Text;
using Foundation;
using Xamarin.Forms;
using AVFoundation;
using System.IO;

[assembly: Dependency(typeof(MonkeyTapGame.iOS.PlatformSoundPlayer))]
namespace MonkeyTapGame.iOS
{
    public class PlatformSoundPlayer : IPlatformSoundPlayer
    {
        const int numChannels = 1;
        const int bitsPerSample = 16;
        public void PlaySound(int samplingRate, byte[] pcmData)
        {
            int numSamples = pcmData.Length / (bitsPerSample / 8);

            MemoryStream memoryStream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(memoryStream, Encoding.ASCII);

            // Construct WAVE header
            writer.Write(new char[] { 'R', 'I', 'F', 'F', });
            writer.Write(36 + sizeof(short) * numSamples);
            writer.Write(new char[] { 'W', 'A', 'V', 'E', });
            writer.Write(new char[] { 'f', 'm', 't', ' ', });
            writer.Write(16);

            writer.Write((short)1);
            writer.Write((short)numChannels);
            writer.Write(samplingRate);

            writer.Write(samplingRate * numChannels * bitsPerSample / 8);
            writer.Write((short)(numChannels * bitsPerSample / 8));

            writer.Write((short)bitsPerSample);

            writer.Write(new char[] { 'd', 'a', 't', 'a', });
            writer.Write(numSamples * numChannels * bitsPerSample / 8);

            // Write data as well
            writer.Write(pcmData, 0, pcmData.Length);

            memoryStream.Seek(0, SeekOrigin.Begin);
            NSData data = NSData.FromStream(memoryStream);
            AVAudioPlayer audioPlayer = AVAudioPlayer.FromData(data);
            audioPlayer.Play();

        }
    }
}