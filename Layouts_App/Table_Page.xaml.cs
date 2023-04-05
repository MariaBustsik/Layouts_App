using Plugin.Messaging;
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
    public partial class Table_Page : ContentPage
    {
        TableView table;
        SwitchCell sc;
        ImageCell ic;

        TableSection foto, lisa;

        EntryCell tel_cell, email_cell;
        Button call_btn, letter_btn, message_btn;

        public Table_Page()
        {
            sc = new SwitchCell { Text = "Näita veel" };
            sc.OnChanged += Sc_OnChanged;
            ic = new ImageCell
            {
                ImageSource = ImageSource.FromFile("flower.jpg"),
                Text = "Foto nimetus",
                Detail = "Kirjeldus"

            };

            foto = new TableSection();

            call_btn = new Button { Text = "Helista", BackgroundColor = Color.Green, TextColor = Color.White }; call_btn.Clicked += ButtonClicked;
            letter_btn = new Button { Text = "Saada email", BackgroundColor = Color.Red, TextColor = Color.White }; letter_btn.Clicked += ButtonClicked;
            message_btn = new Button { Text = "Saada SMS", BackgroundColor = Color.Orange, TextColor = Color.White }; message_btn.Clicked += ButtonClicked;


            var layout = new StackLayout
            {
                Children = { call_btn, letter_btn, message_btn },
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center
            };

            lisa = new TableSection
            {
                new ViewCell
                {
                  View = layout
                }
            };

            tel_cell = new EntryCell
            {
                Label = "Telefon",
                Placeholder = "Sisesta tel. number",
                Keyboard = Keyboard.Telephone
            };

            email_cell = new EntryCell
            {
                Label = "Email",
                Placeholder = "Sisesta email",
                Keyboard = Keyboard.Email
            };


            table = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot("Andmete sisestamine")
                {
                    new TableSection("Põhiandmed:")
                    {
                        new EntryCell
                        {
                            Label="Nimi:",
                            Placeholder="Sisesta nimi",
                            Keyboard=Keyboard.Default
                        }
                    },
                    new TableSection("Kontaktandmed:")
                    {
                        new EntryCell
                        {
                            Label="Telefon:",
                            Placeholder="Sisesta oma telefon nr:",
                            Keyboard=Keyboard.Telephone
                        },

                        new EntryCell
                        {
                            Label="E-mail:",
                            Placeholder="Sisesta oma e-mail:",
                            Keyboard=Keyboard.Email
                        },

                        new EntryCell
                        {
                            Label = "Tekst:",
                            Placeholder = "Sissesta oma teksti:",
                            Keyboard = Keyboard.Default
                        },

                        tel_cell,
                        email_cell,
                        sc

                    },
                    foto,
                    lisa
                }
            };




            Content = table;
        }


        private void Sc_OnChanged(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                foto.Title = "Foto";
                foto.Add(ic);
                sc.Text = "Peida";
            }
            else
            {
                foto.Title = "";
                foto.Remove(ic);
                sc.Text = "Näita";
            }
        }

        private async void ButtonClicked(object sender, EventArgs e)
        {
            if (sender == call_btn)
            {
                var call = CrossMessaging.Current.PhoneDialer;
                if (call.CanMakePhoneCall)
                {
                    call.MakePhoneCall(tel_cell.Text);
                }
            }

            else if (sender == letter_btn)
            {
                var result = await DisplayPromptAsync("Letter Text", "Sisesta sõnum: ");
                var message = result;
                var mail = CrossMessaging.Current.EmailMessenger;
                if (mail.CanSendEmail)
                {
                    mail.SendEmail(email_cell.Text, "Tervitus!", message);
                }
            }

            else if (sender == message_btn)
            {
                var result = await DisplayPromptAsync("Letter Text", "Sisesta sõnum: ");
                var message = result;
                var sms = CrossMessaging.Current.SmsMessenger;
                if (sms.CanSendSms)
                {
                    sms.SendSms(tel_cell.Text, message);
                }
            }

        }
    }
}

    