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

        // Data.ProductId++;

        // fix the number issue if start from 0
        int no = Data.Products.Max(p => p.Id);
        Data.ProductId = no + 1;

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

    public void UpdateProducts()
    {
    BeforeQuantity:
        Console.Write("Enter Product code to update: ");
        string productCode = Console.ReadLine()!;

        var product = Data.Products.FirstOrDefault(p => p.Code == productCode);

        if (product is null)
        {
            Console.WriteLine("Product not found!");
            goto BeforeQuantity;
        }

        Console.Write("Product found: " + product.Name + "\n");
        Console.Write($"Code: ({product.Code}):, Name: ({product.Name}): , Quantity: ({product.Quantity}): ");

    BeforeInputQuantity:
        string quantityInput = Console.ReadLine()!;
        int quantity = 0;
        if (!int.TryParse(quantityInput, out quantity) || quantity < 0)
        {
            Console.Write("Invalid quantity. Please enter a valid non-negative integer.");
            goto BeforeInputQuantity;
        }

        product.Quantity -= quantity;

        Console.Write("Product updated successfully!");
    }

    public void DeleteProduct()
    {
    BeforeCode:
        Console.Write("Enter Product code to delete: ");
        string productCode = Console.ReadLine()!;

        var product = Data.Products.FirstOrDefault(p => p.Code == productCode);

        if (product is null)
        {
            Console.WriteLine("Product not found!");
            goto BeforeCode;
        }

        Console.Write("Product found: " + product.Name + "\n");
        Console.Write("Are you sure to delete this product? (y/n): ");
        string confirm = Console.ReadLine()!;
        if (confirm.ToLower() != "y")
        {
            Console.Write("Delete operation cancelled.");
            return;
        }

        Data.Products.Remove(product);

        Console.Write("Product deleted successfully!");
    }
}