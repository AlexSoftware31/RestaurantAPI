namespace RestaurantWebAPI.Dto
{
    public class OrderDto
    {
        public List<ItemDto> Items { get; set; }
        public CustomerDto Customer { get; set; }
    }
}
