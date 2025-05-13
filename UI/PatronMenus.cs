namespace LibraryManagement;

public class PatronMenus 
{
    public void DisplayPatronMenu() 
    {
        PatronService patronService = new PatronService();
        bool exit = false;

        while(!exit) 
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

            switch(userInput) 
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
                    break;
                case 0: 
                    exit = true;
                    break;
                }
        }
    }

    static void RegisterPatron(PatronService service) 
    {
        Console.Write("Enter the patron name: ");
        string name = Console.ReadLine()!;

         Console.Write("Enter the patron Phone Number: ");
        string phoneNumber = Console.ReadLine()!;

        Console.Write("Enter the patron Email: ");
        string email = Console.ReadLine()!;

        var newPatron = new Patron 
        {
            Name = name,
            PhoneNumber = phoneNumber,
            Email = email
        };

        service.RegisterPatron(newPatron);
    }
}
