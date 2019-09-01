using Data.CredPago.DAL;
using Data.CredPago.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.CredPago.BLL
{
    public class ProductBLL
    {
        public ProductBLL()
        {

        }

        /// <summary>
        /// Insere um novo produto
        /// </summary>
        /// <param name="product"></param>
        public bool Inserir(Product product)
        {
            ProductDAL dal = new ProductDAL();

            var Exist = dal.ProdutoPorId(product.product_id);

            if (!Exist)
            {
                dal.Inserir(product);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        /// <returns></returns>
        public List<Product> Listar()
        {
            ProductDAL dal = new ProductDAL();
            return dal.Listar();
        }
    }
}
