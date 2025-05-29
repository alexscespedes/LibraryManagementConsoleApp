namespace LibraryManagement;

public class PatronRepository
{
    private List<Patron> _patrons;
    FileHandler fileHandler = new FileHandler();

    public PatronRepository()
    {
        _patrons = new List<Patron>();
    }

    public List<Patron> GetAllPatrons() => _patrons;
    public Patron GetPatronById(int id) => _patrons.FirstOrDefault(p => p.Id == id)!;

    public void AddPatron(Patron patron) => _patrons.Add(patron);

    public bool RemovePatron(int id) => _patrons.RemoveAll(p => p.Id == id) > 0;

    public bool UpdateBook(Patron newPatron)
    {
        var patron = _patrons.FirstOrDefault(p => p.Id == newPatron.Id);

        if (patron != null)
        {
            patron.Name = newPatron.Name;
            patron.PhoneNumber = newPatron.PhoneNumber;
            patron.Email = newPatron.PhoneNumber;

            Console.WriteLine("Book updated successfully.");
            return true;
        }
        Console.WriteLine($"No book found with ISBN: {newPatron.Id}");
        return false;
    }

    public void SavePatronToJson() => fileHandler.SavePatronToJsonFile(_patrons);

    public void LoadPatronToJson() => _patrons = fileHandler.LoadPatronFromJsonToList();
}