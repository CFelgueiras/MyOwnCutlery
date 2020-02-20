namespace MDProducaoAPI.Models.DTO
{
    public class ProductDTO
    {
        public long productId { get; set; }
        public string Name { get; set; }

        public long ManPlanId { get; set; }

        public ProductDTO() { }
    }
}