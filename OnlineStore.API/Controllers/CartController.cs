using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.Models;
using OnlineStore.Business.Abstract;
using System;
using System.Linq;

namespace OnlineStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;


        public CartController(ICartService cartService, ICartItemService cartItemService)
        {
            _cartService = cartService;
            _cartItemService = cartItemService;
        }

        [HttpGet("{userId}")]
        public IActionResult GetCartByUserId(Guid userId)
        {
            var cart = _cartService.GetCartByUserId(userId);
            return Ok(cart);
        }

        [HttpPost("add")]
        public IActionResult AddItemToCart([FromBody] AddItemToCartDto addItemDto)
        {
            _cartService.AddToCart(addItemDto.UserId, addItemDto.ProductId, addItemDto.Count);
            return Ok(new { status = "success" });
        }

        [HttpDelete("{cartId}/{productId}")]
        public IActionResult RemoveItemFromCart(Guid cartId, int productId)
        {
            _cartItemService.RemoveCartItem(cartId, productId);
            return Ok();
        }

        [HttpDelete("{cartId}")]
        public IActionResult RemoveCart(Guid cartId)
        {
            _cartService.RemoveCart(cartId);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateCart([FromBody] UpdateCartDto updateCartDto)
        {
            _cartService.UpdateCart(updateCartDto.UserId, updateCartDto.ProductId, updateCartDto.Quantity);
            return Ok(new { status = "Update successful" }); // Returns a status message in JSON format
        }

        // CartController.cs
        [HttpGet("cartItems/{cartId}")]
        public IActionResult GetCartItems(Guid cartId)
        {
            var cartItems = _cartItemService.GetCartItemsByCartId(cartId);

            if (cartItems == null || !cartItems.Any())
            {
                return NotFound("Cart items not found");
            }

            return Ok(new { message = "Successfully fetched cart items", cartItems = cartItems });
        }

    }

}
