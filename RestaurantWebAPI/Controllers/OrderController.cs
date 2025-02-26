using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json;
using WebApi.Entities.Models;
using WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using RestaurantWebAPI.Dto;
using RestaurantWebAPI.Helpers;

namespace RestaurantWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrderController(IOrderServices orderServices, IEmailServices emailServices) : ControllerBase
    {
        private readonly IOrderServices _orderServices = orderServices;
        private readonly IEmailServices _emailServices = emailServices;

        [HttpPost]
        public async Task<IActionResult> Post(OrderDto order)
        {
            if (order == null)
                return BadRequest(order);

            List<OrderDetail> orderDetail = [];

            foreach (var item in order.Items)
            {
                OrderDetail detail = new(item.Id, item.Quantity, item.Price, item.Name, item.Description);
                orderDetail.Add(detail);
            }

            OrderInformation orderInformation = new(order.Customer.Name, order.Customer.Email, order.Customer.Street, order.Customer.PostalCode, order.Customer.City)
            {
                OrderDetails = orderDetail,
                TotalOrder = orderDetail.Sum(d => d.TotalPrice)
            };

            await _orderServices.Add(orderInformation);
            await _emailServices.SendEmailAsync("Order Confirmation", orderInformation.Email, EmailHelper.BuildBody(orderInformation));

            return Created("", new { message = "Order created!" });
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            OrderInformation order = await _orderServices.FindById(id);

            if (order == null)
                return BadRequest(order);

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                WriteIndented = true
            };

            // Serialize the object manually with custom options
            var json = JsonSerializer.Serialize(order, options);

            // Return the JSON string
            return new ContentResult
            {
                Content = json,
                ContentType = "application/json",
                StatusCode = 200
            };

        }

    }
}
