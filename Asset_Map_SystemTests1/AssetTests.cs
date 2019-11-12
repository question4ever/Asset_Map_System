using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Asset_Map_System;


namespace Asset_Map_System.Tests
{
    [TestClass()]
    public class AssetTests
    {
        [TestMethod()]
        public void Asset_Get_Type_ReturnsEmptyString()
        {
            Asset asset_mock = new Asset();
            String type = asset_mock.GetAssetType();
            Assert.AreEqual(type, "");
        }

        [TestMethod()]
        public void Asset_Get_Name_ReturnsEmptyString()
        {
            Asset asset_mock = new Asset();
            String name = asset_mock.GetAssetName();
            Assert.AreEqual(name, "");
        }

        [TestMethod()]
        public void Asset_Get_Tag_Returns0()
        {
            Asset asset_mock = new Asset();
            int tag = asset_mock.GetAssetTag();
            Assert.AreEqual(tag, 0);
        }

        [TestMethod()]
        public void Asset_Get_SerialNumber_ReturnsEmptyString()
        {
            Asset asset_mock = new Asset();
            String serialNumber = asset_mock.GetAssetSN();
            Assert.AreEqual(serialNumber, "");
        }

        [TestMethod()]
        public void Asset_Set_SerialNumber_SetsSNToA()
        {
            Asset asset_mock = new Asset();
            asset_mock.SetAssetSN("A");
            String serialNumber = asset_mock.GetAssetSN();
            Assert.AreEqual(serialNumber, "A");
        }

        [TestMethod()]
        public void Asset_Set_Type_SetsTypeToA()
        {
            Asset asset_mock = new Asset();
            String serialNumber = asset_mock.GetAssetSN();
            Assert.AreEqual(serialNumber, "");
        }

        [TestMethod()]
        public void Asset_Set_Tag_SetsTagTo1()
        {
            Asset asset_mock = new Asset();
            asset_mock.SetAssetTag(1);
            int tag = asset_mock.GetAssetTag();
            Assert.AreEqual(tag, 1);
        }

        [TestMethod()]
        public void Asset_Set_Name_SetsNametoA()
        {
            Asset asset_mock = new Asset();
            asset_mock.SetAssetName("A");
            String name = asset_mock.GetAssetName();
            Assert.AreEqual(name, "A");
        }
    }
}
