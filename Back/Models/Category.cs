using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace webapi.Models;

public class Category{
	public Guid idcategoria {get;set;}
	public string? nombre {get;set;}
	public string? descripcion {get;set;}
	public int estado {get;set;}
	
	[JsonIgnore]
	public virtual ICollection<Product>? Products {get;set;}
}