using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CheckboxDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnItalicCheckBoxChanged(object sender, bool isChecked)
        {
            if (isChecked)
            {
                label.FontAttributes |= FontAttributes.Italic;
            }
            else
            {
                label.FontAttributes &= ~FontAttributes.Italic;
            }

        }

        void OnBoldCheckBoxChanged(object sender, bool isChecked)
        {
            if (isChecked)
            {
                label.FontAttributes |= FontAttributes.Bold;
            }
            else
            {
                label.FontAttributes &= ~FontAttributes.Bold;
            }

        }

    }
}
