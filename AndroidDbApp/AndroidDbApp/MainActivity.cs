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
            EditText noteTitle = FindViewById<EditText>(Resource.Id.tb_NoteTitle);
            EditText noteContent = FindViewById<EditText>(Resource.Id.tb_NoteContent);



            //Database and Table is created
            DbClass db = new DbClass();
            db.createDb();

            saveDataButton.Click += delegate 
            {
                if (noteTitle.Text == string.Empty && noteContent.Text == string.Empty)
                {
                    Toast.MakeText(this, "Fill both boxes to continue", ToastLength.Short).Show();
                }
                else
                {
                    db.insertNote(noteTitle.Text, noteContent.Text);
                }
            };

            activityChangeButton.Click += delegate
            {
                StartActivity(typeof(DataActivity));
            };

            getDataButton.Click += delegate 
            {
                tvText.Text += db.getData();
            };
        }

    }
}

