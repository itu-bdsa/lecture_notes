---
theme: gaia
_class: lead
paginate: true
backgroundColor: #fff
backgroundImage: url('https://marp.app/assets/hero-background.svg')
footer: '![width:300px](https://github.com/itu-bdsa/lecture_notes/blob/main/images/banner.png?raw=true)'
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
Session 9 — Feedback
[Helge Pfeiffer](ropf@itu.dk)


## Feedback

<iframe src="https://itu-bdsa.github.io/status/org-commit-frequency.html" width="100%" height=600 scrolling="auto"></iframe>

All groups are working on their projects.
Super cool!


## Feedback

**But** in some groups some members are not working on the projects?

Recomendation: Do not gamble with coming to the re-exam instead of working on the project and taking the written exam.

| :exclamation:  Without active participation in the project, likely the re-exam will be very difficult to pass. |
|--------------------------------------------------------------------------------------------------------------------------|

## Feedback

<iframe src="https://itu-bdsa.github.io/status/report_razor_apps.html" width="100%" height=600 scrolling="auto"></iframe>


## Feedback - Short-lived branches

- Remember, we do trunk-based development in this course. That is, you do not have a long-lived `dev` branch (as in last semester's project). That would be another branching strategy.
- You have short-lived feature branches. That is, at latest after a day your changes land on the main branch and thereby automatically in production (your deployment workflows deploy all changes from main, right?)

What do we do if we cannot finish our feature during a day?

- Good observation, that means likely that your task descriptions in your issues are too coarse grained. Over time you should train to make them smaller so that you can complete your tasks in max. a day.


## Feedback - Size of commits

Very few commits but big commits?

Something is wrong, try to train to scope your work better to small tiny steps/features.


## Feedback - No tests?

![bg right:30% 100%](https://media1.tenor.com/m/ACBGhLB0v0gAAAAC/looney-tunes-telescope.gif)

* Remember my words from session 3!

  > In this course, we do not follow TDD, i.e., we do not require you to _first_ write tests that fail, which you then implement to make them pass. Once the tests pass your implementation is "complete".
  >
  > However, we require that you from now on implement tests along side your solution. That is, at times you develop a test before the actual implementation of a feature, sometimes afterwards, and likely most of the time you implement them in combination, i.e., as your understanding and implementation of the solution evolves your tests evolve, etc.


## Feedback - No automatic deploy?


That is, build, tests, and deploy are not triggered by a push/merge to main branch but you trigger them manually by clicking a button?

Why do you do that?

* Likely a fear of breaking sometinh with deployment is related to the lack of tests.
* If all tests pass, then you should be confident to deploy automatically.


## Feedback - Mob programming vs. code review

If you do mob programming all the time, then code reviews likely do not make sense and you do not use them since you do that already while programming.

If you worked together on almost all features so far, then try to do something different from now on. For example, try to work for some weeks with pair programming



## Question: [Max length for message](https://teams.microsoft.com/l/message/19:f6bb39ba381f4c62ba51eba83c0e307f@thread.tacv2/1728570895930?tenantId=bea229b6-7a08-4086-b44c-71f57f716bdb&groupId=50f54173-84af-4d6f-bea1-b06854fb189e&parentMessageId=1728570895930&teamName=2024%20Analysis%2C%20Design%20and%20Software%20Architecture&channelName=Ask%20a%20TA&createdTime=1728570895930)

> We were trying to enforce 1.c, stating that cheeps should have a max length of 160 characters, by "Using the mechanisms presented by Adrian, ensure that only cheeps up to 160 characters length can be stored."
Unfortunately it seems SQLite doesn't support length limitations on strings, https://www.sqlite.org/faq.html#q9
But the context should still, enforce it, before trying to commit it to the database right? Or have I misunderstood how DBContext work, and if so, are we then allowed to choose our own way of enforcing it?
Below is a snippet of our code from our Context.
>```
>entity.Property(c => c.Message).IsRequired().HasMaxLength(160);
>```

👏👏👏 I love it!

Last year nobody realized this as an issue. This is a shortcomming of the ORM that hides a missing feature from the underlying DBMS.


## Exam

  > The exam consists of two parts. The two parts are:
  > a) the project, which is covered via the final submission (report) and which covers important aspects of the project work.
  > b) a written exam (two hours), which covers generic course contents.
  >
  > Each part is graded separately, i.e., students receive a grade for the project and another grade for the written exam.
  > Final grades are computed based on the two grades from the two parts. The precise weight of each part's grade will be communicated to all students in class at the start of the course. To pass the exam, both parts need to receive a passing grade. That is, the project has to be passed and the written exam needs to be passed.

The **grading weight** is: project 1/2 written exam 1/2.

see [LearnIT](https://learnit.itu.dk/local/coursebase/view.php?ciid=1478)


## Info: The written exam???

<style scoped>
  section {
    font-size: 22px;
  }
</style>

* On premises, Friday, January 3rd 2025, 09:00 - 11:00
* Pen and paper exam.
* No other books, tools, etc.
* Two hours.
* In person

* The exam will be similar to last year's. That is, there will be free form, multiple choice, and sketching answers.
* You can find last year's exam [here](https://ituniversity.sharepoint.com/:b:/r/sites/2024AnalysisDesignandSoftwareArchitecture/Shared%20Documents/General/Documents/2023-itu-bdsa-exam.pdf?csf=1&web=1&e=RnXPPm)
* You can find the exam from 2022, [here](https://ituniversity.sharepoint.com/:b:/r/sites/2024AnalysisDesignandSoftwareArchitecture/Shared%20Documents/General/Documents/2022-itu-bdsa-exam.pdf?csf=1&web=1&e=CaAzNa)
  - Note, that exam only to get an idea of the structure and some contents of the exam.
  - Since course contents changed, not all contents of that exam apply. Good examples of kinds of questions to be prepared for are: Question 1 a-d, Question 2 a-b, Question 4 j-l, Question 6 a-g
