using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Threading;
using System.Threading.Tasks;
using Android.Support.Animation;
using Android.Views;
using Android.Util;
using Android.Support.Design.Widget;
using static Android.Views.View;
using NuGet.Protocol.Plugins;
using Android.Content;
using SQLite;
using SQLiteDB.Resources.Helper;
using SQLiteDB.Resources.Model;
using System.Collections.Generic;
using System.IO;
using AndroidSQL;

namespace Space_Star_Battle
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppFullScreenTheme", MainLauncher = true, Icon = "@drawable/lv1")]
    public class MainActivity : AppCompatActivity
    {


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
           
            var PlayButton = FindViewById<ImageButton>(Resource.Id.PlayButton);
            var ShopButton = FindViewById<ImageButton>(Resource.Id.ShopButton);
            var Icon = FindViewById<ImageView>(Resource.Id.Icon);
            var Money = FindViewById<TextView>(Resource.Id.Money);
            var MoneyPoint = FindViewById<TextView>(Resource.Id.MoneyPoint);
            PlayButton.Click += delegate
            {
                var gamestart = new Intent(this, typeof(game));
                StartActivity(gamestart);
            };
            ShopButton.Click += delegate
            {
                var shopping = new Intent(this, typeof(shop));
                StartActivity(shopping);
            };

            string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbgame.db3");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<gamedata1>();
            gamedata1 data = new gamedata1(1,"0");
            db.Insert(data);
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}