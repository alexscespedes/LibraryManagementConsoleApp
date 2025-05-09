namespace LibraryManagement;

public class Loan 
{
    public required string BookISBN { get; set; } 
    public int PatronId { get; set; }
    public Book BorrowedBook { get; set; } = null!;
    public Patron Borrower { get; set; } = null!;

    public DateTime CheckoutDate { get; set; }
    public DateTime DueDate { get; set; }
}
