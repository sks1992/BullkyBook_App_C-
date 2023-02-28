using System.ComponentModel.DataAnnotations;


namespace BullkyBook.Models
{
    public class ShoppingCart
    {
        public Product Product { get; set; }
        [Range(1, 1000, ErrorMessage = "Please Enter a value between 1 to 100")]
        public int Count { get; set; }
    }
}
