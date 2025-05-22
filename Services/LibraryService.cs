namespace LibraryManagement;

public class LibraryService
{
    private PatronRepository _patronRepository;
    private LoanRepository _loanRepository;

    ConsoleHelper helper = new ConsoleHelper();

    public LibraryService(PatronRepository patronRepository, LoanRepository loanRepository)
    {
        _patronRepository = patronRepository;
        _loanRepository = loanRepository;
    }

    public void OverdueBooksReport()
    {
        var overDueLoans = _loanRepository.GetAllLoans().Where(l => l.Status == LoanStatus.Overdue).ToList();

        Console.WriteLine($"Overdue Books Report");
        foreach (var loan in overDueLoans)
        {
            Console.WriteLine($"Book {loan.BorrowedBook.Title} by {loan.Borrower.Name}");
        }
    }

    public void PatronActivityReport()
    {
        var patronSortedByLoans = _patronRepository.GetAllPatrons().OrderBy(p => p.ActiveLoans.Count);

        Console.WriteLine($"Patron Activity Report");
        foreach (var patron in patronSortedByLoans)
        {
            Console.WriteLine($"Patron {patron.Name} has {patron.ActiveLoans.Count} Books Borrowed");
        }
    }
}
