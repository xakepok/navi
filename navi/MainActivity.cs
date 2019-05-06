using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Webkit;
using Android.Views.InputMethods;
using Android.Content;

namespace navi
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            Button start = FindViewById<Button>(Resource.Id.button1);
            start.Click += test;
        }

        private void test(object sender, EventArgs eventArgs)
        {
            string tv_park = FindViewById<TextView>(Resource.Id.editText1).Text;
            string tv_bort = FindViewById<TextView>(Resource.Id.editText3).Text;
            string tip = "0";
            if (FindViewById<RadioButton>(Resource.Id.radioButton1).Checked) tip = "0";
            if (FindViewById<RadioButton>(Resource.Id.radioButton2).Checked) tip = "1";
            if (FindViewById<RadioButton>(Resource.Id.radioButton3).Checked) tip = "2";
            string dat = FindViewById<TextView>(Resource.Id.editText2).Text;
            string url = "https://mgt.xakepok.com/search.html?format=raw";
            url += "&filter_search=" + tv_park;
            url += "&filter_route=" + tv_bort;
            url += "&filter_type=" + tip;
            url += "&filter_dat=" + dat;
            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(FindViewById<TextView>(Resource.Id.editText1).WindowToken, 0);
            imm.HideSoftInputFromWindow(FindViewById<TextView>(Resource.Id.editText3).WindowToken, 0);
            WebView webView = FindViewById<WebView>(Resource.Id.webView1);
            webView.Visibility = ViewStates.Invisible;
            webView.LoadUrl(url);
            webView.Visibility = ViewStates.Visible;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        protected override void OnResume()
        {
            base.OnResume();
            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(FindViewById<TextView>(Resource.Id.editText1).WindowToken, 0);
            imm.HideSoftInputFromWindow(FindViewById<TextView>(Resource.Id.editText3).WindowToken, 0);
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(FindViewById<TextView>(Resource.Id.editText1).WindowToken, 0);
            imm.HideSoftInputFromWindow(FindViewById<TextView>(Resource.Id.editText3).WindowToken, 0);
        }

    }
}

