public class Main {
    public static void main(String[] args) {
        Product[] products = {
            new Product(1, "Laptop", "Electronics"),
            new Product(2, "Shoes", "Footwear"),
            new Product(3, "Phone", "Electronics"),
            new Product(4, "T-shirt", "Clothing")
        };

        SearchEngine search = new SearchEngine();

        Product result1 = search.linearSearch(products, "Phone");
        System.out.println("Linear Search Result: " + (result1 != null ? result1 : "Not Found"));

        Product[] sortedProducts = search.sortByName(products);
        Product result2 = search.binarySearch(sortedProducts, "Phone");
        System.out.println("Binary Search Result: " + (result2 != null ? result2 : "Not Found"));
    }
}
