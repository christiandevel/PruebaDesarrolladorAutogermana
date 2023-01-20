using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[Route("api/[controller]")]
public class ProductController: ControllerBase
{
	IProductsService productService;
	
	public ProductController(IProductsService service)
	{
		productService = service;
	}
	
	[HttpGet]
	public IActionResult Get(){
		return Ok(productService.Get());
	}
	
	[HttpPost]
	public IActionResult Post([FromBody] Product product){
		productService.Save(product);
		return Ok();
	}
	
	[HttpPut("{id}")]
	public IActionResult Put(Guid id, [FromBody] Product product){
		productService.Update(id, product);
		return Ok();
	}
	
	[HttpDelete("{id}")]
	public IActionResult Delete(Guid id){
		productService.Delete(id);
		return Ok();
	}
}