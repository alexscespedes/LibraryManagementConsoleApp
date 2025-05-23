namespace LibraryManagement;

public class PatronService
{
    private PatronRepository _patronRepository;
    ConsoleHelper helper = new ConsoleHelper();

    public PatronService(PatronRepository patronRepository)
    {
        _patronRepository = patronRepository;
    }

    public void RegisterPatron(Patron patron)
    {
        if (string.IsNullOrEmpty(patron.Name))
        {
            Console.WriteLine("Error: The name is required.");

        }

        if (!helper.IsValidPhoneNumber(patron.PhoneNumber))
        {
            Console.WriteLine("The PhoneNumber is not valid");
            
        }

        if (!helper.IsValidEmail(patron.Email))
        {
            Console.WriteLine("The Email is not valid");
            
        }

        _patronRepository.AddPatron(patron);
        Console.WriteLine($"Patron '{patron.Name}' created successfully.");
    }

    public void ViewAllPatrons()
    {
        var patrons = _patronRepository.GetAllPatrons();
        if (patrons.Count == 0)
        {
            Console.WriteLine("No patrons found");
        }

        foreach (var patron in patrons)
        {
            helper.PrintPatron(patron);
        }
    }

    public void ViewActiveLoans(int patronID)
    {
        var patron = _patronRepository.GetPatronById(patronID);

        if (patron != null)
        {
            if (patron.ActiveLoans.Count == 0)
            {
                Console.WriteLine("No Active Loans");
                return;
            }
            Console.WriteLine("Borrowed Books");
            foreach (var BorrowedBook in patron.ActiveLoans)
            {
                helper.PrintLoans(BorrowedBook);
            }
        }
    }
    
}
