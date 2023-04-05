using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Layouts_App
{
    internal class Picker_Page : ContentPage
    {
        Picker picker;
        WebView webview;
        Frame frame;
        Entry entry;
        Button btn;
        string[] lehed = new string[3] { "https://tahvel.edu.ee", "https://moodle.edu.ee", "https://www.tthk.ee/" };
        StackLayout st;
        public Picker_Page()
        {
            picker = new Picker
            {
                Title = "Lehed"
            };
            picker.Items.Add("Tahvel");
            picker.Items.Add("Moodle");
            picker.Items.Add("TTHK");
            webview = new WebView { Source = new UrlWebViewSource { Url = lehed[0] } };
            picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

            frame = new Frame
            {
                Content = webview,
                BorderColor = Color.Beige,
                CornerRadius = 10,
                HeightRequest = 200,
                WidthRequest = 400,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HasShadow = true
            };
            entry = new Entry { };
            entry.Completed += Entry_Completed;
            btn = new Button { Text = "Koduleht" };
            btn.Clicked += Btn_Clicked;
            st = new StackLayout { Children = { picker, entry, btn, frame } };
            Content = st;
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            webview.Source = new UrlWebViewSource { Url = (string)Preferences.Get("link", "https://www.postimees.ee/") };//(string)App.Current.Properties["link"] };
        }

        protected override void OnAppearing()
        {
            object link = "";
            entry.Text = Preferences.Get("link", "https://www.postimees.ee/");
            //if (App.Current.Properties.TryGetValue("link", out link))
            //{
            //entry.Text= (string)App.Current.Properties["link"];

            //}
            base.OnAppearing();
        }
        private void Entry_Completed(object sender, EventArgs e)
        {
            string value = "https://www." + entry.Text;
            //App.Current.Properties["link"]=value;
            Preferences.Set("link", value);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            webview.Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] };
        }
    }
}