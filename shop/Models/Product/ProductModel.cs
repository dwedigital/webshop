namespace shop.Models{
    public class ProductModel{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public ProductModel(){
            this.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. In auctor turpis ac elit egestas, ac iaculis elit bibendum. Donec dignissim vitae turpis in porttitor. Praesent odio nisi, ornare eget magna vitae, feugiat sodales nibh. Proin vel pellentesque augue, sed semper augue. Class aptent taciti sociosqu ad litora torquent per conubia.";
        }
    }
}