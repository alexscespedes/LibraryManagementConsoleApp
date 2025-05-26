namespace LibraryManagement;

public class ReportService
{
    private PatronRepository _patronRepository;
    private LoanRepository _loanRepository;

    ConsoleHelper helper = new ConsoleHelper();

    public ReportService(PatronRepository patronRepository, LoanRepository loanRepository)
    {
        _patronRepository = patronRepository;
        _loanRepository = loanRepository;
    }

    public void OverdueBooksReport()
    {
        var overDueLoans = _loanRepository.GetAllLoans().Where(l => l.Status == LoanStatus.Overdue).ToList();

        Console.WriteLine($"Overdue Books Report");
        helper.PrintLoans(overDueLoans);
    }

    public void PatronActivityReport()
    {
        var patronSortedByLoans = _patronRepository.GetAllPatrons().OrderBy(p => p.ActiveLoans.Count);

        Console.WriteLine($"Patron Activity Report");
        foreach (var patron in patronSortedByLoans)
        {
            if (patron.ActiveLoans.Count == 0)
            {
                Console.WriteLine("No Patron Activity");
                return;
            }
            Console.WriteLine($"Patron {patron.Name} has {patron.ActiveLoans.Count} Books Borrowed");
        }
    }
    public void CurrentLoansReport()
    {
        var ActiveLoans = _loanRepository.GetAllLoans().Where(l => l.Status == LoanStatus.Active).ToList();

        Console.WriteLine($"Current Loans Report");
        helper.PrintLoans(ActiveLoans);
    }
}
