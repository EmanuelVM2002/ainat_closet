using ainat_closet.Common;
using ainat_closet.Data.Entities;

namespace ainat_closet.Models
{
    public class HomeViewModel
    {
        public PaginatedList<Product> Products { get; set; }
        public ICollection<Category> Categories { get; set; }

        public float Quantity { get; set; }
    }

}
