using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CredPago
{
    public class BDEngine : IDisposable
    {
        private readonly SqlConnection conn;

        /// <summary>
        /// Abre a conexão com o banco ao referenciar a engine
        /// </summary>
        public BDEngine()
        {
            //abre a conexão com o sql server utilizando a string de conexão da web.config
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CredPago"].ConnectionString);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Cria objeto command contendo a string a ser executada
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlCommand ObterCommand(String sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            return cmd;
        }
        /// <summary>
        /// Executa um comando sem retorno
        /// </summary>
        /// <param name="sql"></param>
        public void ExecuteNonQuery(String sql)
        {
            SqlCommand cmd = ObterCommand(sql);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// Retorna uma coleção de dados
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public SqlDataReader ObterReader(String sql)
        {
            SqlCommand cmd = ObterCommand(sql);
            return cmd.ExecuteReader();
        }
        /// <summary>
        /// Retorna um único campo
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteScalar(String sql)
        {
            SqlCommand cmd = ObterCommand(sql);
            return cmd.ExecuteScalar();
        }

        /// <summary>
        /// Fecha a conexão com o banco no dispose da instância da engine
        /// </summary>
        /// <param name="disposing"></param>
        public void Dispose(bool disposing)
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }
    }
}
