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
            dataBase.ImportPath = "..\\..\\resources\\books.json"; //change this shit asap

            dataBase.Import();

            LoadListView();
        }

        private void LoadListView() 
        {
            listbox.Items.Clear();
            foreach(Book book in dataBase.Records)
            {
                var lbItem = new ListBoxItem()
                {
                    Content = book.Title
                };
                lbItem.Selected += (sender, e) => {
                    LoadDetailsView(book); 
                };
                listbox.Items.Add(lbItem);
            }
            lbStatistics.Content = $"Könyvek darabszáma: {dataBase.Records.Count()}";
        }

        private void LoadDetailsView(Book book)
        {
            btn_Duplicate.IsEnabled = true;
            btn_Delete.IsEnabled = true;
            btn_Save.IsEnabled = true;

            dataBase.CurrentlySelected = book;

            detailsViewMain.Children.Clear();
            detailsViewMain.Children.Add(new DetailsView(book));
        }

        //---------- events ----------  
        private void btn_Save_Click(object sender, RoutedEventArgs r)
        {
            //kids.. never fuckin' do this
            var book = dataBase.CurrentlySelected;
            book.Author = DetailsView.TextBoxes.Find(e => e.Name == "Author").Text; 
            book.Country = DetailsView.TextBoxes.Find(e => e.Name == "Country").Text;
            book.ImageLink = DetailsView.TextBoxes.Find(e => e.Name == "ImageLink").Text;
            book.Language = DetailsView.TextBoxes.Find(e => e.Name == "Language").Text;
            book.Link = DetailsView.TextBoxes.Find(e => e.Name == "Link").Text;
            book.Pages = int.Parse(DetailsView.TextBoxes.Find(e => e.Name == "Pages").Text);
            book.Title = DetailsView.TextBoxes.Find(e => e.Name == "Title").Text;
            book.Year = int.Parse(DetailsView.TextBoxes.Find(e => e.Name == "Year").Text);
            LoadListView();
        }

        private void btn_Duplicate_Click(object sender, RoutedEventArgs e)
        {
            dataBase.Insert(dataBase.CurrentlySelected);
            LoadListView();
        }
        private void btn_SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            dataBase.Export();
            LoadListView(); //why not
        }
        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book();
            dataBase.Insert(book);
            LoadListView();
            LoadDetailsView(book);
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            dataBase.Delete();
            detailsViewMain.Children.Clear();
            LoadListView();
        } 
    }
}
