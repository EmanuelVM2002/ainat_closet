using System.ComponentModel.DataAnnotations;

namespace ainat_closet.Data.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        public Product Product { get; set; }

        [Display(Name = "Foto")]
        public Guid ImageId { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:7199/images/Logo.jpeg"
            : $"https://ainatcloset.blob.core.windows.net/products/{ImageId}";
    }

}
