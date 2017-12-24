using System;
using System.Linq;
using System.Reflection;

using Android.App;
using Android.OS;
using Android.Views;

namespace StudentPlanner.Android.Base
{
    /// <summary>
    /// An abstract class that derives from and enhances <see cref="Fragment"/>.
    /// </summary>
    public abstract class BaseFragment : Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Inflate the layout that the derived class points to through its Fragment attribute
            var view = inflater.Inflate(GetLayoutResource(), container, false);

            // Iterate over all private fields and find any that have the UIElement attribute. This attribute indicates that the class would like
            // an element extracted from the fragment's view and stored in the field.  The attribute contains the ID of the element to retrieve.
            var fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                var uiElementAttribute = field.GetCustomAttributes(typeof(UIElementAttribute), true).FirstOrDefault() as UIElementAttribute;

                if (uiElementAttribute != null)
                {
                    var element = view.FindViewById(uiElementAttribute.ElementID);
                    field.SetValue(this, element);
                }
            }

            return view;
        }

        private int GetLayoutResource()
        {
            var fragAttribute = (FragmentAttribute)Attribute.GetCustomAttribute(GetType(), typeof(FragmentAttribute));

            if (fragAttribute == null)
                throw new ArgumentException($"{GetType()} does not have {nameof(FragmentAttribute)} applied to it.");

            return fragAttribute.LayoutResource;
        }
    }
}