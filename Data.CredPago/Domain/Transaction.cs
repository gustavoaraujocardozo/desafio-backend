using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CredPago.Domain
{
    public class Transaction
    {
        public Transaction()
        {

        }

        public string order_id { get; set; }
        public string client_id { get; set; }
        public string cart_id { get; set; }
        public string client_name { get; set; }
        public int total_to_pay { get; set; }
        public string credit_card { get; set; }
        public string date { get; set; }
    }
}
