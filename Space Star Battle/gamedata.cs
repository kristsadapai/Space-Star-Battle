using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
namespace SQLiteDB.Resources.Model
{
    class gamedata
    {
        public string MoneyPoint { get; set; }
        public gamedata(string moneyl)
        {
            MoneyPoint = moneyl;
        }
    }
}