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
    [JsonObject(MemberSerialization.OptIn)]
    public class Book
    {
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("imageLink")]
        public string ImageLink { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("pages")]
        public int Pages { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("year")]
        public int Year { get; set; }

        public Book()
        {

        }

        [JsonConstructor]
        public Book(string author, string country, string imageLink, string language, string link, string pages, string title, string year)
        {
            Author = author;
            Country = country;
            ImageLink = imageLink;
            Language = language;
            Link = link;
            Pages = int.Parse(pages);
            Title = title;
            Year = int.Parse(year);
        }

        public Grid RenderDetails()
        {
            Grid grid = new Grid() 
            {
            };

            //adding 2 columns 
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(.5, GridUnitType.Star)});
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star)});

            //first column => Title, Image 
            {
                //create image
                Image img = new Image
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(30) // Optional: Add margin
                };

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri("C:\\Dev\\Personal\\!School\\BookCatalog\\resources\\" + this.ImageLink , UriKind.Absolute);
                bitmap.EndInit();
                img.Source = bitmap;

                //create label
                Label label = new Label
                {
                    Content = this.Title,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Bottom,
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
                grid.Children.Add(panel);
            }

            //second column => Author, Country, ImageLink, Language, Link, Pages, Year
            {
                var lb = new ListBox();

                lb.Items.Add(new TextBox() { Text = this.Author});
                lb.Items.Add(new TextBox() { Text = this.Country});
                lb.Items.Add(new TextBox() { Text = this.ImageLink});

                Grid.SetColumn(lb, 1);
                grid.Children.Add(lb);
            }

            return grid;
        }
    }
}
