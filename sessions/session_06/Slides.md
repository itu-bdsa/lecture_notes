---
theme: gaia
_class: lead
paginate: true
backgroundColor: #fff
backgroundImage: url('https://marp.app/assets/hero-background.svg')
footer: '![width:300px](https://github.com/itu-bdsa/lecture_notes/blob/main/images/banner.png?raw=true)'
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

# Intro to EF Core with SQLite, Dependency Injection, and API testing

![bg right:50%](images/azure-sql.png)

Rasmus Lystrøm
Associate Professor
ITU

---

## Feedback

![bg right:70% 100%](images/commit_freqs.png)

All groups are working on their projects!

---

## Feedback

<iframe src="http://209.38.208.62/report_razor_apps.html" width="100%" height=600 scrolling="auto"></iframe>

---

## Feedback

- Have **one** main branch called `main`.
- Remember, we do trunk-based development in this course. That is, you do not have a long-lived `dev` branch (as in last semester's project). That would be another branching strategy.
- You have short-lived feature branches. That is, at latest after a day your changes land on the main branch and thereby automatically in production (your deployment workflows deploy all changes from main, right?)

What do we do if we cannot finish our feature during a day?

- Good observation, that means likely that your task descriptions in your issues are too coarse grained. Over time you should train to make them smaller so that you can complete your tasks in max. a day.

---

## Feedback

- Have **one** main branch called `main`.
- It is not advisable to have a `main2.0` branch.
- Likely, it is also not a good idea to call a branch `origin` since it is confusing when pointing to remote repositories in git commands.


---

# Code Review of last week's project

Use last week's project as motivation for ORM with EFCore
Domain modeling

Different terminology in domain model and in database schema, e.g., `user` vs `author` and `message` vs. `cheep`

# [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)

Entity Framework (EF) Core is a lightweight, extensible, [open source](https://github.com/dotnet/efcore) and cross-platform version of the popular Entity Framework data access technology.

EF Core can serve as an object-relational mapper (O/RM), which:

- Enables .NET developers to work with a database using .NET objects.
- Eliminates the need for most of the data-access code that typically needs to be written.

EF Core supports many database engines, see [Database Providers](https://learn.microsoft.com/en-us/ef/core/providers/) for details.

# Why?

* What's wrong with writing SQL like we did last week?

* Object–relational impedance mismatch??

* Me not understand object me table

# Object Relational Mapping

The act of converting incompatible types in OOP to tables/columns/rows/relations in SQL

# What is an Object-relational-mapper (ORM)?

![bg 80%](images/orm.jpg)

# Model

![bg 80%](images/model.png)

# What is a domain model?

[Wikipedia](https://en.wikipedia.org/wiki/Domain_model):

> In software engineering, a domain model is a conceptual model of the domain that incorporates both behavior and data

![bg right height:60%](https://upload.wikimedia.org/wikipedia/commons/2/2d/Domain_model.png)

# Demo

## Entity Framework Core with Sqlite in a Console App

# Task: _EF Core with Sqlite_ 1

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 15 minutes
-->

Complete this tutorial up to and including **Create the database**:

<https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app>

Inspect the database using a SQLite tool.

# Lambda Expressions

![bg right:50%](images/lambda.png)

# Lambda Expressions

```csharp
Action<string> write = s => Console.WriteLine(s);

Func<int, int> square = a => a * a;
```

```csharp
Predicate<City> b = c => c.Name.StartsWith("B");

Converter<double, double> ftoC = c => c * 9.0 / 5.0 + 32.0;

...
```

# Demo

## Basic CRUD with EF Core

#

![bg left:65%](images/connection-meme.jpg)

<https://twitter.com/overflow_meme/status/1223835574848630784>

# IDisposable

![bg](images/disposable.jpg)

# <strike>IDisposable</strike>

```csharp
public class MyDisposableThingy : IDisposable
```

```csharp
var connection = new SqlConnection("...");
try
{
    ...
}
finally
{
    if (connection != null)
    {
        connection.Dispose();
    }
}
```

# <strike>IDisposable</strike>

```csharp
using (var connection = new SqlConnection("..."))
{
    ...
}
```

# <strike>IDisposable</strike>

```csharp
using var connection = new SqlConnection("...");
```

# Demo

## Dispose context


# Task: _EF Core with Sqlite_ 2

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 10 minutes
-->

Complete remaining:

<https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app>

Ensure your context is disposed.

Inspect the database using a SQLite tool.

# Intro to LINQ

# Prerequisites

![bg](images/belt.png)

# Anonymous types

```csharp
var question = new
{
    Title = "The answer...?",
    Answer = 42
};
```

# (Tuples)

```csharp
var s = Tuple.Create("Clark Kent", "Superman");

var b = ("Bruce Wayne", "Batman");

var f = (name: "Barry Allen", alterEgo: "The Flash");

var random = new Random();

IEnumerable<(float x, float y)> GenerateCoordinates()
{
    yield return (random.NextSingle() * 100, random.NextSingle() * 100);
}
```

# Records

```csharp
public record Superhero(string Name, string AlterEgo, DateTime FirstAppearance);
```

# Data: Collection Initializer

```csharp
IEnumerable<City> cities = new[]
{
    new City(1, "Berlin"),
    new City(2, "Hamburg"),
    new City(3, "Frankfurt")
};

# Data: Collection + Object Initializer

```csharp
IEnumerable<City> cities = new[]
{
    new City { Id = 1, Name = "Berlin" },
    new City { Id = 2, Name = "Hamburg" },
    new City { Id = 3, Name = "Frankfurt" }
};
```

# Extension Methods

![bg](images/extensions.jpg)

# Built-in Extension methods

```csharp
var count = cities.Count();

var sort = cities.OrderBy(c => c.Name);

var filter = cities.Where(c => c.Name.Contains("i"));

var pick = cities.FirstOrDefault(c => c.Id == 2);

var all = cities.All(c => c.Name.Length < 10);

var any = cities.Any(c => c.Name.StartsWith("B"));

var project = cities.Select(c => c.Name);
```

# Create your own extension method

```csharp
public static class Extensions
{
    public static int WordCount(this string str) =>
        str.Split(new[] { ' ', '.', '?' },
                  StringSplitOptions.RemoveEmptyEntries)
           .Length;
}
```

# Demo

## Extension Methods

# Task: Extension Methods

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 10 minutes
-->

- Take the example from the previous task.
- Extend code to add 3-5 new blog posts.
- Experiment with the extension methods:

    - `Select`
    - `FirstOrDefault` / `First`
    - `Any`
    - `Count`
    - `Where`
    - ...

# LINQ - Language INtegrated Query

![bg](images/questions.jpg)

# LINQ

```csharp
var sorted = from c in cities
             where c.Name.Contains("i")
             orderby c.Name descending
             select new { Name = c.Name };
```

## Extension Methods Version

```csharp
var sorted = cities.Where(c => c.Name.Contains("i"))
                   .OrderByDescending(c => c.Name)
                   .Select(c => new { Name = c.Name });
```

# LINQ

## Demo

# Refactoring EF Core Context/Model

## Demo

# Design: Repository Pattern

> A system with a complex domain model often benefits from a layer, [...] that isolates domain objects from details of the database access code. In such systems it can be worthwhile to build another layer of abstraction over the mapping layer where query construction code is concentrated.
>
> A Repository mediates between the domain and data mapping layers, acting like an in-memory domain object collection. Client objects construct query specifications declaratively and submit them to Repository for satisfaction.
> Source and image source: <a href="https://www.martinfowler.com/eaaCatalog/repository.html">E. Hieatt et al.<i>Repository</i></a>


![bg right:50% 100%](https://www.martinfowler.com/eaaCatalog/repositorySketch.gif)


<!-- TODO: Add something from here? http://web.archive.org/web/20150404154203/http://www.remondo.net/repository-pattern-example-csharp/ -->


## Design: Unit of Work

<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

![bg right:60% 100%](https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/media/infrastructure-persistence-layer-design/repository-aggregate-database-table-relationships.png)

<font size=3>
Image source: <a href="https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design">C. Torre et al. <i>Design the infrastructure persistence layer</i></a>
</font>


## Design: Unit of Work

<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

What does that mean for creating repositories



## How to get data from domain models/Repositories into views?


## Testing strategies with database

![bg right:60% 100%](https://learn.microsoft.com/en-us/ef/core/testing/_static/fake-provider-and-repository-pattern.png)


<font size=3>
Image source: <a href="https://learn.microsoft.com/en-us/ef/core/testing/choosing-a-testing-strategy">Microsoft Documentation <i>Choosing a testing strategy</i></a>
</font>

---

### a) SQLite in memory


---

### b) Mocks/Stubs

What are these (mocks and stubs)?
How is the relation to the repository pattern?




## Development and testing of APIs with OpenAPI

- OpenAPI
- Add of endpoint explorer (Swagger middleware)



## Dependency injection revisited

Explain again ASP.NET DI container with repositories


## Process: Scientific problem solving


> 1. Identify the problem
> 2. Gather information
> 3. Iterate potential solutions
> 4. Test your solution<font size=3>
Source: <a href="https://www.oreilly.com/content/4-steps-to-solving-any-software-problem/">E. Cain <i>4 steps to solving any software problem</i></a>
</font>




## Recommendation: Separate Kinds of Code

<!--
_backgroundImage: "linear-gradient(to bottom, #e18ac2, #d112a5)"
_color: white
-->

> **Command Query Separation**
>
> Separate Commands from Queries. Commands are procedures that have side effects. Queries are functions that return data. Every method should be either a Command or a Query, but not both.<font size=3>
Source: Mark Seemann <i>"Code That Fits in Your Head"</i>
</font>



<!-- ----------------------------------------------------------------------- -->



## Dependency Injection

Basic idea, reverse direction of a dependency.
In our examples it is often achieved by injecting a dependency to a class at construction time.
The basic idea is even more general.
When you call a binary with an argument, you inject information into the runtime without having the binary contain it directly.






## Testing of web applications — End-to-end testing

Moved from last week since no new information is stored in the databases.










## `DbContext`? `DbSet`?








## What to do now?

![w:400px](https://25.media.tumblr.com/47f546206bf9a8b5dc97e7fe1b6714b3/tumblr_mi7nkgP6NH1qmegz6o1_500.gif)

- If not done, complete the Tasks (blue slides) from this class
- Check the [reading material](./READING_MATERIAL.md)
- Work on the [project](./README_PROJECT.md)

- <font color="#cecdce">If you feel you want prepare for next session, read chapters TODO! [Andrew Lock _ASP.NET Core in Action, Third Edition_](https://www.manning.com/books/asp-net-core-in-action-third-edition) </font>
