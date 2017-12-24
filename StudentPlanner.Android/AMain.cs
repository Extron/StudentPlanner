using Android.App;
using Android.Widget;
using Android.OS;

namespace StudentPlanner.Android
{
    [Activity(Label = "@string/app_name", MainLauncher = true)]
    public class AMain : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ActivityMain);

            var transaction = FragmentManager.BeginTransaction();

            var homepageFrag = new Homepage.FHomepage();
            transaction.Add(Resource.Id.rootFrameLayout, homepageFrag);
            transaction.Commit();
        }
    }
}

