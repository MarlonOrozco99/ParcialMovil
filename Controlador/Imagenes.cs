using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DocentesAPP
{
   public class Imagenes
    {
        public static string nombre_archivo_sesion { get; } = "Sesion_Usuario";
        public static ImageSource LogoUtap { get; } = ImageSource.FromFile("LogoUtap.png");
        public static ImageSource Plus { get; } = ImageSource.FromFile("Plus.png");
        public static ImageSource Back { get; } = ImageSource.FromFile("Back.png");


        // Logica para validar sesion

        public static int IsLoggedIn()
        {
            var session = Storage.getSesion();
            if (session == null || string.IsNullOrEmpty(session.Codigo_Estudiante))
            {
                Console.WriteLine("Not logged in");
                return -1;
            }
            return 1;
        }
    }
    }

