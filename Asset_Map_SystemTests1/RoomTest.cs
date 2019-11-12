using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Asset_Map_System.Tests
{
    [TestClass]
    public class RoomTest
    {
        [TestMethod]
        public void RoomTestConstructor()
        {
            Room room = new Room();
            Assert.IsNotNull(room);
        }

        [TestMethod]
        public void RoomGetAssets_ReturnsListAssets()
        {
            Room room = new Room();
            List<Asset> assets = room.GetAssets();
        }

        [TestMethod]
        public void RoomSetAssets_SetListAssets()
        {
            Room room = new Room();
            List<Asset> assets = new List<Asset>() { new Asset()};
            room.SetAssets(assets);
            assets = room.GetAssets();
            Assert.AreEqual(assets.Count, 1);
        }

        [TestMethod]
        public void RoomGetNotes_ReturnsEmptyString()
        {
            Room room = new Room();
            String notes = room.GetNotes();
            Assert.IsNotNull(notes);
        }
    }
}
