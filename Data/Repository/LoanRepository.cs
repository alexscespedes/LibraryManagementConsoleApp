namespace LibraryManagement;

public class LoanRepository
{
    private List<Loan> _loans;

    public LoanRepository()
    {
        _loans = new List<Loan>();
    }

    public List<Loan> GetAllLoans() => _loans;

    public void AddLoan(Loan loan) => _loans.Add(loan);
}