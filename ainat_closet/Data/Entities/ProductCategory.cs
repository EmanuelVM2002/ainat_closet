namespace ainat_closet.Data.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }

}
