using System;
using System.Collections.Generic;
using System.Text;

namespace DocentesAPP
{
    public interface IRestApi
    {
        ResponseAPI LoginApp(string Codigo, string Documento, string Contraseña);
    }
}
