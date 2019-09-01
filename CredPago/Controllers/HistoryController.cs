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
    /// Controlador de histórico
    /// </summary>
    [RoutePrefix("store/api/v1")]
    public class HistoryController : ApiController
    {
        /// <summary>
        /// Controlador de histórico
        /// </summary>
        public HistoryController()
        {

        }

        /// <summary>
        /// Lista de compras efetuadas
        /// </summary>
        /// <returns></returns>
        [Route("history")]
        public HttpResponseMessage Get()
        {
            try
            {
                HistoryBLL bll = new HistoryBLL();
                List<History> historic = bll.Listar();

                return new HttpResponseMessage() { Content = new StringContent(JArray.FromObject(historic).ToString(), Encoding.UTF8, "application/json") };
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message.ToString() });
            }
        }
        
        /// <summary>
        /// Lista de compras efetuadas por cliente
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        [Route("history")]
        public HttpResponseMessage Get(String clientId)
        {
            try
            {
                HistoryBLL bll = new HistoryBLL();
                List<History> historic = bll.ListarPorId(clientId);

                return new HttpResponseMessage() { Content = new StringContent(JArray.FromObject(historic).ToString(), Encoding.UTF8, "application/json") };
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { message = ex.Message.ToString() });
            }
        }
    }
}
