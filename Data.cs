internal static class Data
{   
    public static int ProductId = 2;
    public static List<Product> Products = new List<Product>()
    {
        new Product(1, "P001", "Apple", 1.5m, 100, "Fruit"),
        new Product(2, "P002", "Banana", 0.5m, 150, "Fruit"),
        // new Product(3, "P003", "Orange", 1.0m, 200, "Fruit")
    };

}