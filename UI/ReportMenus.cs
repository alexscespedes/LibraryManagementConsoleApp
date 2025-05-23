namespace LibraryManagement;

public class ReportMenus 
{
    public void DisplayReportsMenu(ReportService reportService) 
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("===== Reports =====");
            Console.WriteLine("1. Overdue Books Report");
            Console.WriteLine("2. Patron Activity Report");
            Console.WriteLine("3. Current Loans Report");
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
                    reportService.OverdueBooksReport();
                    break;
                case 2:
                    reportService.PatronActivityReport();
                    break;
                case 3:
                    reportService.CurrentLoansReport();
                    break;
                case 4:
              
                    break;
                case 5:
 
                    break;
                case 6:

                    break;
                case 0:
                    exit = true;
                    break;
            }
        }
        
    }
}
