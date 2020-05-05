using DocentesApp.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace DocentesAPP
{
   public static class Storage
    {
        public static Estudiantes getSesion()
        {
            bool exist = DependencyService.Get<IFileManager>().exist(Imagenes.nombre_archivo_sesion);
            if (exist)
            {
                var sessionJson = DependencyService.Get<IFileManager>().LoadText(Imagenes.nombre_archivo_sesion);
                try
                {
                    return JsonConvert.DeserializeObject<Estudiantes>(sessionJson);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error parsing Session from disk: " + e.Message);
                    deleteSession();
                    return null;
                };
            }
            else
            {
                Console.WriteLine("No Sesion Stored");
                return null;
            }
        }

        private static void deleteSession()
        {
            throw new NotImplementedException();
        }
    }
}
