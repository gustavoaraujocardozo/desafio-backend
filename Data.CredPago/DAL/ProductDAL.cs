using Data.CredPago.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CredPago.DAL
{
    public class ProductDAL
    {
        /// <summary>
        /// string para uso de comandos sql
        /// </summary>
        private StringBuilder sql;

        /// <summary>
        /// Cria uma instância
        /// </summary>
        public ProductDAL()
        {
            sql = new StringBuilder();
        }
        /// <summary>
        /// Insere um novo produto
        /// </summary>
        /// <param name="product"></param>
        public void Inserir(Product product)
        {
            using (var bd = new BDEngine())
            {
                sql.Clear();
                sql.Append(@"
                    INSERT INTO Product(product_id, artist, year, album, price, store, thumb, date)
                         VALUES('{0}', '{1}', {2}, '{3}', {4}, '{5}', '{6}', '{7}')
                ");

                bd.ExecuteNonQuery(string.Format(sql.ToString(),
                    product.product_id,
                    product.artist,
                    product.year,
                    product.album,
                    product.price,
                    product.store,
                    product.thumb,
                    product.date));
            }
        }
        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        /// <returns></returns>
        public List<Product> Listar()
        {
            List<Product> lista = new List<Product>();

            using (var bd = new BDEngine())
            {
                sql.Clear();
                sql.Append(@"
                    SELECT  product_id, artist, year, album, price, store, thumb, date
                    FROM Product
                    ORDER BY album DESC
                ");

                var dr = bd.ObterReader(sql.ToString());

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Product product = new Product();

                        product.product_id = dr["product_id"].ToString();
                        product.artist = dr["artist"].ToString();
                        product.year = Convert.ToInt32(dr["year"]);
                        product.album = dr["album"].ToString();
                        product.price = Convert.ToInt32(dr["price"]);
                        product.store = dr["store"].ToString();
                        product.thumb = dr["thumb"].ToString();
                        product.date = dr["date"].ToString();

                        lista.Add(product);
                    }
                }
            }

            return lista;
        }

        /// <summary>
        /// Retorna um produto por id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public bool ProdutoPorId(String productId)
        {

            using (var bd = new BDEngine())
            {
                sql.Clear();
                sql.Append(@"
                    SELECT  product_id
                    FROM Product
                    WHERE product_id = '{0}'
                ");

                var obj = bd.ExecuteScalar(string.Format(sql.ToString(), productId));

                if (obj != null)
                    return true;

            }

            return false;
        }
    }
}
