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

Prepare for the Demo day next week (Tuesday 3/12/24 or Wednesday 4/12/24).
You present your work to each other in clusters of three groups and you provide peer-feedback to each other.
Each group has 10 minutes to present. The remaining time in the time slots is used for discussions and feedback.

**OBS**: All times given below are sharp! That is, they are not with an academic quarter.

### Schedule

Tuesday 3/12/24

| Time        | Room   | Groups         | TA     |
|-------------|--------|----------------|--------|
| 14:00-14:40 | 4A56   | 1,2,3          | Phi Va |
|             | 4A58   | 4,5,6          | Rasmus |
| 14:45-15:25 | 4A56   | 7,8,9          | Phi Va |
|             | 4A58   | 10,11,12       | Rasmus |


Wednesday 4/12/24

| Time        | Room    | Groups         | TA      |
|-------------|---------|----------------|---------|
| 14:15-14:55 | 4F03    | 13,14,15       | Patrick |
|             | 2A12-14 | 16,17,18       | David F |
|             | 2A52    | 19,20,21       | David S |
| 15:00-15:40 | 4F03    | 22,23,24       | Patrick |
|             | 2A12-14 | 25,26,28       | David F |
|             | 2A52    | 29,30,31       | David S |


### What to present?

- Quick tour of features and demonstration of their functionality
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
  - Are cardinalities correct?
  - Are the correct diagram types used?
  - Are there separate illustrations of structure and behaviour of the _Chirp!_ system or are they mixed?
