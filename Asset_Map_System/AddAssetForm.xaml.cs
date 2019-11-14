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
using System.Windows.Shapes;

namespace Asset_Map_System
{
    /// <summary>
    /// Interaction logic for AddAssetForm.xaml
    /// </summary>
    public partial class AddAssetForm : Window
    {
        public AddAssetForm()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            int tag = Int32.Parse(Tag.Text);
            Asset asset = new Asset(Type.Text, Name.Text, tag, SerialNumber.Text);
            ((MainWindow)Application.Current.MainWindow).AddAssetToRoom(asset);
            Close();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                Submit_Click(sender, e);
            }
        }
    }
}
