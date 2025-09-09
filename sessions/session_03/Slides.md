---
theme: gaia
_class: lead
paginate: true
backgroundColor: #fff
backgroundImage: url('https://marp.app/assets/hero-background.svg')
headingDivider: 2
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

# **Analysis, Design and Software Architecture (BDSA)**
Week 3
[Eduard Kamburjan](eduard.kamburjan@itu.dk)


## Plan for this week

  - Intro to testing, unit testing, integration and end-to-end testing
  - Testing processes and patterns 
  - Continuous build and testing with GitHub Actions workflows


<!-- first hour -->
## Intro to Testing

### Why shall we test at all?

 - Testing is about increasing confidence in the software quality of our software product

*  > Testing is intended to show that a program does what it is intended to do and to discover program defects before it is put into use. (Source: <a href="https://www.pearson.com/en-gb/subject-catalog/p/software-engineering-global-edition/P200000005464/9781292096148">Ian Sommerville <i>Software Engineering</i></a>)

* > [Software Quality...] degree to which a software product satisfies stated and implied needs when used under specified conditions
(Source: <a href="https://www.iso.org/obp/ui/#iso:std:iso-iec:25010:ed-1:v1:en">International Organization for Standardization <i>Systems and software engineering — System and software quality models</i></a>)

* > [Software Quality...] degree to which a software product meets established requirements (Source: <a href="https://standards.ieee.org/standard/730-2014.html"><i>IEEE 730-2014 IEEE Standard for Software Quality Assurance Processes</i></a>)

---



### Why shall we test?

  - Importance of testing less obvious than expected

  > GWS is the web server responsible for serving Google Search queries and is as important to Google Search as air traffic control is to an airport. Back in 2005 [...] releases were becoming buggier, and it was taking longer and longer to push them out. Team members had little **confidence* when making changes to the service, and often found out something was wrong only when features stopped working in production. (**At one point, more than 80% of production pushes contained user-affecting bugs that had to be rolled back.**)
  > ...
  > To address these problems, the tech lead decided to institute a policy of engineer-driven, automated testing. As part of this policy, **all new code changes were required to include tests, and those tests would be run continuously**. Within a year of instituting this policy, the **number of emergency pushes dropped by half**. This drop occurred despite a record number of new changes every quarter.
(Source: <a href="https://abseil.io/resources/swe-book/html/ch11.html">T. Winters et al. <i>Software Engineering at Google</i></a>)

---
### Resistance against testing


* - Only ~750 of the considered ~3000 android app repositories had non-default tests 
  - ("An Empirical Investigation of Android App Testing Practices", Mahmud et al., 2024)

* Quality is invisible: costs of testing are visible and tangible, benefit is counterfactual
* Typical situation: Crisis hits, quality measures are put in place, people wonder why quality measures cost so much but give so little benefit, quality measures are reduced, etc.
* Not specific to software or testing, but general project management paradox

* > Common demotivating factors are higher prioritized tasks, bad communication, and missing recognition. [...]
* > Developers claim they would write more tests to ensure quality and increase personal satisfaction, but would like to receive better recognition for this. On the other hand, many developers want to test less than they currently do since they perceive testing as boring compared to other tasks. 
  - ("A Survey on What Developers Think About Testing, Straubinger and Fraser, 2023")

---

### What are tests?

  > The simplest test is defined by:
  > -  A single behavior you are testing, usually a method or API that you are calling
  > - A specific input, some value that you pass to the API
  > - An observable output or behavior
  > - A controlled environment such as a single isolated process(
Source: <a href="https://abseil.io/resources/swe-book/html/ch11.html">T. Winters et al. <i>Software Engineering at Google</i></a>)

 - One test case has 
   1. An input for the SUT
   2. A verdict or oracle for the output of the SUT
   3. A setup around the SUT
 - A test suite is a set of test cases
 - Test suites may be automated and structured

---

### White-box and black-box testing (Repetition)


