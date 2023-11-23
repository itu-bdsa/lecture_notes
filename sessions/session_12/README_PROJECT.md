# Your turn now! -- Project Work

<img src="https://media.giphy.com/media/13GIgrGdslD9oQ/giphy.gif" width=50%/>

You have to work on the following topics.

- [Your turn now! -- Project Work](#your-turn-now----project-work)
  - [1) Software Development](#1-software-development)
  - [2) Process](#2-process)


Remember, you have to perform work on each topic and on **each** bullet point.
Be done with the project work before we meet again next Thursday.


## 1) Software Development

### Add feature: User information page

After Jakob's lecture on GDPR, you learned that you have to be able to provide users information about their personal data that your application stores about them.

In the navigation bar on top, in between links to timelines and login, create a link to a new page with the link text "about me".
That link appears only if a user is authenticated in your _Chirp!_ application.
If authenticated, a user should be able to see all information that your _Chirp!_ application stores about her on that page.
That is all personal information, like name, email address, links to other users that this user is following, etc. should be presented
Additionally, all cheeps of this user are listed.

Optionally, you can implement functionality to download all this information as a zipped archive of text files.
These might be CSV files, plain text files, etc.


### Add feature: Forget me.

On the user information page, place a red button with the text `Forget me!`.
An authenticated user can click this button.
The system should then delete all information about this user, e.g., name, email address, links to other users that this user is following, etc. should be removed from your _Chirp!_ application.

As you know from the lecture, there are various ways of implementing this feature.
For this class and project, it is okay if you implement the technically most simply form of this feature as described in section 12.4.4 in [Andrew Lock _ASP.NET Core in Action, Third Edition_](https://www.manning.com/books/asp-net-core-in-action-third-edition).
That is, so that a delete operation is not a real delete but an update operation that modifies the respective data so that it is not displayed anymore.
This solution is of course not GDPR compliant.

Alternatively, since you remember from Jakob that in terms of GDPR "anonymization == deletion", you can decide to implement deletion in this way.
That is, you may want to implement this feature so that user names and other personal data are anonymized
For this project, it is okay that you do not consider


## 2) Process

Make sure that the above features are tested in a suitable form.
