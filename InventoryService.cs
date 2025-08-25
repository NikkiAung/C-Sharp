internal class InventoryService
{
    public void CreateProduct()
    {
        Console.Write("Input Product Name: ");
        string productName = Console.ReadLine()!;

    BeforePrice:
        Console.Write("Input Product Price: ");
        string priceInput = Console.ReadLine()!;
        decimal price = 0;
        if (!decimal.TryParse(priceInput, out price) || price < 0)
        {
            Console.Write("Invalid price. Please enter a valid non-negative number.");
            goto BeforePrice;
        }

    BeforeQuantity:
        Console.Write("Input Product Quantity: ");
        string quantityInput = Console.ReadLine()!;
        int quantity = 0;
        if (!int.TryParse(quantityInput, out quantity) || quantity < 0)
        {
            Console.Write("Invalid quantity. Please enter a valid non-negative integer.");
            goto BeforeQuantity;
        }

        Data.ProductId++;

        string productCode = "P" + Data.ProductId.ToString().PadLeft(3, '0');

        Product product = new Product(Data.ProductId, productCode, productName, price, quantity, "Fruit");

        Data.Products.Add(product);

        Console.Write("Product added successfully!");
    } 

    public void ViewProducts()
    {
        Console.WriteLine("Product List:");
        Console.WriteLine("ID\tCode\tName\tPrice\tQuantity\tCategory");
        foreach (var product in Data.Products)
        {
            Console.WriteLine($"{product.Id}\t{product.Code}\t{product.Name}\t{product.Price}\t{product.Quantity}\t{product.Category}");
        }
    }
}