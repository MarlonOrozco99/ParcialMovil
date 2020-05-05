using System;
using System.Collections.Generic;
using System.Text;

namespace DocentesAPP
{
    public interface IRestApiOlvidar
    {
        ResponseAPI LoginApp(string OlvidoContraseña);
    }
}
