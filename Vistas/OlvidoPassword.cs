using DocenteApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DocentesAPP
{
    public class OlvidoPassword : ContentView
    {
        StackLayout VistaGeneral;
        Entry Correo;
        Button Recuperar;
        Cargando loading;
        RelativeLayout VistaPrincipal;
        BoxView Navegacion;
        public OlvidoPassword()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.White;
            CrearVistas();
            AgregarVistas();
            AgregarEventos();
        } 
        void CrearVistas()
        {
            VistaPrincipal = new RelativeLayout();
            VistaGeneral = new StackLayout();
            VistaGeneral.HorizontalOptions = LayoutOptions.Center;
            VistaGeneral.VerticalOptions = LayoutOptions.CenterAndExpand;
            loading = new Cargando();
            Correo = new Entry
            {
                PlaceholderColor = Color.Black,
                Placeholder = "Correo Institucional",
                TextColor = Color.Black,
               Keyboard = Keyboard.Email    
            };
            Recuperar = new Button
            {
                Text = "Recuperar",
                BackgroundColor = Color.FromHex("2E4F8F"),
                TextColor = Color.White
                
            };
            Navegacion = new BoxView
            {
                BackgroundColor = Color.FromHex("2E4F8F")
            };

            Recuperar.Clicked += Recuperar_Clicked;
        }

        private async void Recuperar_Clicked(object sender, EventArgs e)
        {
            Logica log = new Logica();

            bool ValidarCorreo = log.ValidarCorreo(Correo);
            if (ValidarCorreo)
            {
                loading.IsVisible = true;
                await Task.Delay(1000);
                loading.IsVisible = false;
                await App.Current.MainPage.DisplayAlert("Alerta", "Correo No Valido", "OK");
                return;
            }

            await App.Current.MainPage.DisplayAlert("Alerta!", "Se envió correo de verificacion", "OK");
            loading.IsVisible = true;
            await Task.Delay(1000);
            loading.IsVisible = false;

            var respuesta = DependencyService.Get<IRestApiOlvidar>().LoginApp(Correo.Text);
            if (respuesta.Ok == 0)
            {
                await Navigation.PushAsync(new Login());

            }
            else
            {
                 await App.Current.MainPage.DisplayAlert("Alerta", "Correo No Valido", "OK");
            }
        }

        void AgregarVistas()
        {


            VistaPrincipal.Children.Add(Navegacion,
                Constraint.RelativeToParent((p) => { return 0; }), //X
                Constraint.RelativeToParent((p) => { return 0; }), //Y
                Constraint.RelativeToParent((p) => { return p.Width; }), //ANCHO
                Constraint.RelativeToParent((p) => { return p.Height * 0.083; }) //ALTO
                    );
            VistaPrincipal.Children.Add(Correo,
              Constraint.RelativeToParent((p) => { return p.Width * 0.1; }),
              Constraint.RelativeToParent((p) => { return p.Height * 0.4; }),
              Constraint.RelativeToParent((p) => { return p.Width * 0.8; }), //ANCHO
              Constraint.RelativeToParent((p) => { return p.Height * 0.07; })
               );
            VistaPrincipal.Children.Add(Recuperar,
              Constraint.RelativeToParent((p) => { return p.Width * 0.1; }),
              Constraint.RelativeToParent((p) => { return p.Height * 0.5; }),
              Constraint.RelativeToParent((p) => { return p.Width * 0.8; }), //ANCHO
              Constraint.RelativeToParent((p) => { return p.Height * 0.07; })
               );
            VistaPrincipal.Children.Add(loading,
                Constraint.RelativeToParent((p) => { return 0; }), //X
                Constraint.RelativeToParent((p) => { return 0; }), //Y
                Constraint.RelativeToParent((p) => { return p.Width; }), //ANCHO
                Constraint.RelativeToParent((p) => { return p.Height; }) //ALTO
                );
            Content = VistaPrincipal;
        }
        void AgregarEventos()
        {
           
        }
    }
}