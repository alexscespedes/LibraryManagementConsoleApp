namespace LibraryManagement;

public class BookRepository
{
    private List<Book> _books;

    public BookRepository()
    {
        _books = new List<Book>();
    }

    public List<Book> GetAllBooks() => _books;
    public Book GetBookByISBN(string isbn) => _books.FirstOrDefault(b => b.ISBN == isbn)!;
    public void AddBook(Book book) => _books.Add(book);
    public bool RemoveBook(string isbn) => _books.RemoveAll(b => b.ISBN == isbn) > 0;

    public bool UpdateBook(Book newBook)
    {
        var book = _books.SingleOrDefault(b => b.ISBN == newBook.ISBN);

        if (book != null) 
        {
            book.Title = newBook.Title;
            book.Author = newBook.Author;
            book.GenreBook = newBook.GenreBook;

            Console.WriteLine("Book updated successfully.");
            return true;
        }
            Console.WriteLine($"No book found with ISBN: {newBook.ISBN}");
            return false;
    }
}