* > _White-box_ testing, sometimes called structural testing or internal testing, **focuses on the text of the program**. The tester constructs a test suite [...] that demonstrates that all branches of the program’s choice and loop constructs — `if`, `while`, `switch`, `try`-`catch`-`finally`, and so on — can be executed. The test suite is said to cover the statements of the program.
  >
  > _Black-box_ testing, sometimes called external testing, **focuses on the problem that the program is supposed to solve**; or more precisely, the problem statement or specification for the program. The tester constructs a test data set that includes ‘typical’ as well as ‘extreme’ input data. In particular, one must include inputs that are described as exceptional or erroneous in the problem description.(
Source: <a href="https://learnit.itu.dk/mod/resource/view.php?id=151551">P. Sestoft <i>Software Testing</i></a>)




## Task: Your first .NET Unit Tests

<style scoped>
section {
  font-size: 24px;
}
</style>

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 15 minutes
-->

- Clone the .NET example repository: `git clone --depth 1 https://github.com/dotnet/samples.git dotnet_samples`
- Change directory to a unit test example: `cd dotnet_samples/core/getting-started/unit-testing-using-dotnet-test/`
  - If you have .Net 8 installed, change line 7 in `PrimeService.Tests/PrimeService.Tests.csproj` to `<TargetFramework>net8.0</TargetFramework>`.
-  Execute the tests suite with `dotnet test`. What do you see?

Now:
- Inspect the system under test (SUT) in `PrimeService/PrimeService.cs`
- Inspect the corresponding unit tests in `PrimeService.Tests/PrimeService_IsPrimeShould.cs`


Finally and based on your inspections answer the question:

_What is the "unit" in unit testing?_


## Unit Tests for _Chirp!_

Unpublished demo: `Chirp.Demo/tests/`

<!-- second hour -->

## Integration Tests

