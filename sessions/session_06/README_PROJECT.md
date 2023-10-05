# Your turn now! -- Project Work

<img src="https://media.giphy.com/media/13GIgrGdslD9oQ/giphy.gif" width=50%/>

You have to work on the following topics.

  - [1) Software Development](#1-software-development)
  - [2) Process](#2-process)

Remember, you have to perform work on each topic and on **each** bullet point.
Be done with the project work before we meet again next Thursday.


## 1) Software Development

Refactor `Chirp.Razor` away from direct SQLite access to EF Core

After this session, we realized that our direct dependence on SQLite and its dialect of SQL is less optimal.
Consequently, refactor your `Chirp.Razor` application to use EF Core instead of SQLite directly.
However, continue to use SQLite as your underlying database.

The functionality of your `Chirp.Razor` application will not be different compared to last week.
That is, you have an application that can display public and private timelines, both of which are paginated to 32 cheeps per page.

### 1.a) Data Model

Create a data model for your `Chirp.Razor` application.
In the end, your data model shall consist of two classes: `Cheep` and `Author`.
For now, an author has a `Name` and an `Email` address (both of which are strings).
A `Cheep` contains a `Text` and a `TimeStamp`, where the former is a string and the latter is a `DateTime`.
Additionally, each `Cheep` refers to its `Author` and each `Author` keeps a reference to all its `Cheeps`.

Note, we intend you to implement this data model by hand as two classes as in the in-class task.
That is, we do not want you to convert last week's SQL schema into a data model via automatic tooling.

### 1.b) Repository Pattern

Implement the _Repository_ pattern in your application.
Likely, you will create a `CheepRepository`, which gathers information about the cheeps that your application displays in timelines.
Configure the ASP.NET DI container (dependency injection container) so that instances of `CheepRepository` are injected into your application wherever needed.
That is, none of your views, services, etc. has a direct dependency onto `CheepRepository`.

### 1.c) Data Transfer Objects (DTOs)

The information that your application receives from the `CheepRepository` is more rich than what your application needs to display to users.
Consequently, create DTOs that transport information to your views.
Usually, it is advisable that DTOs consist of fields of predefined types only, i.e., `int`, `strings`, etc. `DateTime` is not a predefined type.

### 1.d) Seeding the database with example data.

Use the file [`DbInitializer.cs`](./data/DbInitializer.cs) to import example data into you `Chirp.Razor` application on application start.

This file becomes part of your project.
That is, your deployed `Chirp.Razor` application on Azure App Services is always seeded with at least this information.
Whenever we access your applications, we expect to find at least the cheeps written by the authors in that file.

Right after creating your database context object, which we assume to be called `ChirpDBContext`, you can call the only method from `DbInitializer.cs` to seed the example data into your application.


## 2) Process

### 2.a) Scientific problem solving

Do not start programming directly.
Instead, follow the advice from the lecture and start by identification of the problem at hand, i.e., what is the task to be solved, what is the issue, etc.
Now that you identified a problem, do not start programming yet.
Instead, gather information.
For all tasks, it is likely advisable to check the lecture notes, the reading material, and in particular the book for relevant information.
All these sources contain building blocks for your solution.
First now, implement a potential solution that addresses the task at hand.
Evaluate via manual and automated tests if the solution you implemented suitably solves the problem, task, etc.
If not, iterate over this cycle, i.e., problem identification, information gathering, implementation of potential solutions, testing of solutions.

### 2.b) Continuous Deployment

Continue to release automatically.
That is, during the next week you make multiple new versions `Chirp.Razor` running in production.
The latest version of the application in production is always the latest version of the application in your main branch.
Assure that this is the case via a respective GitHub Actions workflow.
Likely, you have one already from last week.
If not, this task is here to signal that it is high time creating a working deployment workflow.

### 2.c) Add Unit Tests

Now, that you have decoupled your data persistence code properly from your application, augment your test suite from last time.

Implement a set of unit tests for suitable functionality, e.g., data conversion.

### 2.d) Use In-memory SQLite Database for testing

As we realized during the last weeks, a direct dependency to a certain database is not advisable when running test suites.

Consequently, configure your integration test suite so that it uses an in-memory SQLite database for testing.
