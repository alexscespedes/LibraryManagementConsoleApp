namespace LibraryManagement;

public class MenuSystem 
{
    public void DisplayMainMenu() 
    {
        BookMenus bookMenus = new BookMenus();
        bool exit = false;

        while(!exit) 
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

            if (!int.TryParse(Console.ReadLine(), out int userInput)) 
            {
                Console.WriteLine("Invalid input! Please enter a valid integer");
                break;
            }

            switch(userInput) 
            {
                case 1: 
                    bookMenus.DisplayBookMenu();
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
