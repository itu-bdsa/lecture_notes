# Your turn now! -- Project Work

<img src="https://media.giphy.com/media/13GIgrGdslD9oQ/giphy.gif" width=50%/>

You have to work on the following topics.

  - [1) Software Development](#1-software-development)
  - [2) Process](#2-process)

Remember, you have to perform work on each topic and on **each** bullet point.
Be done with the project work before we meet again next Thursday.


## 1) Software Development

**Note**: You may want to perform these steps in a different order - or simultaneously for some.

### 1.a) Restrict Length of Cheeps in Data Model

Make sure that your database does not contain cheeps, whose text is longer than 160 characters.
Implement this restriction by constraining the data model accordingly.
Implement other reasonable restrictions on author name length etc.

### 1.b) Use In-memory SQLite Database for Testing

As we realized during the last weeks, a direct dependency to a certain database is not advisable when running test suites.

Consequently, configure your integration test suite so that it uses an in-memory SQLite database for testing.

### 1.c) Add Unit Tests

Now, that you have decoupled your data persistence code properly from your application, augment your test suite from last time.

Implement a set of unit tests for suitable functionality, e.g., data conversion.

### 1.d) Validation

Implement fluent validation on your DTOs/repository ensuring input is valid and proper error handling is made.

E.g. author email should be formatted correctly and cheep length must be between 5 and 160 characters.

### 1.e) Expose API

Expose your repository methods using minimal APIs in `Chirp.Razor`.

### 1.f) Create cheep from UI

Add a `/cheep` endpoint where you can enter `Author` and `Text` and `[Submit]` a cheep.

### 1.g) CQS

Ensure your repositories are following the CQS pattern.

### 1.h) Extend repositories

Enables:

- Author:
  - Find by `name`
  - Find by `email`
  - Create
  - Delete (taking down all cheeps from author)

- Cheeps:
  - Get pages result
  - Get pages result by author `name`
  - Create

### 1.i) Warning

Ensure *all* warnings in your code have been dealt with.

## Process

### Choose a license for your _Chirp!_ project.

Choose a license for your _Chirp!_ project.
If in doubt about which license might be suitable for your project, consult [choosealicense.com](https://choosealicense.com/)

Make sure that you can choose the license you want to choose with the dependencies that you declare in your `.csproj` file.
For license compatibility, consider the overview from a [corresponding Wikipedia article](https://en.wikipedia.org/w/index.php?title=License_compatibility&section=3#Compatibility_of_FOSS_licenses):

![](https://upload.wikimedia.org/wikipedia/commons/thumb/2/2b/Floss-license-slide-image.svg/2880px-Floss-license-slide-image.svg.png)

Place the license text in a file `LICENSE.md`, which you place in the root directory of your project on the main branch.
See [GitHub's documentation](https://docs.github.com/en/communities/setting-up-your-project-for-healthy-contributions/adding-a-license-to-a-repository) on how to add a license to an existing project.
