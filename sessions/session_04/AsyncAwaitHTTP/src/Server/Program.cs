var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    Thread.Sleep(2000);
    return "Hello World!";
});

app.Run();
