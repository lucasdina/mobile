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
                Text = "Hi, Randy! " + Environment.NewLine,
                ForegroundColor = Color.Red
            });
            formattedString.Spans.Add(new Span
            {
                Text = "This is Lucas." + Environment.NewLine,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                ForegroundColor = Color.Green
            });
            formattedString.Spans.Add(new Span
            {
                Text = "SWDV 265 Mobile Apps Developement",
                ForegroundColor = Color.Blue
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
