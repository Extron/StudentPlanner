using System;

namespace StudentPlanner.Android.Base
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FragmentAttribute : Attribute
    {
        /// <summary>
        /// The layout resource for the fragment.
        /// </summary>
        public int LayoutResource { get; private set; }

        public FragmentAttribute(int layoutResource)
        {
            LayoutResource = layoutResource;
        }
    }
}