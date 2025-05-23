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
        helper.PrintPatron(patrons);
    }

    public void ViewActiveLoans(int patronID)
    {
        var patron = _patronRepository.GetPatronById(patronID);

        if (patron != null)
        {
            helper.PrintLoans(patron.ActiveLoans);
        }
    }
    
}
