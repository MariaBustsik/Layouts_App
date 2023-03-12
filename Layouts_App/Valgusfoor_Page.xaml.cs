using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Layouts_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Valgusfoor_Page : ContentPage
    {
        Button on;
        Button off;
        Label punane, kollane, roheline;
        Frame red;
        Frame yellow;
        Frame green;
        int turned = 1;
        public Valgusfoor_Page()
        {
            on = new Button
            {
                Text = "Lülita sisse",
                BackgroundColor = Color.DarkKhaki,
                TextColor = Color.Black,
                CornerRadius = 150,
            };
            on.Clicked += On_Clicked;
            off = new Button
            {
                Text = "Lülita välja",
                HorizontalOptions = LayoutOptions.End,
                BackgroundColor = Color.DarkSalmon,
                TextColor = Color.Black,
                CornerRadius = 150,
            };
            off.Clicked += Off_Clicked;

            punane = new Label()
            {
                Text = "",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            kollane = new Label()
            {
                Text = "",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            roheline = new Label()
            {

                Text = "",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };



            red = new Frame
            {
                Content = punane,
                BackgroundColor = Color.Gray,
                WidthRequest = 150,
                HeightRequest = 150,
                CornerRadius = 150,
                Margin = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            yellow = new Frame
            {
                Content = kollane,
                BackgroundColor = Color.Gray,
                WidthRequest = 150,
                HeightRequest = 150,
                CornerRadius = 150,
                Margin = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            green = new Frame
            {
                Content = roheline,
                BackgroundColor = Color.Gray,
                WidthRequest = 150,
                HeightRequest = 150,
                CornerRadius = 150,
                Margin = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            FlexLayout knopki = new FlexLayout
            {
                Children = { on, off },
                JustifyContent = FlexJustify.SpaceEvenly
            };
            StackLayout st = new StackLayout
            {
                Children = { red, yellow, green, knopki }
            };

            
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            red.GestureRecognizers.Add(tap);
            yellow.GestureRecognizers.Add(tap);
            green.GestureRecognizers.Add(tap);
            
            Content = st;
            st.BackgroundColor = Color.BlanchedAlmond;

        }
        private async void Off_Clicked(object sender, EventArgs e)
        {

            turned = 1;

            red.BackgroundColor = Color.Gray;
            red.Opacity = 1;
            yellow.BackgroundColor = Color.Gray;
            yellow.Opacity = 1;
            green.BackgroundColor = Color.Gray;
            green.Opacity = 1;
            punane.Text = "";
            kollane.Text = "";
            roheline.Text = "";

        }

        private async void On_Clicked(object sender, EventArgs e)
        {
            turned = 0;
            if (turned == 1)
            {
                
            }
            else
            {

                punane.Text = "SEISA!";
                kollane.Text = "OOTA!";
                roheline.Text = "MINE!";
                while (turned != 1)
                {
                    red.BackgroundColor = Color.Red;
                    await Task.Delay(3000);
                    if (turned == 1) break;
                    red.BackgroundColor = Color.Gray;
                    yellow.BackgroundColor = Color.Yellow;
                    await Task.Delay(2000);
                    if (turned == 1) break;
                    yellow.BackgroundColor = Color.Gray;
                    green.BackgroundColor = Color.Green;
                    await Task.Delay(3000);
                    if (turned == 1) break;
                    green.BackgroundColor = Color.Gray;
                    await Task.Delay(500);
                    if (turned == 1) break;
                    green.BackgroundColor = Color.Green;
                    await Task.Delay(500);
                    if (turned == 1) break;
                    green.BackgroundColor = Color.Gray;
                    await Task.Delay(500);
                    if (turned == 1) break;
                    green.BackgroundColor = Color.Green;
                    await Task.Delay(500);
                    if (turned == 1) break;
                    green.BackgroundColor = Color.Gray;
                    yellow.BackgroundColor = Color.Yellow;
                    await Task.Delay(2000);
                    if (turned == 1) break;
                    yellow.BackgroundColor = Color.Gray;
                    
                }


            }

        }
        int i = 0;
        private void Tap_Tapped(object sender, EventArgs e)
        {
            if (turned == 0)
            {
                if (i == 0)
                {
                    punane.Text = "Punane";
                    kollane.Text = "Kollane";
                    roheline.Text = "Roheline";
                    i++;
                }
                else if (i == 1)
                {

                    punane.Text = "SEISA!";
                    kollane.Text = "OOTA!";
                    roheline.Text = "MINE!";
                    i = 0;
                }
            }
            else
            {
                DisplayAlert("Hoiatus!", "LÜLITAGE VALGUSFOOR SISSE!", "OK");
                punane.Text = "";
                kollane.Text = "";
                roheline.Text = "";
            }
        }
    }
}


