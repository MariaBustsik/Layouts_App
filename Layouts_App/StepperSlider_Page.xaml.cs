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
    public partial class StepperSlider_Page : ContentPage
    {
        Stepper stp;
        Slider sld;
        Label lbl;
        public StepperSlider_Page()
        {
            stp = new Stepper
            {
                Minimum=0,
                Maximum=100,
                Value=50,
                Increment=5
            };

            stp.ValueChanged += Stp_ValueChanged;

            lbl = new Label
            {
                Text="TTHK",
                FontSize=stp.Value,
            };

            sld = new Slider
            {
                Minimum = stp.Minimum,
                Maximum = stp.Maximum,
                Value=stp.Value,
                MinimumTrackColor=Color.White,
                MaximumTrackColor=Color.Black
            };

            sld.ValueChanged += Stp_ValueChanged;

            //AbsoluteLayout abs = new AbsoluteLayout { Children = { stp, lbl, sld } };
            //AbsoluteLayout.SetLayoutBounds(stp, new Rectangle(0.2, 0.2, 300, 100));
            //AbsoluteLayout.SetLayoutFlags(stp, AbsoluteLayoutFlags.PositionProportional);
            //AbsoluteLayout.SetLayoutBounds(sld, new Rectangle(0.2, 0.8, 300, 500));
            //AbsoluteLayout.SetLayoutFlags(sld, AbsoluteLayoutFlags.PositionProportional);
            //AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.2, 0.8, 300, 100));
            //AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);
            //Content = abs;


            //sposob avtomatizatsii

            List<Object> objects = new List<Object> { lbl, stp, sld };
            AbsoluteLayout abs = new AbsoluteLayout();
            double y = 0;
            foreach (var item in objects)
            {
                y = y + 0.2;
                AbsoluteLayout.SetLayoutBounds((BindableObject)item, new Rectangle(0.2, y, 300, 100));
                AbsoluteLayout.SetLayoutFlags((BindableObject)item, AbsoluteLayoutFlags.PositionProportional);
                abs.Children.Add((View)(BindableObject)item);
            }
            Content = abs;

        }

        private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.FontSize = e.NewValue;
        }
    }
}