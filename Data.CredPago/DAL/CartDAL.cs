using Data.CredPago.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CredPago.DAL
{
    public class CartDAL
    {
        private StringBuilder sql;

        public CartDAL()
        {
            sql = new StringBuilder();
        }

        /// <summary>
        /// Insere um item ao carrinho
        /// </summary>
        /// <param name="cart"></param>
        public void Inserir(Cart cart)
        {
            using (var bd = new BDEngine())
            {
                sql.Clear();
                sql.Append(@"
                    INSERT INTO Cart(cart_id, client_id, product_id, date, time) 
                    VALUES('{0}', '{1}', '{2}', '{3}', '{4}')
                ");

                bd.ExecuteNonQuery(string.Format(sql.ToString(),
                    cart.cart_id,
                    cart.client_id,
                    cart.product_id,
                    cart.date,
                    cart.time));
            }
        }
    }
}