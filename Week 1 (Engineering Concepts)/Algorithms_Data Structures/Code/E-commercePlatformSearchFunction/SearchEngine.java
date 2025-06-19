import java.util.Arrays;
import java.util.Comparator;

public class SearchEngine {
    public Product linearSearch(Product[] products, String name) {
        for (Product p : products) {
            if (p.productName.equalsIgnoreCase(name)) {
                return p;
            }
        }
        return null;
    }

    public Product binarySearch(Product[] sortedProducts, String name) {
        int left = 0;
        int right = sortedProducts.length - 1;

        while (left <= right) {
            int mid = (left + right) / 2;
            int cmp = sortedProducts[mid].productName.compareToIgnoreCase(name);

            if (cmp == 0) return sortedProducts[mid];
            else if (cmp < 0) left = mid + 1;
            else right = mid - 1;
        }

        return null;
    }

    public Product[] sortByName(Product[] products) {
        Product[] sorted = Arrays.copyOf(products, products.length);
        Arrays.sort(sorted, Comparator.comparing(p -> p.productName.toLowerCase()));
        return sorted;
    }
}
