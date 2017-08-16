using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using SQLitePCL;
using SQLite;
using System.IO;

namespace AndroidDbApp
{
    [Activity(Theme = "@android:style/Theme.Material.Light", Label = "Note App", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;



        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button saveDataButton = FindViewById<Button>(Resource.Id.btn_SaveData);
            Button getDataButton = FindViewById<Button>(Resource.Id.btn_GetData);
            Button activityChangeButton = FindViewById<Button>(Resource.Id.btn_ChangeActivity);
            TextView tvText = FindViewById<TextView>(Resource.Id.tv_Test1);



            //Database and Table is created
            DbClass db = new DbClass();
            db.createDb();

            saveDataButton.Click += delegate 
            {

            };

            activityChangeButton.Click += delegate
            {
                StartActivity(typeof(DataActivity));
            };

            getDataButton.Click += delegate 
            {
                //var db = new SQLiteConnection(dbPath);

                ////connect to table
                //var table = db.Table<Notes>();

                //foreach (var item in table)
                //{
                //    Notes newNote2 = new Notes(item.Title, item.Content);

                //    tvText.Text += newNote2 + "\n";
                //}
            };
        }

    }
}

