using System;
using System.Collections;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace CustomRally
{

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainMenu : AppCompatActivity
    {
        private Button selectRouteButton;
        private Button createRouteButton;
        private Button leaderBoardButton;
        private Button optionButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                Xamarin.Essentials.Platform.Init(this, savedInstanceState);
                SetContentView(Resource.Layout.MainMenu);
                selectRouteButton = FindViewById<Button>(Resource.Id.SelectRoute);
                createRouteButton = FindViewById<Button>(Resource.Id.CreateRoutes);
                leaderBoardButton = FindViewById<Button>(Resource.Id.LeaderBoard);
                optionButton = FindViewById<Button>(Resource.Id.Options);

                selectRouteButton.Click += (sender, e) =>
                {
                    var intent = new Intent(this, typeof(SelectRouteActivity));
                    StartActivity(intent);
                };

                createRouteButton.Click += (sender, e) =>
                {
                    var intent = new Intent(this, typeof(CreateRouteActivity));
                    StartActivity(intent);
                };

                leaderBoardButton.Click += (sender, e) =>
                {
                    var intent = new Intent(this, typeof(LeaderBoardActivity));
                    StartActivity(intent);
                };

                optionButton.Click += (sender, e) =>
                {
                    var intent = new Intent(this, typeof(OptionsActivity));
                    StartActivity(intent);
                };
            }
            catch (Exception e)
            {
                Toast.MakeText(this, e.Message, ToastLength.Long).Show();
            }
           
        }
	}
}

