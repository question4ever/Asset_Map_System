using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Asset_Map_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Asset asset = new Asset();
            asset.Name = "Computer-1";
            asset.Tag = 0;
            asset.Type = "Computer";
            asset.SerialNumber = "SN0123";
        
            InitializeComponent();

            AssetTextBlock.Text = asset.ToString();
        }
    }
}
