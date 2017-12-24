using System;

namespace StudentPlanner.Android.Base
{
    /// <summary>
    /// An attribute that can be applied to properties of classes derived from <see cref="BaseFragment"/>.  These properties will be mapped to UI elements defined in the fragment's
    /// layout file and properly assigned by <see cref="BaseFragment"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class UIElementAttribute : Attribute
    {
        /// <summary>
        /// The ID of the UI element.
        /// </summary>
        public int ElementID { get; private set; }

        public UIElementAttribute(int elementID)
        {
            ElementID = elementID;
        }
    }
}