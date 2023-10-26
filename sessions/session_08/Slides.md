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

  div.mermaid { all: unset; }
---

# **Analysis, Design and Software Architecture (BDSA)**
Session 8
[Rasmus Lystrøm, Senior Cloud Solution Architect](rnie@itu.dk)



## Feedback: 😎😎😎

As I hear from the TAs and can see, all of you have working _Chirp!_ applications up and running!

<iframe src="http://209.38.208.62/report_razor_apps.html" width="100%" height=500 scrolling="auto"></iframe>


## Feedback: We feel stressed by the ever growing backlog

- Focus on the tasks in this week
- Try to work only on these things.
  - Not more, nothing else, nothing that is not explicitly stated in the project description file for that week.
- Old issues:
  - If it gives you mental peace, close them for now.
  - **OBS**: when closing issues that are about previous versions, add a respective comment that explains that the issue is about a previous version, state which one, e.g. CLI version, Razor page with direct SQLite integration, etc., and state explicitly what is missing.
  - The latter is described so that you know what to do in case you reopen the issue eventually.
- Now, focus on a Razor Page _Chirp!_ application, that uses EF Core, and for which you enable authentication (this week's task).


## Feedback: One Repository to rule them all?

- Remember that Rasmus showed you and mentioned that usually, you create one repository class per entity.


## Info: The written exam???

  > The exam consists of two parts. The two parts are:
  > a) the project, which is covered via the final submission (report) and which covers important aspects of the project work.
  > b) a written exam (two hours), which covers generic course contents.
  >
  > Each part is graded separately, i.e., students receive a grade for the project and another grade for the written exam.
  > Final grades are computed based on the two grades from the two parts. The precise weight of each part's grade will be communicated to all students in class at the start of the course. To pass the exam, both parts need to receive a passing grade. That is, the project has to be passed and the written exam needs to be passed.

The **grading weight** is: project 2/3 written exam 1/3.

see [LearnIT](https://learnit.itu.dk/local/coursebase/view.php?ciid=1241)


## Info: The written exam???

* On premises Wed. January 3rd 2024, 09:00 - 11:00
* Pen and paper exam.
* No other books, tools, etc.
* Two hours.
* In person

* The exam will be similar to last year's. That is, there will be free form, multiple choice, and sketching answers.
* You can find last year's exam [here](https://ituniversity.sharepoint.com/:b:/r/sites/2023AnalysisDesignandSoftwareArchitecture/Shared%20Documents/General/Documents/2022-itu-bdsa-exam.pdf?csf=1&web=1&e=DbwOM5)
* Note, use it to get an idea of the structure and some contents of the exam.
  - Since course contents changed, not all contents of the exam apply. Good examples of kinds of questions to be prepared for are: Question 1 a-d, Question 2 a-b, Question 4 j-l, Question 6 a-g



## Topic for today

How to make it possible that **users** are supported by our _Chirp!_ applications and that these can **login/-out**?

* We need to model users.
* We need to add authentication.


## Authentication vs. Authorization

![bg](images/padlock.gif)


## Authentication

* Authentication is the process of verifying that a user or a device is who they claim to be
* 401 Unauthorized

## Authorization

* Authorization is the process of granting or denying access rights to a user or a device based on their identity and other factors
* 403 Forbidden

## Authentication Options

* (None)
* Individual User Accounts
* Microsoft Identity Platform (Entra ID)
* Windows
* Easy Auth (Azure only)
* Others


## Individual User Accounts

### aka ASP.NET Core Identity

* Built-in
* Local accounts
* Credentials stored in database
* Works offline
* Support for social (Facebook, Twitter, GitHub, etc.)
* Support for authorization
* You manage everyting (some code auto generated)

## Task:

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 15 minutes
-->
<style scoped>
section {
   font-size: 21px;
}
</style>

Explore options using `dotnet new webapp --auth Individual` - or use Visual Studio GUI.

Look through the generated code.

Try to run the app, register a user, and sign in.

## Individual User Accounts

### Demo: Add GitHub + User Secrets

## Individual User Accounts

### Demo: Extend/connect data model

## Microsoft Identity Platform

### aka Entra ID aka Azure AD

### LOB, Corporate, Business to Business (B2B)

Entra ID is Microsoft's cloud-based identity and access management service, which helps your employees sign in and access resources in:

External resources, such as Microsoft 365, the Azure portal, and thousands of other SaaS applications.
Internal resources, such as apps on your corporate network and intranet, along with any cloud apps developed by your own organization.

![](images/app-registration-account-types.png)


## Microsoft Identity Platform

### Business to Consumer (B2C)

**Notes**:

* No built-in support for *authorization*.
* Will be replaced with *Microsoft Entra ID for customers* (public preview)

![bg right](images/azure-ad-b2c-identity-providers.png)

## Task:

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 5 minutes
-->
<style scoped>
section {
   font-size: 21px;
}
</style>

Go to [portal.azure.com](https://portal.azure.com/)

Create new B2C Tenant

(don't wait for it to be created)

## Azure AD B2C

### Demo: Add GitHub

## Task:

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 20 minutes
-->
<style scoped>
section {
   font-size: 21px;
}
</style>

Explore your new Azure AD B2C tenant.

Create a Signup-Signin policy called `sisu`.

Create a new app registration with callback `https://jwt.ms`.

Test it.

Add `https://localhost` to your app registration.

Configure a new web app to use `--auth IndividualB2C`

## Azure AD B2C

### Demo: Claims page

## Windows

Old school

Legacy

Don't use!

Works offline - Enterprise scenario with no Internet?


## Easy Auth

* Built-in to Azure App Service (Web Apps + Functions) and Azure Container Apps
* *Easy* but somewhat limited.
* Superb for prototyping but also production ready
* No built-in support for authorization
* *Only* works on Azure


## Others


* ForgeRock
* Okta
* ...


## Key takeaways:

### Don’t roll your own security/identity layer


## We mean it!

### Don’t roll your own security/identity layer

![bg](https://media.giphy.com/media/12Pb87uq0Vwq2c/giphy.gif)


## Key takeaways (2):

* Taking the easy route (individual auth) might only be easy at first...

* Invest in learning how to implement Entra ID
