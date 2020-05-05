using DocentesAPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DocenteApp
{
    public class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            Page _PaginaPrincipal = new VistaMenuMaster();
            Master = _PaginaPrincipal;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(PaginaPrincipal))) 
            {
                BarBackgroundColor = Color.FromHex("2963D4"),
                BarTextColor = Color.FromHex("FFFFFF"),
            };
        }
    }
}