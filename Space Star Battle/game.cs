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
    [Activity(Label = "game")]
    public class game : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.gameplay);
            var Hp = FindViewById<TextView>(Resource.Id.Hp);
            var HpPoint = FindViewById<TextView>(Resource.Id.HPoint);
            var Money = FindViewById<TextView>(Resource.Id.Money);
            var MoneyPoint = FindViewById<TextView>(Resource.Id.MoneyPoint);
            var LeftBtn = FindViewById<ImageButton>(Resource.Id.Left);
            var RightBtn = FindViewById<ImageButton>(Resource.Id.Right);
            var Ship1 = FindViewById<ImageView>(Resource.Id.ShipLv1);
            var Enyme1 = FindViewById<ImageView>(Resource.Id.Enyme1);
            var Enyme2 = FindViewById<ImageView>(Resource.Id.Enyme2);
            var Enyme3 = FindViewById<ImageView>(Resource.Id.Enyme3);
            var midbull = FindViewById<ImageView>(Resource.Id.midbull);
            var Count = 400;
            var MoneyThis = 0;
            Random rnd = new Random();
            int spawnx1 = rnd.Next(0, 2);
            int spawnx2 = rnd.Next(2, 4);
            int spawnx3 = rnd.Next(4, 5);
            int[] PositonX = new int[] { 0, 200, 400, 600, 800 };
            int[] PositonY = new int[] { 0, 200, 400, 600 };
            int spawnx11 = PositonX[spawnx1];
            int spawnx21 = PositonX[spawnx2];
            int spawnx31 = PositonX[spawnx3];
            int spawnx111 = spawnx11;
            int spawnx211 = spawnx21;
            int spawnx311 = spawnx31;
            Hp.Visibility = Android.Views.ViewStates.Visible;
            HpPoint.Visibility = Android.Views.ViewStates.Visible;
            Money.Visibility = Android.Views.ViewStates.Visible;
            MoneyPoint.Visibility = Android.Views.ViewStates.Visible;
            LeftBtn.Visibility = Android.Views.ViewStates.Visible;
            RightBtn.Visibility = Android.Views.ViewStates.Visible;
            Ship1.Visibility = Android.Views.ViewStates.Visible;
            Enyme1.Visibility = Android.Views.ViewStates.Visible;
            Enyme2.Visibility = Android.Views.ViewStates.Visible;
            Enyme3.Visibility = Android.Views.ViewStates.Visible;
            Enyme1.SetX(spawnx11);
            Enyme2.SetX(spawnx21);
            Enyme3.SetX(spawnx31);
            string dbpath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbgame.db3");
            var db = new SQLiteConnection(dbpath);
            LeftBtn.Click += (e, o) =>
            {
                Count -= 200;
                Ship1.SetX(Count);
                midbull.SetX(Count - 50);
                midbull.Visibility = Android.Views.ViewStates.Visible;
                SpringAnimation midbullx = new SpringAnimation(midbull, DynamicAnimation.TranslationY, -200);
                midbullx.Spring.SetStiffness(SpringForce.StiffnessLow);
                midbullx.Spring.SetDampingRatio(SpringForce.DampingRatioHighBouncy);
                midbullx.SetStartVelocity(DpToPx(-4000));
                midbullx.Start();

                if (Count == spawnx111)
                {
                    MoneyThis += 100;
                    int MoneyPoints = MoneyThis;
                    MoneyPoint.Text = MoneyPoints.ToString();
                    Enyme1.Visibility = Android.Views.ViewStates.Invisible;
                    spawnx111 = -1000;


                }
                else if (Count == spawnx211)
                {
                    MoneyThis += 100;
                    int MoneyPoints = MoneyThis;
                    MoneyPoint.Text = MoneyPoints.ToString();
                    Enyme2.Visibility = Android.Views.ViewStates.Invisible;
                    spawnx211 = -1000;


                }
                else if (Count == spawnx311)
                {
                    MoneyThis += 100;
                    int MoneyPoints = MoneyThis;
                    MoneyPoint.Text = MoneyPoints.ToString();
                    Enyme3.Visibility = Android.Views.ViewStates.Invisible;
                    spawnx311 = -1000;



                }
                else if (Count != spawnx111 && Count != spawnx211 && Count != spawnx311 && MoneyThis >= 300)
                {
                    Android.App.AlertDialog.Builder alertDilog = new Android.App.AlertDialog.Builder(this);

                    alertDilog.SetTitle("Game End");
                    alertDilog.SetMessage("Do you want To Exit");
                    alertDilog.SetNeutralButton("Yes", delegate
                    {
                        FinishAffinity();
                    });
                    alertDilog.SetPositiveButton("No", delegate
                    {
                        var gameend = new Intent(this, typeof(MainActivity));
                        StartActivity(gameend);
                    });
                    alertDilog.Show();
                    gamedata1 data = new gamedata1(1, "300");
                    db.Update(data);
                }
            };
            RightBtn.Click += (e, o) =>
            {
                Count += 200;
                Ship1.SetX(Count);
                midbull.SetX(Count - 50);
                midbull.Visibility = Android.Views.ViewStates.Visible;
                SpringAnimation midbullx = new SpringAnimation(midbull, DynamicAnimation.TranslationY, -200);
                midbullx.Spring.SetStiffness(SpringForce.StiffnessLow);
                midbullx.Spring.SetDampingRatio(SpringForce.DampingRatioHighBouncy);
                midbullx.SetStartVelocity(DpToPx(-4000));
                midbullx.Start();
                if (Count == spawnx111)
                {
                    MoneyThis += 100;
                    int MoneyPoints = MoneyThis;
                    MoneyPoint.Text = MoneyPoints.ToString();
                    Enyme1.Visibility = Android.Views.ViewStates.Invisible;
                    spawnx111 = -1000;

                }
                else if (Count == spawnx211)
                {
                    MoneyThis += 100;
                    int MoneyPoints = MoneyThis;
                    MoneyPoint.Text = MoneyPoints.ToString();
                    Enyme2.Visibility = Android.Views.ViewStates.Invisible;
                    spawnx211 = -1000;


                }
                else if (Count == spawnx311)
                {
                    MoneyThis += 100;
                    int MoneyPoints = MoneyThis;
                    MoneyPoint.Text = MoneyPoints.ToString();
                    Enyme3.Visibility = Android.Views.ViewStates.Invisible;
                    spawnx311 = -1000;

                }
                else if (Count != spawnx111 && Count != spawnx211 && Count != spawnx311 && MoneyThis >= 300)
                {
                    Android.App.AlertDialog.Builder alertDilog = new Android.App.AlertDialog.Builder(this);

                    alertDilog.SetTitle("Game End");
                    alertDilog.SetMessage("Do you want To Exit");
                    alertDilog.SetNeutralButton("Yes", delegate
                    {
                        FinishAffinity();
                    });
                    alertDilog.SetPositiveButton("No", delegate
                    {
                        var gameend = new Intent(this, typeof(MainActivity));
                        StartActivity(gameend);
                    });
                    alertDilog.Show();
                    gamedata1 data = new gamedata1(1,"300");
                    db.Update(data);
                }
            };

            // Create your application here
            
        }



        private float DpToPx(float dp)
        {
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, dp, Resources.DisplayMetrics);
        }
    }
}