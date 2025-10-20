var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var htmlText = @"<h1>Hello World!</h1>
I am an HTML document from the <a href='https://github.com/itu-bdsa/lecture_notes'>ITU BDSA course.</a>
";
app.Map("/", () => Results.Content(htmlText, "text/html"));

app.Run();
