using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using System.Xml;
using System.Text.RegularExpressions;
using Svg;

namespace Asset_Map_System
{
    /// <summary>
    /// Interaction logic for FloorMapWindow.xaml
    /// </summary>
    public partial class FloorMapWindow : Window
    {

        public static System.Drawing.Size MaximumSize { get; set; }

        public FloorMapWindow()
        {
            InitializeComponent();
            PDFtoSVG.PDFRead();
            FloorPlan.Width = this.Width;
            FloorPlan.Height = this.Height;
        }

        public List<List<float>> ReadFloorPlan(string filename)
        {
            string x = "";
            using (StreamReader sr = File.OpenText(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    x += line;
                }
            }
            
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(x);

            XmlNodeList itemRefList = xml.GetElementsByTagName("GeometryDrawing.Geometry");
            List<List<float>> allRectangles = new List<List<float>>();
            foreach (XmlNode xmlNode in itemRefList)
            {
                string geom = xmlNode.InnerXml.ToString();
                string rect = geom.Substring(geom.IndexOf("Rect=") + 6, 32);
                rect = rect.Replace("\"", "");
                rect = rect.Replace("x", "");
                string[] vs = rect.Split(',');
                List<float> coordinates = new List<float>();
                foreach(string c in vs)
                {
                    coordinates.Add(float.Parse(c));
                }
                allRectangles.Add(coordinates);
            }
            return allRectangles;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            FloorPlan.Width = this.Width;
            FloorPlan.Height = this.Height;
        }

        private void GetRoom(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            RoomWindow roomWindow = new RoomWindow();
            roomWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<List<float>> buttonCoordinates = ReadFloorPlan("../../Assets/sol_floor_3.xaml");
            int i = 0;
            foreach (List<float> coordinates in buttonCoordinates)
            {
                Button button = new Button
                {
                    Width = coordinates[2],
                    Name = "Room" + (++i),
                    Height = coordinates[3]
                };
                button.Click += new RoutedEventHandler(GetRoom);
                Canvas.SetLeft(button, coordinates[0]);
                Canvas.SetTop(button, coordinates[1]);
                Floor.Children.Add(button);
            }
        }
    }
}
