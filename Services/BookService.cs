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
        foreach (var book in books)
        {
            helper.PrintBook(book);
        }
    }
}
