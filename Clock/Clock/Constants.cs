using SQLite;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Clock
{
   public class Constants
    {

        public const string DatabaseFileName = "MyTimerDB.db3";

        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache | SQLiteOpenFlags.ReadWrite;
        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return Path.Combine(basePath, DatabaseFileName);
            }
        }

    }
}
