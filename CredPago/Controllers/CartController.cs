using Data.CredPago.BLL;
using Data.CredPago.Domain;
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
    /// Controlador de Carrinho
    /// </summary>
    [RoutePrefix("store/api/v1")]
    public class CartController : ApiController
    {
        /// <summary>
        /// Controlador de Carrinho
        /// </summary>
        public CartController()
        {

        }

        /// <summary>
        /// Insere um item ao carrinho
        /// </summary>
        /// <returns></returns>
        [Route("add_to_cart")]
        public HttpResponseMessage Post()
        {
            try
            {
                System.Threading.Tasks.Task<string> content = Request.Content.ReadAsStringAsync();
                Object jobj = new object();
                jobj = JObject.Parse(content.Result);

                JToken cart_id = JObject.Parse(jobj.ToString()).SelectToken("cart_id");
                JToken client_id = JObject.Parse(jobj.ToString()).SelectToken("client_id");
                JToken product_id = JObject.Parse(jobj.ToString()).SelectToken("product_id");
                JToken date = JObject.Parse(jobj.ToString()).SelectToken("date");
                JToken time = JObject.Parse(jobj.ToString()).SelectToken("time");

                Cart cart = new Cart();

                cart.cart_id = cart_id.ToString();
                cart.client_id = client_id.ToString();
                cart.product_id = product_id.ToString();
                cart.date = date.ToString();
                cart.time = time.ToString();

                CartBLL bll = new CartBLL();
                bll.Inserir(cart);

                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Item inserido ao carrinho!" });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message.ToString() });
            }
        }
    }
}
