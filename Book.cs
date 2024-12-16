using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace WebShop
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Book
    {
        [JsonProperty]
        public string Author { get; set; }
        [JsonProperty]
        public string Country { get; set; }
        [JsonProperty]
        public string ImageLink { get; set; }
        [JsonProperty]
        public string Language { get; set; }
        [JsonProperty]
        public string Link { get; set; }
        [JsonProperty]
        public int Pages { get; set; }
        [JsonProperty]
        public string Title { get; set; }
        [JsonProperty]
        public int Year { get; set; }

        public Book()
        {

        }

        public Book(string jsonStr)
        {

        }

        public Grid RenderDetails()
        {
            throw new NotImplementedException();
        }
    }
}
