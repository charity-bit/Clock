using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace Clock.models
{
   public class TimerItem
    {  [PrimaryKey,AutoIncrement]
         public int ID { get; set; }
         public string Title { get; set; }
        public TimeSpan TimeSpan { get; set; }

    }
}
