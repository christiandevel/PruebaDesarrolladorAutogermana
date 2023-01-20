using webapi.Models;
namespace webapi.Services;

public class CategoryService: ICategoryService {
	
	ProductsContext context;
	
	public CategoryService(ProductsContext dbcontext){
		context = dbcontext;
	}
	
	public IEnumerable<Category> Get(){
		return context.Categories;
	}
	
	public async Task Save(Category category){
		context.Add(category);
		await context.SaveChangesAsync();
	}
	
	public async Task  Update(Guid id, Category category){
		 
		 var categoryActual = context.Categories.Find(id);
		 
		 if(categoryActual != null) {
			categoryActual.nombre = category.nombre;
			categoryActual.descripcion  = category.descripcion;
			categoryActual.estado  = category.estado;
		 }
		 
		 await context.SaveChangesAsync();
	}
	
	public async Task Delete(Guid id){
		var categoryActual = context.Categories.Find(id);
		
		 if(categoryActual != null) {
			context.Remove(categoryActual);
			await context.SaveChangesAsync();
		 }
	}
}

public interface ICategoryService {
	IEnumerable<Category> Get();
	Task Save(Category category);
	
	Task Update(Guid id, Category category);
	
	Task Delete(Guid id);
}