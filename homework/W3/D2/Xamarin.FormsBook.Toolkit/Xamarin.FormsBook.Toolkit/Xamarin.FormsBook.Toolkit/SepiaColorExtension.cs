using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.FormsBook.Toolkit
{
    public static class Toolkit
    {
        public static void Init()
        {

        }
    }

    public class SepiaColorExtension : IMarkupExtension
    {
        public SepiaColorExtension()
        {
            A = 1;
        }

        public double R { set; get; }

        public double G { set; get; }

        public double B { set; get; }

        public double A { set; get; }

        public object ProvideValue(IServiceProvider service)
        {
            return Color.FromRgba(R, G, B, A);
        }
    }
}
