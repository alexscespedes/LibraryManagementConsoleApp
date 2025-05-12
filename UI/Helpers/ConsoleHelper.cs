using System.Text.RegularExpressions;

namespace LibraryManagement;

public class ConsoleHelper 
{
    public void PrintBook(Book book) 
    {
        string status = book.IsAvailable ? "Available" : "Not Available";
        Console.WriteLine($" ISBN: {book.ISBN} | Title: {book.Title} | Author: {book.Author} | Genre: {book.GenreBook} | Status: {status} ");
    }

    public static bool IsValidISBNCode(string str) 
    {
        string strRegex = @"^(?=(?:[^0:9]*[0:9]){10}(?:(?:[^0:9]*[0:9]){3})?$)[\d-]+$";
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
}