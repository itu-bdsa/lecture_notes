# Your turn now! -- Project Work

<img src="https://media.giphy.com/media/13GIgrGdslD9oQ/giphy.gif" width=50%/>

You have to work on the following topics.

  - [1) Software Development](#1-software-development)
  - [2) Process](#2-process)

Remember, you have to perform work on each topic and on **each** bullet point.
Be done with the project work before we meet again next Thursday.


## 1) Software Development

This week, you have to implement a first version of a _Chirp!_ Razor Page web application.

Base your work on the source code that the project template `chirp-razor` creates.

```bash
dotnet new chirp-razor -o Chirp.Razor
```

The public timeline, i.e., a list of all cheeps written by all users shall be reachable under the root endpoint (`/`) and the private timeline, i.e., all the cheeps written by a certain user shall be reachable under the endpoint with the respective username (e.g., `/<username>`) as it is when running the code from the template.

Note, the `chirp-razor` template does not contain a complete application though.
However, it contains the scaffolding that allows you to implement the following features:


### 1.a) Switch Database to File-based SQLite Database

From now on, you will use [SQLite](https://sqlite.org/index.html) as your database.
That is, we will retire our previous CSV database which we will not require anymore for the reminder of the project work.

Modify the code in `CheepService.cs` so that it retrieves cheeps and their authors from an SQLite database.
For that, use the [schema](./data/schema.sql) and the [data dump](./data/dump.sql).
For local development, you can import that data into new database, for example, by running the [script](./scripts/initDB.sh) from the command-line, e.g., via `./initDB.sh`.

Encapsulate all database related code, i.e., establishing of connections, access of data, etc. into its own "wrapper" class called `DBFacade.cs`.

Modify the code in the method `GetCheeps()` in `CheepService.cs` so that it executes an SQL query against the SQLite database.
The signature of the method should remain the same, i.e., return type remains `List<CheepViewModel>` and it consumes no input.

Decide if or how you want to refactor the second method `GetCheepsFromAuthor(string author)`.
Likely, it is a good idea to execute a query that collects specifically only the cheeps of a certain author,

Your program shall receive the location from the SQLite database file from an environment variable called `CHIRPDBPATH`.
In case no such variable is defined the database file shall be located under a [user's temporary directory](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.gettemppath?view=net-7.0&tabs=linux) with the file name `chirp.db`.
That is, calling your program directly, e.g., with `dotnet run` will store the database file under `<user's tempdir>`, whereas calling it with, e.g., `CHIRPDBPATH=./mychirp.db dotnet run` will store the file in the current directory under the file name `mychirp.db`.


#### Hints

- Since your `CheepViewModel` combines data from both the `user` table and the `message` table from the database, your SQL queries need to select data from these two tables and they have to assure that they get the correct author of a cheep, i.e., a `user` corresponding to a `method`.
- To specify the author of a cheep, you likely want to [add a respective parameter to an SQL query](https://learn.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand.parameters?view=dotnet-plat-ext-7.0)
- [Check the official documentation](https://learn.microsoft.com/en-us/dotnet/api/system.environment.getenvironmentvariable?view=net-7.0) on how to get values from environment variables.


### 1.b) Add pagination of cheeps

The _Chirp!_ application from the `chirp-razor` template, is quite dumb.
It displays all cheeps that it knows about.
That is, if a corresponding database contained a million cheeps, they would all be returned to the client.
That is quite inefficient, since the response would be many megabytes large.
To avoid that, implement pagination of cheeps.
Modify the Razor Pages of the public and private timelines so that you read query parameters that are provided via the URL that specify which page a client wants to receive.
That is, a `GET` request to `http(s)://<your_host>/?page=12` shall return the twelfth page of all cheeps and a `GET` request to `http(s)://<your_host>/Helge?page=2` shall return the second page of all of Helge's cheeps.
If no query parameter for a page is specified for a URL, then per default, the first page should be returned to the client.
Consequently, a `GET` request to `http(s)://<your_host>/?page=1` returns the same result as a `GET` request to `http(s)://<your_host>/`.
The same pattern holds for private timelines.

Let's say that for us and for now, pages are of fixed length and that they shall contain at most 32 cheeps.

Try to modify your database queries to support paged queries too.
That is, try to **not** retrieve all cheeps from the database, which then get filtered in C♯ code for those that you want to return to the clients.
Instead, modify your SQL queries so that they retrieve as few as possible values to fill a requested HTML page.


### 1.c) Add initial testing

Refactor the test suite from your previous _Chirp!_ CLI application.
That is, keep all those test cases around that still apply to the new Razor Page application.
Likely, these are some unit tests and perhaps a few suitable integration tests.
Due to their dependency on CLI parameters and output, the previous end-to-end tests likely do not apply anymore.

Add some new API tests.
These should send `GET` requests to the endpoints for public and private timelines (`/` and  `/<username>` respectively) and assert that certain information is in the HTML text of the response in the HTTP body.
For example, given the [example database dump](./data/dump.sql), a response body for a `GET` request send to `/` shall contain a cheep written by `Helge` and the content of a cheep shall be `Hello, BDSA students!`
Similarly, a response body for a `GET` request send to `/Rasmus` shall contain a cheep written by `Rasmus` with the content `Hej, velkommen til kurset.`


## 2) Process

### 2.a) Move CLI application code to another branch

"Retire" your current _Chirp!_ CLI application that you developed so far, by moving it to another branch that you call `chirp_cli`.

This is not a feature branch as discussed in the _"trunk-based development"_ branching strategy. However, we have to keep it around so that the teachers and censors can assess your project work at the end of the course. You remember that your project work is graded, right.

Your main branch will contain the new Razor Page _Chirp!_ application and associated test suites that you are developing for the next few weeks.

### 2.b) Add Automatic Deployment of Razor Page App

Refactor your GitHub Actions workflows in the main branch so that they build and test the new Razor Page _Chirp!_ application in it.
Additionally , refactor the deployment workflow so that the new Razor Page _Chirp!_ application is deployed to Azure App Service as soon as new working versions are available in the repository's main branch.
Likely the easiest way to configure a respective GitHub Actions workflow, is to refactor the deployment workflow from last [weeks's exercise](../session_04/README_PROJECT.md#2-process).

Make sure that your Razor Page web application is available online under the name `bdsagroup<no>chirprazor`, i.e., that it will be reachable under the URL `https://bdsagroup<no>chirprazor.azurewebsites.net/`.

### 2.c) Start using Pull-requests with code reviews

From now on you switch to using pull-requests for all those features that a subset of the group implemented independently of the rest of the group.

Likely the easiest way to start is to send pull-requests from feature branches to the main branch.
That is, you continue to develop as you did so far in short-lived feature branches but instead of merging these directly into main after completion of a task, you send a pull-request to the main branch.
Those team members that were not part of working on a feature branch perform the code review.
In case they spot things that should be modified or improved they initiate a corresponding discussion.
Once everybody agrees on the state of the feature branch, the pull-request can be merged to main.

Make sure that these code reviews do not block the developing group members.
That is, it should not be performed two days after a pull-request is send but ideally the same day within a maximum of a few hours.


### 2.d) "Proper" pair programming.

From now on, try to be conscious about how you do pair programming.
As described in the lecture, switch roles of driver and navigator every 15/20 minutes.
Commits are done now always by the group member that is currently the driver with correctly attributed co-author.
