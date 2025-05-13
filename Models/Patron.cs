namespace LibraryManagement;

public class Patron 
{

    static int nextId;
    public int Id { get; private set; }

    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public List<Loan> ActiveLoans { get; set; }

    public Patron() 
    {
        Id = Interlocked.Increment(ref nextId);
        ActiveLoans = new List<Loan>();
    }
}
