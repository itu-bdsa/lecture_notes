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
Session 10
[Rasmus Lystrøm, Senior Cloud Solution Architect](rnie@itu.dk)


## Feedback: New Checks

I created a new set of automatic checks, that try to log into your _Chirp!_ applications and that try to send cheeps: <http://209.38.208.62/report_razor_apps2.html>

<iframe src="http://209.38.208.62/report_razor_apps2.html" width="100%" height=500 scrolling="auto"></iframe>


## Feedback: Read carefully!

Links to login should have `login` as link text, see [the project description](../session_08/README_PROJECT.md).

```html
    <div class=navigation>
        ...
        else
        {
            <div>
                <a href="/">public timeline</a> |
                <a ... >register</a>
                <a ... >login</a>
            </div>
        }
    </div>
```

Our automatic checks get quite complex when searching for `login`, `Login`, `Log-in`, `Log-In`, `signin`, `Signin`, `sign in`, `Sign in`, `Sign-in`, ...


## Feedback: Too many open tasks

I believe you are struggling with completing the project work from the last weeks:

- Sending cheeps
- Login with GitHub
- Migrate database to hosted database on Azure
- + Tasks from this week

How could you handle the situation of too many open and pressing tasks?
* Prioritization
* If you were to order, which are the most important and which are the least important tasks from the list above?


## Survey: How many groups have issues moving to hosted DB?

👋👋👐👐👐🖐️🖐️


## First Hour Next Week: Guest Lecture

Next week, we start the lecture with a guest lecture. **Be on time**

![w:400px](https://assets.swoogo.com/uploads/full/1642938-622b4a6ee2364.png)

Jakob Krabbe Sørensen from [ComplyCloud](https://www.complycloud.com/) will give a guest lecture on "Privacy by Design" and why GDPR matters to you as software engineers.


---------------------------------------------------------------

## Last Lecture from me

### Picture for LinkedIn

### Also, sick child :(

## Topics

- Zero Trust
- Security in Web Applications
- OWASP
- SQL Injection
- Cross Site Scripting (XSS)
- Cross-site request forgery (CSRF)
- Vulnerabilities
- GitHub Advanced Security
- Microsoft Defender for Cloud
- Azure Security Components
- Azure Web App Security
- Azure SQL Security
- Hosted SQL Server support
- Login support

##

![bg](images/identity.png)

## Identity

* It’s not about where you are
* it’s about who you are

## Zero Trust

### 1. Verify explicitly

#### Always authenticate and authorize based on all available data points.

### 2. Use least privilege access

#### Limit user access with Just-In-Time and Just-Enough-Access (JIT/JEA), risk-based adaptive policies, and data protection.

### 3. Assume breach

#### Minimize blast radius and segment access. Verify end-to-end encryption and use analytics to get visibility, drive threat detection, and improve defenses.

## Network

**network** noun

*a system of computers and peripherals that are able to communicate with each other*

<https://www.merriam-webster.com/dictionary/network>

## Network

### The most secure network is no network at all

me

## Security in Web Applications

### HTTPS demo

## OWASP Foundation, the Open Source Foundation for Application Security

### [OWASP Top Ten](https://owasp.org/www-project-top-ten/)

![](https://owasp.org/www-project-top-ten/assets/images/mapping.png)

## XSRF/CSRF

[Prevent Cross-Site Request Forgery (XSRF/CSRF) attacks in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/anti-request-forgery)

### Antiforgery in ASP.NET Core

Antiforgery middleware is added to the [Dependency injection](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection) container when one of the following APIs is called in `Program.cs`:

```txt
AddMvc
MapRazorPages
MapControllerRoute
MapBlazorHub
```

#### Demo

## XSS

[Prevent Cross-Site Scripting (XSS) in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/security/cross-site-scripting)

## SQL Injection

### Demo

## GitHub Advanced Security

![bg](https://cyber-reports.com/wp-content/uploads/2021/05/GitHub-headpic-1000x600.jpg)

## Secret Scanning

### Demo

## Code Scanning

### Demo

## Dependency Review

### Demo

## [.NET Conf 2023](https://www.dotnetconf.net/)

The largest .NET event hosted online

November 14 ‐ 16.

Releasing .NET 8

[.NET Support Policy](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core)

**Note**: You do not need to update Chirp to .NET 8 for this course.

- You should plan to update it NLT Q1 2024.

## Microsoft Defender for Cloud

[What is Microsoft Defender for Cloud?](https://learn.microsoft.com/en-us/azure/defender-for-cloud/defender-for-cloud-introduction)

Your cloud provider probably has built-in features you will want to use.

## Microsoft Defender for Cloud

### Demo

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

Configure GitHub Advanced Security

Review the *Security* tab.

Try to push a secret - can you make it fail?

## Azure Security Components

[Azure Application Gateway](https://learn.microsoft.com/en-us/azure/application-gateway/)

[Azure Front Door](https://learn.microsoft.com/en-us/azure/frontdoor/front-door-overview)

## Azure Web App Security

### Demo

#### Security Settings

#### (Firewall)

## Azure SQL Security

### Demo

#### Security Settings

#### (Firewall)

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

Configure Defender:

- Enable Trial

Configure Web App:

- Basic Auth Publishing Credentials
- FTP state
- HTTP version
- SSH
- HTTPS only
- Minimum Inbound TLS Version
- Remote debugging

Configure SQL Server:

- Allow Azure services only

## Security and compliance is everybody's responsibility

![bg](images/keys.jpg)

## Extending data model

### Follow/unfollow

### Likes/reactions

## Hosted SQL Server support

### ?

## Login support

### ?

#### Demo

## Thank you

![bg right:60% contain](images/applause.png)

---------------------------------------------------------------


## What to do now?

![w:400px](https://25.media.tumblr.com/47f546206bf9a8b5dc97e7fe1b6714b3/tumblr_mi7nkgP6NH1qmegz6o1_500.gif)

- If not done, complete the Tasks (blue slides) from this class
- Check the [reading material](./READING_MATERIAL.md)
- Work on the [project](./README_PROJECT.md)

- <font color="#cecdce">If you feel you want prepare for next session, read chapters [Andrew Lock _ASP.NET Core in Action, Third Edition_](https://www.manning.com/books/asp-net-core-in-action-third-edition) </font>
