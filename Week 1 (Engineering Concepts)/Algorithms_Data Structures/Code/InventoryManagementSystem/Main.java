public class Main {
    public static void main(String[] args) {
        Inventory inventory = new Inventory();

        Product p1 = new Product(101, "Laptop", 10, 55000);
        Product p2 = new Product(102, "Phone", 25, 25000);

        inventory.addProduct(p1);
        inventory.addProduct(p2);

        inventory.displayInventory();

        inventory.updateProduct(101, 8, 54000);
        inventory.deleteProduct(102);

        inventory.displayInventory();
    }
}
