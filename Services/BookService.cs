namespace LibraryManagement;

public class BookService
{
    private BookRepository _bookRepository;
    ConsoleHelper helper = new ConsoleHelper();

    public BookService(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public void AddBook(Book book)
    {
        if (!helper.IsValidISBNCode(book.ISBN))
        {
            Console.WriteLine("The ISBN is not valid");
        }

        if (string.IsNullOrEmpty(book.Title) || string.IsNullOrEmpty(book.Author))
        {
            Console.WriteLine("Error: Title and Author are required.");
        }

        _bookRepository.AddBook(book);
        Console.WriteLine($"Book '{book.Title}' by {book.Author} added successfully.");
    }

    public void ViewAllBooks()
    {
        var books = _bookRepository.GetAllBooks();
        if (books.Count == 0)
        {
            Console.WriteLine("No books found");
        }

        foreach (var book in books)
        {
            helper.PrintBook(book);
        }
    }

    public void RemoveBook(string isbn)
    {
        var success = _bookRepository.RemoveBook(isbn);

        if (success)
        {
            Console.WriteLine("Book removed successfully");
        }
        else
        {
            Console.WriteLine($"No book found with ISBN: {isbn}");
        }
    }

    public void UpdateBook(Book newBook)
    {
        if (!helper.IsValidISBNCode(newBook.ISBN))
        {
            Console.WriteLine("The ISBN is not valid");

        }

        if (string.IsNullOrEmpty(newBook.Title) || string.IsNullOrEmpty(newBook.Author))
        {
            Console.WriteLine("Error: Title and Author are required.");

        }

        var success = _bookRepository.UpdateBook(newBook);

        if (success)
        {
            Console.WriteLine("Book updated successfully.");
        }

        else
        {
            Console.WriteLine($"No book found with ISBN: {newBook.ISBN}");
        }
    }

    public void SearchBookByTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            
        }
    }

}
