# Your turn now! -- Project Work

<img src="https://media.giphy.com/media/13GIgrGdslD9oQ/giphy.gif" width=50%/>

You have to work on the following topics.

  - [1) Process](#1-process)
  - [2) Software Development](#2-software-development)
  - [3) Ethics](#3-ethics)
  - [4) Prepare for next session](#4-prepare-for-next-session)

Remember, you have to perform work on each topic and on **each** bullet point.
Be done with the project work before we meet again next Thursday.


## 1) Process

### 1.a) Automate build, test, and publishing with GitHub Workflows

Add GitHub Actions workflows to your projects.
Likely, you will add two or more of them.

* Start with adding an adapted version of  a [.NET starter workflow](https://github.com/actions/starter-workflows/blob/main/ci/dotnet.yml).
  - When adapting it, make sure that you are using a .NET version 7, the same that we told you to install on your local computers.
  - That workflow shall be executed on all pushes and merge of pull-requests in your repository.
* Add a workflow that releases your `chirp` executable, i.e., a single file .NET application.
  - The workflow should build and test your project whenever you push a new version that is accordingly tagged ([`git tag`](https://git-scm.com/book/en/v2/Git-Basics-Tagging)) to your repository.
  - When all tests pass, create at least three executables of your _Chirp!_ project, one for Windows, one for MacOS, and one for Linux (`<OS>-x64`).
  - If you want to publish an executable for MacOS ARM processors too, publish it as fourth executable.
  - Each executable shall be distributed as compressed with `zip` file.
  - All of the above steps shall be executed in an `ubuntu-latest` environment, i.e., you want to cross-compile for the different targets.
  - Since everybody in this course has .NET 7 installed it is sufficient to publish a platform-dependent single file application, i.e., not a self-contained application.

### Hints:

* Likely you can combine the building blocks from the lecture notes and the reading material into a working solution.
* To publish a release of your project, you might want to use the [`softprops/action-gh-release` action](https://github.com/softprops/action-gh-release)
* You might use this [blog post](https://patriksvensson.se/posts/2020/03/creating-release-artifacts-with-github-actions) for inspiration on how to create releases for various operating systems. Note though, that you want to build in one environment (`ubuntu-latest`) instead of three as in the given example, i.e., you do not need a build matrix.
* To allow a GitHub action to create releases, you have to grant it write access. You do that on GitHub in your repository under `Settings` → `Actions` → `General` under `Workflow permissions` enable `"Read and write permissions"`, see the [official documentation](https://docs.github.com/en/repositories/managing-your-repositorys-settings-and-features/enabling-features-for-your-repository/managing-github-actions-settings-for-a-repository#setting-the-permissions-of-the-github_token-for-your-repository)

### 1.b) Automate certain project management tasks

Using GitHub Actions, you can [automate certain tasks](https://docs.github.com/en/actions/managing-issues-and-pull-requests/using-github-actions-for-project-management), like [adding labels to issues](https://docs.github.com/en/actions/managing-issues-and-pull-requests/adding-labels-to-issues), [moving labels to project board columns on state change](https://docs.github.com/en/actions/managing-issues-and-pull-requests/moving-assigned-issues-on-project-boards), etc.
Choose some of these project management tasks that you deem suitable and automate the with GitHub Actions workflow.

### 1.c) Enable automatic code formatting

Make sure that everybody in the team formats code whenever it is edited with VSCode.
The editor supports this by default, the [respective configuration needs to be activated](https://code.visualstudio.com/updates/v1_6#_format-on-save).


## 2) Software Development

### 2.a) Software Testing

* Restructure your current project so that the _Chirp!_ application and the CSV database library reside under a `src/` directory
  - Hint: use `git mv` to move files and directories while restructuring.
* Create XUnit .NET test projects, see `dotnet new list` in a `test` directory that is in the root of your project, see e.g., page 880 of A. Lock _ASP.NET Core in Action, Third Edition_.
  - That is, one test project that tests your _Chirp!_ CLI app and a second one that tests your CSV database library project.
* Make your test projects depend on the respective system under test (SUT).
  -  That is, add a reference from each of the two test projects to either the _Chirp!_ CLI app or to the CSV database library project with the [`dotnet add reference`](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-add-reference) command.
* Add unit tests to your _Chirp!_ CLI app.
  -  Add unit tests for suitable functionality. For example, conversion of UNIX timestamps to user readable times and similar functionality are good candidates for unit testing.
* Add integration tests that test your CSV database library works as intended.
  - For example, add a test case that checks that an entry can be received from the database after it was stored in there.
* Add two end-to-end tests that test your _Chirp!_ CLI app:
  - For example, you want to test that given example data from [`chirp_cli_db.csv`](../session_01/chirp_cli_db.csv) calling `chirp read 10` from the command line produces output as in the following:
    ```
    ropf @ 08/01/23 14:09:20: Hello, BDSA students!
    rnie @ 08/02/23 14:19:38: Welcome to the course!
    rnie @ 08/02/23 14:37:38: I hope you had a good summer.
    ropf @ 08/02/23 15:04:47: Cheeping cheeps on Chirp :)
    ```
  - Additionally, you want to test that calling `chirp cheep "Hello!!!"` stores the respective values in the database.

### 2.b) Software Design

We want to be able to express and to assure that there is at any given point in time only one CSV database on our system.
That is we want to couple the database CSV file on the file system to a singleton object in our software.
Consequently, refactor your `CSVDatabase` class that is responsible for `Read`ing cheeps from and `Store`ing cheeps to a CSV file to be a _singleton_.
That is, make it adhere to the singleton design pattern.
Likely, it is a good idea to skim the various implementations that are presented in [C♯ in Depth](https://csharpindepth.com/Articles/Singleton) and to adapt a suitable version for your implementation.
For this session, it is not yet necessary that your implementation is thread-safe.


## 3) Ethics

Now that you test and build your software with GitHub Actions, consider if want to share telemetry data with Microsoft. Per default, Microsoft collects data about many actions that you perform using their tools, see e.g., https://learn.microsoft.com/en-us/dotnet/core/tools/telemetry and https://dotnet.microsoft.com/en-us/platform/telemetry.

Remember, that you can disable telemetry when using the `dotnet` command by creating an environment variable set to true before invoking any `dotnet` commands:

  * `DOTNET_CLI_TELEMETRY_OPTOUT=1` or
  * `DOTNET_CLI_TELEMETRY_OPTOUT=true`

See the [official documentation](https://docs.github.com/en/actions/learn-github-actions/variables) to see how to define respective environment variables in GitHub Actions workflows.


## 4) Prepare for next session

Next session, we need that you are signed-up to Microsoft's cloud-service platform, which is called _Azure_.

- To sign up to Azure with free student credits, follow [this guide](https://app.tango.us/app/workflow/Steps-to-Sign-Up-for-Azure-with-Student-Mail-285020aa8d76412eada4b6915b695de2)
  - Note, follow mainly what is illustrated on the image. Except of the first link, you will just navigate through the illustrated flow of actions.
  - OBS: of course fill in your name, birthday, email address, etc.
- Thereafter, [install the Azure CLI client](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli) before class.
  - Make sure that you can login and out to Azure from the command-line via `az login` and `az logout` respectively.
* Verify that you can log onto <https://portal.azure.com/#home> with your ITU credentials.
