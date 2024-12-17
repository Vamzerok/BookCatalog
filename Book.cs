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
    }
}
