import java.util.HashMap;

public class Inventory {
    private HashMap<Integer, Product> products;

    public Inventory() {
        products = new HashMap<>();
    }

    public void addProduct(Product product) {
        products.put(product.productId, product);
        System.out.println("Product added.");
    }

    public void updateProduct(int productId, int quantity, double price) {
        Product p = products.get(productId);
        if (p != null) {
            p.quantity = quantity;
            p.price = price;
            System.out.println("Product updated.");
        } else {
            System.out.println("Product not found.");
        }
    }

    public void deleteProduct(int productId) {
        if (products.remove(productId) != null) {
            System.out.println("Product removed.");
        } else {
            System.out.println("Product not found.");
        }
    }

    public void displayInventory() {
        for (Product p : products.values()) {
            System.out.println(p);
        }
    }
}
