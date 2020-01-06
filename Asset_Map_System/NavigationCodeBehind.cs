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

namespace Asset_Map_System {
    public partial class NavigationWindow : Window {
        _mainFrame.Navigate(new Page1());

        _mainFrame.NavigationService.GoBack(); 
        _mainFrame.NavigationService.GoForward(); 
        _mainFrame.NavigationService.Refresh();

        _mainFrame.NavigationService.Navigate(new Uri("http://www.google.com/"));
        _mainFrame.NavigationService.Navigate(new Uri("Page1.xaml", UriKind.Relative));
        _mainFrame.NavigationService.Navigate(new Page1());
        _mainFrame.NavigationService.Navigate(new Button());
        _mainFrame.NavigationService.Navigate("Hello world");
    }
}