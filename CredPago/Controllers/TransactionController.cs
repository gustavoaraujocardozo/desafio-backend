using Data.CredPago.BLL;
using Data.CredPago.DAL;
using Data.CredPago.Domain;
using Library.CredPago;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CredPago.Controllers
{
    /// <summary>
    /// Controlador de Transações
    /// </summary>
    [RoutePrefix("store/api/v1")]
    public class TransactionController : ApiController
    {
        /// <summary>
        /// Controlador de Transações
        /// </summary>
        public TransactionController()
        {

        }

        /// <summary>
        /// Finaliza uma compra com os itens selecionados no carrinho
        /// </summary>
        /// <returns></returns>
        [Route("buy")]
        public HttpResponseMessage Post()
        {
            try
            {
                System.Threading.Tasks.Task<string> content = Request.Content.ReadAsStringAsync();
                Object jobj = new object();

                var orderId = new TransactionLibrary().GetOrderId();

                //dados da operação
                jobj = JObject.Parse(content.Result);
                JToken client_id = JObject.Parse(jobj.ToString()).SelectToken("client_id");
                JToken cart_id = JObject.Parse(jobj.ToString()).SelectToken("cart_id");
                JToken client_name = JObject.Parse(jobj.ToString()).SelectToken("client_name");
                JToken value_to_pay = JObject.Parse(jobj.ToString()).SelectToken("value_to_pay");
                JToken credit_card = JObject.Parse(jobj.ToString()).SelectToken("credit_card");

                #region Cartão de Crédito
                //dados do cartão de crédito
                jobj = JObject.Parse(credit_card.ToString());
                JToken number = JObject.Parse(jobj.ToString()).SelectToken("number");
                JToken cvv = JObject.Parse(jobj.ToString()).SelectToken("cvv");
                JToken exp_date = JObject.Parse(jobj.ToString()).SelectToken("exp_date");
                JToken card_holder_name = JObject.Parse(jobj.ToString()).SelectToken("card_holder_name");

                CreditCard creditCard = new CreditCard();
                creditCard.card_number = number.ToString();
                creditCard.cvv = Convert.ToInt32(cvv);
                creditCard.exp_date = exp_date.ToString();
                creditCard.card_holder_name = card_holder_name.ToString();

                //registra o cartão de crédito
                CreditCardBLL creditCardBll = new CreditCardBLL();
                creditCardBll.Inserir(creditCard);
                #endregion

                #region Transação
                //registra a transação de venda
                Transaction transaction = new Transaction();
                transaction.client_id = client_id.ToString();
                transaction.cart_id = cart_id.ToString();
                transaction.client_name = client_name.ToString();
                transaction.total_to_pay = Convert.ToInt32(value_to_pay);
                transaction.credit_card = creditCard.card_number;
                transaction.order_id = orderId;
                transaction.date = DateTime.Today.ToString("dd/MM/yyyy");

                TransactionBLL transactionBll = new TransactionBLL();
                transactionBll.Inserir(transaction);
                #endregion

                #region Histórico
                History history = new History();
                history.card_number = creditCard.card_number;
                history.client_id = transaction.client_id;
                history.value = transaction.total_to_pay;
                history.order_id = orderId;

                HistoryBLL historyBll = new HistoryBLL();
                historyBll.Inserir(history);
                #endregion

                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Compra realizada com sucesso!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message.ToString() });
            }
        }
    }
}
