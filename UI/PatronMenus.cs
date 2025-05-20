namespace LibraryManagement;

public class PatronMenus
{
    public void DisplayPatronMenu(PatronService patronService)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("===== PATRON MANAGEMENT =====");
            Console.WriteLine("1. Register New Patron");
            Console.WriteLine("2. Search Patrons");
            Console.WriteLine("3. Display All Patrons");
            Console.WriteLine("4. Edit Patron Details");
            Console.WriteLine("5. View Patron's Borrowed Books");
            Console.WriteLine("0. Return to Main Menu");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int userInput))
            {
                Console.WriteLine("Invalid input! Please enter a valid integer");
                break;
            }

            switch (userInput)
            {
                case 1:
                    RegisterPatron(patronService);
                    break;
                case 2:

                    break;
                case 3:
                    patronService.ViewAllPatrons();
                    break;
                case 4:
                    break;
                case 5:
                    ActiveLoans(patronService);
                    break;
                case 0:
                    exit = true;
                    break;
            }
        }
    }

    static void RegisterPatron(PatronService service)
    {

        var newPatron1 = new Patron
        {
            Name = "Alexander Sencion",
            PhoneNumber = "809-123-4789",
            Email = "alex@gmail.com"
        };
        service.RegisterPatron(newPatron1);
        var newPatron2 = new Patron
        {
            Name = "Chris Paul",
            PhoneNumber = "809-124-4779",
            Email = "chris@nba.com"
        };
        service.RegisterPatron(newPatron2);
        var newPatron3 = new Patron
        {
            Name = "Damon Salvatore",
            PhoneNumber = "809-196-4749",
            Email = "damon@hotmail.com"
        };
        service.RegisterPatron(newPatron3);
        var newPatron4 = new Patron
        {
            Name = "Stefan Salvatore",
            PhoneNumber = "809-852-6321",
            Email = "stefan@hotmail.com"
        };
        service.RegisterPatron(newPatron4);
        var newPatron5 = new Patron
        {
            Name = "Daddy Yankee",
            PhoneNumber = "809-741-3256",
            Email = "daddy@yahoo.com"
        };
        service.RegisterPatron(newPatron5);
    }

    static void ActiveLoans(PatronService service)
    {
        Console.Write("Enter the Patron ID: ");
        if (!int.TryParse(Console.ReadLine(), out int patronID))
        {
            Console.WriteLine("Invalid input! Please enter a valid integer");
            return;
        }
        service.ViewActiveLoans(patronID);
    }
}
