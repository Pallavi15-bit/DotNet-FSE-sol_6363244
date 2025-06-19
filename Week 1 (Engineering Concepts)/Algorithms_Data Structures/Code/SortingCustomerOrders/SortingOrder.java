public class SortingOrder {
    static class Order {
        int orderId;
        String customerName;
        double totalPrice;

        public Order(int orderId, String customerName, double totalPrice) {
            this.orderId = orderId;
            this.customerName = customerName;
            this.totalPrice = totalPrice;
        }

        public String toString() {
            return "Order ID: " + orderId + ", Name: " + customerName + ", Total: Rs." + totalPrice;
        }
    }

    static class OrderSorter {
        public void bubbleSort(Order[] orders) {
            int n = orders.length;
            for (int i = 0; i < n - 1; i++) {
                for (int j = 0; j < n - i - 1; j++) {
                    if (orders[j].totalPrice > orders[j + 1].totalPrice) {
                        Order temp = orders[j];
                        orders[j] = orders[j + 1];
                        orders[j + 1] = temp;
                    }
                }
            }
        }

        public void quickSort(Order[] orders, int low, int high) {
            if (low < high) {
                int pi = partition(orders, low, high);
                quickSort(orders, low, pi - 1);
                quickSort(orders, pi + 1, high);
            }
        }

        private int partition(Order[] orders, int low, int high) {
            double pivot = orders[high].totalPrice;
            int i = low - 1;
            for (int j = low; j < high; j++) {
                if (orders[j].totalPrice <= pivot) {
                    i++;
                    Order temp = orders[i];
                    orders[i] = orders[j];
                    orders[j] = temp;
                }
            }
            Order temp = orders[i + 1];
            orders[i + 1] = orders[high];
            orders[high] = temp;
            return i + 1;
        }
    }

    public static void main(String[] args) {
        Order[] orders = {
            new Order(101, "Alice", 1500.0),
            new Order(102, "Bob", 3000.0),
            new Order(103, "Charlie", 2000.0)
        };

        OrderSorter sorter = new OrderSorter();

        System.out.println("Before Sorting (Bubble):");
        for (Order o : orders) System.out.println(o);

        sorter.bubbleSort(orders);
        System.out.println("\nAfter Bubble Sort (Low to High):");
        for (Order o : orders) System.out.println(o);

        Order[] quickSortOrders = {
            new Order(101, "Alice", 1500.0),
            new Order(102, "Bob", 3000.0),
            new Order(103, "Charlie", 2000.0)
        };

        sorter.quickSort(quickSortOrders, 0, quickSortOrders.length - 1);
        System.out.println("\nAfter Quick Sort (Low to High):");
        for (Order o : quickSortOrders) System.out.println(o);
    }
}
