using lab11.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab11.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> Products =
    [
        new Product { Id = 1, Name = "Product A", Price = 10.5m },
        new Product { Id = 2, Name = "Product B", Price = 20.0m }
    ];

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll()
    {
        return Ok(Products);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Product> GetById(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> Create([FromBody] Product newProduct)
    {
        newProduct.Id = Products.Max(p => p.Id) + 1;
        Products.Add(newProduct);

        return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] Product updatedProduct)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();

        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();

        Products.Remove(product);
        return NoContent();
    }
}
