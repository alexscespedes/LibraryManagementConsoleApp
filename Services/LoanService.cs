using System.Data.Common;

namespace LibraryManagement;

public class LoanService
{
    // BookService bookService = new BookService();
    private BookRepository _bookRepository;
    private PatronRepository _patronRepository;

    public LoanService(BookRepository bookRepository, PatronRepository patronRepository)
    {
        _bookRepository = bookRepository;
        _patronRepository = patronRepository;
    }

    public void CheckoutBook(string isbn, int patronID, int loanDurationDays = 14)
    {
        var book = _bookRepository.GetBookByISBN(isbn);
        var patron = _patronRepository.GetPatronById(patronID);

        if (book == null || patron == null)
        {
            Console.WriteLine("Book and Patron were not found.");
            return;
        }
        else if (!book.IsAvailable)
        {
            Console.WriteLine("The book is not available");
        }
        book.IsAvailable = false;
        DateTime today = DateTime.Now;

        // Create a loan object
        var loanedBook = new Loan
        {
            BookISBN = isbn,
            PatronId = patronID,
            BorrowedBook = book,
            Borrower = patron,
            CheckoutDate = today,
            DueDate = today.AddDays(loanDurationDays),
            Status = LoanStatus.Active
        };
        patron.ActiveLoans.Add(loanedBook);
        Console.WriteLine("Checkout made successfully.");
    }

    public bool ReturnBook(int id)
    {
        return true;
    }
    

}
