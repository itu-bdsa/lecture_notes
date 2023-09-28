namespace DIExample.Writer;

public interface IWriter
{
    public void Write(string message);
}

public class StdIoWriter : IWriter
{
    public void Write(string message) => Console.WriteLine(message);
}

public class FileWriter : IWriter
{
    public void Write(string message)
    {
        string docPath = Path.GetTempPath();
        using StreamWriter outputFile = new(Path.Combine(docPath, "store.txt"));
        outputFile.WriteLine(message);
    }
}
