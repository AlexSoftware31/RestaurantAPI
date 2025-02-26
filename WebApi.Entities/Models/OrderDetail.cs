using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        public string MealId { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; } 

        //public int OrderId { get; set; }
        public OrderInformation OrderInformation { get; set; }

        public OrderDetail(string mealId, int quantity, decimal price, string mealName, string mealDescription)
        {

            MealId = mealId;
            Quantity = quantity;
            Price = price;
            MealName = mealName;
            MealDescription = mealDescription;
            TotalPrice = quantity * price;
        }
    }
}
