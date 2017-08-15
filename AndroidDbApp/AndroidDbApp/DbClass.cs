using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using SQLitePCL;

namespace AndroidDbApp
{
    class DbClass
    {
        string dbCon = "";

        private void DbCreate()
        {
            //TODO: Create DB
        }

        private void DbCon()
        {

        }

        public bool DBExists()
        {
            //TODO: Check if db exists

            return true;
        }
    }
}