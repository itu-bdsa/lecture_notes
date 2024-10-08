---
theme: gaia
_class: lead
paginate: true
backgroundColor: #fff
backgroundImage: url('https://marp.app/assets/hero-background.svg')
footer: '![width:300px](images/banner-transparent.png)'
headingDivider: 1
marp: true
style: |
  section {
    font-size: 25px;
  }
  container {
    height: 300px;
    width: 100%;
    display: block;
    justify-content: right;
    text-align: right;
  }
  header {
    float: right;
  }

  a {
    color: blue;
    text-decoration: underline;
    background-color: lightgrey;
    font-size: 80%;
  }

  table {
    font-size: 22px;
  }
---

# BDSA: Session 7
### Onion Architecture, Testing, and Advanced Database Schemas

Adrian Hoff
Postdoctoral Researcher
ITU



# Todays's lecture

&emsp;
&emsp;
## 🧅 Onion architecture
&emsp;
## 🧪 Testing: EF Core & in-memory databases
&emsp;
## 🔗 Influencing the database schema in EF Core



# Reflection on Chirp: What about architecture?
<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 5 minutes
-->

We have distinct components:
- a domain model (currently the classes `Cheep` and `Author`)
- repositories (e.g., `ICheepRepository` + `CheepRepository`)
- services (e.g., `ICheepService` + `CheepService`)
- a view / user interface (the Razor pages)
- testing infrastructure
&emsp;
### Think about a good design for your app:
### What component should depend on what other?



# Onion Architecture
<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

> Onion Architecture is based on the inversion of control principle. Onion Architecture is comprised of multiple concentric layers interfacing each other towards the core that represents the domain.

<font size=3>
Text and Image taken from: <a href="https://www.codeguru.com/csharp/understanding-onion-architecture/">Tapas Pal <i>Understanding Onion Architecture</i></a>
</font>

* The domain layer has no external dependencies while the individual layers are loosly coupled.
  - Replacing layer implementations is easy
  - Good testability: we can easily replace and mock layers in tests, e.g., database

![bg right:45% 100%](images/onion_architecture.webp)



# Onion Architecture
<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 10 minutes
-->

How could we implement the onion architecture in Chirp?

#### Doodle a simple boxes-and-arrows diagram using a pen and paper
- Boxes = .NET C# projects & namespaces
  - As projects use:
  `Core`, `Infrastructure`, `Web`, `Tests`
  - Fill the boxes with namespaces and classes, e.g., `Chirp.Repositories`, `Program.cs`, etc.
- Arrows = Project dependencies
  - Remember dependency injection

![bg right:45% 100%](images/onion_architecture.webp)



---

![bg center w:100% h:100%](images/Onion-Diagram-a.svg)

<span style="font-size: 1rem;position:absolute;bottom: 20px;right: 150px">
  <ul>
    <li>This is one of <strong>many</strong> ways to implement the onion architecture</li>
    <li><strong>Beware</strong>: A multi-project setup requires adaptions to the<br>commands for working with EF Core database migrations</li>
  </ul>
</span>



# Onion Architecture: Why is this good?
- ### Loosely coupled and more independant layers!
- ### How?
  - Inversion of Control: Dependency Injection
* ### So what?
  - We can easily replace components!
    - Maintainability
    - **Testability**
    - ...



# Dependency Injection (revisited)

`Program.cs`:
```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
```

`ChatService.cs`:
```csharp
public class ChatService : IChatService
{
    private readonly IMessageRepository _messageRepository;
    public ChatService(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    ...
}
```

<font size=3><span style="margin-left: 40%;">(These snippets should look familiar!)</span></font>



# Testing: loose component coupling helps

