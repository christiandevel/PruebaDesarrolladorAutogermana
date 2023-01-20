using Microsoft.AspNetCore.Mvc;
namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealtController: ControllerBase {
	
	ProductsContext context;
	
	public HealtController(ProductsContext db){
		context = db;
	}
	
	[HttpGet]
	[Route("createdb")]
	public IActionResult CreateDatabase(){
		context.Database.EnsureCreated();
		return Ok();
	}
}