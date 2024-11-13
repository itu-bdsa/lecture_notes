# Your turn now! -- Project Work

<img src="https://media.giphy.com/media/13GIgrGdslD9oQ/giphy.gif" width=50%/>

You have to work on the following topics.

- [Your turn now! -- Project Work](#your-turn-now----project-work)
  - [1) Software Development](#1-software-development)
  - [2) Process](#2-process)


Remember, you have to perform work on each topic and on **each** bullet point.
Be done with the project work before we meet again next Thursday.


## 1) Software Development

### Add feature: Users can follow and unfollow each other

Extend your _Chirp!_ application so that users can follow and unfollow each other.

Users can follow any other user, except themselves.
Initially, users do not follow any other user.

Once authenticated to your _Chirp!_ application, cheeps in public (on the root endpoint `/`) and private timelines (on the username endpoint `/<user_name>`) should contain a link next to all listed user names with the link text `follow`.
Clicking these links, shall register in your application that a user is now following the selected other user.
Likely, clicking it just redirects a user to the currently displayed page.

If a user already follows another user, the link text displayed to the other user's name in the public and private timelines is `unfollow`.

Following another user has an impact on what is displayed in a user's private timeline (those on the username endpoint `/<user_name>`).
The cheeps of all followed users and those of the user logged into your _Chirp!_ application should be displayed in the private timeline of an authenticated user.
That means also, that if an authenticated user visits the private timeline of any other user, she sees only the cheeps written by that user but not those that are written by other users that the the other user is following.


To implement this feature, you have to extend your data model so that it can store the information on who is following whom.
There are several possible solutions on how to implement this feature.
You decide how to modify the data model, i.e., if you want to store the information about whom a user is following in a separate entity, as a property of a user, etc.
Besides the changes in the datamodel, you have to refactor your repositories, DTOs, views, etc. accordingly.


#### Example

For example, imagine your _Chirp!_ application has three users `Anna`, `Bella`, and `Cheryl`.
Since `Bella` likes `Cheryl`'s writing, she follows her, which is already stored in the _Chirp!_ application.
Now, `Anna` logs into the system.
Since she never logged in before, she does not follow any other user yet.
Imagine now, `Anna` sends a first cheep.
On the public timeline (`/` root endpoint), `Anna` gets presented a link to follow users `Bella` and `Cheryl` displayed next to their respective user names but **not** next to her own user name `Anna`.
That is, users can only follow others but not themselves.
`Anna` decides to follow both `Bella` and `Cheryl`, i.e., the _Chirp!_ application adds the information that `Anna` follows `Bella` and that `Anna` follows `Cheryl` on top of the information that `Bella` follows `Cheryl`.
In her private timeline (`/Anna`), gets now displayed all the cheeps that are written by herself and all of those that are written by `Bella` and `Cheryl` respectively.
However, when `Anna` is logged in and she visits `Bella`'s timeline, she can only see `Bella`'s cheeps, **not** those written by `Cheryl`.
The same holds for `Bella` and any other user, i.e., if `Bella` was logged in, she would see her own cheeps and those of `Cheryl` on her own private timeline (`/Bella`), on `Anna`'s timeline (`/Anna`) she would only see cheeps written by `Anna`

Now, still logged in, `Anna` realizes that she does not like `Bella`'s writing anymore.
On both the public and private timelines next to `Bella`'s name a link to `unfollow` her is displayed.
After clicking it, the _Chirp!_ application registers this new information and updates its data store accordingly.
Now only, `Anna` follows `Cheryl` and `Bella` follows `Cheryl`.
When visiting her own private timeline (`/Anna`), `Anna`'s timeline displays now only her own cheeps and those written by `Cheryl`.


### Assure requirements for users of _Chirp!_

- An author on your chirp application has always a name and an email address.
- An email address **is not** the name.
- For login: be specific if you want the user to insert a name or an email address.

* When logging in via GitHub OAuth, a user **shall not** provide an extra email or username. If you need this in your _Chirp!_ application receive this from GitHub with the help of the information that you receive in the ClaimsPrinciple. It should contain a GitHub user ID.


## 2) Process

Since the (un-)following functionality is quite tricky, it is likely a good idea to implement a set of tests that assure only the right users can read cheeps written by those that they are following.
Due to its trickiness, you might want to consider to start writing certain tests before you start your implementation of the new feature.

The description of the example above is likely a very good candidate to be implemented as a set of tests.

You can decide if these tests are implemented as integration tests or as UI tests.
With integration tests, you could for example seed example data in your test database, e.g., `Bella` follows `Cheryl` and both of them have some example cheeps.
Now, when you ask a certain repository that `Anna` wants to follow both `Bella` follows `Cheryl` and when
Writing integration tests this way, allows you to circumvent that `Anna` has to be logged into _Chirp!_.
You can test you repositories in isolation.
If in doubt, consult the links in the reading material for how to build such integration tests.


Alternatively, you might want to implement some of these tests as UI tests with PlayWright.
When doing so, it is okay that the Playwright tests are not integrated into your GitHub Actions workflows.
It can be done, but it requires a bit more of fiddling that may be to time intensive.
However, one has to be able to execute them locally when checking out the main branch of your repository.

If you cannot get these tests done until next week, continue working on them during the following weeks.
Once you hand-in your project though, it is important that some of the aspects of un-/following each other are tested in some way.
