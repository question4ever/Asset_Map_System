using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Map_System
{
    public class Asset
    {
        private String type;
        private String name;
        private int tag;
        private String serialNumber;

        public Asset(String type = "", String name = "", int tag = 0, String serialNumber = "")
        {
            this.type = type;
            this.name = name;
            this.tag = tag;
            this.serialNumber = serialNumber;
        }

        //Get and set asset type
        public String GetAssetType()
        {
            return type;
        }

        public void SetAssetType(String type)
        {
            this.type = type;
        }
        //end

        //start get name and set name
        public String GetAssetName()
        {
            return name;
        }

        public void SetAssetName(String name)
        {
            this.name = name;
        }
        //end

        //Start get and set TAG
        public int GetAssetTag()
        {
            return tag;
        }

        public void SetAssetTag(int tag)
        {
            this.tag = tag;
        }
        //end

        //Start get and set serial number
        public String GetAssetSN()
        {
            return serialNumber;
        }

        public void SetAssetSN(String serialNumber)
        {
            this.serialNumber = serialNumber;
        }
        //end
    }
}
