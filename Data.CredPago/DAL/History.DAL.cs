using Data.CredPago.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CredPago.DAL
{
    public class HistoryDAL
    {
        private StringBuilder sql;

        public HistoryDAL()
        {
            sql = new StringBuilder();
        }

        /// <summary>
        /// Insere histórico
        /// </summary>
        /// <param name="history"></param>
        public void Inserir(History history)
        {
            using (var bd = new BDEngine())
            {
                sql.Clear();
                sql.Append(@"
                    INSERT INTO History(card_number, client_id, value, order_id)
                    VALUES('{0}', '{1}', {2}, '{3}')
                ");

                bd.ExecuteNonQuery(string.Format(sql.ToString(),
                    history.card_number,
                    history.client_id,
                    history.value,
                    history.order_id));
            }
        }

        /// <summary>
        /// Retorna as compras efetuadas
        /// </summary>
        /// <returns></returns>
        public List<History> Listar()
        {
            List<History> lista = new List<History>();

            using (var bd = new BDEngine())
            {
                sql.Clear();
                sql.Append(@"
                    select 
	                    h.client_id,
	                    h.order_id,
	                    o.credit_card,
	                    o.total_to_pay,
	                    o.date
                    from History h(nolock)
                    inner join Orders o(nolock) on(o.order_id = h.order_id)
                    order by o.date
                ");

                var dr = bd.ObterReader(sql.ToString());

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        History history = new History();

                        history.card_number = dr["credit_card"].ToString();
                        history.client_id = dr["client_id"].ToString();
                        history.value = Convert.ToInt32(dr["total_to_pay"]);
                        history.order_id = dr["order_id"].ToString();
                        history.date = dr["date"].ToString();

                        lista.Add(history);
                    }
                }
            }

            return lista;
        }

        /// <summary>
        /// Retorna as compras efetuadas por cliente
        /// </summary>
        /// <returns></returns>
        public List<History> ListarPorId(String clientId)
        {
            List<History> lista = new List<History>();

            using (var bd = new BDEngine())
            {
                sql.Clear();
                sql.Append(@"
                    select 
	                    h.client_id,
	                    h.order_id,
	                    o.credit_card,
	                    o.total_to_pay,
	                    o.date
                    from History h(nolock)
                    inner join Orders o(nolock) on(o.order_id = h.order_id)
                    where h.client_id = '{0}'
                    order by o.date
                ");

                var dr = bd.ObterReader(string.Format(sql.ToString(), clientId));

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        History history = new History();

                        history.card_number = dr["credit_card"].ToString();
                        history.client_id = dr["client_id"].ToString();
                        history.value = Convert.ToInt32(dr["total_to_pay"]);
                        history.order_id = dr["order_id"].ToString();
                        history.date = dr["date"].ToString();

                        lista.Add(history);
                    }
                }
            }

            return lista;
        }
    }
}
