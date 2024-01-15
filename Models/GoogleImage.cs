using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatGptApi.Models
{
    public class GoogleImage
    {
        public string Link { get; set; }
    }
    public class GoogleImageResponse
    {
        public List<GoogleImage> Items { get; set; }
    }
}