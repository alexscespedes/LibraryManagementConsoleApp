namespace LibraryManagement;

public class LoanMenus 
{
    public void DisplayLoanMenu() 
    {
        Console.Clear();
        Console.WriteLine("===== LOAN OPERATIONS =====");
        Console.WriteLine("1. Check Out Book");
        Console.WriteLine("2. Return Book");
        Console.WriteLine("3. View All Current Loans");
        Console.WriteLine("4. View Overdue Books");
        Console.WriteLine("5. Process Late Fees");
        Console.WriteLine("0. Return to Main Menu");
        Console.Write("Enter your choice: ");
    }
}
