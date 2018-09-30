using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project1
{
    public partial class GreetingsRandyPage : ContentPage
    {
        public GreetingsRandyPage()
        {
            FormattedString formattedString = new FormattedString();
            formattedString.Spans.Add(new Span
            {
                Text = "I "
            });
            formattedString.Spans.Add(new Span
            {
                Text = "love",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold
            });
            formattedString.Spans.Add(new Span
            {
                Text = " Xamarin.Forms!"
            });
            Content = new Label
            {
                FormattedText = formattedString,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            //InitializeComponent();
        }
    }
}
