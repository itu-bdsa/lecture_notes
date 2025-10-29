# Your turn now! -- Project Work

<img src="https://media.giphy.com/media/13GIgrGdslD9oQ/giphy.gif" width=50%/>

You have to work on the following topics.

- [Your turn now! -- Project Work](#your-turn-now----project-work)
  - [1) Software Development](#1-software-development)
    - [Add feature: Sending Cheeps](#add-feature-sending-cheeps)
    - [Constrain Length of Cheeps](#constrain-length-of-cheeps)
    - [Add UI Tests](#add-ui-tests)
    - [Add End-to-end Tests](#add-end-to-end-tests)
  - [2) Process](#2-process)


Remember, you have to perform work on each topic and on **each** bullet point.
Be done with the project work before we meet again next week.


## 1) Software Development

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

Using the mechanisms presented by Adrian or in chapter 18 of the course book Andrew Lock _ASP.NET Core in Action_, validate that only `cheep`s up to 160 characters length can be sent.


### Add UI Tests

Add UI tests for suitable functionality related to sending cheeps.
For example, good UI test cases are that a cheep box only appears on screen once a user sucessfully logged into your _Chirp!_ application.
Another good test case is that you _Chirp!_ application displays a message or behaves according to your liking once a user tries to send a cheep with more than 160 characters.


### Add End-to-end Tests

Similar to the UI tests above, implement some suitable end-to-end test cases.
For example, test if a cheep that a user enters into a cheep box is stored in the database for the respective author.


## 2) Process

Continue to automatically deploy your _Chirp!_ application to Azure App Service.
