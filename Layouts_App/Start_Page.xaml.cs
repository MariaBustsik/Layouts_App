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
    public partial class Start_Page : ContentPage
    {
        public Start_Page()
        {
            //InitializeComponent();

            Button Editor_btn = new Button
            {
                Text = "Editor Page",
                BackgroundColor = Color.FromRgb(125, 10, 100)
            };

            StackLayout st = new StackLayout();
            st.Children.Add(Editor_btn);
            Content = st;

            Editor_btn.Clicked += Editor_btn_Clicked;
        }

        private async void Editor_btn_Clicked (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Editor_Page());
        }
    }
}