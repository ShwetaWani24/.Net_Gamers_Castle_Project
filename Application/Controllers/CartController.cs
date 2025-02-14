using Application.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class CartController : Controller
{
    private readonly IProductService _productService;

    public CartController(IProductService productService)
    {
        _productService = productService;
    }

    public Cart GetCart()
    {
        var cart = HttpContext.Session.GetString("Cart");
        if (string.IsNullOrEmpty(cart))
        {
            return new Cart();
        }
        return JsonConvert.DeserializeObject<Cart>(cart);
    }

    public void SaveCart(Cart cart)
    {
        HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
    }

    // Add Product to Cart
    public IActionResult AddToCart(int productId, int quantity)
    {
        var product = GetProductById(productId);
        if (product == null)
        {
            TempData["ErrorMessage"] = "Product not found.";
            return RedirectToAction("ViewCart");
        }

        var cart = GetCart();
        cart.AddToCart(product, quantity);
        SaveCart(cart);
        return RedirectToAction("ViewCart"); // Fixed typo
    }

    // Remove Product from Cart
    public IActionResult RemoveFromCart(int productId)
    {
        var cart = GetCart();
        cart.RemoveFromCart(productId);
        SaveCart(cart);
        return RedirectToAction("ViewCart"); // Fixed typo
    }

    // View Cart
    public IActionResult ViewCart()
    {
        var cart = GetCart();
        return View(cart);
    }

    // Buy Now Action
    public IActionResult BuyNow(int productId, int quantity)
    {
        var product = GetProductById(productId);
        if (product == null)
        {
            TempData["ErrorMessage"] = "Product not found.";
            return RedirectToAction("ViewCart");
        }

        // Redirect to the ProductController's BuyNow action
        return RedirectToAction("BuyNow", "Product", new { productId, quantity });
    }

    private Product GetProductById(int productId)
    {
        return _productService.GetProductById(productId);
    }
}