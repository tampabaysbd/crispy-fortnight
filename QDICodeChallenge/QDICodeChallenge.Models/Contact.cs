using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDICodeChallenge.Models
{
    public class Contact
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string zipcodeid { get; set; }
        public ZipCode zipcode { get; set; }
    }
}
