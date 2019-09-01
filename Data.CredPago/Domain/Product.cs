using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CredPago.Domain
{
    public class Product
    {
        public Product()
        {

        }

        public string product_id { get; set; }
        public string artist { get; set; }
        public int year { get; set; }
        public string album { get; set; }
        public int price { get; set; }
        public string store { get; set; }
        public string thumb { get; set; }
        public string date { get; set; }
    }
}
