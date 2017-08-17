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
using SQLite;
using System.IO;

namespace AndroidDbApp
{
    class DbClass
    {
        //path
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "NoteDb.db3");
        public void createDb()
        {
            //connection
            var db = new SQLiteConnection(dbPath);

            //setup table
            db.CreateTable<Notes>();
        }

        public void insertNote(string noteTitle, string noteContent)
        {
            var db = new SQLiteConnection(dbPath);
            try
            {
                Notes note = new Notes(noteTitle, noteContent);

                db.Insert(note);
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }

        }

        public string getData()
        {
            var db = new SQLiteConnection(dbPath);

            //connect to table
            var table = db.Table<Notes>();

            string stringToReturn = "";

            foreach (var item in table)
            {
                Notes newNote2 = new Notes(item.Title, item.Content);

                stringToReturn += newNote2 + "\n";
            }

            return stringToReturn;
        }

        public string getDbPath()
        {
            return dbPath;
        }
    }
}