namespace shop.Models{
    using System.Collections.Generic;
    public class ProductsViewModel{
        public ProductsViewModel() {
            Products = new List<ProductModel>();
        }

        public List<ProductModel> Products { get; set; }
    }
}