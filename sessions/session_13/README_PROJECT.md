# Your turn now! -- Project Work

<img src="https://media.giphy.com/media/13GIgrGdslD9oQ/giphy.gif" width=50%/>

You have to work on the following topics.

- [Your turn now! -- Project Work](#your-turn-now----project-work)
  - [1) Software Development](#1-software-development)
  - [2) Process](#2-process)
  - [3) Demo Day](#3-demo-day)



Remember, you have to perform work on each topic and on **each** bullet point.
Be done with the project work before we meet again next week.


## 1) Software Development

### Add feature(s): Wild Style

Implement whichever feature you like to your _Chirp!_ applications.
In case you have the time and energy, you might implement multiple such features.

For inspiration, wild style features might be:
- Ranking or liking of cheeps
- Tags in cheeps (for example, strings preceded by a `#` sign might be indexed and cheeps containing tags might be listed in a separate page)
- List of trending cheeps based on likes or tags
- Support of images in cheeps
- "Re-cheeping", i.e., forwarding of cheeps that are send by others to own timeline and own followers.
- ...

### Refactoring: Repositories and Data-Transfer Objects (DTO)

After the third round of project reviews, we became aware of that many groups implement only one repository class and only one DTO class. First, that is likely an issue with resepect to some of the SOLID design principles. Additionally, if you remember Adrian's lecture on the topic and the related reading material, you likely remember that it is often recommended to have one repository class per one domain model class. Similarly, each of these return separate data-transfer objects.

Refactor your project so that it contains suitable repository classes and respective DTOs.


## 2) Process

Make sure that the above features are tested in a suitable form.


## 3) Demo Day: Peer feedback

Prepare for the Demo day next week (Wednesday 3/12/24 or Friday 5/12/24).
You present your work to each other in clusters of three groups and you provide peer-feedback to each other.
Each group has 5 minutes to present. The remaining time in the time slots is used for discussions and feedback.

**OBS**: All times given below are sharp! That is, they are not with an academic quarter.

### Schedule

Wednesday 3/12/24

| Time        | Room   | Groups         | TA     |
|-------------|--------|----------------|--------|
| 12:15-14:00 | Aud1   | 1,2,3,4        | Carl   |
|             | Aud1   | 5,6,7,8        | Jakob  |
|             | Aud1   | 9,10,11,12     | Jonas  |


Friday 5/12/24

| Time        | Room    | Groups         | TA      |
|-------------|---------|----------------|---------|
| 08:15-10:00 | Aud1    | 13,14,15,16    | Marius  | 
|             | Aud1    | 17,18,19,20,21 | Patrick |
|             | Aud1    | 22,23,24,25,26 | Phi Va  |


### What to present?

- Quick tour of features and demonstration of their functionality (keep parts everyone had to do short)
- Brief demo of additional features.
- Describe design descision that are characteristic for your projects. Amongst others:
  - How is "forget me" feature implemented?
  - How are additional features implemented?
- Overview of tests.
- If you already have some and want to show them, some of the visualizations that you intend to use in the report.


### How to provide feedback in the presentations?

In the following you find a kind of checklist that you may use as inspiration when providing peer-feedback to the presentations of your fellow groups.


- Functionality:
  - Is functionality complete or are major features missing?
  - Login with GitHub works without prompting for additional information?
- Tests:
  - Are there any tests presented?
  - Are there different kinds of tests, like unit tests, integration tests, UI-tests, end-to-end tests?
  - Are the presented tests sensible?
  - The presented tests are well designed? (There was a pattern we discussed in class that test cases should adhere to.)
- Visualizations:
  - Are the presented visualizations syntactically correct?
  - Are relation ends on the correct side of relations?
  - Are multiplicities/cardinalities correct?
  - Are the correct diagram types used?
  - Are there separate illustrations of structure and behaviour of the _Chirp!_ system or are they mixed?
