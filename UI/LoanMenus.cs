namespace LibraryManagement;

public class LoanMenus
{
    public void DisplayLoanMenu(LoanService loanService)
    {

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
                    CheckoutBook(loanService);
                    break;
                case 2:
                    ReturnBook(loanService);
                    break;
                case 3:
                    loanService.ViewAllLoans();
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

    static void CheckoutBook(LoanService service)
    {
        service.CheckoutBook("978-0-14310-595-4", 1);
        service.CheckoutBook("978-0-14104-034-9", 2);
        service.CheckoutBook("978-1-77458-394-4", 3);
        service.CheckoutBook("978-1-32408-671-0", 4);
        service.CheckoutBook("978-0-26382-523-7", 5);
    }

    static void ReturnBook(LoanService service)
    {
        Console.Write("Enter the Book ISBN: ");
        string isbn = Console.ReadLine()!;

        Console.Write("Enter the Patron ID: ");
        if (!int.TryParse(Console.ReadLine(), out int patronID))
        {
            Console.WriteLine("Invalid input! Please enter a valid integer");
            return;
        }
        service.ReturnBook(isbn, patronID);
    }
}
