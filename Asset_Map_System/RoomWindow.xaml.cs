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
    public partial class RoomWindow : Window
    {
        private bool InventoryMode = false;
        private Room room = new Room();
        private String filename;

        public RoomWindow()
        {
            InitializeComponent();
        }

        public RoomWindow(string filename)
        {
            InitializeComponent();
            this.filename = filename;
            Notes.Text = room.Notes;
            try
            {
                room.Assets = Load();
            }
            catch (FileNotFoundException fnf)
            {
                Console.WriteLine(fnf.StackTrace);
                FileStream f = File.OpenWrite(filename);
                f.Close();
                room.Assets = Load();
            }
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

        private void Save()
        {
            try
            {
                File.Delete(filename);
            }
            catch(IOException ioe)
            {
                Console.WriteLine(ioe.StackTrace);
            }
            FileStream fileStream = File.OpenWrite(filename);
            string x = "";
            foreach (Asset asset in room.Assets)
            {
                x += asset.Name + "," + asset.Type + "," + asset.Tag + "," + asset.SerialNumber + "\n";
            }
            
            fileStream.Write(Encoding.ASCII.GetBytes(x), 0, x.Length);
            fileStream.Close();
        }

        private ObservableCollection<Asset> Load()
        {
            ObservableCollection<Asset> tmpAssetList = new ObservableCollection<Asset>();
            using (StreamReader sr = File.OpenText(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] attrs = line.Split(',');
                    tmpAssetList.Add(new Asset(attrs[1], attrs[0], Int32.Parse(attrs[2]), attrs[3]));
                }
            }
            return tmpAssetList;
        }

        private void AddAsset_Click(object sender, RoutedEventArgs e)
        {
            AddAssetForm form = new AddAssetForm();
            form.Show();
        }

        public void AddAssetToRoom(Asset asset)
        {
            room.Assets.Add(asset);
            Save();
        }

        private void DeleteAsset_Click(object sender, RoutedEventArgs e)
        {
            int index = DG1.SelectedIndex;
            if(index > -1)
            {
                room.Assets.RemoveAt(index);
            }
            Save();
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

        private void DG1_CurrentCellChanged(object sender, EventArgs e)
        {
            Save();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new FloorMapWindow();
            window.Show();
        }
    }
}
