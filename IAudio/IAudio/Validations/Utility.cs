using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace IAudioXamarin.Validations
{
    public static class Utility
    {
        public static T GetParentControl<T>(this Element control) where T : class
        {
            // Parent is null return null
            if (control.Parent == null)
                return null;

            // Parent is desired control
            // Than return parent
            if (control.Parent is T)
                return control.Parent as T;

            // search for control
            return GetParentControl<T>(control.Parent);

        }
    }
}
