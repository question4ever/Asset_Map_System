using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Map_System
{
    public class Asset
    {
        public String Type         { get; set; }
        public String Name         { get; set; }
        public int Tag             { get; set; }
        public String SerialNumber { get; set; }

        public override string ToString()
        {
            return String.Format("{0}  {1}  {2}  {3}",
                            Name, Type, Tag, SerialNumber);
        }
    }
}
