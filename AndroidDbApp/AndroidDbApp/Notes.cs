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

namespace AndroidDbApp
{
    class Notes
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Notes(string title, string content)
        {
            Title = title;
            Content = content;
        }

        public Notes()
        {

        }

        public override string ToString() => Title + " " + Content;
    }
}