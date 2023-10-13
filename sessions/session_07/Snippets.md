# Snippets from Rasmus' code

This file contains some snippets from Rasmus' code that might be useful to you.

## Register database context to the DI Container

When you want to register a database context to the DI container you can do it like this.

```csharp
builder.Services.AddDbContext<ChirpContext>(
    options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Chirp")));
```

As you can see, the connection string is fetched by a name.
You might want to consider doing the same thing.
Read up on `GetConnectionString()` to understand how to set the connection string.

## Get access to the database context in `Program.cs`

You might see yourself in a situation where you need to access the database context in the `Program.cs` file.
This is possible by using the `CreateScope()` method on the `IServiceProvider` that is available on the `IApplicationBuilder` that is available via the `app` object.

```csharp
// Seed database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ChirpContext>();

    //Then you can use the context to seed the database for example
    await DbInitializer.SeedDatabase(context);
}
```

## Get access to services in other services

To access services in other services, you need to inject the service in the constructor of the service you want to use it in.

```csharp
public class MyService
{
    private readonly IMyOtherService _myOtherService;

    public MyService(IMyOtherService myOtherService)
    {
        _myOtherService = myOtherService;
    }

    public void DoSomething()
    {
        _myOtherService.DoSomethingElse();
    }
}
```

## Arranging Repositories tests

When testing your repositories you need to inject a database context.
This can be done like this.

```csharp
// Arrange
using var connection = new SqliteConnection("Filename=:memory:");
connection.Open();
var builder = new DbContextOptionsBuilder<ChirpContext>().UseSqlite(connection);
using var context = new ChirpContext(builder.Options);
await context.Database.EnsureCreatedAsync(); // Applies the schema to the database
var repository = new AuthorRepository(context);
```

## Make sure that a propriety is not null after creation

If you want to make sure that a propriety is not null after creation, you can use the `required` modifier.

```csharp
public required string MyProperty { get; set; }
```

EF Core does not respect the `required` modifier, so you will need to use the `[Required]` attribute from `System.ComponentModel.DataAnnotations`.

```csharp
[Required]
public string MyProperty { get; set; }
```

<https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties?tabs=data-annotations%2Cwithout-nrt#required-and-optional-properties>

## String length constraint

Rasmus had two ways of setting the length of a string. Feel free to use whatever version you prefer.

```csharp
[StringLength(50)]
public string MyProperty { get; set; }
```

or

```csharp
modelBuilder.Entity<Author>().Property(a => a.Name).HasMaxLength(50);
```

## Unique constraint on a propriety

If you want to make sure that a propriety is unique you can use the `Index` attribute.

```csharp
[Index(IsUnique = true)]
public string MyProperty { get; set; }
```

or add it in the `OnModelCreating` method.

```csharp
modelBuilder.Entity<Author>()
    .HasIndex(c => c.Name)
    .IsUnique();
```

## Composite Primary Key

If you want to make a composite primary key (more than one index in the key) you can do it like this.

```csharp
modelBuilder.Entity<Author>()
    .HasKey(k => new { k.FollowerId, k.FollowingId });
```

## Global Usings

If you want to globally use a namespace in your project you might want to creating a `Usings.cs` file in the root of your project.
Then you use the following syntax to globally use a namespace.

```csharp
global using <namespace>;
```
