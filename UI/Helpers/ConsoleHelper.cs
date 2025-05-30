using System.Text.RegularExpressions;

namespace LibraryManagement;

public class ConsoleHelper 
{   
    public void PrintBook(List<Book> books)
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Books not found");
            return;
        }
        foreach (var book in books)
        {
            string status = book.IsAvailable ? "Available" : "Not Available";
            Console.WriteLine($" ISBN: {book.ISBN} | Title: {book.Title} | Author: {book.Author} | Genre: {book.GenreBook} | Status: {status} ");
        }
    }

    public void PrintPatron(List<Patron> patrons)
    {
        if (patrons.Count == 0)
        {
            Console.WriteLine("Patrons not found");
            return;
        }
        foreach (var patron in patrons)
        {
            Console.WriteLine($" Name: {patron.Name} | Phone Number: {patron.PhoneNumber} | Email: {patron.Email} | Number of Active Loans: {patron.ActiveLoans.Count}");
        }
    }

    public void PrintLoans(List<Loan> loans)
    {
        if (loans.Count == 0)
        {
            Console.WriteLine("Loans not found");
            return;
        }
        foreach (var loan in loans)
        {
            Console.WriteLine($" Book Title: {loan.BorrowedBook.Title} | Patron Name: {loan.Borrower.Name} | Loan CheckoutDate: {loan.CheckoutDate} | Loan DueDate: {loan.DueDate} | Loan Status: {loan.Status}");
        }
    }

    public bool IsValidISBNCode(string str)
    {
        string strRegex = @"^(?=(?:[^0-9]*[0-9]){10}(?:(?:[^0-9]*[0-9]){3})?$)[\d-]+$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(str))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsValidPhoneNumber(string phoneNumber) 
    {
        string pattern = @"^\+?[0-9\s\-\(\)]{7,15}$";
        return Regex.IsMatch(phoneNumber, pattern);
    }

    public bool IsValidEmail(string email) 
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        return Regex.IsMatch(email, pattern);
    }      
}