namespace LibraryManagement;

public class PatronService {
    private List<Patron> patrons = new List<Patron>();
    ConsoleHelper helper = new ConsoleHelper();

    public bool RegisterPatron(Patron patron) 
    {
        if (string.IsNullOrEmpty(patron.Name))
        {
            Console.WriteLine("Error: The Name is required.");
            return false;
        }

        if (!helper.IsValidPhoneNumber(patron.PhoneNumber))
        {
            Console.WriteLine("The PhoneNumber is not valid");
            return false;
        }

        if (!helper.IsValidEmail(patron.Email))
        {
            Console.WriteLine("The PhoneNumber is not valid");
            return false;
        }

        patrons.Add(patron);
        Console.WriteLine($"Patron '{patron.Name}' created successfully.");
        return true;
    }

    public void ViewAllPatrons() 
    {
        if (patrons.Count == 0)
        {
            Console.WriteLine("No patrons found");
        }

        foreach (var patron in patrons)
        {
            helper.PrintPatron(patron);
        }
    }
}
