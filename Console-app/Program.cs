BeforeSystem:
Console.WriteLine("Inventory Management System");

Console.WriteLine("Choose an option:");
Console.WriteLine("1. Create Product");
Console.WriteLine("2. View Products");
Console.WriteLine("3. Update Product");
Console.WriteLine("4. Delete Product");
Console.WriteLine("5. Exit");
Console.Write("Enter your choice (1-5): ");
string choice = Console.ReadLine()!;

InventoryService inventoryService = new InventoryService();

switch (choice)
{
    case "1":
        Console.WriteLine("Create Product");
        inventoryService.CreateProduct();
        break;
    case "2":
        Console.WriteLine("View Products");
        inventoryService.ViewProducts();
        break;
    case "3":
        Console.WriteLine("Update Product");
        inventoryService.UpdateProducts();
        break;
    case "4":
        Console.WriteLine("Delete Product");
        inventoryService.DeleteProduct();
        break;
    case "5":
        Console.WriteLine("Exiting the program. Goodbye!");
        return;
    default:
        Console.WriteLine("Invalid choice. Please select a valid option.");
        goto BeforeSystem;
}

goto BeforeSystem;