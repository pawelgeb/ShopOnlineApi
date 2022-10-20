using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopOnlineApi.Data;
using ShopOnlineApi.ModelsSQL;

namespace ShopOnlineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ShopContext context;
        public OrderController(ShopContext shopcontext)
        {
            context = shopcontext;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> GetOrderDTO()
        {
            return await context.Orders
                .Select(x => OrderDTO(x))
                .ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetItemOrderDTO(int id)
        {
            var orderItem = await context.Orders.FindAsync(id);
            if (orderItem == null )
            {
                return NotFound();
            }
            return OrderDTO(orderItem);
        }
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> PostOrder(OrderDTO orderDTO)
        {
            var orderItem = new Order
            {
                Id = orderDTO.Id,
                ProductId = orderDTO.ProductId,
                Price = orderDTO.Price,
                OrderDate = orderDTO.OrderDate,
                UserId = orderDTO.UserId
            };

            context.Orders.Add(orderItem);
            await context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetUserDTO),
                new
                {
                    id = userItem.Id
                },
                UserDTO(userItem));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUserItem(int id)
        {
            var userItem = await context.Users.FindAsync(id);
            if (userItem == null)
            {
                return NotFound();
            }
            context.Users.Remove(userItem);
            await context.SaveChangesAsync();
            return NoContent();
        }
        private bool UserItemExist(int id)
        {
            return context.Users.Any(e => e.Id == id);
        }


        private OrderDTO OrderDTO(Order order) => new OrderDTO
        {
            Id = order.Id,
            OrderDate = order.OrderDate,
            Price = order.Price,
            ProductId = order.ProductId,
            UserId = order.UserId
        };
     }
}
