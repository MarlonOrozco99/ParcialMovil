using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DocentesAPP
{
    public class PaginaPrincipal : ContentPage
    {
        StackLayout VistaListas;
        RelativeLayout VistaPrincipal;
        SearchBar miControlDeBusqueda;
        List<string> MiListaEstudiantil;
        ObservableCollection<string> MiListaEstudiantilDos;
        ListView ListaEstudiantes;
        Image Plus;
        TapGestureRecognizer TapImage;
                          
       
        Cargando loading;

        public PaginaPrincipal()
        {
            //NavigationPage.SetHasNavigationBar(this, false);
            BackgroundColor = Color.White;
            CrearVistas();
            AgregarVistas();
            AgregarEventos();
            Title = "Pagina Principal";
        }

        void CrearVistas()
        {

            VistaListas = new StackLayout();
            VistaPrincipal = new RelativeLayout();

            MiListaEstudiantil = new List<string>();
            MiListaEstudiantilDos = new ObservableCollection<string>();

            MiListaEstudiantilDos.Add("Sebitas");
            MiListaEstudiantilDos.Add("Marlon");
            MiListaEstudiantilDos.Add("Juancho");

            loading = new Cargando();

            Plus = new Image
            {
                Source = Imagenes.Plus
            };


            ListaEstudiantes = new ListView()
            {
                ItemsSource = MiListaEstudiantilDos,
                BackgroundColor = Color.White
               
            };

            miControlDeBusqueda = new SearchBar
            {
                Placeholder = "Agrega tu nombre",
                BackgroundColor = Color.White
            };
 


            TapImage = new TapGestureRecognizer();

            Plus.GestureRecognizers.Add(TapImage);
           

            VistaListas.HorizontalOptions = LayoutOptions.Center;
            VistaListas.VerticalOptions = LayoutOptions.CenterAndExpand;
            

        }
        void AgregarVistas()
        {

         

            VistaPrincipal.Children.Add(ListaEstudiantes,
                 Constraint.RelativeToParent((p) => { return p.Width * 0.095; }), //X
                 Constraint.RelativeToParent((p) => { return p.Height * 0.08; }), //Y
                 Constraint.RelativeToParent((p) => { return p.Width * 0.9; }), //ANCHO
                 Constraint.RelativeToParent((p) => { return p.Height * 0.88; }) //ALTO
                );

            VistaPrincipal.Children.Add(miControlDeBusqueda,
                Constraint.RelativeToParent((p) => { return p.Width * 0.095; }),
                Constraint.RelativeToParent((p) => { return p.Height * 0.01; }),
                Constraint.RelativeToParent((p) => { return p.Width * 0.66; })

               );

            VistaPrincipal.Children.Add(Plus,
                Constraint.RelativeToParent((p) => { return p.Width * 0.83; }), //X
                Constraint.RelativeToParent((p) => { return p.Height * 0.87; }), //Y
                Constraint.RelativeToParent((p) => { return p.Width * 0.15; }), //ANCHO
                Constraint.RelativeToParent((p) => { return p.Height * 0.15; }) //ALTO
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
            Plus.GestureRecognizers.Add(TapImage);
            TapImage.Tapped += TapImage_Tapped;
            
            //TapBack.Tapped += TapBack_Tapped;
            miControlDeBusqueda.TextChanged += MiControlDeBusqueda_TextChanged;
            ListaEstudiantes.ItemSelected += ListaEstudiantes_ItemSelected;
        }

        private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            
        }

        private async void TapImage_Tapped(object sender, EventArgs e)
        {
            AnimacionBack((View)sender);
        }

        private void MiControlDeBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == null) return;
            string nuevovalor = miControlDeBusqueda.Text;
            if (nuevovalor.Length >= 11)
                miControlDeBusqueda.Text = nuevovalor.Remove(nuevovalor.Length - 1);
        } 

        async void AnimacionBack (View control)
        {
            uint tiempo3 = 200;
            await control.ScaleTo(0.85, tiempo3);
            await Plus.ScaleTo(1, tiempo3);
            if (string.IsNullOrEmpty(miControlDeBusqueda.Text))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "No Puede Agregar Vacios", "OK");
                return;
            }
            loading.IsVisible = true;
            await Task.Delay(1000);
            loading.IsVisible = false;
            MiListaEstudiantilDos.Add(miControlDeBusqueda.Text);
            miControlDeBusqueda.Text = string.Empty;

        }
    }
}