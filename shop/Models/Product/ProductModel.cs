using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;
using System;
using System.ComponentModel.DataAnnotations;
namespace shop.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 100)]
        public int Qty { get; set; }
        [Required]
        [Range(0,100000)]
        public int PriceInPence { get; set; }

        public decimal Price => Convert.ToDecimal(PriceInPence)/100m;
        [Required]
        [StringLength(8)]
        public string Sku { get; set; }

        public static List<ProductModel> GetAll()
        {
            DataTable data = DbConnection.Current.GetAllProducts();
            List<ProductModel> products = new List<ProductModel>();

            foreach(DataRow r in data.Rows)
            {
                products.Add(new ProductModel
                {
                    Id = Convert.ToInt32(r["id"]),
                    Name = Convert.ToString(r["name"]),
                    PriceInPence = Convert.ToInt32(r["PriceInPence"]),
                    Sku = Convert.ToString(r["sku"])
                });
            }

            return products;
        }

        public static ProductModel GetById(int id)
        {
            DataTable data = DbConnection.Current.GetProduct(id);
            ProductModel product = new ProductModel();

            product.Id = Convert.ToInt32(data.Rows[0]["id"]);
            product.Name = Convert.ToString(data.Rows[0]["name"]);
            product.PriceInPence = Convert.ToInt32(data.Rows[0]["PriceInPence"]);
            product.Sku = Convert.ToString(data.Rows[0]["sku"]);

            return product;
        }

        public static void Save(ProductModel product){
            DbConnection.Current.SaveProduct(product);
        }
    }
}