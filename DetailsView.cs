using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace WebShop
{
    internal class LbItem : Grid 
    {
        public LbItem(string propertyName, string value)
        {
            this.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(.3, GridUnitType.Star)});
            this.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star)});
            
            var left = new Label()
            {
                Content = propertyName,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Margin = new Thickness(0,2,5,2) 
            };

            var right = new TextBox()
            {
                Text = value, 
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Margin = new Thickness(0,2,5,2),
                VerticalAlignment = VerticalAlignment.Center,
                TextAlignment = TextAlignment.Center,
                Name = propertyName
            };

            DetailsView.TextBoxes.Add(right);

            Grid.SetColumn(left,0);
            Grid.SetColumn(right,1);
            this.Children.Add(left);
            this.Children.Add(right);
        }
    }
    internal class DetailsView : Grid
    {
        public static List<TextBox> TextBoxes = new List<TextBox>();
        public DetailsView(Book book) 
        {
            //adding 2 columns 
            this.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(.5, GridUnitType.Star)});
            this.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star)});

            //first column => Title, Image 
            try{
                //create image
                Image img = new Image
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(30) // Optional: Add margin
                };

                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + "../../resources/" + book.ImageLink, UriKind.Absolute); //I give up
                    bitmap.EndInit();
                    img.Source = bitmap;
                }
                catch
                {
                    MessageBox.Show("Could not load image :/");
                }

                //create label
                Label label = new Label
                {
                    Content = book.Title,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(5)
                };

                //create stackpanel
                StackPanel panel = new StackPanel
                {
                    Orientation = Orientation.Vertical
                };
                panel.Children.Add(img);
                panel.Children.Add(label);

                Grid.SetColumn(panel, 0);
                this.Children.Add(panel);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //second column => Author, Country, ImageLink, Language, Link, Pages, Year
            {
                var lb = new ListBox();

                DetailsView.TextBoxes.Clear();
                
                //important to name them like this (I know it's shit but we ball)
                lb.Items.Add(new LbItem("Author", book.Author));
                lb.Items.Add(new LbItem("Country", book.Country));
                lb.Items.Add(new LbItem("ImageLink", book.ImageLink));
                lb.Items.Add(new LbItem("Language", book.Language));
                lb.Items.Add(new LbItem("Link", book.Link));
                lb.Items.Add(new LbItem("Pages", book.Pages.ToString()));
                lb.Items.Add(new LbItem("Title", book.Title));
                lb.Items.Add(new LbItem("Year", book.Year.ToString()));

                Grid.SetColumn(lb, 1);
                this.Children.Add(lb);
            }

        }
    }
}
