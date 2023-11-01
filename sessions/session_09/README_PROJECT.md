# Your turn now! -- Project Work

<img src="https://media.giphy.com/media/13GIgrGdslD9oQ/giphy.gif" width=50%/>

You have to work on the following topics.

- [Your turn now! -- Project Work](#your-turn-now----project-work)
  - [1) Software Development](#1-software-development)
    - [For local development: Switch to _SQL Server_ database](#for-local-development-switch-to-sql-server-database)
    - [For production: Create a hosted Azure SQL database on Azure](#for-production-create-a-hosted-azure-sql-database-on-azure)
    - [Add feature: Sending Cheeps](#add-feature-sending-cheeps)
    - [Constrain Length of Cheeps](#constrain-length-of-cheeps)
  - [2) Process](#2-process)


Remember, you have to perform work on each topic and on **each** bullet point.
Be done with the project work before we meet again next Thursday.


## 1) Software Development

### For local development: Switch to _SQL Server_ database


  - Refactor your _Chirp!_ application so that it uses an _SQL Server_ database when executed locally.
Such a database can be instantiated via `docker` for example as in the following:

  ```bash
  docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433  --name sqlpreview --hostname sqlpreview -d mcr.microsoft.com/mssql/server:2022-latest
  ```
  - Ensure your tests are still running - using SQLite in-memory and/or test containers.
  - Run your *production* code with Azure SQL.
  - Ensure you apply your migrations when deploying to App Services.
  - Extend your `CheepRepository` to support create (test and implement).
  - Using `FluentValidation` to ensure all inputs are valid.
  - Add a *Chirp! form* to your app which is only visible when a user is signed in.
  - Ensure a user can only post to the form if she is signed in.

### For production: Create a hosted Azure SQL database on Azure

See for example this guide: https://learn.microsoft.com/en-us/azure/azure-sql/database/single-database-create-quickstart?view=azuresql&tabs=azure-portal

Configure your _Chirp!_ applications that are deployed to Azure App Service, i.e., your applications in _production_, to target this Azure SQL database.

### Add feature: Sending Cheeps

Extend your _Chirp!_ application so that users can send cheeps.

Only users that are authenticated should be able to send cheeps.
That is, after logging in, the user interface should display an input field on all public or private timelines.
For authenticated users, that input field should be displayed under the second level headline (`<h2>`) that says `Public Timeline` or `<UserName> Timeline`.

In the CSS file that you have in your _Chirp!_ projects, there is a style for an input element, which you should use, e.g., `<div class=cheepbox>`.
A skeleton of a corresponding input field may look as in the following:

```html
    <div class="cheepbox">
        <h3>What's on your mind @(User.Identity.Name)?</h3>
        <form method="post">
            <input style="float: left" type="text" asp-for="Text">
            <input type="submit" value="Share">
        </form>
    </div>
```

After sending a cheep, it should appear on the public timeline and on the timeline of the user that created it.

To support sending of `cheep`s, you have to extend your `CheepRepository` accordingly.
Besides extending your `CheepRepository`, remember to add test cases for creation of `cheep`s to your test suites.


### Constrain Length of Cheeps

Constrain cheeps so that only cheeps of length 160 characters are considered valid.
Your _Chirp!_ application should not accept cheeps that are longer that 160 character.
Such cheeps should never be stored to the database.

Using the mechanisms presented in chapter 18 of the course book Andrew Lock _ASP.NET Core in Action_, validate that only `cheep`s up to 160 characters length can be sent.


<!--
1. UI Tests

    - Add UI tests for login with test user and send cheeps
    - Add UI tests for login with test user and send cheeps (optional???) -->

## 2) Process

Continue to automatically deploy your _Chirp!_ application to Azure App Service.
