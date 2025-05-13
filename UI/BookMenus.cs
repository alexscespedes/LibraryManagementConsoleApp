namespace LibraryManagement;

public class BookMenus 
{
    

    public void DisplayBookMenu() 
    {
        BookService bookService = new BookService();
        bool exit = false;

        while(!exit) 
        {
            Console.WriteLine("===== BOOK MANAGEMENT =====");
            Console.WriteLine("1. Add New Book");
            Console.WriteLine("2. Search Books");
            Console.WriteLine("3. Display All Books");
            Console.WriteLine("4. Edit Book Details");
            Console.WriteLine("5. Remove Book");
            Console.WriteLine("0. Return to Main Menu");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int userInput)) 
            {
                Console.WriteLine("Invalid input! Please enter a valid integer");
                break;
            }

            switch(userInput) 
            {
                case 1: 
                    AddBook(bookService);
                    break;
                case 2:
                            
                    break;
                case 3: 
                    bookService.ViewAllBooks();   
                    break;
                case 4:
                    UpdateBookInfo(bookService);
                    break;
                case 5:
                    RemoveBook(bookService);
                    break;
                case 0: 
                    exit = true;
                    break;
                }
        }
    }

    static void AddBook (BookService service) 
    {
        Console.Write("Enter the book ISBN: ");
        string isbn = Console.ReadLine()!;

        Console.Write("Enter the book title: ");
        string title = Console.ReadLine()!;

        Console.Write("Enter the book author: ");
        string author = Console.ReadLine()!;

        Console.WriteLine("Select the book genre: ");
        Console.WriteLine("1. Adventure");
        Console.WriteLine("2. Business");
        Console.WriteLine("3. Comedy");
        Console.WriteLine("4. Romantic");
        Console.WriteLine("5. Science");
        Console.Write("Choose an option: ");
        
    
        if (!int.TryParse(Console.ReadLine(), out int genreSelection)) 
        {
            Console.WriteLine("Invalid input! Please enter a valid integer");
            return;
        }
        Genre genre;
        switch (genreSelection) 
        {
            case 1:
                genre = Genre.Adventure;
                break;
            case 2:
                genre = Genre.Business;
                break;
            case 3:
                genre = Genre.Comedy;
                break;
            case 4:
                genre = Genre.Romantic;
                break;
            case 5:
                genre = Genre.Science;
                break;
            default:
                Console.WriteLine("Invalid option, please select (1-5)");
                return;
        }

        var newBook = new Book 
        {
            ISBN = isbn,
            Title = title,
            Author = author,
            GenreBook = genre
        };

        service.AddBook(newBook);
    }

    static void RemoveBook(BookService service) 
    {
        Console.Write("Enter the isbn of the book to remove: ");
        string isbn = Console.ReadLine()!;
        service.RemoveBook(isbn);
    }

    static void UpdateBookInfo(BookService service) 
    {
        Console.Write("Enter the isbn of the book to update: ");
        string isbn = Console.ReadLine()!;

        Console.Write("Enter new title: ");
        string newTitle = Console.ReadLine()!;

        Console.Write("Enter new author: ");
        string newAuthor = Console.ReadLine()!;

        Console.WriteLine("Select new genre: ");
        Console.WriteLine("1. Adventure");
        Console.WriteLine("2. Business");
        Console.WriteLine("3. Comedy");
        Console.WriteLine("4. Romantic");
        Console.WriteLine("5. Science");
        Console.Write("Choose an option: ");

        if (!int.TryParse(Console.ReadLine(), out int genreSelection)) 
        {
            Console.WriteLine("Invalid input! Please enter a valid integer");
            return;
        }
        Genre newGenre;
        switch (genreSelection) 
        {
            case 1:
                newGenre = Genre.Adventure;
                break;
            case 2:
                newGenre = Genre.Business;
                break;
            case 3:
                newGenre = Genre.Comedy;
                break;
            case 4:
                newGenre = Genre.Romantic;
                break;
            case 5:
                newGenre = Genre.Science;
                break;
            default:
                Console.WriteLine("Invalid option, please select (1-5)");
                return;
        }
        var updatedBook = new Book 
        {
            ISBN = isbn,
            Title = newTitle,
            Author = newAuthor,
            GenreBook = newGenre
        };

        service.UpdateBook(updatedBook);
    }
}
