using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities.Models
{
    public class OrderInformation
    {
        [Key]
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public decimal TotalOrder { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }

        public OrderInformation(string name, string email, string address, string postalCode, string city)
        {
            Name = name; Email = email; Address = address; PostalCode = postalCode; City = city; CreatedDate = DateTime.Now;
        }
    }
}
