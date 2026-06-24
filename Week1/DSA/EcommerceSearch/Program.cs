using System;

class Product
{
    public int ProductId;
    public string ProductName;
    public string Category;

    public Product(int id, string name, string category)
    {
        ProductId = id;
        ProductName = name;
        Category = category;
    }
}

class SearchDemo
{
    static Product LinearSearch(Product[] products, string target)
    {
        foreach (Product product in products)
        {
            if (product.ProductName.Equals(target, StringComparison.OrdinalIgnoreCase))
                return product;
        }
        return null;
    }

    static Product BinarySearch(Product[] products, string target)
    {
        int left = 0;
        int right = products.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            int result = string.Compare(
                products[mid].ProductName,
                target,
                StringComparison.OrdinalIgnoreCase);

            if (result == 0)
                return products[mid];

            if (result < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return null;
    }

    static void Main()
    {
        Product[] products =
        {
            new Product(101, "Laptop", "Electronics"),
            new Product(102, "Mobile", "Electronics"),
            new Product(103, "Shoes", "Fashion"),
            new Product(104, "Watch", "Accessories")
        };

        Array.Sort(products,
            (a, b) => a.ProductName.CompareTo(b.ProductName));

        string searchItem = "Mobile";

        Product linearResult =
            LinearSearch(products, searchItem);

        Console.WriteLine("Linear Search Result:");

        if (linearResult != null)
            Console.WriteLine(linearResult.ProductName);

        Product binaryResult =
            BinarySearch(products, searchItem);

        Console.WriteLine("Binary Search Result:");

        if (binaryResult != null)
            Console.WriteLine(binaryResult.ProductName);
    }
}