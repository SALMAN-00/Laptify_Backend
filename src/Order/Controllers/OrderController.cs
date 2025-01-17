using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{

    public class OrderController : ControllerTemplate
    {

        private IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderReadDto>> FindAll()
        {
            return Ok(_orderService.FindAll());
        }

        [HttpGet("{id}")]
        public ActionResult<OrderReadDto?> FindOne([FromRoute] Guid id)
        {
            return Ok(_orderService.FindOne(id));
        }

        [Authorize(Roles = "Admin,User")]
        [HttpPost("checkout")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<OrderReadDto> Checkout([FromBody] CheckoutDto checkoutList)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (checkoutList is null) return BadRequest();
            return CreatedAtAction(nameof(Checkout), _orderService.Checkout(checkoutList, userId!));
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<OrderReadDto> UpdateOne(Guid id, [FromBody] Order order)
        {
            OrderReadDto? updatedOrder = _orderService.UpdateOne(id, order);
            if (updatedOrder is null) return BadRequest();
            return CreatedAtAction(nameof(UpdateOne), updatedOrder);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteOne([FromRoute] Guid id)
        {
            bool isDeleted = _orderService.DeleteOne(id);
            if (!isDeleted) return NotFound();
            return NoContent();

        }
    }
}
