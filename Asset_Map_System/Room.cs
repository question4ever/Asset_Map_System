using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Map_System
{
    public class Room
    {
        private List<Asset> assets;
        private String notes;

        public Room()
        {
            this.assets = new List<Asset>();
            this.notes = "";
        }

        public List<Asset> GetAssets()
        {
            return assets;
        }

        public void SetAssets(List<Asset> assets)
        {
            this.assets = assets;
        }

        public String GetNotes()
        {
            return notes;
        }

        public void SetNotes(String notes)
        {
            this.notes = notes;
        }
    }
}
