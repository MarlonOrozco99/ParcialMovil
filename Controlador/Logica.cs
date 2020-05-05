using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DocentesAPP
{
    public class Logica
    {
        public bool ValidarPassword(Entry password, Entry Documento, Entry Codigo)
        {
            if (string.IsNullOrEmpty(password.Text) && string.IsNullOrEmpty(Documento.Text) && string.IsNullOrEmpty(Codigo.Text))
            {
                return false;
            }
            if (String.IsNullOrEmpty(password.Text))
            {
                return false;
            }
            if (password.Text.Length < 8)
                return false;
            else
                return true;
        }
        public bool ValidarCorreo(Entry Correo)
        {

            if (string.IsNullOrEmpty(Correo.Text))
            {
                return true;
            }
            if (!Correo.Text.Contains("."))
            {
                return true;
            }

            if (!Correo.Text.Contains("@"))
            {
                return true;
            }
            //FIN

            else
                return false;
        }

    }

}
