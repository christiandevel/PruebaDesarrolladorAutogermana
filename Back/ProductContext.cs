using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi;

public class ProductsContext: DbContext {
	
	public DbSet<Category> Categories {get;set;}
	public DbSet<Product> Products {get;set;}
	
	public ProductsContext(DbContextOptions<ProductsContext> options) :base(options){ } 
	
	protected override void OnModelCreating(ModelBuilder modelBuilder){
		
		List<Category> categoriesInit = new List<Category>();
		categoriesInit.Add(new Category(){ idcategoria= Guid.Parse("222a5ea0-ebd8-4ce6-8252-3b509bd2ef89"), nombre = "Aseo Personal", descripcion = "Productos de Aseo Personal", estado = 1 });
		categoriesInit.Add(new Category(){ idcategoria= Guid.Parse("d6c637e7-af34-48a2-a99b-98cda497949c"), nombre = "Canasta Familiar", descripcion = "Productos de Canasta Familiar", estado = 1 });
		
		modelBuilder.Entity<Category>(category => {
			category.ToTable("categoria");
			category.HasKey(p => p.idcategoria);
			category.Property(p=> p.nombre);
			category.Property(p=> p.descripcion);
			category.Property(p=> p.estado);
			
			category.HasData(categoriesInit);
			
		});
		
		List<Product> productsInit = new List<Product>();
		productsInit.Add(new Product(){ idproducto= Guid.Parse("0b2abbc2-07d1-42fc-aa70-72028c800d20"), idcategoria= Guid.Parse("d6c637e7-af34-48a2-a99b-98cda497949c"), codigo="AAA01", nombre="Desodorante", precio_venta= 10.000f, stock= 3, descripcion="Desodorante Rexona", imagen="https://imagendesodorante", estado=1});
		
		modelBuilder.Entity<Product>(product => {
			product.ToTable("producto");
			product.HasKey(p => p.idproducto);
			
			product.HasOne(p=> p.Category).WithMany(p=> p.Products).HasForeignKey(p => p.idcategoria);
			product.Property(p=> p.codigo);
			product.Property(p=> p.nombre);
			product.Property(p=> p.precio_venta);
			product.Property(p=> p.stock);
			product.Property(p=> p.descripcion);
			product.Property(p=> p.imagen);
			product.Property(p=> p.estado);
			
			product.HasData(productsInit);
			
		});
	}
}