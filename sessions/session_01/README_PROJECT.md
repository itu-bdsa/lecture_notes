# Your turn now! -- Project Work

<img src="https://media.giphy.com/media/13GIgrGdslD9oQ/giphy.gif" width=50%/>

You have to work on the following four topics.

  - [1) Bureaucracy](#1-bureaucracy)
  - [2) Process](#2-process)
  - [3) Software Development](#3-software-development)
  - [4) Ethics](#4-ethics)

Remember, you have to perform work on each topic and on **each** bullet point.
Be done with the project work before we meet again next week.


## 1) Bureaucracy

* Register your groups in the [shared spreadsheet on Teams](https://ituniversity.sharepoint.com/:x:/r/sites/2025AnalysisDesignandSoftwareArchitecture/Shared%20Documents/General/Groups.xlsx?d=wba26ee18e8af4a74930ed5337ed38d77&csf=1&web=1&e=2o55hB)
* Per person, register your ITU login name and your GitHub user name in the [shared spreadsheet on Teams](https://ituniversity.sharepoint.com/:x:/r/sites/2025AnalysisDesignandSoftwareArchitecture/Shared%20Documents/General/Github-Handles.xlsx?d=wbd422f0b26604f2e938b7180556c50a4&csf=1&web=1&e=jMvbvH)


## 2) Process

* Form groups of **five** students, if you are lacking team members, find each other in the first exercise session or use our Teams channel.
* [Create an organization on GitHub](https://docs.github.com/en/organizations/collaborating-with-groups-in-organizations/creating-a-new-organization-from-scratch)
  - The organization has to be named `ITU-BDSA2025-GROUP<no>`, where `<no>` is replaced with your group number
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
  adho @ 08/02/23 14:19:38: Welcome to the course!
  adho @ 08/02/23 14:37:38: I hope you had a good summer.
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
  - Make sure that what you receive from these tools is actually .NET 8 code and not code generated for previous versions of the framework.
* Consider if you really want to use an LLM, they burn a lot of energy, their basis is ethically questionable, and they are bullshitting:
  - > [...] bare én ordre - eller 'prompt' - til ChatGPT koster det samme i energi som 40 opladninger af en mobiltelefon.
    >
    > "Hvis folk ved, hvad det koster af energi at interagere med ChatGPT, så tror jeg, det vil have en betydning for ens valg og gøre, at man ændrer adfærd", siger Raghavendra Selvan.
    >
    > For samme mængde strøm kan man streame en times Netflix eller køre en kilometer i elbil, oplyser ingeniørforeningen IDA. Konkret koster én prompt i ChatGPT i gennemsnit 0,19 kWh, viser beregningerne. Til sammenligning koster én søgning på Google 0,0003 kWh, [...]
    >
    > ["Chatbots sviner klimaet" - dr.dk](https://www.dr.dk/nyheder/viden/teknologi/chatbots-sviner-klimaet-kaempe-datacentre-kan-om-faa-aar-sluge-hele-japans)
  - > " Vi bliver bedt om at ignorere det faktum, at udviklingen af kunstig intelligens allerede skaber [umådelig skade på miljøet](https://disconnect.blog/generative-ai-is-a-climate-disaster/). Computerkraften afhænger af konfliktmineraler fra minearbejdere fanget i [moderne slaveri](https://books.google.dk/books/about/The_Atlas_of_AI.html?id=KfodEAAAQBAJ&redir_esc=y)). Træningen af algoritmerne foregår ved tyveri af [kunstnere og forskeres arbejde](https://arxiv.org/abs/2401.06178) og ved at udnytte en stor global underklasse af [spøgelsesarbejdere](https://www.ghostwork.org/), der har til opgave at finjustere modellerne under uretfærdige, [ofte traumatiserende](https://www.theguardian.com/technology/2023/aug/02/ai-chatbot-training-human-toll-content-moderator-meta-openai) forhold.
    >
    > Og hvad bliver vi tilbudt til gengæld? En teknologi med så tvivlsom nytteværdi og lav pålidelighed, at dens output omtales som [»blødt bullshit«](https://link.springer.com/article/10.1007/s10676-024-09775-5) af akademikere"
    > ["KU skal ikke æde 'AI'-bullshit" - uniavisen.dk](https://uniavisen.dk/ku-skal-ikke-aede-ai-bullshit/)
  - > "Investors, policymakers, and members of the general public make decisions on how to treat these machines and how to react to them based not on a deep technical understanding of how they work, but on the often metaphorical way in which their abilities and function are communicated. Calling their mistakes ‘hallucinations’ isn’t harmless: it lends itself to the confusion that the machines are in some way misperceiving but are nonetheless trying to convey something that they believe or have perceived. This, as we’ve argued, is the wrong metaphor. The machines are not trying to communicate something they believe or perceive. Their inaccuracy is not due to misperception or hallucination. As we have pointed out, they are not trying to convey information at all. They are bullshitting.
    > [Hicks, M. T., Humphries, J., & Slater, J. (2024). _ChatGPT is bullshit._ Ethics and Information Technology, 26(2), 38.](https://link.springer.com/article/10.1007/s10676-024-09775-5)
