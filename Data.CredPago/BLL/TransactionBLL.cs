using Data.CredPago.DAL;
using Data.CredPago.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CredPago.BLL
{
    public class TransactionBLL
    {
        public TransactionBLL()
        {

        }

        /// <summary>
        /// Insere uma nova transação de compra
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="creditCard"></param>
        public void Inserir(Transaction transaction)
        {
            TransactionDAL dal = new TransactionDAL();
            dal.Inserir(transaction);
        }

    }

}
