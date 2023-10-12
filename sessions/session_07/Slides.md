---
theme: gaia
_class: lead
paginate: true
backgroundColor: #fff
backgroundImage: url('https://marp.app/assets/hero-background.svg')
footer: '![width:300px](https://github.com/itu-bdsa/lecture_notes/blob/main/images/banner.png?raw=true)'
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
Session 7
[Rasmus Lystrøm, Senior Cloud Solution Architect](rnie@itu.dk)

---

## Guest Lecture, [Henrik Mansfeldt Witt](https://dk.linkedin.com/in/henrikmansfeldtwitt) ([Aumento](https://www.aumento.dk/))

On software licenses

![](https://assets.website-files.com/63b5704a3b12157537453cb2/63ed0f4e5a2a099e98ce0d72_32.jpg)

---

## Info: Semester meeting

- Dan and Louise hold a semester meeting with you in Auditorium 2 on October 25th from 12.30 to 13.30.
- You should receive more information about this via LearnIT.

---

## Feedback: Working with/on issues

<object data="http://209.38.208.62/issue_activity_weekly.svg" width="60%" height="50%"><div></div></object>

---

## Feedback: Continue to release!

<object data="http://209.38.208.62/release_activity_weekly.svg" width="60%" height="50%"><div></div></object>

---

## Feedback: Deployment

<iframe src="http://209.38.208.62/report_razor_apps.html" width="100%" height=500 scrolling="auto"></iframe>

---

# Agenda

- Clean architecture
- Testing repositories (EF Core)
- Validating input
- Exposing API
- Documenting API

---

# Command Query Seperation

<https://blog.ploeh.dk/2014/08/11/cqs-versus-server-generated-ids/>

---

![bg](images/onion.jpg)

<div style="text-align: right;">

# Onion Architecture

</div>

---

<!-- _class: default -->

![bg 75%](images/clean-architecture.png)

---

# Entity Framework Core

![bg](images/entity-framework-core.jpg)

---

# Entity Framework Core

```bash
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate --project ... --startup-project ...
dotnet ef database update --project ... --startup-project ...
```

<https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet>
<https://docs.microsoft.com/en-us/ef/core/modeling/>

---

# Task: _Fix your model_

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 15 minutes
-->

Make it *Clean* with *Onion*

Add restrictions to length and non-null on data model

Replace integer IDs with Guids

## What to do now?

![w:400px](https://25.media.tumblr.com/47f546206bf9a8b5dc97e7fe1b6714b3/tumblr_mi7nkgP6NH1qmegz6o1_500.gif)

- If not done, complete the Tasks (blue slides) from this class
- Check the [reading material](./READING_MATERIAL.md)
- Work on the [project](./README_PROJECT.md)

- <font color="#cecdce">If you feel you want prepare for next session, read chapters 6, 7, and 23 [Andrew Lock _ASP.NET Core in Action, Third Edition_](https://www.manning.com/books/asp-net-core-in-action-third-edition) </font>
