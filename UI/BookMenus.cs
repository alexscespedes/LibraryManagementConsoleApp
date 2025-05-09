namespace LibraryManagement;

public class BookMenus 
{
    public void DisplayBookMenu() 
    {
        Console.Clear();
        Console.WriteLine("===== BOOK MANAGEMENT =====");
        Console.WriteLine("1. Add New Book");
        Console.WriteLine("2. Search Books");
        Console.WriteLine("3. Display All Books");
        Console.WriteLine("4. Edit Book Details");
        Console.WriteLine("5. Remove Book");
        Console.WriteLine("0. Return to Main Menu");
        Console.Write("Enter your choice: ");
    }
}
