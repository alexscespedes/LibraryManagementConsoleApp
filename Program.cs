namespace LibraryManagement;
class Program
{
    static void Main(string[] args)
    {
        var bookRepo = new BookRepository();
        var patronRepo = new PatronRepository();
        var loanRepo = new LoanRepository();

        var bookService = new BookService(bookRepo);
        var patronService = new PatronService(patronRepo);
        var loanService = new LoanService(bookRepo, patronRepo, loanRepo);
        var reportService = new ReportService(patronRepo, loanRepo);
        DataManager dataManager = new DataManager(bookRepo, patronRepo, loanRepo);

        var menuSystem = new MenuSystem(bookService, patronService, loanService, reportService, dataManager);
        menuSystem.DisplayMainMenu();
    }
}
