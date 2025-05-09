namespace LibraryManagement;

public class MenuSystem 
{
    public void DisplayMainMenu() 
    {
        Console.Clear();
        Console.WriteLine("===== LIBRARY MANAGEMENT SYSTEM =====");
        Console.WriteLine("1. Book Management");
        Console.WriteLine("2. Patron Management");
        Console.WriteLine("3. Loan Operations");
        Console.WriteLine("4. Reports");
        Console.WriteLine("5. Save Data");
        Console.WriteLine("6. Load Data (manually)");
        Console.WriteLine("0. Exit");
        Console.Write("Enter your choice: ");
    }
}
