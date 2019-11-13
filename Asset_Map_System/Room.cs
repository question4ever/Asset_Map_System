using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Map_System
{
    public class Room
    {
        public ObservableCollection<Asset> Assets { get; set; }
        public String Notes { get; set; }

        public Room()
        {
            this.Assets = new ObservableCollection<Asset>();
            this.Notes = "";
        }
    }
}
