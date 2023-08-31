# Your turn now! -- Project Work

<img src="https://media.giphy.com/media/13GIgrGdslD9oQ/giphy.gif" width=50%/>

You have to work on the following four topics.

  - [1) Bureaucracy](#1-bureaucracy)
  - [2) Process](#2-process)
  - [3) Software Development](#3-software-development)
  - [4) Ethics](#4-ethics)

Remember, you have to perform work on each topic and on **each** bullet point.
Be done with the project work before we meet again next Thursday.


## 1) Bureaucracy

* Register your groups in the [shared spreadsheet on Teams](https://ituniversity.sharepoint.com/:x:/r/sites/2023AnalysisDesignandSoftwareArchitecture/Shared%20Documents/General/Groups.xlsx?d=w1bf8302469ea4240b490ba7fb3d23ed3&csf=1&web=1&e=PV8buH)
* Per person, register your ITU login name and your GitHub user name in the [shared spreadsheet on Teams](https://ituniversity.sharepoint.com/:x:/r/sites/2023AnalysisDesignandSoftwareArchitecture/Shared%20Documents/General/ITU_GH_handles.xlsx?d=w8b08c7fa4d584a4a8410ac91b37a077d&csf=1&web=1&e=cQtbc0)


## 2) Process

* Form groups of **five** students, if you are lacking team members, find each other in the first exercise session or use our Teams channel.
* [Create an organization on GitHub](https://docs.github.com/en/organizations/collaborating-with-groups-in-organizations/creating-a-new-organization-from-scratch)
  - The organization has to be named `ITU_BDSA23_GROUP<no>`, where `<no>` is replaced with your group number
  - [Add the five members of your group to that organization](https://docs.github.com/en/organizations/managing-membership-in-your-organization/inviting-users-to-join-your-organization)
* Within the organization, [create a new public repository](https://docs.github.com/en/get-started/quickstart/create-a-repo) called `Chirp`.
* All the project work of the next weeks takes place in this repository.


## 3) Software Development

During the first four weeks of this course, you will create and gradually enhance a first version of a Chirp application.
It will be a command-line application that will be able to display cheeps from and to store cheeps in a local comma-separated-value (CSV) file.
For this weeks, project work do the following:

1. Create a .NET CLI App called `Chirp.CLI` (You may create a new one or reuse your in-class work)
2. The comma-separated-value (CSV) file [`chirp_cli_db.csv`](./chirp_cli_db.csv) is a basic database containing a list of cheeps, their authors, and time of cheep creation.
3. Make your `Chirp.CLI` display all cheeps that are stored in the file by writing them line-wise to stdout (i.e., `Console.WriteLine()`)
  - When your program is called from the command line (either with `Chirp.CLI read` or `dotnet run -- read`) the output should look as in the following:
  ```
  ropf @ 08/01/23 14:09:20: Hello, BDSA students!
  rnie @ 08/02/23 14:19:38: Welcome to the course!
  rnie @ 08/02/23 14:37:38: I hope you had a good summer.
  ropf @ 08/02/23 15:04:47: Cheeping cheeps on Chirp :)
  ```
4. Once display of cheeps from CSV file works, add a second option to your program so that you can store cheeps in the CSV file.
  - Your program shall be called like `Chirp.CLI cheep "Hello, world!"` (or similarly via `dotnet run -- cheep "Hello, world!"`)
  - The cheep message `"Hello, world!"` shall be appended to the CSV file.
  - The author shall be set to the name of the currently logged in user, i.e., the user name from the operating system.
  - The time stamp shall be set to the current Unix time stamp

Note, while developing your program continuously log its evolution via commits, e.g., on commit per item above, and push your work to your remote repository on GitHub.
Remember to register everybody who contributed to a commit as co-authors (via `Co-authored-by:` lines in the commit messages, see lecture slides.)

### Design considerations:

Make this week's version as simple as possible.
That is, apply the [KISS design principle](https://en.wikipedia.org/wiki/KISS_principle), which suggest that _"simplicity should be a key goal in design, and unnecessary complexity should be avoided"_.
Hence, likely all code is organized in `Program.cs`.


### Hints:

* You can create a CLI tool in .NET using [this guide](https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools-how-to-create).
  - Per default, the project template create a _new style `Program.cs`_ file, read more about differences to the _old style_ [here](https://learn.microsoft.com/en-us/dotnet/core/tutorials/top-level-templates)
* [How-to read lines from a text file in C♯?](https://learn.microsoft.com/en-us/dotnet/standard/io/how-to-read-text-from-a-file)
  - When searching the internet on how to parse comma-separated-values from a string in C♯, you will likely find answers like [this one](
   https://stackoverflow.com/a/34265869), which relies on a regular expression.
  - In case you use regular expressions for parsing, read the [corresponding documentation](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex?view=net-7.0).
* [How-to append lines to text files in C♯?](https://learn.microsoft.com/en-us/dotnet/api/system.io.file.appendtext?view=net-7.0)
* You can receive current user names from the operating system via the [`Environment.UserName`](https://learn.microsoft.com/en-us/dotnet/api/system.environment.username?view=net-7.0) property
* The following documentation pages might help you with storing time stamps properly:
  - https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset.utcnow?view=net-7.0
  - https://learn.microsoft.com/en-us/dotnet/api/system.datetimeoffset.tounixtimeseconds?view=net-7.0


## 4) Ethics

The following bullet points hold true for the entire project work during this semester (also for other subjects).

* **Do not** copy source code, documentation, configuration, or any other artifact from other project groups without asking for their permission. This holds for the remainder of the term (and for the remainder of your career).
* **Do not** copy source code, documentation, configuration, or any other artifact from any other sources without being sure that you are allowed to do so.
  - In case you are allowed, then cite the sources of respective artifacts explicitly in your repository by providing links back to the original.
  - The back links have to appear in a separate text file in your repository or directly in the sources as comments.
* In case you are using Large Language Models (LLMs), like ChatGPT, GitHub CodePilot, etc. while creating your solution:
  - Register the respective tool as co-author in the corresponding commits.
  - Make sure that you actually understand what these tools generate and if it is really what you would like to implement as a solution.
  - Make sure that what you receive from these tools is actually .NET 7 code and not code generated for previous versions of the framework.
