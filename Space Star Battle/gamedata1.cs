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

namespace AndroidSQL
{
    class gamedata1
    {
        [PrimaryKey , AutoIncrement]
        public int PrimaryKey { get; set; }
        public int Id { get; set; }
        public string MoneyPoint { get; set; }
        public gamedata1(int idx,string moneyl)
        {
            Id = idx;
            MoneyPoint = moneyl;
        }
        public gamedata1()
        {
           
        }
    }
}