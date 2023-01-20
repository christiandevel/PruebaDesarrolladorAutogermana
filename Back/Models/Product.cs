using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace webapi.Models;


public class Product
{
	
	public Guid idproducto {get;set;}
	public Guid idcategoria {get;set;}
	public string? codigo {get;set;}
	public string? nombre {get;set;}
	public float precio_venta {get;set;}
	public int stock {get;set;}
	public string? descripcion {get;set;}
	public string? imagen {get;set;}
	public virtual Category? Category {get;set;}
	public int estado {get;set;}
	
}