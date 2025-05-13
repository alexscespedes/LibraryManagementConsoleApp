namespace LibraryManagement;

public class BookService {
    private List<Book> books = new List<Book>();
    ConsoleHelper helper = new ConsoleHelper(); 

    public bool AddBook(Book book) 
    {
        if (!helper.IsValidISBNCode(book.ISBN))
        {
            Console.WriteLine("The ISBN is not valid");
            return false;
        }
        
        if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author))
        {
            Console.WriteLine("Error: Title and Author are required.");
            return false;
        }
        
        books.Add(book);
        Console.WriteLine($"Book '{book.Title}' by {book.Author} added successfully.");
        return true;
    }

    public void ViewAllBooks() 
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books found");
        }

        foreach (var book in books)
        {
            helper.PrintBook(book);
        }
    }

    public bool RemoveBook(string isbn) 
    {
        var book = books.SingleOrDefault(b => b.ISBN == isbn);

        if (book != null)
        {
            books.Remove(book);
            Console.WriteLine("Book removed successfully");
            return true;
        }
        Console.WriteLine($"No book found with ISBN: {isbn}");
        return false;
    }
}
