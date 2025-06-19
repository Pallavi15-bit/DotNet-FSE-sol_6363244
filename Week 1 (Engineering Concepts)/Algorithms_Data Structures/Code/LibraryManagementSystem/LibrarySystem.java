import java.util.Arrays;

public class LibrarySystem {
    static class Book {
        int bookId;
        String title;
        String author;

        public Book(int bookId, String title, String author) {
            this.bookId = bookId;
            this.title = title;
            this.author = author;
        }

        public String toString() {
            return bookId + " | " + title + " | " + author;
        }
    }

    static class BookSearch {
        public Book linearSearch(Book[] books, String title) {
            for (Book book : books) {
                if (book.title.equalsIgnoreCase(title)) {
                    return book;
                }
            }
            return null;
        }

        public Book binarySearch(Book[] books, String title) {
            int low = 0, high = books.length - 1;
            while (low <= high) {
                int mid = (low + high) / 2;
                int compare = books[mid].title.compareToIgnoreCase(title);
                if (compare == 0) return books[mid];
                else if (compare < 0) low = mid + 1;
                else high = mid - 1;
            }
            return null;
        }

        public Book[] sortByTitle(Book[] books) {
            Arrays.sort(books, (b1, b2) -> b1.title.compareToIgnoreCase(b2.title));
            return books;
        }
    }

    public static void main(String[] args) {
        Book[] books = {
            new Book(1, "Harry Potter I", "J.K Rowling"),
            new Book(2, "The Days I Loved You", "Ruskin Bond"),
            new Book(3, "It Ends With Us", "Colleen Hoover")
        };

        BookSearch search = new BookSearch();

        System.out.println("Linear Search for 'Harry Potter I':");
        Book result1 = search.linearSearch(books, "Harry Potter I");
        System.out.println(result1);

        Book[] sortedBooks = search.sortByTitle(books);
        System.out.println("\nBinary Search for 'It Ends With Us':");
        Book result2 = search.binarySearch(sortedBooks, "It Ends With Us");
        System.out.println(result2);
    }
}
