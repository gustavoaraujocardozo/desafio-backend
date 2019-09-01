using Data.CredPago.DAL;
using Data.CredPago.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CredPago.BLL
{
    public class HistoryBLL
    {
        public HistoryBLL()
        {

        }

        /// <summary>
        /// Insere histórico
        /// </summary>
        /// <param name="history"></param>
        public void Inserir(History history)
        {
            HistoryDAL dal = new HistoryDAL();
            dal.Inserir(history);
        }

        /// <summary>
        /// Retorna as compras efetuadas
        /// </summary>
        /// <returns></returns>
        public List<History> Listar()
        {
            HistoryDAL dal = new HistoryDAL();
            return dal.Listar();
        }

        /// <summary>
        /// Retorna as compras efetuadas por cliente
        /// </summary>
        /// <returns></returns>
        public List<History> ListarPorId(String clientId)
        {
            HistoryDAL dal = new HistoryDAL();
            return dal.ListarPorId(clientId);
        }
    }
}
