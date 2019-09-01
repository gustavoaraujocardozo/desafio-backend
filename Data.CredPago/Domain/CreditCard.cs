using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CredPago.Domain
{
    public class CreditCard
    {
        public CreditCard()
        {

        }

        public string card_number { get; set; }
        public string card_holder_name { get; set; }
        public int cvv { get; set; }
        public string exp_date { get; set; }
    }
}
