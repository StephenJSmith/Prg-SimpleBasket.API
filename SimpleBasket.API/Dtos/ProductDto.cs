using System.ComponentModel.DataAnnotations;

namespace SimpleBasket.API.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
