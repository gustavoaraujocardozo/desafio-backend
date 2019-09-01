using Data.CredPago.DAL;
using Data.CredPago.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CredPago.BLL
{
    public class CartBLL
    {
        public CartBLL()
        {

        }

        /// <summary>
        /// Insere um item ao carrinho
        /// </summary>
        /// <param name="cart"></param>
        public void Inserir(Cart cart)
        {
            CartDAL dal = new CartDAL();
            dal.Inserir(cart);
        }
    }
}
