using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HelloXamarin
{

    public partial class App : Application
    {
        private Entry syötekenttä;
        private Label arvauksenTulosLabel;

        private int oikeaLuku;

        public App()
        {
            Random rnd = new Random();
            oikeaLuku = rnd.Next(1, 21);

            // painonapin alustus
            Button arvaaNappi = new Button();
            arvaaNappi.Text = "Arvaa";
            arvaaNappi.Clicked += ArvaaNappi_Clicked;

            syötekenttä = new Entry
            {
                Keyboard = Keyboard.Numeric,
                Text = ""
            };

            arvauksenTulosLabel = new Label();
            arvauksenTulosLabel.Text = "";

            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                //VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Label
                    {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Arvaa luku",
                        TextColor = Color.Red,
                        BackgroundColor = Color.Black
                    },
                    new Label
                    {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Sovellusversio 0.10",
                        TextColor = Color.Black,
                        BackgroundColor = Color.Silver
                    },
                    syötekenttä,
                    arvaaNappi,
                    arvauksenTulosLabel
                }
            }
        };
    }

        private void ArvaaNappi_Clicked(object sender, EventArgs e)
        {
            int arvaus = int.Parse(syötekenttä.Text);
            if (arvaus < oikeaLuku)
            {
                arvauksenTulosLabel.Text = "Luku on suurempi.";
            }
            else if (arvaus > oikeaLuku)
                     {
                arvauksenTulosLabel.Text = "Luku on pienempi.";
            }
            else if (arvaus == oikeaLuku) {
                arvauksenTulosLabel.Text = "Voitit pelit!";
                Random rnd = new Random();
                oikeaLuku = rnd.Next(1, 21);

            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
