namespace LibraryManagement;

public class LoanRepository
{
    private List<Loan> _loans;

    DataManager dataManager = new DataManager();

    public LoanRepository()
    {
        _loans = new List<Loan>();
    }

    public List<Loan> GetAllLoans() => _loans;

    public Loan GetLoan(string isbn, int patronID)
    {
        return _loans.FirstOrDefault(loan => loan.BookISBN == isbn && loan.PatronId == patronID)!;
    }

    public void AddLoan(Loan loan) => _loans.Add(loan);

    public void SaveLoanToJson() => dataManager.SaveLoanToJsonFile(_loans);
}