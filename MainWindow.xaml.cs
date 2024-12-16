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
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections;
using Newtonsoft.Json.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.IO;
using System.Reflection;

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
            dataBase.ImportPath = "C:\\Dev\\Personal\\!School\\BookCatalog\\resources\\books.json"; //change this shit asap
            dataBase.ExportPath = "out.json";

            dataBase.Import();

            LoadListView();
        }

        private void LoadListView() 
        {
            listbox.Items.Clear();
            foreach(Book book in dataBase.Records)
            {
                var lbItem = new ListBoxItem();
                lbItem.Selected += (sender, e) => { LoadDetailsView(book); };
                lbItem.Content = book.Title;
                listbox.Items.Add(lbItem);
            }
        }

        private void LoadDetailsView(Book book)
        {
            btn_Copy.IsEnabled = true;
            btn_Delete.IsEnabled = true;
            btn_Save.IsEnabled = true;

            detailsViewMain.Children.Clear();
            detailsViewMain.Children.Add(book.RenderDetails());
        }

        //---------- events ----------  
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_Copy_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
        } 
    }
}
