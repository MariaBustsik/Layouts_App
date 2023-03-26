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
        List<ContentPage> pages=new List<ContentPage>() { new Editor_Page(), new Timer_Page(), new Box_Page(), new Valgusfoor_Page(), new Date_Time(), new StepperSlider_Page(), new RGB_Page(), new Image_Page(), new Frame_Page(), new Horoskop_Page ()};

        List<string> texts=new List<string> { "Editor Page", "Timer", "Box Page", "Valgusfoor Page", "Date/Time Page", "Stepper Slider Page", "RGB Page", "Image Page", "Frame Page", "Horoskop Page"};
        Random random = new Random();
        public Start_Page()
        {
            //InitializeComponent();

            StackLayout st = new StackLayout();

            for (int i = 0; i < pages.Count; i++) 
            {
                Button button = new Button 
                {
                    Text = texts[i],
                    BackgroundColor=Color.FromRgb(random.Next(0,255), random.Next(0, 255), random.Next(0, 255)),
                    TabIndex = i

                };

                st.Children.Add(button);
                button.Clicked += Button_Clicked;
            
            }
            
            Content = st;

            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button b = sender as Button;
            await Navigation.PushAsync(pages[b.TabIndex]);
        }

        


    }
}