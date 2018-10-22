using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.FormsBook.Toolkit
{
    public class BmpMaker
    {
        const int headerSize = 54;
        readonly byte[] buffer;

        public BmpMaker(int width, int height)
        {
            Width = width;
            Height = height;

            int numPixels = Width * Height;
            int numPixelBytes = 4 * numPixels;
            int fileSize = headerSize + numPixelBytes;
            buffer = new byte[fileSize];

            // Write headers in MemorySTream and hencce the buffer.
            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (BinaryWriter write = new BinaryWriter(memoryStream, Encoding.UTF8))
                {
                    // Construct BMP header
                    write.Write(new char[] { 'B', 'M' });      //  Signature
                    write.Write(fileSize);      // File size
                    write.Write((short)0);      // reserved
                    write.Write((short)0);      // reserved
                    write.Write(headerSize);      // Offset to pixels

                    // Construct BitmapInfoHeader
                    write.Write(40);      // Header size
                    write.Write(Width);      //   Pixel Width
                    write.Write(Height);      // Pixel Height
                    write.Write((short)1);      // Planes
                    write.Write((short)32);      //   Bits per pixel
                    write.Write(0);      //  compression
                    write.Write(numPixelBytes);      //  Image size in bytes
                    write.Write(0);      // X pixels per meter
                    write.Write(0);      // Y pixels per meter
                    write.Write(0);      //  Nubm,er of colors in color table
                    write.Write(0);      // Important color count
                }
            }
        }
        public int Width
        {
            private set;
            get;
        }

        public int Height
        {
            private set;
            get;
        }

        public void SetPixel(int row, int col, Color color)
        {
            SetPixel(row, col,
                (int)(255 * color.R),
                (int)(255 * color.G),
                (int)(255 * color.B),
                (int)(255 * color.A));
        }

        public void SetPixel(int row, int col, int r, int g, int b, int a = 255)
        {
            int index = (row * Width + col) * 4 + headerSize;
            buffer[index + 0] = (byte)b;
            buffer[index + 1] = (byte)g;
            buffer[index + 2] = (byte)r;
            buffer[index + 3] = (byte)a;
        }

        public ImageSource Generate()
        {
            // Create MemoryStream from buffer with bitmap.
            MemoryStream memoryStream = new MemoryStream(buffer);

            // Convert to StreramImageSource
            ImageSource imageSource = ImageSource.FromStream(() =>
            {
                return memoryStream;
            });
            return imageSource;
        }
    }
}

