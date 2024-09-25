namespace InjectedDependencyExample;
public class Informer
{
    private readonly DIExample.Writer.IWriter _messageWriter;

    public Informer(DIExample.Writer.IWriter messageWriter) => _messageWriter = messageWriter;

    public void Inform(string message) => _messageWriter.Write(message);
}
