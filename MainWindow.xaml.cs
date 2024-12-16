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
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections;
using Newtonsoft.Json.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;

namespace WebShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataBase dataBase;
        public MainWindow()
        {
            InitializeComponent();

            dataBase = new DataBase();
            dataBase.Import("../ ../resources/books.json");
        }

        //what desperation looks like
        private void LoadListView() 
        {
            listbox.Items.Clear();
        }

        private void LoadDetailsView(Book r)
        {
            btn_Copy.IsEnabled = true;
            btn_Delete.IsEnabled = true;
            btn_Save.IsEnabled = true;

            detailsViewMain.Children.Clear();
            detailsViewMain.Children.Add(r.RenderDetails());
        }

        //---------- events ----------  
        private void OrderClick(object sender, RoutedEventArgs e)
        {
            LoadListView();
        }
        private void ProductClick(object sender, RoutedEventArgs e)
        {
            LoadListView();
        }
        private void CusotmerClick(object sender, RoutedEventArgs e)
        {
            LoadListView();
        } 

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            //dataBase.Save("out.json");
        }

        private void btn_Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {

        } 
    }
}
