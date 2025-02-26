namespace WebApi.Entities.Models
{
    public class Meal
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public Meal(string id,  string name, string price, string description, string image) {
            Id = id; Name = name; Price = price; Description = description; Image = image;
        }
    }
}
