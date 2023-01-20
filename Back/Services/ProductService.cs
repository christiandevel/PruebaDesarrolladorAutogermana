using webapi.Models;
namespace webapi.Services;

public class ProductsService: IProductsService {
	
	ProductsContext context;
	
	public ProductsService(ProductsContext dbcontext){
		context = dbcontext;
	}
	
	public IEnumerable<Product> Get(){
		return context.Products;
	}
	
	public async Task Save(Product product){
		context.Add(product);
		await context.SaveChangesAsync();
	}
	
	public async Task  Update(Guid id, Product product){
		 
		 var productActual = context.Products.Find(id);
		 
		 if(productActual != null) {
			productActual.codigo = product.codigo;
			productActual.nombre = product.nombre;
			productActual.precio_venta = product.precio_venta;
			productActual.stock = product.stock ;
			productActual.descripcion = product.descripcion ;
			productActual.imagen = product.imagen;
			productActual.estado = product.estado;
		 await context.SaveChangesAsync();
		 }
		 
	}
	
	public async Task Delete(Guid id){
		var productActual = context.Products.Find(id);
		
		 if(productActual != null) {
			context.Remove(productActual);
			await context.SaveChangesAsync();
		 }
	}
}

public interface IProductsService {
	IEnumerable<Product> Get();
	Task Save(Product product);
	
	Task Update(Guid id, Product product);
	
	Task Delete(Guid id);
}