namespace LibraryManagement;

public class ReportMenus 
{
    public void DisplayReportsMenu(LibraryService libraryService) 
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("===== Reports =====");
            Console.WriteLine("1. Overdue Books Report");
            Console.WriteLine("2. Patron Activity Report");
            Console.WriteLine("3. Popular Books Report");
            Console.WriteLine("4. Fee Collection Report");
            Console.WriteLine("5. Current Loans Report");
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
                    libraryService.OverdueBooksReport();
                    break;
                case 2:
                   
                    break;
                case 3:
                  
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
