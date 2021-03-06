﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.IO;
using SQLite;
namespace AndroidDbApp
{
    [Activity(Label = "DataActivity")]
    public class DataActivity : Activity
    {
        private readonly string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "NoteDb.db3");

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.DataActivityLayout);
            TextView tv1 = FindViewById<TextView>(Resource.Id.debugtext);
            try
            {
                //views
                var db = new SQLiteConnection(_dbPath);

                Notes myNotes = new Notes();

                var table = db.Table<Notes>();
                var data = new List<string>();

                //int count = 0;

                foreach (var item in table)
                {
                    //myNotes[count] = item;
                    //count++;
                    data.Add("Title: " + item.Title + "   -   " + "Content: " + item.Content);
                }
                var lv = FindViewById<ListView>(Resource.Id.lv_DatabaseView);
                lv.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSelectableListItem, data.ToArray());
            }
            catch (Exception ex)
            {
                tv1.Text = ex.ToString();
            }





        }
    }
}