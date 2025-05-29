using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LibraryManagement;

public class FileHandler
{
    string filePath = "/home/alexsc03/Documents/Projects/DotNet/C-SharpConsoleApps/LibraryManagementSystem/Data/Json/";
    JsonSerializerOptions options = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.IgnoreCycles, MaxDepth = 256, WriteIndented = true };
    public void SaveBookToJsonFile(List<Book> books)
    {
        string jsonString = JsonSerializer.Serialize(books, options);
        File.WriteAllText(filePath + "Books.json", jsonString);
    }

    public List<Book> LoadBookFromJsonToList()
    {
        string json = File.ReadAllText(filePath + "Books.json");
        var bookList = JsonSerializer.Deserialize<List<Book>>(json)!;
        return bookList;
    }

    public void SavePatronToJsonFile(List<Patron> patrons)
    {
        string jsonString = JsonSerializer.Serialize(patrons, options);
        using (StreamWriter outputFile = new StreamWriter(filePath + "Patrons.json"))
        {
            outputFile.WriteLine(jsonString);
        }
    }

    public List<Patron> LoadPatronFromJsonToList()
    {
        string json = File.ReadAllText(filePath + "Patrons.json");
        var patronList = JsonSerializer.Deserialize<List<Patron>>(json)!;
        return patronList;
    }

    public void SaveLoanToJsonFile(List<Loan> loans)
    {
        string jsonString = JsonSerializer.Serialize(loans, options);
        using (StreamWriter outputFile = new StreamWriter(filePath + "Loans.json"))
        {
            outputFile.WriteLine(jsonString);
        }
    }

    public List<Loan> LoadLoanFromJsonToList()
    {
        string json = File.ReadAllText(filePath + "Loans.json");
        var loanList = JsonSerializer.Deserialize<List<Loan>>(json)!;
        return loanList;
    }
}