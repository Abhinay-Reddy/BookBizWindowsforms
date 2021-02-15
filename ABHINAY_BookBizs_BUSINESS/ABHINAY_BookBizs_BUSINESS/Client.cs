using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABHINAY_BookBizs_BUSINESS
{
    public class Client
    {
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int FaxNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int CreditLimit { get; set; }
        public string Designation { get; set; }
        public string Password { get; set; }
    }
}
