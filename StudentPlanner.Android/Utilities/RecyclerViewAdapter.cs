using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Android.Support.V7.Widget;
using Android.Views;

using StudentPlanner.Android.Base;

namespace StudentPlanner.Android.Utilities
{
    public class RecyclerViewAdapter<T> : RecyclerView.Adapter
    {
        #region Nested Classes

        /// <summary>
        /// The view holder for an item in the adapter.  Handles binding the item data to the view.
        /// </summary>
        class ViewHolder : RecyclerView.ViewHolder
        {
            /// <summary>
            /// The item this view holder is bound to.
            /// </summary>
            public T Item { get; private set; }

            /// <summary>
            /// A dictionary of views that the view holder binds data to.
            /// </summary>
            Dictionary<int, View> views = new Dictionary<int, View>();


            public ViewHolder(View view, List<ViewBinding> bindings) : base(view)
            {
                foreach (var binding in bindings)
                    views.Add(binding.ViewID, view.FindViewById(binding.ViewID));
            }

            /// <summary>
            /// Binds the specified item to the view holder.
            /// </summary>
            /// <param name="item">The item to bind to.</param>
            /// <param name="bindings">A list of bindings used to extract data from <paramref name="item"/> and apply it to views managed by this view holder.</param>
            public void BindItem(T item, List<ViewBinding> bindings)
            {
                Item = item;

                foreach (var binding in bindings)
                    binding.Bind(Item, views[binding.ViewID]);
            }
        }

        /// <summary>
        /// Stores a view binding, which binds a property on an item to a view managed by a view holder.
        /// </summary>
        class ViewBinding
        {
            /// <summary>
            /// The name of the property within the item to bind.
            /// </summary>
            public string PropertyName { get; set; }

            /// <summary>
            /// An action that dictates how the the binding occurs.  The action should take in as parameters a value from <see cref="PropertyName"/> and a view to bind to.
            /// </summary>
            public Delegate BindAction { get; set; }

            /// <summary>
            /// The resource ID of the view to bind to within the view holder.
            /// </summary>
            public int ViewID { get; set; }


            /// <summary>
            /// Binds the value of the property with name <see cref="PropertyName"/> from the specified item to the specified view with ID <see cref="ViewID"/>.
            /// </summary>
            /// <param name="item">The item to bind.</param>
            /// <param name="view">The view to bind to.</param>
            public void Bind(T item, View view)
            {
                var pInfo = typeof(T).GetProperty(PropertyName);

                if (pInfo == null)
                    throw new ArgumentException($"Type {typeof(T)} does not contain a property named {PropertyName}");

                var pValue = pInfo.GetValue(item);

                BindAction.DynamicInvoke(pValue, view);
            }
        }

        #endregion


        #region Fields

        /// <summary>
        /// A list of bindings to map properties of items of type <see cref="T"/> to UI elements within each <see cref="ViewHolder"/>.
        /// </summary>
        List<ViewBinding> bindings = new List<ViewBinding>();

        #endregion
        

        #region Properties

        /// <summary>
        /// A list of items of type <see cref="T"/> within the adapter.
        /// </summary>
        public List<T> Items { get; set; } = new List<T>();

        /// <summary>
        /// The layout resource to use for each item.
        /// </summary>
        public int ItemLayoutResource { get; set; }

        #endregion


        #region RecyclerView.Adapter Methods

        /// <summary>
        /// The number of items in the adapter.
        /// </summary>
        public override int ItemCount => Items.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as ViewHolder;

            viewHolder.BindItem(Items[position], bindings);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(ItemLayoutResource, parent, false);

            return new ViewHolder(itemView, bindings);
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Adds a new binding to the adapter, mapping a property within <see cref="T"/> to a UI element in each item's view holder.
        /// </summary>
        /// <typeparam name="TValue">The type of the property in <see cref="T"/> to bind.</typeparam>
        /// <typeparam name="TView">The type of the view in the view holder to bind to.</typeparam>
        /// <param name="propertyName">The name of the property in <see cref="T"/> to bind.</param>
        /// <param name="viewID">The resource ID of the view in the view holder to bind to.</param>
        /// <param name="binding">An action that applies the value, taken from <paramref name="propertyName"/> in <see cref="T"/>, to the view with ID <paramref name="viewID"/>.</param>
        public void AddBinding<TValue, TView>(string propertyName, int viewID, Action<TValue, TView> binding) where TView : View
        {
            bindings.Add(new ViewBinding()
            {
                PropertyName = propertyName,
                ViewID = viewID,
                BindAction = binding
            });
        }

        #endregion
    }
}