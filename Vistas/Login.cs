using DocenteApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DocentesAPP
{
    public class Login : ContentPage
    {
        RelativeLayout VistaPrincipal;
        StackLayout VistaCirculo;
        StackLayout VistaGeneral;
        Entry entryDocumento, entryCodigo, entryPassword;
        Label Bienvenidos;
        Button buttonAcceder;
        Image Logo;
        Label OlvidarPassword;
        //BoxView Circulo;
        //BoxView Circulo2;
        uint Tiempo = 200;
        PaginaPrincipal paginaprincipal;
        Image Back;
        TapGestureRecognizer TapBack;
        OlvidoPassword olvidopassword;
        TapGestureRecognizer TapOlvidoContraseña;
        Cargando loading;


        public Login()
        {
            BackgroundColor = Color.FromHex("2E4F8F");
            NavigationPage.SetHasNavigationBar(this, false);
            //paginaprincipal = new PaginaPrincipal
            //{
            //    TranslationX = 420,
            //    BackgroundColor = Color.White

            //};
            olvidopassword = new OlvidoPassword
            {
                TranslationX = 420,
                BackgroundColor = Color.White,

            };
            CrearVistas();
            AgregarVistas();
            AgregarEventos();
        }

        void CrearVistas()
        {
            VistaPrincipal = new RelativeLayout();
            entryCodigo = new Entry
            {
                PlaceholderColor = Color.White,
                Placeholder = "Codigo",
                TextColor = Color.White,
                Keyboard = Keyboard.Numeric
            };
            entryDocumento = new Entry
            {
                PlaceholderColor = Color.White,
                Placeholder = "Documento",
                TextColor = Color.White,
                MaxLength = 10
            };
            entryPassword = new Entry
            {
                PlaceholderColor = Color.White,
                Placeholder = "Contraseña",
                TextColor = Color.White,
                IsPassword = true,

            };
            buttonAcceder = new Button
            {
                Text = "Acceder A la App",
                //Scale = 0 //tamaño al que inicia el boton

            };
            Bienvenidos = new Label
            {
                Text = "Bienvenidos",
                FontSize = 40,
                TextColor = Color.White
            };
            OlvidarPassword = new Label
            {
                Text = "¿Olvidaste tu contraseña?",
                TextColor = Color.White

            };
            loading = new Cargando();
            //Circulo = new BoxView
            //{
            //    BackgroundColor = Color.Black,
            //    CornerRadius = 40,
            //    Scale = 20
            //};
            Back = new Image
            {
                Source = Imagenes.Back,
                IsVisible = false

            };
            Logo = new Image
            {
                Source = Imagenes.LogoUtap
            };
            //Circulo2 = new BoxView
            //{
            //    Scale = 20,
            //    BackgroundColor = Color.Red,
            //    CornerRadius = 40
            //};
            VistaGeneral = new StackLayout();
            VistaCirculo = new StackLayout();

            buttonAcceder.Clicked += ButtonAcceder_Clicked;

            TapBack = new TapGestureRecognizer();
            TapOlvidoContraseña = new TapGestureRecognizer();

            OlvidarPassword.GestureRecognizers.Add(TapOlvidoContraseña);
            Back.GestureRecognizers.Add(TapBack);

            VistaGeneral.HorizontalOptions = LayoutOptions.Center;
            VistaGeneral.VerticalOptions = LayoutOptions.CenterAndExpand;

        }

        private async void ButtonAcceder_Clicked(object sender, EventArgs e)
        {


            Logica log = new Logica();

            bool ValidarPassword = log.ValidarPassword(entryPassword, entryDocumento, entryCodigo);
            if (!ValidarPassword)
            {
                await DisplayAlert("Advertencia", "No cumple con los requisitos", "Aceptar");
                return;
            }

            ////Rectangle dimensiones = paginaprincipal.Bounds;
            var respuesta = DependencyService.Get<IRestApi>().LoginApp(entryPassword.Text, entryDocumento.Text, entryCodigo.Text);
            if (respuesta.Ok == 1)
            {
                loading.IsVisible = true;
                await Task.Delay(500);
                loading.IsVisible = false;
                await Navigation.PushAsync(new MasterPage());
               
            }
            else
                await DisplayAlert("Notificacion", "Usuario Incorrecto", "Ok");

        }

        async Task AnimacionInicial()
        {

            await buttonAcceder.ScaleTo(0.80, Tiempo);
            await buttonAcceder.ScaleTo(1, Tiempo);
        }
        //async Task AnimacionCirculo()
        //{
        //    uint Tiempo1 = 800;
        //    //await Circulo2.ScaleTo(0, Tiempo1);
        //    await Circulo.ScaleTo(0, Tiempo1);
        //    Circulo.BackgroundColor = Color.Blue;
        //    await Circulo.ScaleTo(40, Tiempo1);

        //    await Circulo.FadeTo(0, Tiempo1);


        ////}


        protected override async void OnAppearing()
        {
            base.OnAppearing(); //Se activa a lo que ingrese a la pagina
                                //await Task.Delay(800);


            // await AnimacionCirculo2();


            //await AnimacionCirculo();

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing(); //antes de ir de la pagina se ejecuta
        }
        void AgregarVistas()
        {
            VistaGeneral.Children.Add(Bienvenidos);
            VistaGeneral.Children.Add(entryCodigo);
            VistaGeneral.Children.Add(entryDocumento);
            VistaGeneral.Children.Add(entryPassword);

            //            VistaGeneral.Children.Add(VistaPrincipal);

            VistaPrincipal.Children.Add(Logo,
               Constraint.RelativeToParent((p) => { return p.Width * 0.1; }),
               Constraint.RelativeToParent((p) => { return p.Height * 0.1; })
               );
            // VistaPrincipal.Children.Add(Circulo,
            //Constraint.RelativeToParent((p) => { return p.Width * 0; }), // X Posicion
            //Constraint.RelativeToParent((p) => { return p.Height * 0; }),// Y Posicion
            //Constraint.RelativeToParent((p) => { return p.Width * 0.45; }),
            //Constraint.RelativeToParent((p) => { return p.Height * 0.4; }));


            VistaPrincipal.Children.Add(VistaGeneral,
                Constraint.RelativeToParent((p) => { return p.Width * 0.2; }),
                Constraint.RelativeToParent((p) => { return p.Height * 0.3; })
                );
            //VistaPrincipal.Children.Add(Circulo2,
            //    Constraint.RelativeToParent((p) => { return p.Width * 0.45; }),
            //    Constraint.RelativeToParent((p => { return p.Height * 0.4; })));

           //VistaPrincipal.Children.Add(paginaprincipal,
           // Constraint.RelativeToParent((p) => { return p.Width * 0; }), // X Posicion
           // Constraint.RelativeToParent((p) => { return p.Height * 0; }),// Y Posicion
           // Constraint.RelativeToParent((p) => { return p.Width; }),
           // Constraint.RelativeToParent((p) => { return p.Height; }));
            VistaPrincipal.Children.Add(olvidopassword,
                Constraint.RelativeToParent((p) => { return p.Width * 0; }), // X Posicion
                Constraint.RelativeToParent((p) => { return p.Height * 0; }),// Y Posicion
                Constraint.RelativeToParent((p) => { return p.Width; }),
                Constraint.RelativeToParent((p) => { return p.Height; }));
            VistaPrincipal.Children.Add(Back,
               Constraint.RelativeToParent((p) => { return p.Width * 0; }),
               Constraint.RelativeToParent((p) => { return p.Width * 0; })
               );
           VistaPrincipal.Children.Add(buttonAcceder,
                Constraint.RelativeToParent((p) => { return p.Width * 0.3; }),
                Constraint.RelativeToParent((p) => { return p.Height * 0.7; })
                //Constraint.RelativeToParent((p) => { return p.Width * 0.50; }), //Ancho
                //Constraint.RelativeToParent((p) => { return p.Height * 0.10; })
           );
           VistaPrincipal.Children.Add(OlvidarPassword,
              Constraint.RelativeToParent((p) => { return p.Width * 0.3; }),
              Constraint.RelativeToParent((p) => { return p.Height * 0.8; })
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
            Back.GestureRecognizers.Add(TapBack);
            TapBack.Tapped += TapBack_Tapped;

            TapOlvidoContraseña.Tapped += TapOlvidoContraseña_Tapped;
        }

        private async void TapOlvidoContraseña_Tapped(object sender, EventArgs e)
        {
            Rectangle dimensiones = olvidopassword.Bounds;
            await olvidopassword.TranslateTo(0, 0, 200);
            Back.IsVisible = true;
            buttonAcceder.IsVisible = false;
            OlvidarPassword.IsVisible = false;
            loading.IsVisible = true;
            await Task.Delay(1000);
            loading.IsVisible = false;
        }

        private async void TapBack_Tapped(object sender, EventArgs e)
        {
            //await paginaprincipal.TranslateTo(450, 0, 200);
            await olvidopassword.TranslateTo(450, 0, 200);
            Back.IsVisible = false;
            buttonAcceder.IsVisible = true;
            OlvidarPassword.IsVisible = true;

        }
    }
}