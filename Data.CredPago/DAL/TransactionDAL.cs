using Data.CredPago.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CredPago.DAL
{
    public class TransactionDAL
    {
        private StringBuilder sql;
        public TransactionDAL()
        {
            sql = new StringBuilder();
        }

        /// <summary>
        /// Insere uma nova transação de compra
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="orderId"></param>
        public void Inserir(Transaction transaction)
        {
            using (var bd = new BDEngine())
            {
                sql.Clear();
                sql.Append(@"
                    INSERT INTO Orders(client_id, cart_id, client_name, total_to_pay, credit_card, order_id, date)
                    VALUES('{0}', '{1}', '{2}', {3}, '{4}', '{5}', '{6}')
                ");

                bd.ExecuteNonQuery(string.Format(sql.ToString(),
                    transaction.client_id,
                    transaction.cart_id,
                    transaction.client_name,
                    transaction.total_to_pay,
                    transaction.credit_card,
                    transaction.order_id,
                    transaction.date
                    ));
            }
        }
    }
}
