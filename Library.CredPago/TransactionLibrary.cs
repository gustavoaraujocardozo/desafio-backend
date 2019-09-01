using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.CredPago
{
    public class TransactionLibrary
    {
        public TransactionLibrary()
        {

        }

        /// <summary>
        /// Retorna o código da transação
        /// </summary>
        /// <returns></returns>
        public String GetOrderId()
        {
            return GetPartOrderId(8) + ("-") + GetPartOrderId(4) + ("-") + GetPartOrderId(4) + ("-") + GetPartOrderId(4) + ("-") + GetPartOrderId(12);
        }

        /// <summary>
        /// Retorna partes do código da transação
        /// </summary>
        /// <param name="tamanho"></param>
        /// <returns></returns>
        public String GetPartOrderId(Int32 tamanho)
        {
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return result;
        }
    }
}
