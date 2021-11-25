using System;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;

namespace shop.Models
{
    public class DbConnection : IDisposable
    {
        public MySqlConnection Connection { get; }

        public static DbConnection Current { get; set; }

        public DbConnection(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
            this.Connection.Open();
        }


        public DataTable GetAllProducts()
        {
            string query = "SELECT * FROM product;";

            DataTable t = new DataTable();

            MySqlDataAdapter x = new MySqlDataAdapter(query, this.Connection);
            x.Fill(t);

            return t;
        }

        public DataTable GetProduct(int id)
        {

            MySqlCommand cmd = this.Connection.CreateCommand();

            cmd.CommandText = "SELECT * FROM product WHERE id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            DataTable t = new DataTable();

            MySqlDataAdapter x = new MySqlDataAdapter(cmd);
            x.Fill(t);

            return t;
        }

        public void SaveProduct(ProductModel product)
        {
            MySqlCommand cmd = this.Connection.CreateCommand();
            cmd.CommandText = $"INSERT INTO product (name, PriceInPence, sku, qty) VALUES (@Name, @PriceInPence, @SKU, @qty);";
            
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@PriceInPence", product.PriceInPence);
            cmd.Parameters.AddWithValue("@SKU", product.SKU);
            cmd.Parameters.AddWithValue("@qty", product.Qty);
            
            cmd.ExecuteNonQuery();

        }

        public void DeleteProduct(int id)
        {
            MySqlCommand cmd = this.Connection.CreateCommand();
            cmd.CommandText = $"DELETE FROM product WHERE id = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public void UpdateProduct(ProductModel product)
        {
            MySqlCommand cmd = this.Connection.CreateCommand();
            cmd.CommandText = $"UPDATE product SET name = @Name, PriceInPence = @PriceInPence, sku = @SKU, qty = @qty WHERE id = @id;";
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@PriceInPence", product.PriceInPence);
            cmd.Parameters.AddWithValue("@SKU", product.SKU);
            cmd.Parameters.AddWithValue("@qty", product.Qty);
            cmd.Parameters.AddWithValue("@id", product.Id);
            cmd.ExecuteNonQuery();
        }

        public void Dispose() => Connection.Dispose();

    }
}

