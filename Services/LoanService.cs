using System.Data.Common;

namespace LibraryManagement;

public class LoanService
{
    BookService bookService = new BookService();
    PatronService patronService = new PatronService();

    public Loan CheckoutBook(string isbn, int patronID, int loanDurationDays = 14)
    {
        var book = bookService.books.SingleOrDefault(b => b.ISBN == isbn);
        var patron = patronService.patrons.SingleOrDefault(p => p.Id == patronID);

        if (book == null || patron == null)
        {
            Console.WriteLine("Book and Patron were not found.");
            return null!;
        }
        else if (!book.IsAvailable)
        {
            Console.WriteLine("The book is not available");
        }
        book.IsAvailable = false;
        DateTime today = DateTime.Now;

        // Create a loan object
        var loanedBook = new Loan
        {
            BookISBN = isbn,
            PatronId = patronID,
            BorrowedBook = book,
            Borrower = patron,
            CheckoutDate = today,
            DueDate = today.AddDays(loanDurationDays),
            Status = LoanStatus.Active
            };
            patron.ActiveLoans.Add(loanedBook);
            return loanedBook;
    }

    public bool ReturnBook(int id)
    {
        return true;
    }
    

}
