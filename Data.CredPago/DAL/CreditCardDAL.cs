using Data.CredPago.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CredPago.DAL
{
    public class CreditCardDAL
    {
        private StringBuilder sql;

        public CreditCardDAL()
        {
            sql = new StringBuilder();
        }

        /// <summary>
        /// Registra o cartão de crédito informado na transação
        /// </summary>
        /// <param name="creditCard"></param>
        public void Inserir(CreditCard creditCard)
        {
            using (var bd = new BDEngine())
            {
                sql.Clear();
                sql.Append(@"
                    INSERT INTO CreditCard(card_number, card_holder_name, cvv, exp_date)
                    VALUES ('{0}', '{1}', {2}, '{3}')
                ");

                bd.ExecuteNonQuery(string.Format(sql.ToString(),
                    creditCard.card_number,
                    creditCard.card_holder_name,
                    creditCard.cvv,
                    creditCard.exp_date));
            }
        }

        /// <summary>
        /// Obter cartão de crédito por número
        /// </summary>
        /// <param name="creditCard"></param>
        /// <returns></returns>
        public Boolean GetCreditCard(String cardNumber)
        {
            using (var bd = new BDEngine())
            {
                sql.Append(@"
                    SELECT card_number
                    FROM CreditCard c(nolock)
                    WHERE c.card_number = '{0}'
                ");

                object CreditCard = bd.ExecuteScalar(string.Format(sql.ToString(), cardNumber));

                if (CreditCard != null)
                    return true;
            }

            return false;
        }
    }
}
