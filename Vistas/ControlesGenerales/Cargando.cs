using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DocentesAPP
{
    public class Cargando : RelativeLayout
    {
        ActivityIndicator loading;
    public Cargando()
    {
            IsVisible = false;
            BackgroundColor = Color.FromHex("#2E4F8F").MultiplyAlpha(0.6);
            loading = new ActivityIndicator
            {
                Color = Color.White,
                IsRunning = true,
                IsVisible = true
            };

            Children.Add(loading,
                Constraint.RelativeToParent((p) => { return p.Width * 0.33; }), //X
                Constraint.RelativeToParent((p) => { return p.Height * 0.3; }), //Y
                Constraint.RelativeToParent((p) => { return p.Width * 0.3; }),
                Constraint.RelativeToParent((p) => { return p.Height * 0.3; }) 
                );
    }
}
}
