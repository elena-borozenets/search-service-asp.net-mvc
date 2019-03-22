using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchService.Models
{
    public class GoogleViewModel
    {
        public string Title { get; set; }
        public string Snippet { get; set; }
        public string Link { get; set; }
    }
    public class SearchViewModel
    {
        public List<Record> Items { get; set; }
    }
}