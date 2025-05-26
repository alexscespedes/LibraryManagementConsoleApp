using System.Text.Json;
using System.Text.Json.Serialization;

namespace LibraryManagement;

public class DataManager
{
    string filePath = "/home/alexsc03/Documents/Projects/DotNet/C-SharpConsoleApps/LibraryManagementSystem/Data/Json/";
    public void SaveBookToJsonFile(List<Book> books)
    {
        string jsonString = JsonSerializer.Serialize(books, new JsonSerializerOptions() { WriteIndented = true });
        using (StreamWriter outputFile = new StreamWriter(filePath + "Books.json"))
        {
            outputFile.WriteLine(jsonString);
        }
    }

    public void SavePatronToJsonFile(List<Patron> patrons)
    {
        string jsonString = JsonSerializer.Serialize(patrons, new JsonSerializerOptions() { WriteIndented = true });
        using (StreamWriter outputFile = new StreamWriter(filePath + "Patrons.json"))
        {
            outputFile.WriteLine(jsonString);
        }
    }

    public void SaveLoanToJsonFile(List<Loan> loans)
    {
        var options = new JsonSerializerOptions() { ReferenceHandler = ReferenceHandler.Preserve, MaxDepth = 256, WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(loans, options);
        using (StreamWriter outputFile = new StreamWriter(filePath + "Loans.json"))
        {
            outputFile.WriteLine(jsonString);
        }
    }
}
