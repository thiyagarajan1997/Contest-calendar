using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contest_calendar
{
    class eventtable
    {
        [SQLite.AutoIncrement, SQLite.PrimaryKey]
        public int slno { get; set;}

        public string eventname { get; set; }

        public string dates { get; set; }

        public string description { get; set; }
    }
}
