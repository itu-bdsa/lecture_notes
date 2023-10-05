var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/a/{endpoint}", (string endpoint) =>
{
    var informer = new DirectDependencyExample.Informer();
    informer.Inform(endpoint);
});

app.MapGet("/b/{endpoint}", (string endpoint) =>
{
    var informer = new InjectedDependencyExample.Informer(new DIExample.Writer.StdIoWriter());
    informer.Inform(endpoint);
});

app.Run();
