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

        loan.BorrowedBook.IsAvailable = true;
        loan.Status = LoanStatus.Returned;

        Console.WriteLine("Book returned successfully.");
    }

    public void ViewAllLoans()
    {
        RefreshLoanStatues();
        var loans = _loanRepository.GetAllLoans();
        helper.PrintLoans(loans);
    }

    public void RefreshLoanStatues()
    {
        var allLoans = _loanRepository.GetAllLoans();
        bool StatusChanged = false;

        foreach (var loan in allLoans)
        {
            if (loan.Status == LoanStatus.Active && loan.DueDate < DateTime.Now)
            {
                loan.Status = LoanStatus.Overdue;
                StatusChanged = true;
            }
        }

        if (StatusChanged)
        {
            _loanRepository.SaveLoanToJson();
        }
    }

    public void ProcessLateFees(decimal dailyLateFeeRate = 0.25m)
    {
        
        double loanLateFee = 0;
        double totalLateFee = 0;

        RefreshLoanStatues();

        var overdueLoans = _loanRepository.GetAllLoans().Where(l => l.Status == LoanStatus.Overdue).ToList();
        foreach (var loan in overdueLoans)
        {
            var daysLate = (DateTime.Now - loan.DueDate).Days;
            if (daysLate > 0)
            {
                var fee = daysLate * dailyLateFeeRate;
                Console.WriteLine($"Loan for {loan.BorrowedBook.Title} per {loan.Borrower.Name} | Days Late: {daysLate} | Fee: ${fee:C}");
            }
            totalLateFee += loanLateFee;
        }
        Console.WriteLine($" Total Late Fee: {totalLateFee}");
    }
}
