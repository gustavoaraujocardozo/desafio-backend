using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CredPago.Domain
{
    public class History
    {
        public History()
        {

        }

        public string card_number { get; set; }
        public string client_id { get; set; }
        public int value { get; set; }
        public string order_id { get; set; }
        public string date { get; set; }
    }
}
