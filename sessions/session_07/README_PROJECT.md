# Your turn now! -- Project Work

<img src="https://media.giphy.com/media/13GIgrGdslD9oQ/giphy.gif" width=50%/>

You have to work on the following topics.

  - [1) Software Development](#1-software-development)
  - [2) Process](#2-process)
  - [3) Project Review 2](#3-project-review-2)


Remember, you have to perform work on each topic and on **each** bullet point.
Be done with the project work before we meet again next week.


## 1) Software Development

**Note**: You may want to perform these steps in a different order - or simultaneously for some.

### 1.a) Use In-memory SQLite Database for Testing

As we realized during the last weeks, a direct dependency to a certain database is not advisable when running test suites.

Consequently, configure your integration test suite so that it uses an in-memory SQLite database for testing.

### 1.b) Extend Your Repositories

Expose methods in your repositories (OBS: that includes the respective interfaces) that enable to:

- Find `Author` by `name`
- Find `Author` by `email`
- Create a new `Author`

- If not implemented already, retrieve `cheeps` for a certain page.
- If not implemented already, retrieve `cheeps` for a certain page that are written by a certain `Author` who is identified by `name`
- Create a new `cheep`. Note, that might mean to also create a respective author if she does not exist yet in _Chirp!_.

### 1.c) Constrain Length of Cheeps

Constrain cheeps so that only cheeps of length 160 characters are considered valid.
Your _Chirp!_ application should not accept cheeps that are longer than 160 character.
Such cheeps should never be stored to the database.

Using the mechanisms presented by Adrian, ensure that only `cheep`s up to 160 characters length can be stored.

### 1.d) Add Unit Tests

Now, that you have decoupled your data persistence code properly from your application, augment your test suite from last time.

Implement a set of unit tests for suitable functionality, e.g., all of the repository methods from the task above, data conversion, etc.

### 1.e) Command Query Separation

Ensure that the methods that are exposed in your repositories follow are separated into commands and queries:

> Separate Commands from Queries. Commands are procedures that have side effects. Queries are functions that return data. Every method should be either a Command or a Query, but not both.<font size=3>
Source: Mark Seemann <i>"Code That Fits in Your Head"</i>
</font>

### 1.f) Onion Architecture

Refactor your projects into an onion architecture, as seen in class.
That is, in your `src` directory, create a `Chirp.Core` project that contains your DTOs, Repository interface(s), etc., a `Chirp.Infrastucture` project that contains you Repositorie(s), data model, database context, etc., and a `Chirp.Web` project that contains the actual Razor Page application

### 1.g) Warnings

Ensure that your project builds without any warnings.
That is, make sure that *all* warnings in your code are addressed.


## 2) Process

### 2.a) Choose a license for your _Chirp!_ project.

Choose a license for your _Chirp!_ project.
If in doubt about which license might be suitable for your project, consult [choosealicense.com](https://choosealicense.com/)

Make sure that you can choose the license you want to choose with the dependencies that you declare in your `.csproj` file.
For license compatibility, consider the overview from a [corresponding Wikipedia article](https://en.wikipedia.org/w/index.php?title=License_compatibility&section=3#Compatibility_of_FOSS_licenses):

![](https://upload.wikimedia.org/wikipedia/commons/thumb/2/2b/Floss-license-slide-image.svg/2880px-Floss-license-slide-image.svg.png)

Place the license text in a file `LICENSE.md`, which you place in the root directory of your project on the main branch.
See [GitHub's documentation](https://docs.github.com/en/communities/setting-up-your-project-for-healthy-contributions/adding-a-license-to-a-repository) on how to add a license to an existing project.

### 2.b) Continue to Release

Continue to release and deploy automatically.
That is, whenever you deploy automatically, you also create a new release.
Meaning, the latest version of the application in production is always the latest version of the application in your main branch.
You decide if it is the latest tagged version or the latest committed version, i.e., if your workflow is triggered by pushes to main or pushes of tags.

This task is not asking for any new functionality.
Just for that you continue to release automatically as during the last weeks.


## 3) Project Review 2

Prepare for the second project review (week 43, the week after fall break).
Be prepared to demonstrate and inspect with the assigned TA:
* How you build, test, and deploy your projects
* The current state of your project

In case you cannot meet with the TA who is assigned to your group, let him know well in advance that you cannot and reschedule to meeting to another suitable time slot!
