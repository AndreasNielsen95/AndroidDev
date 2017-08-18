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

namespace AndroidDbApp
{
    class AdapterClass : BaseAdapter<Notes>
    {
        Notes[] myNotes;
        Activity context;

        public AdapterClass(Activity context, Notes[] notes) : base()
        {
            this.myNotes = notes;
            this.context = context;
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override Notes this[int position]
        {
            get
            {
                return myNotes[position]; //returns position of item in array
            }
        }
        public override int Count
        {
            get
            {
                return myNotes.Length;
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            //this sets up to reuse exisiting row if one is available
            View view = convertView;


            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleExpandableListItem1, null);
            }
            try
            {
                view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = myNotes[position].ToString();
            }
            catch (Exception ex)
            {
                
                Toast.MakeText(context, ex.ToString(), ToastLength.Long).Show() ;
            }

            return view;
        }
    }
}