using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DocentesAPP
{
    public class App : Application
    {
        public static Estudiantes usuario;
        public App()
        {
            if (Imagenes.IsLoggedIn() == 1)
            {
                usuario = Storage.getSesion();
                MainPage = new NavigationPage(new PaginaPrincipal());  
            }
            else
            {
                MainPage = new NavigationPage(new Login());
            }
        }
    }
}