using ProductsCrud.Data;
using ProductsCrud.Models;
using System.Linq;

namespace ProductsCrud.Services;

public class ProductService
{
  private readonly AppDb _db;

  public ProductService()
  {
    _db = new AppDb();
  }

  public void Create(string label, decimal price, int quantity)
  {
    var product = new Product
    {
      Label = label,
      Price = price,
      Quantity = quantity
    };

    _db.Products.Add(product);
    _db.SaveChanges();
  }

  public void List()
  {
    var products = _db.Products.ToList();

    Console.WriteLine("\n--- Products: ---");

    foreach(var p in products)
      Console.WriteLine($"{p.Id} - {p.Label} | {p.Price} | {p.Quantity}");

    Console.WriteLine("All the products were now listed above!");
  }

  public void UpdateStock(int id, int newQuantity)
  {
    var product = _db.Products.Find(id);

    if ( product == null )
    {
      Console.WriteLine("Product was not found!");
      return;
    }

    product.Quantity = newQuantity;
    _db.SaveChanges();

    Console.WriteLine($"Successfully updated the product with id '{id}'");
  }

  public void GetTotalPrice()
  {
    var total = _db.Products
      .Select(p => p.Price * p.Quantity)
      .Sum();
    
    Console.WriteLine($"\nTotal Value: ${total}");
  }

  public void Delete(int id)
  {
    var product = _db.Products.Find(id);

    if( product == null)
    {
      Console.WriteLine($"Cannot find the product with id '{id}'");
      return;
    }

    _db.Products.Remove(product);
    _db.SaveChanges();

    Console.WriteLine($"The product with id '{id}' was successfully deleted!");
  }
}