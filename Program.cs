using ProductsCrud.Services;

var service = new ProductService();

while (true)
{
  Console.WriteLine("\n1 - Create product");
  Console.WriteLine("2 - List all products");
  Console.WriteLine("3 - Update stock");
  Console.WriteLine("4 - Calculate total stock value");
  Console.WriteLine("5 - Delete product");
  Console.WriteLine("6 - Exit");

  Console.Write("\nChoose: ");

  var op = Console.ReadLine();


  switch (op)
  {
      case "1":
          Console.Write("Nome: ");
          var nome = Console.ReadLine();

          Console.Write("Preço: ");
          var preco = decimal.Parse(Console.ReadLine());

          Console.Write("Quantidade: ");
          var qtd = int.Parse(Console.ReadLine());

          service.Create(nome, preco, qtd);
          break;

      case "2":
          service.List();
          break;

      case "3":
          Console.Write("ID do produto: ");
          var idEstoque = int.Parse(Console.ReadLine());

          Console.Write("Nova quantidade: ");
          var novaQtd = int.Parse(Console.ReadLine());

          service.UpdateStock(idEstoque, novaQtd);
          break;

      case "4":
          service.GetTotalPrice();
          break;

      case "5":
          Console.Write("ID do produto: ");
          var idDel = int.Parse(Console.ReadLine());
          service.Delete(idDel);
          break;

      case "6":
          return;

      default:
          Console.WriteLine("Opção inválida!");
          break;
  }
}