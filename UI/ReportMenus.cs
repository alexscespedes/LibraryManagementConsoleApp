namespace LibraryManagement;

public class ReportMenus 
{
    public void DisplayReportsMenu() 
    {
        Console.Clear();
        Console.WriteLine("===== Reports =====");
        Console.WriteLine("1. Overdue Books Report");
        Console.WriteLine("2. Patron Activity Report");
        Console.WriteLine("3. Popular Books Report");
        Console.WriteLine("4. Fee Collection Report");
        Console.WriteLine("5. Current Loans Report");
        Console.WriteLine("0. Return to Main Menu");
        Console.Write("Enter your choice: ");
    }
}
