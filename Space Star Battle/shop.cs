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
    [Activity(Label = "Shop")]
    public class shop : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.shop);
            string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbgame.db3");
            var db = new SQLiteConnection(dbpath);
            var money = FindViewById<TextView>(Resource.Id.MoneyPoint);
            var moneyx = money.ToString();
            var tablex = db.Table<gamedata1>();
            var upgrade = FindViewById<Button>(Resource.Id.button1);
            var Ship1 = FindViewById<ImageView>(Resource.Id.ShipLv1);
            var Ship2 = FindViewById<ImageView>(Resource.Id.ShipLv2);
            var Ship3 = FindViewById<ImageView>(Resource.Id.ShipLv3);
            foreach (var item in tablex) {

                gamedata1 mygame = new gamedata1(item.Id,item.MoneyPoint) ;
                money.Text += mygame.MoneyPoint;
            }
            upgrade.Click += delegate
            {
                
                
                Ship1.Visibility = Android.Views.ViewStates.Invisible;
                Ship2.Visibility = Android.Views.ViewStates.Visible;
                money.Text = "1000";

            };
            // Create your application here
        }
    }
}