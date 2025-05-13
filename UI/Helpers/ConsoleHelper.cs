using System.Text.RegularExpressions;

namespace LibraryManagement;

public class ConsoleHelper 
{
    public void PrintBook(Book book) 
    {
        string status = book.IsAvailable ? "Available" : "Not Available";
        Console.WriteLine($" ISBN: {book.ISBN} | Title: {book.Title} | Author: {book.Author} | Genre: {book.GenreBook} | Status: {status} ");
    }

    public void PrintPatron(Patron patron) 
    {
        Console.WriteLine($" Name: {patron.Name} | Phone Number: {patron.PhoneNumber} | Email: {patron.Email} | Number of Active Loans: {patron.ActiveLoans.Count}");
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