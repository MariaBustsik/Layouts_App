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

            Button Timer_btn = new Button
            {
                Text = "Timer",
                BackgroundColor = Color.FromRgb(223,15,100)
            };

            Button Box_btn = new Button
            {
                Text = "Box Page",
                BackgroundColor = Color.FromRgb(223, 45, 170)
            };

            StackLayout st = new StackLayout();
            st.Children.Add(Editor_btn);
            st.Children.Add(Timer_btn);
            st.Children.Add(Box_btn);
            Content = st;

            Editor_btn.Clicked += Editor_btn_Clicked;
            Timer_btn.Clicked += Timer_btn_Clicked;
            Box_btn.Clicked += Box_btn_Clicked;
        }

        private async void Box_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Box_Page());
        }

        private async void Timer_btn_Clicked (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Timer_Page());
        }

        private async void Editor_btn_Clicked (object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Editor_Page());
        }

        
    }
}