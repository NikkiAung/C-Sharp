BeforeSystem:
Console.WriteLine("Inventory Management System");
InventoryService inventoryService = new InventoryService();
inventoryService.CreateProduct();

goto BeforeSystem;