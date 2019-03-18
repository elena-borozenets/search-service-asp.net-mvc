using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchService.Data.Entities
{
    public class Record
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public Guid RequestNumber { get; set; }
    }
}
