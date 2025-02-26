using WebApi.Entities.Models;

namespace RestaurantWebAPI.Helpers
{
    public class EmailHelper
    {

        public static string BuildBody(OrderInformation orderInformation)
        {
            decimal orderTotal = 0;
            string orderDetailsTable = "<table border='1' cellpadding='5' cellspacing='0'>";
            orderDetailsTable += "<tr><th>Product Name</th><th>Quantity</th><th>Price</th><th>Total</th></tr>";

            foreach (var detail in orderInformation.OrderDetails)
            {
                orderDetailsTable += $"<tr>" +
                                     $"<td>{detail.MealName}</td>" +
                                     $"<td>{detail.Quantity}</td>" +
                                     $"<td>{detail.Price:C}</td>" +
                                     $"<td>{detail.TotalPrice:C}</td>" +
                                     $"</tr>";
                orderTotal += detail.TotalPrice;
            }

            orderDetailsTable += "</table>";

            return $@"<html>
            <body>
                <h3>Dear {orderInformation.Name},</h3>
                <h4>Order Detail:</h4>
                {orderDetailsTable}
                <h4>Total to pay: {orderTotal:C}</h4>
                <br>
                <p>Your order will be sent to: {orderInformation.Address}</p>
                <br>
                <h4>Thank you for your purchase!</h4>
            </body>
        </html>";
        }
    }
}
