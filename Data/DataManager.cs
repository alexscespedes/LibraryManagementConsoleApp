namespace LibraryManagement;

public class DataManager
{
    private BookRepository _bookRepository;
    private PatronRepository _patronRepository;
    private LoanRepository _loanRepository;

    public DataManager(BookRepository bookRepository, PatronRepository patronRepository, LoanRepository loanRepository)
    {
        _bookRepository = bookRepository;
        _patronRepository = patronRepository;
        _loanRepository = loanRepository;
    }

    public void SaveDataToJsonFile()
    {
        _bookRepository.SaveBookToJson();
        _patronRepository.SavePatronToJson();
        _loanRepository.SaveLoanToJson();
        Console.WriteLine("Data successfully saved");
        Console.ReadLine();
    }

    public void LoadDataToJsonFile()
    {
        _bookRepository.LoadBookToJson();
        _patronRepository.LoadPatronToJson();
        _loanRepository.LoadLoanToJson();
        Console.WriteLine("Data successfully loaded");
        Console.ReadLine();
    }
}
