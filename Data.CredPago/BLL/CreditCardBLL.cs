using Data.CredPago.DAL;
using Data.CredPago.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CredPago.BLL
{
    public class CreditCardBLL
    {
        /// <summary>
        /// Registra o cartão de crédito informado na transação
        /// </summary>
        /// <param name="creditCard"></param>
        public void Inserir(CreditCard creditCard)
        {
            CreditCardDAL dal = new CreditCardDAL();

            //busca o cartão de crédito pelo número
            var Exist = dal.GetCreditCard(creditCard.card_number);

            //se não existir insere o novo registro
            if (!Exist)
                dal.Inserir(creditCard);
        }
    }
}
