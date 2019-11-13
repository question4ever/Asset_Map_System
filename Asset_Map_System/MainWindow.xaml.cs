using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
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
using System.IO;

namespace Asset_Map_System
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool InventoryMode = false;
        private Room room = new Room();

        public MainWindow()
        {
            InitializeComponent();
            Notes.Text = room.Notes;
            DG1.DataContext = room.Assets;
            if (InventoryMode)
            {
                DataGridCheckBoxColumn existsColumn = new DataGridCheckBoxColumn();
                existsColumn.Header = "Is it there?";
                existsColumn.Binding = new Binding("Exists");
                DG1.Columns.Add(existsColumn);

                DataGridCheckBoxColumn imageColumn = new DataGridCheckBoxColumn();
                imageColumn.Header = "Is it imaged?";
                imageColumn.Binding = new Binding("Imaged");
                DG1.Columns.Add(imageColumn);
            }
        }

        public void Save()
        {
            FileStream fileStream = File.OpenWrite("assets.sav");
            string x = "";
            foreach (Asset asset in room.Assets)
            {
                x += asset.Name + "," + asset.Type + "," + asset.Tag + "," + asset.SerialNumber + "\n";
            }
            
            fileStream.Write(Encoding.ASCII.GetBytes(x), 0, x.Length);
            fileStream.Close();
        }

        public Asset ReadAsset(FileStream fileStream)
        {
            int c = fileStream.ReadByte();
            while (c != Encoding.ASCII.GetBytes("\n")[0])
            {

            }
        }

        public ObservableCollection<Asset> Load()
        {
            FileStream fileStream = File.OpenRead("assets.sav");
            fileStream.ReadByte
        }

        private void AddAsset_Click(object sender, RoutedEventArgs e)
        {
            AddAssetForm form = new AddAssetForm();
            form.Show();
        }

        public void AddAssetToRoom(Asset asset)
        {
            room.Assets.Add(asset);
        }

        private void DeleteAsset_Click(object sender, RoutedEventArgs e)
        {
            int index = DG1.SelectedIndex;
            if(index > -1)
            {
                room.Assets.RemoveAt(index);
            }
        }

        private void Notes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int startIndex = Notes.CaretIndex;
                Notes.Text += "\n";
                Notes.CaretIndex = startIndex+1;
            }
            if(e.Key == Key.Tab)
            {
                e.Handled = true;
                int startIndex = Notes.CaretIndex;
                Notes.Text += "\t";
                Notes.CaretIndex = startIndex + 1;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }
    }
}
