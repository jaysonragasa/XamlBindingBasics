using System;
using Xamarin.Forms;

namespace BindingBasics
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnGeet.Clicked += BtnGeet_Clicked;
        }

        private void BtnGeet_Clicked(object sender, EventArgs e)
        {
            lblGreet.Text = "Hello World";
        }
    }
}
