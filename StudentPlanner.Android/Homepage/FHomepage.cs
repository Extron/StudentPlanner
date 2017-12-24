using System;
using System.Collections.Generic;

using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

using StudentPlanner.Android.Base;
using StudentPlanner.Android.Utilities;
using StudentPlanner.DataModel;

namespace StudentPlanner.Android.Homepage
{
    [Fragment(Resource.Layout.FragmentHomepage)]
    public class FHomepage : BaseFragment
    {
        #region UI Elements

        [UIElement(Resource.Id.assignmentsRecyclerView)]
        private RecyclerView AssignmentsRecyclerView;

        #endregion




        #region Lifecycle Methods

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            var layoutManager = new LinearLayoutManager(Context);
            layoutManager.Orientation = LinearLayoutManager.Vertical;

            AssignmentsRecyclerView.SetLayoutManager(layoutManager);

            var adapter = new RecyclerViewAdapter<Assignment>();

            adapter.Items = new List<Assignment>()
            {
                new Assignment() { Name = "Test1", Description = "Test Description", DueDate = DateTime.Now },
                new Assignment() { Name = "Test2", Description = "Test Description", DueDate = DateTime.Now },
                new Assignment() { Name = "Test3", Description = "Test Description", DueDate = DateTime.Now },
                new Assignment() { Name = "Test4", Description = "Test Description", DueDate = DateTime.Now },
                new Assignment() { Name = "Test5", Description = "Test Description", DueDate = DateTime.Now },
                new Assignment() { Name = "Test6", Description = "Test Description", DueDate = DateTime.Now },
                new Assignment() { Name = "Test7", Description = "Test Description", DueDate = DateTime.Now },
            };

            adapter.ItemLayoutResource = Resource.Layout.ViewAssignment;

            adapter.AddBinding(nameof(Assignment.Name), Resource.Id.titleTextView, (string name, TextView textView) => textView.Text = name);
            adapter.AddBinding(nameof(Assignment.Description), Resource.Id.descriptionTextView, (string description, TextView textView) => textView.Text = description);
            adapter.AddBinding(nameof(Assignment.DueDate), Resource.Id.dueDateTextView, (DateTime date, TextView textView) => textView.Text = date.ToShortDateString());

            AssignmentsRecyclerView.SetAdapter(adapter);

            return view;
        }

        #endregion
    }
}