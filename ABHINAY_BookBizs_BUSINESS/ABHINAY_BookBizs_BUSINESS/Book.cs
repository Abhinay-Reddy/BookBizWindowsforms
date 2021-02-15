using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABHINAY_BookBizs_BUSINESS
{
    public class Book
    {
        public int ISBN { get; set; }
        public string Title { get; set; }
        public int UnitPrice { get; set; }
        public int YearPublished { get; set; }
        public int QOH { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
    }
}
