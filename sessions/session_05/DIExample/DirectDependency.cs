namespace DirectDependencyExample;
public class Informer
{
    private readonly DIExample.Writer.StdIoWriter _messageWriter = new();
    public void Inform(string message) => _messageWriter.Write(message);
}
