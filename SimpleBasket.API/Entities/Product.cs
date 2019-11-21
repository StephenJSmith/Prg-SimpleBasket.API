using System.ComponentModel.DataAnnotations;

namespace SimpleBasket.API.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "999999.99")]
        public decimal UnitPrice { get; set; }
    }
}
