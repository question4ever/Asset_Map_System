using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;
using Asset_Map_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asset_Map_System.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        [TestMethod()]
        public void MainWindowTest()
        {
            MainWindow mainWindow = new MainWindow();
            Assert.IsNotNull(mainWindow);
        }
    }
}