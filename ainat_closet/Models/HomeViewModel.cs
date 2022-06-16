using ainat_closet.Data.Entities;

namespace ainat_closet.Models
{
    public class HomeViewModel
    {
        public ICollection<Product> Products { get; set; }

        public float Quantity { get; set; }
    }

}
