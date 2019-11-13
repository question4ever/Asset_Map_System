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
        public bool Exists { get; set; }
        public bool Imaged { get; set; }

        public Asset(String Type = "", String Name = "", int Tag = 0, String SerialNumber = "")
        {
            this.Type = Type;
            this.Name = Name;
            this.Tag = Tag;
            this.SerialNumber = SerialNumber;
        }

        public override string ToString()
        {
            return String.Format("{0}  {1}  {2}  {3}",
                            Name, Type, Tag, SerialNumber);
        }
    }
}
