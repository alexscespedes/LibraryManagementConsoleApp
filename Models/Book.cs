namespace LibraryManagement;

public class Book 
{
    public string ISBN { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public Genre GenreBook { get; set; }

    public bool IsAvailable { get; set; } = true;

    public Book() {}

}
