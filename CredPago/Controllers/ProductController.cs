using Data.CredPago.BLL;
using Data.CredPago.Domain;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace CredPago.Controllers
{
    /// <summary>
    /// Controlador de Produtos
    /// </summary>
    [RoutePrefix("store/api/v1")]
    public class ProductController : ApiController
    {
        /// <summary>
        /// Controlador de Produtos
        /// </summary>
        public ProductController()
        {

        }

        /// <summary>
        /// Insere um novo produto
        /// </summary>
        /// <returns></returns>
        [Route("product")]
        public HttpResponseMessage Post()
        {
            try
            {
                System.Threading.Tasks.Task<string> content = Request.Content.ReadAsStringAsync();
                Object jobj = new object();
                jobj = JObject.Parse(content.Result);

                JToken product_id = JObject.Parse(jobj.ToString()).SelectToken("product_id");
                JToken artist = JObject.Parse(jobj.ToString()).SelectToken("artist");
                JToken year = JObject.Parse(jobj.ToString()).SelectToken("year");
                JToken album = JObject.Parse(jobj.ToString()).SelectToken("album");
                JToken price = JObject.Parse(jobj.ToString()).SelectToken("price");
                JToken store = JObject.Parse(jobj.ToString()).SelectToken("store");
                JToken thumb = JObject.Parse(jobj.ToString()).SelectToken("thumb");
                JToken date = JObject.Parse(jobj.ToString()).SelectToken("date");

                Product product = new Product();

                product.product_id = product_id.ToString();
                product.artist = artist.ToString();
                product.year = Convert.ToInt32(year);
                product.album = album.ToString();
                product.price = Convert.ToInt32(price);
                product.store = store.ToString();
                product.thumb = thumb.ToString();
                product.date = date.ToString();

                ProductBLL bll = new ProductBLL();

                if (bll.Inserir(product))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Produto inserido com sucesso!" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Produto já existe!" });
                }


            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message.ToString() });
            }
        }

        /// <summary>
        /// Retorna uma lista de produtos
        /// </summary>
        /// <returns></returns>
        [Route("products")]
        public HttpResponseMessage Get()
        {
            try
            {
                ProductBLL bll = new ProductBLL();
                List<Product> products = bll.Listar();

                return new HttpResponseMessage() { Content = new StringContent(JArray.FromObject(products).ToString(), Encoding.UTF8, "application/json") };
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message.ToString() });
            }
        }
    }
}
