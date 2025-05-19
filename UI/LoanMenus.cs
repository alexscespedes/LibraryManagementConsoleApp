namespace LibraryManagement;

public class LoanMenus
{
    public void DisplayLoanMenu(LoanService loanService)
    {
        // var bookRepo = new BookRepository();
        // var patronRepo = new PatronRepository();
        
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("===== LOAN OPERATIONS =====");
            Console.WriteLine("1. Check Out Book");
            Console.WriteLine("2. Return Book");
            Console.WriteLine("3. View All Current Loans");
            Console.WriteLine("4. View Overdue Books");
            Console.WriteLine("5. Process Late Fees");
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
                    Checkout(loanService);
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

    static void Checkout(LoanService service)
    {
        Console.Write("Enter the Book ISBN: ");
        string isbn = Console.ReadLine()!;

        Console.Write("Enter the Patron ID: ");
        if (!int.TryParse(Console.ReadLine(), out int patronID))
        {
            Console.WriteLine("Invalid input! Please enter a valid integer");
            return;
        }
        service.CheckoutBook(isbn, patronID);
    }
}