![bg right:50% 100%](https://twilio-cms-prod.s3.amazonaws.com/images/MyR86UeunZJcErQJmlEoEwWpAt56uIH2k2mHFqfsA95S2R.width-500_NbXJ1BV.png)

  > In contrast to unit tests, integration tests:
  >
  > - Use the actual components that the app uses in production.
  > - Require more code and data processing.
  > - Take longer to run.
(Source: <a href="https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-7.0">Jos van der Til et al.</a>)


## Integration Tests

  > Integration tests check whether different chunks of code are interacting successfully in a local environment. A “chunk of code” can manifest in many ways, but **generally integration tests involve verifying service/API interactions**. Since integration tests are generally local, you may need to mock different services. 
  (Source: <a href="https://www.twilio.com/blog/unit-integration-end-to-end-testing-difference">M. Tran from Twillio</a>)


  > Integration tests possess the next level of complexity in the testing pyramid. They are more complex than the unit tests because you need to **handle code block dependency**. You are testing how a code snippet (the method most of the time) depends on another method to run and pass some value to it.
  >
  > [...] there is no special syntax to do it. **It’s the same syntax used in unit tests**. It’s just called integration since it’s testing code that depends on another.
  (Source: <a href="https://moduscreate.com/blog/an-overview-of-unit-integration-and-e2e-testing/">Modus Create</a>)


## Integration Tests for _Chirp!_


Unpublished demo: `Chirp.Demo/tests/`


## End-to-end (E2E) Tests

  > End-to-End tests, or E2E tests, are a way of **verifying your code’s deployed behavior from a user perspective**. You automate a user simulation that interacts with your system as a black box, so all that matters is whether the user’s actions correspond to the correct output in a timely manner. These tests are typically done in a dev or staging environment, in order to match the production user interactions as closely as possible.
(Source: <a href="https://www.twilio.com/blog/unit-integration-end-to-end-testing-difference">M. Tran from Twillio</a>)


  > End-to-end (E2E) testing is a Software testing methodology to **test a functional and data application flow consisting of several sub-systems working together from start to end**.
  >
  > At times, these systems are developed in different technologies by different teams or organizations. Finally, they come together to form a functional business application. Hence, testing a single system would not suffice. Therefore, end-to-end testing verifies the application from start to end putting all its components together. 
(Source: <a href="https://microsoft.github.io/code-with-engineering-playbook/automated-testing/e2e-testing/">Code With Engineering Playbook</a>)



## End-to-end (E2E) Tests of C♯ CLI Programs

Unpublished demo: `Chirp.Demo/tests/`

```csharp
  [Fact]
  public void TestReadTenCheeps()
  {
      // Arrange
      var args = new string[] { "read", "10" };
      // Act
      var result = Program.Main(args);
      // Assert
      Assert.Equal(0, result);
  }
```

<font size=3>
See for <a href="https://darthpedro.net/2021/02/15/lesson-1-10-cli-end-to-end-tests/">example</a>
</font> 


## End-to-end (E2E) Tests of Arbitrary CLI Programs

<style scoped>
pre {
   font-size: 18px;
}
</style>

```csharp
public class End2End
{
    [Fact]
    public void TestReadCheep()
    {
        // Arrange
        ArrangeTestDatabase();
        // Act
        string output = "";
        using (var process = new Process())
        {
            process.StartInfo.FileName = "/usr/bin/dotnet";
            process.StartInfo.Arguments = "./src/Chirp.CLI.Client/bin/Debug/net8.0/chirp.dll read 10";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.WorkingDirectory = "../../../../../";
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            // Synchronously read the standard output of the spawned process.
            StreamReader reader = process.StandardOutput;
            output = reader.ReadToEnd();
            process.WaitForExit();
        }
        string fstCheep = output.Split("\n")[0];
        // Assert
        Assert.StartsWith("ropf", fstCheep);
        Assert.EndsWith("Hello, World!", fstCheep);
    }
}
```

(See for <a href="https://darthpedro.net/2021/02/15/lesson-1-10-cli-end-to-end-tests/">example</a>)




## Fluent Assertions

- Above assertions in test cases are unintuitive to read
- Might be a problem if customers need to understand them
- One possibility: [Fluent Assertions](https://fluentassertions.com/).

```csharp
using FluentAssertions;

string actual = "ABCDEFGHI";
actual.Should().StartWith("AB").And.EndWith("HI").And.Contain("EF").And.HaveLength(9);
```


```csharp
IEnumerable<int> numbers = new[] { 1, 2, 3 };

numbers.Should().OnlyContain(n => n > 0);
numbers.Should().HaveCount(3, "because we put three items in the collection");
```

(Source: <a href="https://fluentassertions.com/introduction">Fluent Assertions Documentation</i></a>)

---

### Recommended distribution of tests

![](https://abseil.io/resources/swe-book/html/images/seag_1104.png)

(Source: <a href="https://abseil.io/resources/swe-book/html/ch11.html">T. Winters et al. <i>Software Engineering at Google</i></a>)

---

### Test suite anti-pattern

![w:768](https://abseil.io/resources/swe-book/html/images/seag_1105.png)


(Source: <a href="https://abseil.io/resources/swe-book/html/ch11.html">T. Winters et al. <i>Software Engineering at Google</i></a>)






## Recommendation: TDD — Red Green Refactor

<!--
_backgroundImage: "linear-gradient(to bottom, #e18ac2, #d112a5)"
_color: white
-->

> **Red Green Refactor**
> When engaging in test-driven development, follow the Red Green Refactor process. You can think of it as a checklist:
> 1. Write a failing test.
>     - Did you run the test?
>     - Did it fail?
>     - Did it fail because of an assertion?
>     - Did it fail because of the last assertion?
> 2. Make all tests pass by doing the simplest thing that could possibly work.
> 3. Consider the resulting code. Can it be improved? If so, do it, but make sure that all tests still pass.
> 4. Repeat.
(Source: <a href="https://blog.ploeh.dk/2021/06/14/new-book-code-that-fits-in-your-head/">Mark Seemann <i>Code That Fits in Your Head</i></a>)




## How to organize code in projects?

<style scoped>
pre {
   font-size: 16px;
}
</style>

One way could be to just put all .NET projects in the root of your repository, but don't do it.
```
.
├── Chirp_session_03.sln
├── data
│   └── chirp.csv
├── LICENSE
├── Makefile
├── README.md
├── scripts
│   └── initDB.sh
├── Chirp.CLI.Client
│   ├── Chirp.CLI.Client.csproj
│   ├── Program.cs
│   └── UserInterface.cs
├── Chirp.CSVDB
│   ├── Chirp.CSVDB.csproj
│   └── Database.cs
├── Chirp.CLI.Client.Tests
│   ├── Chirp.CLI.Client.Tests.csproj
│   ├── End2EndTests.cs
│   ├── IntegrationTests.cs
│   ├── UnitTests.cs
│   └── Usings.cs
└── Chirp.CSVDB.Tests
    ├── Chirp.CSVDB.Tests.csproj
    ├── IntegrationTest.cs
    └── Usings.cs
```

(Source: <a href="https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test">Unit testing C♯ in .NET Core using dotnet test and xUnit</a>)


## Recommended way to organize code in projects

<style scoped>
pre {
   font-size: 18px;
}
</style>

```
.
├── Chirp_session_03.sln
├── data
│   └── chirp.csv
├── LICENSE
├── Makefile
├── README.md
├── scripts
│   └── initDB.sh
├── src
│   ├── Chirp.CLI.Client
│   │   ├── Chirp.CLI.Client.csproj
│   │   ├── Program.cs
│   │   └── UserInterface.cs
│   └── Chirp.CSVDB
│       ├── Chirp.CSVDB.csproj
│       └── Database.cs
└── test
    ├── Chirp.CLI.Client.Tests
    │   ├── Chirp.CLI.Client.Tests.csproj
    │   ├── End2EndTests.cs
    │   ├── IntegrationTests.cs
    │   ├── UnitTests.cs
    │   └── Usings.cs
    └── Chirp.CSVDB.Tests
        ├── Chirp.CSVDB.Tests.csproj
        ├── IntegrationTest.cs
        └── Usings.cs
```

(Source: <a href="">A. Lock <i>ASP.NET Core in Action</i>Third Edition</a>, <a href="https://learn.microsoft.com/en-us/dotnet/core/tutorials/testing-with-cli">Organizing and testing projects with the .NET CLI</a>)


## Refactoring a project to support tests


|:warning:| Remember to use `git mv` instead of moving files directly when moving code around during refactoring. Otherwise, your version control gets confused.|
|-----|------------------------------------|



<!-- Third hour -->

## Testing and processes?
 - Where do all the tests come from?
 - How to they interact with processes?
 - How do we integrate them with our programming workflows?


---
### Test-driven Development (TDD)

![](images/SE_TDD.png)

(Source: <a href="https://www.pearson.com/en-gb/subject-catalog/p/software-engineering-global-edition/P200000005464/9781292096148">Ian Sommerville <i>Software Engineering</i></a>)


 - In this course, we do not follow TDD, i.e., we do not require you to _first_ write tests that fail, which you then implement to make them pass.

 - However, we require that you from now on implement tests along side your solution. 

 - Test cases may evolve together with the feautre they test

---
### Acceptance Test-driven Development (ATDD)

 - Test cases are understable by costumer and connected to requirements
 - Not a full test suite, can only operate on API
 - Understandability hard to achieve, consider Fluent Assertions
 - Similar to _conformance testing_ 
   - Often used to demonstrate that a software product adheres to some standard
   - Conformance test suites come from standardization documents
   - ATDD test suites are specific to development project

---
### Regression Testing

> Yes, I know, it’s just a simple function to display a window, but it has grown little hairs and stuff on it and nobody knows why. Well, I’ll tell you why: those are bug fixes.
> One of them fixes that bug that Nancy had when she tried to install the thing on a computer that didn’t have Internet Explorer. 
> Another one fixes that bug that occurs in low memory conditions. 
> Each of these bugs took weeks of real-world usage before they were found. 
(Source: <a href="https://www.joelonsoftware.com/2000/04/06/things-you-should-never-do-part-i/">Joel Spolsky</a>)

 - Turn your bugs into test cases so you do not reintroduce them (= regress)
 - Bug fixes may be ugly code, very tempting to remove them while refactoring


## Recommendations for Testing

<!--
_backgroundImage: "linear-gradient(to bottom, #e18ac2, #d112a5)"
_color: white
-->

<style scoped>
pre {
   font-size: 18px;
}
section {
  font-size: 22px;
}
</style>

- > **Arrange Act Assert**
  >
  > Structure automated tests according to the Arrange Act Assert pattern. Make it clear to readers where one section ends and the next begins.
(Source: <a href="https://blog.ploeh.dk/2021/06/14/new-book-code-that-fits-in-your-head/">Mark Seemann <i>Code That Fits in Your Head</i></a>)

  ```csharp
    [Fact]
    public void NinetynineIsNotPrime()
    {
        // Arrange
        var input = 99;
        // Act
        var result = _primeService.IsPrime(input);
        // Assert
        Assert.False(result);
    }
  ```


* > **Reproduce Defects as Tests**
  >
  > If at all possible, reproduce bugs as one or more automated tests.
(Source: <a href="https://blog.ploeh.dk/2021/06/14/new-book-code-that-fits-in-your-head/">Mark Seemann <i>Code That Fits in Your Head</i></a>)


## Testing stages - Who is testing?


  1. Development testing, where the system is tested during development to discover bugs and defects. System designers and programmers are likely to be involved in the testing process.
  
  2. Release testing, where a separate testing team tests a complete version of the system before it is released to users. The aim of release testing is to check that the system meets the requirements of the system stakeholders.
  
  3. User testing, where users or potential users of a system test the system in their own environment. For software products, the “user” may be an internal marketing group that decides if the software can be marketed, released and sold. Acceptance testing is one type of user testing where the customer formally tests a system to decide if it should be accepted from the system supplier or if further development is required.


(Source: <a href="https://www.pearson.com/en-gb/subject-catalog/p/software-engineering-global-edition/P200000005464/9781292096148">Ian Sommerville <i>Software Engineering</i></a>)

## Other testing consideration
- Tests must be independent of each other
  - Order should not matter
  - Test harness should reset the state after each test case

- Functional tests are about expected functionality (input/output, expected behavior)
- You may have tests for non-functional properties: resource usage, scalability
- Automate, automate, automate
<!-- ---------------------------------------------------------------------- -->
<!-- Fourth hour -->

## Process: GitHub Actions Workflows

<!-- - For building software
- For testing software
- For automating project boards and issue tracking
- For merging to main -->

Last time, we were discussing how to build .NET/C♯ software locally on your computers. There is a problem with this: _"It builds on my computer!?"_

That can be solved by having the same build and test environment for the entire team.

Build systems, such as, GitHub Actions, attempt to "abstract away" the environment by establishing one build environment for the entire development team.


## GitHub Actions

> GitHub Actions is a continuous integration and continuous delivery (CI/CD) platform that allows you to automate your build, test, and deployment pipeline. You can create workflows that build and test every pull request to your repository, or deploy merged pull requests to production.
(Source: <a href="https://docs.github.com/en/actions/learn-github-actions/understanding-github-actions">GitHub Docs</a>)


> A workflow is a configurable automated process that will run one or more jobs. Workflows are defined by a YAML file checked in to your repository and will run when triggered by an event in your repository, or they can be triggered manually, or at a defined schedule.
(Source: <a href="https://docs.github.com/en/actions/using-workflows/about-workflows">GitHub Docs</a>
Image Source: <a href=" https://learn.microsoft.com/en-us/training/modules/introduction-to-github-actions/3-explore-actions-flow">Microsoft Training Material</a>)

![bg right:35% 90%](https://learn.microsoft.com/en-us/training/wwl-azure/introduction-to-github-actions/media/actions-structure-1b8448db.png)

---

### Alternatives to GitHub Actions

- Self-hosted most often in bigger organizations and companies:
  - [Jenkins](https://jenkins.io/index.html)
  - [Bamboo](https://www.atlassian.com/software/bamboo)
  - [TeamCity](https://www.jetbrains.com/teamcity/)
  - [Concourse](https://concourse.ci)
  - [Azure DevOps Server](https://azure.microsoft.com/en-us/services/devops/server/)

- Build systems as a service:
  - [Travis CI](https://travis-ci.org/)
  - [CircleCI](https://circleci.com)
  - [Wercker](http://www.wercker.com)
  - [Azure Pipelines](https://azure.microsoft.com/en-in/products/devops/pipelines/)


## Task: Add a workflow to your project

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 10 minutes
-->

- Navigate your browser to the [Quickstart for GitHub Actions](https://docs.github.com/en/actions/quickstart) article.
- Perform the steps described in the tutorial.

```yaml
name: GitHub Actions Demo
run-name: ${{ github.actor }} is testing out GitHub Actions 🚀
on: [push]
jobs:
  Explore-GitHub-Actions:
    runs-on: ubuntu-latest
    steps:
      - run: echo "🎉 The job was automatically triggered by a ${{ github.event_name }} event."
      - run: echo "🐧 This job is now running on a ${{ runner.os }} server hosted by GitHub!"
      - run: echo "🔎 The name of your branch is ${{ github.ref }} and your repository is ${{ github.repository }}."
      - name: Check out repository code
        uses: actions/checkout@v3
      - run: echo "💡 The ${{ github.repository }} repository has been cloned to the runner."
      - run: echo "🖥️ The workflow is now ready to test your code on the runner."
      - name: List files in the repository
        run: |
          ls ${{ github.workspace }}
      - run: echo "🍏 This job's status is ${{ job.status }}."
```

---

### GitHub Actions

  > - GitHub tracks events that occur. Events can trigger the start of workflows.
  >
  > - Workflows can also start on cron-based schedules and can be triggered by events outside of GitHub.
  >
  > - They can be manually triggered.
  >
  > - Workflows are the unit of automation. They contain Jobs.
  >
  > - Jobs use Actions to get work done.
  > 
(Source: <a href="https://learn.microsoft.com/en-us/training/modules/introduction-to-github-actions/">GitHub Docs</a>)

---

### GitHub Actions Workflows

<style scoped>
section {
  font-size: 21px;
}
</style>

  > Workflows include several standard syntax elements.
  >
  >  **Name**: is the name of the workflow. It's optional but is highly recommended. It appears in several places within the GitHub UI.
  >
  >  - **On**: is the event or list of events that will trigger the workflow.
  >
  >  - **Jobs**: is the list of jobs to be executed. Workflows can contain one or more jobs.
  >
  >  - **Runs-on**: tells Actions which runner to use.
  >
  >  - **Steps**: It's the list of steps for the job. Steps within a job execute on the same runner.
  >
  >  - **Uses**: tells Actions, which predefined action needs to be retrieved. For example, you might have an action that installs node.js.
  >
  >  - **Run**: tells the job to execute a command on the runner. For example, you might execute an NPM command.
(Source: <a href="https://learn.microsoft.com/en-us/training/modules/introduction-to-github-actions/5-describe-standard-workflow-syntax-elements">GitHub Docs</a>)


---

### GitHub Actions Workflow Syntax

A more thorough description of GitHub Actions workflow syntax: <https://docs.github.com/en/actions/using-workflows/workflow-syntax-for-github-actions>

<!-- https://www.jenkins.io/doc/book/pipeline/jenkinsfile/#using-a-jenkinsfile -->

---

### GitHub Actions Events

- Scheduled events
- Code events
- Manual events
- Webhook events
- External events

(Source: <a href="https://docs.github.com/actions/learn-github-actions/events-that-trigger-workflows">GitHub Docs</a>)

---

### GitHub Actions Jobs

  > By default, if a workflow contains multiple jobs, they run in parallel.


`needs` allows to define an order between jobs:

```yaml
jobs:
  startup:
    runs-on: ubuntu-latest
    steps:

      - run: ./setup_build_env.sh
  build:
    needs: startup
    steps:

      - run: ./build.sh
```

(Source: <a href="https://learn.microsoft.com/en-us/training/modules/introduction-to-github-actions/7-explore-jobs">GitHub Docs</a>)


---

### GitHub Actions Runners

  > When you execute jobs, the steps execute on a Runner.
  >
  > The steps can be the execution of a shell script or the execution of a predefined Action.
  >
  > GitHub provides several hosted runners to avoid you needing to spin up your infrastructure to run actions.
  >
  > Now, the maximum duration of a job is 6 hours, and for a workflow is 72 hours.
  >
(Source: <a href="https://learn.microsoft.com/en-us/training/modules/introduction-to-github-actions/8-explore-runners">Microsoft Docs</a>)

<!-- TODO: Add note on allowing GH Actions to write for releases Settings -> Actions -> General -> Workflow permissions enable "Read and write permissions" -->

---

### GitHub Actions Starter Workflows

<style scoped>
pre {
   font-size: 20px;
}
</style>

```yaml
name: .NET Build and Test

on:
  push:
    branches: [ $default-branch ]
  pull_request:
    branches: [ $default-branch ]

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v3
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: 8.0.x
    - name: Restore dependencies
      run: dotnet restore
    - name: Build
      run: dotnet build --no-restore
    - name: Test
      run: dotnet test --no-build --verbosity normal
```

(Source: Adapted from <a href="https://github.com/actions/starter-workflows/blob/main/ci/dotnet.yml">GitHub Actions Starter Workflows</a>)

## Task: Add a .NET Build and Test Workflow to Your Project

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
__header: 15 minutes
-->
- Add the test and build workflow to the local `.github/workflows` directory, e.g., as `build_and_test.yml`.
- Add it to version control and push it to GitHub.
- Observe on `https://github.com/ITU-BDSA2025-GROUP<no>/Chirp/actions` if your project can be build and passes the tests. If not, understand with the logs what is not working.

<style scoped>
pre {
   font-size: 12px;
}
section {
  font-size: 23px;
}
</style>

```yaml
name: .NET Build and Test

on:
  push:
    branches: [ $default-branch ]
  pull_request:
    branches: [ $default-branch ]

jobs:
  build:
    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v3
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: 8.0.x
    - name: Restore dependencies
      run: dotnet restore
    - name: Build
      run: dotnet build --no-restore
    - name: Test
      run: dotnet test --no-build --verbosity normal
```


<!-- ---------------------------------------------------------------------- -->
## Semantic Versioning

![bg right:40% 100% ](https://miro.medium.com/v2/resize:fit:720/format:webp/1*7h56wnp4mqlOqRm4aF9cTQ.png)

  > Given a version number MAJOR.MINOR.PATCH, increment the:
  >
  >   MAJOR version when you make incompatible API changes
  >   MINOR version when you add functionality in a backward compatible manner
  >   PATCH version when you make backward compatible bug fixes
  >
  > Additional labels for pre-release and build metadata are available as extensions to the MAJOR.MINOR.PATCH format.
(Source: <a href="https://semver.org/">Semantic Versioning Specification</i></a>)

(Image source: <a href="https://blog.greenkeeper.io/introduction-to-semver-d272990c44f2">I. J. Gebauer<i>Introduction to SemVer</i></a>)
<!-- ---------------------------------------------------------------------- -->


<!--## Design: The Singleton Design Pattern
-->

<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->


<!--@Helge: Explain the purpose on the black board and illustrate with example from _Chirp!_ implementation.
-->



## Design: The Singleton Design Pattern

<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

We want to assure that not every time we ask a `Database` object, we are overwriting the underlying data store, i.e., the corresponding CSV file.

![bg right:45% 100%](https://refactoring.guru/images/patterns/diagrams/singleton/structure-en-2x.png?id=cae4853e43f06db09f249668c35d61a1)

  > The Singleton class declares the static method `getInstance` that returns the same instance of its own class.
  >
  > The Singleton’s constructor should be hidden from the client code. Calling the `getInstance` method should be the only way of getting the Singleton object.
(Source: <a href="https://refactoring.guru/design-patterns/singleton">A. Shvets <i>Dive Into DESIGN PATTERNS</i></a>)


## Summary

 - Testing, building
 - What now?
   - If not done, complete the Tasks (blue slides) from this class
   - Check the [reading material](./READING_MATERIAL.md) 
   - Work on the [project](./README_PROJECT.md)
 - Next week: Intro to minimal API web apps and deployment to Azure


If you feel you want prepare for next session, read chapters 3-5 from [Andrew Lock _ASP.NET Core in Action, Third Edition_](https://www.manning.com/books/asp-net-core-in-action-third-edition) 