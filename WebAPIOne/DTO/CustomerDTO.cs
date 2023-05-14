using System.ComponentModel.DataAnnotations;

namespace WebAPIOne.DTO
{
    public class CustomerDTO
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Mobile  { get; set; }
        public string Email { get; set; }
    }
}
