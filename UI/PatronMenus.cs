namespace LibraryManagement;

public class PatronMenus 
{
    public void DisplayPatronMenu() 
    {
        Console.Clear();
        Console.WriteLine("===== PATRON MANAGEMENT =====");
        Console.WriteLine("1. Register New Patron");
        Console.WriteLine("2. Search Patrons");
        Console.WriteLine("3. Display All Patrons");
        Console.WriteLine("4. Edit Patron Details");
        Console.WriteLine("5. View Patron's Borrowed Books");
        Console.WriteLine("0. Return to Main Menu");
        Console.Write("Enter your choice: ");
    }
}
