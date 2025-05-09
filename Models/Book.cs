namespace LibraryManagement;

public class Book 
{
    public required string ISBN { get; set; }

    public required string Title { get; set; }

    public required string Author { get; set; }

    public Genre GenreBook { get; set; }

    public bool IsAvailable { get; set; } = true;

    public Book() {}

}
