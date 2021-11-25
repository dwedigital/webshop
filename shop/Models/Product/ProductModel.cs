using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace shop.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 100)]
        [Display(Name = "Quantity")]
        public int Qty { get; set; }

        [Required]
        [Range(0,100000)]
        [Display(Name = "Price (in pence)")]
        public int PriceInPence { get; set; }

        public decimal Price => Convert.ToDecimal(PriceInPence)/100m;
        [Required]
        [StringLength(8)]
        public string SKU { get; set; }

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
                    SKU = Convert.ToString(r["sku"]),
                    Qty = Convert.ToInt32(r["qty"])
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
            product.SKU = Convert.ToString(data.Rows[0]["sku"]);

            return product;
        }

        public static void Save(ProductModel product){
            DbConnection.Current.SaveProduct(product);
        }

        public static void Update(ProductModel product)
        {
            DbConnection.Current.UpdateProduct(product);
        }

        public static void Delete(int id)
        {
            DbConnection.Current.DeleteProduct(id);
        }
    }
}