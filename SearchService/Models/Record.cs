using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchService.Models
{
    public class Record
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public int RequestId { get; set; }
    }
}