For example, we can replace a component by registering a **[test double](https://martinfowler.com/articles/mocksArentStubs.html)** - without further adaptions to the unit under test.

`ChatServiceUnitTests.cs`:
```csharp
[Fact]
public void SomeUnitTestOnChatService()
{
    // Arrange
    IChatRepository chatRepo = new ChatRepositoryStub(...); // not the repository class used in production!
    IChatService service = new ChatService(chatRepo);

    // Act
    service.CreateMessage(...);

    // Assert
    ...
}
```



# Testing: loose component coupling helps (ctd.)

Similarly, we can replace the real database with a **fake in-memory database**.
This can be helpful when your database is slow or limits querying over time (e.g., in a cloud).

`MessageRepositoryUnitTests.cs`:
```csharp
// Arrange
using var connection = new SqliteConnection("Filename=:memory:");
await connection.OpenAsync();
var builder = new DbContextOptionsBuilder<ChirpContext>().UseSqlite(connection);

using var context = new ChirpContext(builder.Options);
await context.Database.EnsureCreatedAsync(); // Applies the schema to the database

IMessageRepository repository = new MessageRepository(context);

// Act
var result = repository.QueryMessages("TestUser");
...
```
<div style="margin-left: 50%; margin-top: 20px; font-size: 1rem;">
  (Note: In the project, we use SQLite as our database in production!
  Nevertheless, using it in in-memory mode for testing is useful.)
</div>


# Testing (ctd.)

Various parts of your system can be replaced with test doubles to test a targeted unit in isolation:
- services
- repositories
- database contexts
- databases
- ...

<div style="margin-top:50px;font-size: 1rem;">Image Source:<br><a href="https://learn.microsoft.com/en-us/ef/core/testing/choosing-a-testing-strategy">Microsoft, <i>Choosing a testing strategy</i></a>
</div>

![bg right:65% 90%](images/fake-provider-and-repository-pattern.png)








# Command Query Separation (CQS)
<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

![bg right:45% 100%](../session_06/images/Repository.svg)

> [CQS] states that every method should either be a command that performs an action, or a query that returns data to the caller, but _not both_.

<font size=3>Source: <a href="https://en.wikipedia.org/wiki/Command%E2%80%93query_separation">Wikipedia</a></font>


&emsp;
#### If asking a question changes the answer, we're likely to run into problems.

<font size=3>Cf. Bertrand Meyer, <a href="https://se.inf.ethz.ch/old/people/meyer/publications/eiffel/eiffel_jss.pdf"><i>Eiffel: a language for software engineering</i></a></font>



# Command Query Separation (CQS)
<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 5 minutes
-->

&emsp;
## Revisit your project code

Do not change your code. Just think about the following points:
&emsp;
- Did you separate commands from queries in your repository?
&emsp;
- What makes mixing commands and queries tempting in your current setup?
  - How could we address this?



# Unit of Work
<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

> The repository and unit of work patterns are intended to create an abstraction layer between the data access layer and the business logic layer of an application. Implementing these patterns can help insulate your application from changes in the data store and can facilitate automated unit testing [..]

<font size=3>
Text and Image Source: <a href="https://www.martinfowler.com/eaaCatalog/repository.html"><i>Microsoft</i></a>
</font>

![bg right:59% 100%](images/unit-of-work-diagram.png)



# Unit of Work Pattern (ctd.)

A Unit of Work bundles repositories and operations.
&emsp;
- Reliably and efficiently execute a batch of queries and/or commands
  - for instance: query from one repository, process the results, and send update commands to another repository
&emsp;
* Using EF Core, we should
  - first perform all data changes in memory, e.g., `dbContext.Messages.Add(...)`
  - and, if done successfully, persist them in our database via `dbContext.SaveChanges()`
- Note: In a unit of work operation, use one EF Core database context per database



# From domain model  to data model
<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 10 minutes
-->

Remember last session?
- We defined a domain model and used at as input for EF Core
- EF Core mapped it to a database schema


&emsp;
* ### Inspect `XyzDBContextModelSnapshot.cs` in your Migrations folder
  - Inspect how the `BuildModel` method defines your db schema

![bg right:25% width:100%](../session_06/images/domain_model.svg)



# From domain model  to data model (ctd.)
The mapping process in EF Core is controlled largely by [conventions](https://learn.microsoft.com/en-us/ef/core/modeling/#built-in-conventions)
(e.g., properties ending on `Id` are turned into keys).
&emsp;
- We can control this process further through

  - _Data Annotations_ in the domain model

  - _Fluent API_: overriding the `OnModelCreating(...)` method in the database context class
&emsp;
* Precedence: &emsp; Fluent API &emsp; _overrides_ &emsp; Data Annotations &emsp; _overrides_ &emsp; Conventions

&emsp;
Read more about this in the documentation on [EF Core Modeling](https://learn.microsoft.com/en-us/ef/core/modeling/) and, therein, [Entity Properties](https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties).



# Required properties

If you want to make sure that a property in your domain model is not null after creation,
you can use the `required` modifier.

```csharp
public required string MyProperty { get; set; }
```

&emsp;

However, EF Core does not respect the `required` modifier when creating a db schema.
You will need to use the `[Required]` annotation from `System.ComponentModel.DataAnnotations`.

```csharp
[Required]
public string MyProperty { get; set; }
```



# String length limits

To validate the maximum length of strings, you can annotate a property directly:

```csharp
[StringLength(500)]
public string Text { get; set; }
```

&emsp;

Alternatively, you can add constraings in the `OnModelCreating` method.

```csharp
modelBuilder.Entity<Message>().Property(m => m.Text).HasMaxLength(500);
```



# Try it out!
<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 10 minutes
-->

#### Recommended: Make sure you have committed all changes to your project
- Running `git status` returns something like `nothing to commit, working tree clean`.

&emsp;

#### 1. Limit the length of cheeps:
```csharp
[Required]
[StringLength(500)]
public required string Text { get; set; }
```

#### 2. Add a new migration: `dotnet ef migrations add LimitAuthorInfoStringLength`

#### 3. Inspect the changes in `XyzDBContextModelSnapshot.cs`
- Navigate to the Migrations folder in your console and and run `git diff .`



# Unique properties

If you want to make sure that a property is unique, you can use the `Index` attribute:

```csharp
[Index(IsUnique = true)]
public string MyProperty { get; set; }
```

&emsp;

Alternatively, add it in the `OnModelCreating` method:

```csharp
modelBuilder.Entity<Author>()
    .HasIndex(c => c.Name)
    .IsUnique();
```

Hint: The fluent API applies a configuration in the order of method calls. If configurations are conflicting, the later method call will overrides the earlier call.



# Try it out!
<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 5 minutes
-->

#### 1. Make authors' names and emails unique
Add an `OnModelCreating` method to you database context:
```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Author>()
        .HasIndex(c => c.Name)
        .IsUnique();
    modelBuilder.Entity<Author>()
        .HasIndex(c => c.Email)
        .IsUnique();
}
```

#### 2. Add a new migration: `dotnet ef migrations add UniqueAuthorNamesAndEmails`

#### 3. Inspect the changes in `XyzDBContextModelSnapshot.cs` (run `git diff .`)



# Composite Primary Key

If you want to define a composite primary key (more than one column as the key), use the `OnModelCreating` method:

```csharp
modelBuilder.Entity<Author>()
    .HasKey(k => new { k.FollowerId, k.FollowingId });
```

&emsp;
&emsp;
&emsp;
&emsp;
&emsp;
&emsp;
&emsp;
Read more in the documentation on [EF Core Modeling](https://learn.microsoft.com/en-us/ef/core/modeling/) and, therein, [Entity Properties](https://learn.microsoft.com/en-us/ef/core/modeling/entity-properties).



# Summary

* ### 🧅 Onion architecture
  - helps with achieving loosely coupled components
  - domain model separated from rest of system and free of dependencies
  - individual components can be replaced more easily (e.g., for testing purposes)

* ### 🧪 Testing: EF Core & in-memory databases
  - to test units in isolation, it is userful to replace collaborators with test doubles
    - includes the database, where using in-memory SQLite is a popular approach
    - it is easy to set up and fast in execution

* ### 🔗 Influencing the database schema in EF Core
  - solved via data annotations and/or the fluent API (`OnModelCreating` method)
  - influences the database schema and, respectively, the migrations generated by EF Core


# What to do now?

![w:400px](https://25.media.tumblr.com/47f546206bf9a8b5dc97e7fe1b6714b3/tumblr_mi7nkgP6NH1qmegz6o1_500.gif)

- If not done, complete the Tasks (blue slides) from this class
- Check the [reading material](./READING_MATERIAL.md)
- Work on the [project](./README_PROJECT.md)

- <font color="#cecdce">If you feel you want prepare for next session, read chapters 6, 7, and 23 [Andrew Lock _ASP.NET Core in Action, Third Edition_](https://www.manning.com/books/asp-net-core-in-action-third-edition) </font>


## Now: Guest Lecture

![bg right](https://www.twobirds.com/-/media/twobirdssite/people/lawyers/photos/denmark/martin-vonhaller/martin-vonhaller-mobile.jpg?h=435&iar=0&w=750&hash=2F2B45E76908434DCF00E39834D8F4C2)

[Martin von Haller Grønbæk](https://www.twobirds.com/en/people/m/martin-von-haller-groenbaek), one of Denmark's leading IT lawyers, will give a guest lecture on _Software Licenses and Software License Compatibility_.

The lecture will start at 11:00 (sharp) in Auditorium 1. So be there on time, best 10:50.
After his guest lecture, Martin will be available for deeper questions and discussions in the canteen (12:00 - 12:30).
