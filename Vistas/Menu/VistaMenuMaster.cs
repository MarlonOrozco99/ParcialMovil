using DocentesAPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DocenteApp
{
    public class VistaMenuMaster : ContentPage
    {
        StackLayout Vista;
        List<MasterMenu> Menu;
        ListView ListView;

        public VistaMenuMaster() //Constructor
        {
            Title = "Bienvenidos";
            CrearVistas();
            AgregarVistas();
            AgregarEventos();
        }
        void CrearVistas()
        {

            Vista = new StackLayout
            {
                BackgroundColor = Color.White
            };
            Menu = new List<MasterMenu>
            {
               
                new MasterMenu{Texto_Menu = "Registro Notas"},
                new MasterMenu{Texto_Menu = "Listado Estudiantes"},
                new MasterMenu{Texto_Menu = "Cerrar Sesión"}
            };
            ListView = new ListView //Instancia 
            {
                ItemsSource = Menu,
                ItemTemplate = new DataTemplate(typeof(EstiloTemplate)),
                SeparatorVisibility = SeparatorVisibility.Default,  
                RowHeight = 60//Altura de la celda
            };

            ListView.VerticalOptions = LayoutOptions.Center; 

        }
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
        void AgregarVistas()
        {

            Vista.Children.Add(ListView);
            Content = Vista;
        }
        void AgregarEventos()
        {
            ListView.ItemSelected += ListView_ItemSelected;
            ListView.ItemTapped += ListView_ItemTapped;    //cuando lo toco
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)  
        {
            //Siempre que yo le haga tap 
            //
            switch (((MasterMenu)e.Item).Texto_Menu)
            {
                case "Registro Notas":
                  
                    break;
                case "Listado estudiantes":
                    break;
                case "Cerrar Sesión":
                    await Navigation.PushAsync(new Login());
                    break;

                default:
                    break;
            }
        }
    }
}
