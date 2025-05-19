using System.Data.Common;

namespace LibraryManagement;

public class LoanService
{
    // BookService bookService = new BookService();
    private BookRepository _bookRepository;
    private PatronRepository _patronRepository;
    private LoanRepository _loanRepository;

    ConsoleHelper helper = new ConsoleHelper();

    public LoanService(BookRepository bookRepository, PatronRepository patronRepository, LoanRepository loanRepository)
    {
        _bookRepository = bookRepository;
        _patronRepository = patronRepository;
        _loanRepository = loanRepository;
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
        _loanRepository.AddLoan(loanedBook);
        patron.ActiveLoans.Add(loanedBook);
        
        Console.WriteLine("Checkout made successfully.");
    }

    public void ReturnBook(string isbn, int patronID)
    {
        var loan = _loanRepository.GetLoan(isbn, patronID);

        if (loan == null)
        {
            Console.WriteLine("Loan was not found.");
            return;
        }

        // Calculate any late fees if applicable

        loan.BorrowedBook.IsAvailable = true;
        loan.Status = LoanStatus.Returned;
    }

    public void ViewAllLoans()
    {
        var loans = _loanRepository.GetAllLoans();
        if (loans.Count == 0)
        {
            Console.WriteLine("No loans found");
        }

        foreach (var loan in loans)
        {
            helper.PrintLoans(loan);
        }
    }
    

}
