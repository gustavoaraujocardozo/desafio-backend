using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CredPago.Domain
{
    public class Cart
    {
        public Cart()
        {

        }

        public string cart_id { get; set; }
        public string client_id { get; set; }
        public string product_id { get; set; }
        public string date { get; set; }
        public string time { get; set; }
    }
}
