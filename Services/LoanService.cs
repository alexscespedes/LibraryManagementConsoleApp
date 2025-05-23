using System.Data.Common;

namespace LibraryManagement;

public class LoanService
{
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
        DateTime today = new DateTime(2025, 05, 11);

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

        loan.BorrowedBook.IsAvailable = true;
        loan.Status = LoanStatus.Returned;

        Console.WriteLine("Book returned successfully.");
    }

    public void ViewAllLoans()
    {
        var loans = _loanRepository.GetAllLoans();
        helper.PrintLoans(loans);
    }

    public void OverdueBooks()
    {
        var loans = _loanRepository.GetAllLoans();
        foreach (var loan in loans)
        {
            if (loan.DueDate < DateTime.Now)
            {
                loan.Status = LoanStatus.Overdue;
            }

            TimeSpan interval = loan.DueDate - DateTime.Now;
            if (interval.Days <= 3)
            {
                Console.WriteLine($"Loan for {loan.BorrowedBook.Title} per {loan.Borrower.Name} about to expire!");
            }

            Console.WriteLine($"{loan.BorrowedBook.Title} with {interval.Days} days left");
        }
    }

    public void ProcessLateFees()
    {
        double dailyLateFeeRate = 0.25;
        double loanLateFee = 0;
        double totalLateFee = 0;

        var loans = _loanRepository.GetAllLoans();
        foreach (var loan in loans)
        {
            TimeSpan overDueDays = loan.DueDate - DateTime.Now;
            if (loan.Status == LoanStatus.Overdue)
            {
                loanLateFee = overDueDays.Days * dailyLateFeeRate;
                Console.WriteLine($"Loan for {loan.BorrowedBook.Title} per {loan.Borrower.Name} has a late rate of ${loanLateFee}");
            }
            totalLateFee += loanLateFee;
        }
        Console.WriteLine($" Total Late Fee: {totalLateFee}");
    }
}
