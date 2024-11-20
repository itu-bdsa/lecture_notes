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
Session 12
[Helge Pfeiffer](ropf@itu.dk)


## Plan for today

- First hour: Guest Lecture on GDPR and "Privacy by Design"
- Second hour: Ethics
- Third hour: Documentation
- Fourth hour: Design, Architecture and project work


## Guest lecture: GDPR and "Privacy by Design"

We will start the lecture with a guest lecture.

![w:400px](https://assets.swoogo.com/uploads/full/1642938-622b4a6ee2364.png)

Jakob Krabbe Sørensen from [ComplyCloud](https://www.complycloud.com/) will give a guest lecture on "Privacy by Design" and why GDPR matters to you as software engineers.


<!-- Second hour -->

## Task: Privacy by Design?

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 10 minutes
-->

- What precisely do you know about your users?
- Where do you have to check?
- Inspect your data model, i.e., all entities on what you store about your users.
  - Is there somewhere else to check?
- With a database browser, investigate what your database really contains about users.


## Professional organizations

> [Institute of Electrical and Electronics Engineers] IEEE is the world's largest technical professional organization dedicated to advancing technology for the benefit of humanity.
><font size=3>
Source: <a href="https://www.ieee.org/">IEEE</a>
</font>

> [Association for Computing Machinery] ACM, the world's largest educational and scientific computing society, delivers resources that advance computing as a science and a profession.
> <font size=3>
Source: <a href="https://www.acm.org/about-acm">ACM</a>
</font>


## IEEE Code of Ethics

> We, the members of the IEEE, in recognition of the importance of our technologies in affecting the quality of life throughout the world, and in accepting a personal obligation to our profession, its members and the communities we serve, do hereby commit ourselves to the highest ethical and professional conduct and agree:
>
> I. To uphold the highest standards of integrity, responsible behavior, and ethical conduct in professional activities.
>
> II. To treat all persons fairly and with respect, to not engage in harassment or discrimination, and to avoid injuring others.
>
> III. To strive to ensure this code is upheld by colleagues and co-workers.
<font size=3>
Source: <a href="https://www.ieee.org/about/corporate/governance/p7-8.html">IEEE Code of Ethics</a>
</font>


## ACM Code of Ethics and Professional Conduct

> 1. GENERAL ETHICAL PRINCIPLES.
> _A computing professional should ..._
> **1.1** Contribute to society and to human well-being, acknowledging that all people are stakeholders in computing.
> **1.2** Avoid harm.
> 1.3 Be honest and trustworthy.
> 1.4 Be fair and take action not to discriminate.
> 1.5 Respect the work required to produce new ideas, inventions, creative works, and computing artifacts.
> **1.6** Respect privacy.
> 1.7 Honor confidentiality.<font size=3>
Source: <a href="https://ethics.acm.org/">ACM Code of Ethics and Professional Conduct</a>
</font>


## ACM Code of Ethics and Professional Conduct

<style scoped>
section {
  font-size: 23px;
}
</style>

> 2. PROFESSIONAL RESPONSIBILITIES.
> _A computing professional should ..._
> **2.1** Strive to achieve high quality in both the processes and products of professional work.
> 2.2 Maintain high standards of professional competence, conduct, and ethical practice.
> **2.3** Know and respect existing rules pertaining to professional work.
> 2.4 Accept and provide appropriate professional review.
> **2.5** Give comprehensive and thorough evaluations of computer systems and their impacts, including analysis of possible risks.
> **2.6** Perform work only in areas of competence.
> **2.7** Foster public awareness and understanding of computing, related technologies, and their consequences.
> **2.8** Access computing and communication resources only when authorized or when compelled by the public good.
> **2.9** Design and implement systems that are robustly and usably secure.<font size=3>
Source: <a href="https://ethics.acm.org/">ACM Code of Ethics and Professional Conduct</a>
</font>


## ACM Code of Ethics and Professional Conduct

> 3. PROFESSIONAL LEADERSHIP PRINCIPLES.
> _A computing professional, especially one acting as a leader, should ..._
> **3.1** Ensure that the public good is the central concern during all professional computing work.
> 3.2 Articulate, encourage acceptance of, and evaluate fulfillment of social responsibilities by members of the organization or group.
> 3.3 Manage personnel and resources to enhance the quality of working life.
> 3.4 Articulate, apply, and support policies and processes that reflect the principles of the Code.
> 3.5 Create opportunities for members of the organization or group to grow as professionals.
> **3.6** Use care when modifying or retiring systems.
> **3.7** Recognize and take special care of systems that become integrated into the infrastructure of society.<font size=3>
Source: <a href="https://ethics.acm.org/">ACM Code of Ethics and Professional Conduct</a>
</font>
<!-- >
> 4. COMPLIANCE WITH THE CODE.
> A computing professional should…
> 4.1 Uphold, promote, and respect the principles of the Code.
> 4.2 Treat violations of the Code as inconsistent with membership in the ACM. -->


## Task: IEEE Code of Ethics

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 5 minutes
-->

Read the [complete IEEE Code of Ethics](https://www.ieee.org/about/corporate/governance/p7-8.html)


## Why does it matter?

- Soon, you will enter the labor market as a professional software developer.
Eventually, many of you will raise in the hierarchy, become team leads, managers, etc.
You should be able to look to the mirror and be happy with your actions.

* ![w:750](https://i5.walmartimages.com/asr/83c4fe30-b5d1-491f-a0a9-13e87442c103.12f237b8fc2e4cb20c2f44145d714c2b.jpeg)<font size=3>
Image source: <a href="https://www.walmart.com/ip/With-Great-Power-Comes-Responsibility-22-x-36-Home-Art-Superhero-Spider-Man-Decor-Design-Uncle-Ben-Wall-Decal-Quotes-Vinyl-Kids-Bedroom-Living-Room-A/851492097">Walmart</a>
</font>


## Why does it matter? Volkswagen emissions scandal

> The Volkswagen emissions scandal [...] began in September 2015, when the United States Environmental Protection Agency (EPA) issued a notice of violation of the Clean Air Act to German automaker Volkswagen Group.
> The agency had found that Volkswagen had intentionally programmed turbocharged direct injection (TDI) diesel engines to activate their emissions controls only during laboratory emissions testing, which caused the vehicles' NOx output to meet US standards during regulatory testing. However, the vehicles emitted up to 40 times more NOx in real-world driving. Volkswagen deployed this software in about 11 million cars worldwide, including 500,000 in the United States, in model years 2009 through 2015.<font size=3>
Source: <a href="https://en.wikipedia.org/wiki/Volkswagen_emissions_scandal">Wikipedia</a>
</font>

Do you want to be the person that implemented that software?


## Why does it matter? Profiling of unemployed citizens

> I årevis har Styrelsen for Arbejdsmarked og Rekruttering samt en lang række danske kommuner eksperimenteret med, udviklet og anvendt adskillige forskellige machine learning-modeller, som havde til formål at hjælpe ledige borgere hurtigere i job.
>
> Som Version2 har afdækket, har profileringsprojekterne dog et efter et måttet lukke på grund af både juridiske, tekniske og performancemæssige udfordringer. Særligt juraen har været et problem for kommunerne, siden Datatilsynet i sommeren 2022 offentliggjorde en udtalelse, hvoraf det fremgår, at kommunerne ikke har lovhjemmel til at profilere ledige borgere. Heller ikke selvom borgerne samtykker til profileringen.<font size=3>
Source: <a href="https://pro.ing.dk/datatech/artikel/beskaeftigelsesministeren-slaar-fast-ai-profilering-af-ledige-er-ulovligt">ING/DataTech</a>
</font>

Do you want to be the person that implemented that software?


## Why does it matter? Sharing data of citizens

<style scoped>
section {
  font-size: 23px;
}
</style>

> »Københavns Kommune har på nuværende tidspunkt flere ulovlige kontrakter med leverandører og vil i den nærmeste fremtid have behov for at forny flere af disse kontrakter, fordi leverandørens løsning ikke udbydes af andre, og fordi systemet er nødvendigt for, at Københavns Kommune kan levere velfærdsydelser til borgere,« skriver DPO’en i et notat fra april i år.
> [...]
> Kontrakterne har hidtil været ulovlige af to grunde: Den første er videregivelses-problemet, som opstår, fordi tech-giganterne insisterer på at bruge borgeres persondata til egne formål som profilering og markedsføring. Det problem plager stadig kommunen.
>
> Den anden grund til ulovlige kontrakter er, at man inden sommer ikke måtte sende persondata til USA, hvor mange af de store it-leverandører hører til.
>
> Med to omfattende problemer hængende over hovedet, forsøgte Københavns Kommune sidste år at danne sig et overblik over, hvor mange af kommunens systemer, der ulovligt sender borgeres personoplysninger til USA. Svaret er 557 it-systemer, skriver DPO’en i et notat fra januar i år.

<font size=3>
Sources: <a href="https://pro.ing.dk/compliancetech/artikel/kommune-fanget-i-ulovlige-it-kontrakter-borgernes-data-bruges-til-reklamer">ING/ComplianceTech</a>, <a href="https://www.version2.dk/artikel/schrems-ii-slaar-revner-i-aula-vil-have-aendret-ulovlig-aws-aftale">Version2</a>
</font>


## Why does it matter? Sustainability

> Total US 2011 video viewing required about 192 PJ of primary energy and emitted about 10.5 billion kg of CO2(e). Shifting all 2011 DVD viewing to video streaming reduces the total primary energy use to about 162 PJ and the CO2(e) emissions to about 8.6 billion kg, representing a savings equivalent to the primary energy used to meet the electricity demand of nearly 200 000 US households each year.<font size=3>
Source: <a href="https://www.sciencedirect.com/science/article/pii/S0195925517303505">A. Shehabi et al. _The energy and greenhouse-gas implications of internet video streaming in the United States_</i></a>
</font>


Online advertising consumed between 20.38 to 282.75 TWh of energy and 11.53 – 159.93 million tons of CO2e was emitted to produce the electricity consumed [in 2016].<font size=3>
Source: <a href="https://www.sciencedirect.com/science/article/pii/S0195925517303505">M. Pärssinen et al. <i>Environmental impact assessment of online advertising</i></a>
</font>


## Task: What can you do?

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 10 minutes
-->

Imagine you continue to work on _Chirp!_. You and your group got hired by a big corporation "LoremIpsumSoft". _Chirp!_ went viral, you have 500 million users from all over the world.
Your boss realizes that it is quite difficult to make money with the application, advertisements were tried, but almost all users are blocking them since they are so annoying. Therefore, he comes to you to ask if you could build a statistical model over the users that predicts political positions and believes. He plans to sell the results from such a model to political parties to support their election campaigns

Discuss with your neighbors:

- How do you react?
- What do you answer your boss?
- What do you do yourself?


## Why does it matter? Cambridge Analytica scandal

>  In the 2010s, personal data belonging to millions of Facebook users was collected without their consent by British consulting firm Cambridge Analytica, predominantly to be used for political advertising.
>
> The data was collected through an app called "This Is Your Digital Life", developed by data scientist Aleksandr Kogan and his company Global Science Research in 2013. The app consisted of a series of questions to build psychological profiles on users, and collected the personal data of the users’ Facebook friends via Facebook's Open Graph platform. The app harvested the data of up to 87 million Facebook profiles. Cambridge Analytica used the data to provide analytical assistance to the 2016 presidential campaigns of Ted Cruz and Donald Trump.<font size=3>
Source: <a href="https://en.wikipedia.org/wiki/Facebook%E2%80%93Cambridge_Analytica_data_scandal">Wikipedia</a>
</font>


<!-- Third hour -->

<!-- ## Documentation -->

## In-code documentation

<style scoped>
pre {
  font-size: 23px;
}
section {
  font-size: 23px;
}
</style>

```csharp
/// <summary>
/// This class repesents the user of the _Chirp!_ application.
/// Since _Chirp!_ is a micro-blogging application, all authenticated
/// users are expected to author cheeps.
/// </summary>
public class Author : IdentityUser
{
    public List<Cheep> Cheeps { get; set; }
    ...
}

/// <summary>
/// ...?
/// </summary>
public class Cheep
{
    public int Id { get; set; }
    public required string Content { get; set; }
    public required DateTime Timestamp { get; set; }
    ...
}
```
<font size=3>
Source: <a href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/">.NET Docs Documentation comments</a>, <a href="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/documentation-comments">.NET Docs Annex D Documentation comments</a>
</font>


## Best practice

<style scoped>
section {
  font-size: 23px;
}
</style>

- Do not over use in-code documentation.
- **Never** document trivial or default code!
- Focus on your domain and complicated business logic.
  - Likely you do not have a lot of the latter in _Chirp!_.
  - Where you have it, add respective documentation

- In code, provide links to sources that influenced your solution.
- If you create code that is complex and difficult to understand, explain next to it **what** the reasons for complexity are, what you ruled out as more simple solutions, and everything that the future you/colleague needs to know to understand the reason for complexity.
  - Likely you do not have a lot of that in _Chirp!_.
  - You want to document that this is not _accidental_ complexity.
  - If you were Skat, you had a lot of _inherent_ complexity.

- A good example is the implementation of [Gitlet](https://github.com/maryrosecook/gitlet/blob/master/gitlet.js)


## Task: In-code documentation

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 5 minutes
-->

Provide an explanatory comment for the `Cheep` entity class.

```csharp
/// <summary>
/// ...?
/// </summary>
public class Cheep
{
    public int Id { get; set; }
    public required string Content { get; set; }
    public required DateTime Timestamp { get; set; }
    ...
}
```

## External documentation — Know your audience

- End-user documentation
- Developer documentation
- Operator documentation

In your project report, you will provide information for developers and operators, not for end-users. We skip that in this course.


## How to write?

> - Use inline markup liberally.
> - Write in short paragraphs.
> - Use a variety of structural elements. [Lists, tables, code blocks, etc.]
> - Make your structure visual.
>
>
> - Watch out for passivity.
> - Omit fluff.<font size=3>
Source: <a href="https://jacobian.org/2009/nov/11/technical-style/">Jacob Kaplan-Moss</a>
</font>


## How to write technical documentation?

> 1. Dry sucks
> 1. Before you start, be clear about what you want your reader to do after you end
> 1. Write to a well formed outline, always
> 1. Avoid ambiguous pronouns
> 1. clarity = illustrations + words
> 1. When dealing with concepts… logical illustration and example
> 1. Embrace revision<font size=3>
Source: <a href="https://www.developer.com/guides/the-7-rules-for-writing-world-class-technical-documentation">Bob Reselman</a>
</font>


## How to write technical documentation?
<style scoped>
section {
   font-size: 18px;
}
</style>

> Technical documentation is hard, really hard. It's easier to explain what not to do. Some suggestions:
>
>  - It's no prose, so don't try to be arty.
>  - Keep it short!
>  - When in doubt, drop it.
>  - Use simple words. Not everyone is fluent in English.
>  - Any sentence with more then two lines is an anomaly.
>  - Be consistent. Avoid surprises.
>  - Use cases and Examples are important and may shorten explanations.
>  - Include common mistakes and their workarounds.
>  - You have to refactor often (>>20x).
>   - Use a versioning system like git or mercurial.
>  - Avoid abbreviations and introduce them at first occurrence e.g: concurrent versioning system (CVS)
>  - A column shouldn't exceed 9-12 words (~60 chars) to improve readability.
>  - Keep your rules in a file (e.g: doc.playbook) and check them
>  - Let others proof read, or yet better find an editor.
>  - Try to be gender agnostic. Why? cautionary tale: https://github.com/joyent/libuv/pull/1015<font size=3>
Source: <a href="https://news.ycombinator.com/item?id=8414714">kevin_bauer on Hacker News</a>
</font>


## Writing documentation for an open-source project

... for which you want to have contributors is a bit different though, see e.g., [Write the Docs](https://www.writethedocs.org/guide/writing/beginners-guide-to-docs/#what-to-write)


## Best practice: Be short and concise

![w:600px](https://assets-global.website-files.com/5f7178312623813d346b8936/633fe7576d64c17f9254ec05_VoFhK48srXT66sQZFnVnlByGTZ7AcTzit1O-hzPWosFMEbv9nrzG4ATOq8B0JQm2yRZCxhsW6lZXSQ3lc98csjOhtW6r9hhBhnVji9P_dholtte8X1GNQuMS0xecFdG5fOoDtWJbKU6cxIq50Ha81j5BjB-tj1w9c6U3WN1MdM7_uM-BYRLwG4LzUg.png)

<font size=3>
Image source: <a href="https://www.archbee.com/blog/how-to-improve-technical-writing-skills">Archbee Blog</a>
</font>


## Best practice: KISS


> 6. Be CONCISE
>
>Don't say: "The mystery lady was one who every eligible man at the ball admired."
>
>Instead say : "Every eligible man at the ball admired the mystery lady."
>
> 7. Use the VOCABULARY that you know.
>
> Don't always feel you have to use big words. It is always better to be clear and use simple language rather than showing off flashy words you aren't sure about and potentially misusing them. This is not to say, however, that you should settle for very weak vocabulary choices (like "bad" or "big" or "mad").
<font size=3>
Source: <a href="https://slc.berkeley.edu/writing-worksheets-and-other-writing-resources/nine-basic-ways-improve-your-style-academic-writing">Berkeley Student Learning Center</a>
</font>


## Task: Improve writing

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 5 minutes
-->

Read the following paragraph.

> Modern software development is full of dependencies on
free open source software (FOSS). This software ranges from
the application the code is being written in e.i. visual studio
code, to how the quality of the software is tested e.i. Moq,
NUnit, etc. As such, it is important to keep the health of
a project in mind when choosing to rely on it.<font size=3>
Source: Anonymous
</font>

- Can you understand it?
- Try to improve it.


## Tooling for writing documentation

- Simple: [mkdocs](https://www.mkdocs.org/)
- More elaborate: [Sphinx](https://www.sphinx-doc.org/en/master/)
- [AsciiDoc](https://docs.asciidoctor.org/)

We take it way more simple. Your project reports are written in one Markdown file and converted to PDF with [`pandoc`](https://pandoc.org/).


## Tools for illustration

There is a plethora of such tools. In this and future courses at ITU, you likely find the following two sufficient.

- [PlantUML](https://plantuml.com/)
- [DrawIO](https://app.diagrams.net/).

Many projects consider it a good practice when your illustrations are generated in-code (PlantUML) compared to WYSIWYG editors (DrawIO).
(Same philosophy as with markup languages compared, e.g. Microsoft Word files.)


## Best practice: Let documentation live together with your source code

What is Software? Helge's definition:

  > Software is the collection of **all artifacts**, which allow (a) **suitably educated person(s)** with access to specified and suitable **hardware** to instantiate a running system.
  >
  > Additionally, the collection of such artifacts allow such suitably educated person(s) to **understand** and **reason** about a systems' working and properties and let them **understand** why the system is as it is and why it behaves the way it does.<font size=3>
Source:  Helge
</font>


## The report

- See the description of the deliverable [here](./README_REPORT.md)
- Find the template for the report [here](./docs/)


<!-- Fourth hour -->

## Software Design?

  > use of **scientific principles**, **technical information**, and **imagination** in the definition of a software system to perform **pre-specified functions** with maximum **economy** and **efficiency**<font size=3>
Source: ISO/IEC/IEEE 24765:2017 <i>Systems and software engineering-Vocabulary</i>
</font>


## Software Design?

  > In every engineering discipline, design encompasses the **disciplined approach** we use to **invent a solution** for some problem, thus providing a **path from requirements to implementation**. In the context of software engineering, Mostow suggests that the purpose of design is to construct a system that:
  >
  > - **Satisfies** a given (perhaps informal) **functional specification**
  > - **Conforms to limitations** of the target medium
  > - **Meets** implicit or explicit **requirements** on performance and resource usage
  > - **Satisfies** implicit or explicit **design criteria** on the form of the artifact
  > - **Satisfies** restrictions on the **design process** itself, such as its length or cost, or the tools available for doing the design<font size=3>
Source: <a href="https://www.informit.com/articles/article.aspx?p=726130&seqNum=6">G. Booch et al. _"Object-Oriented Analysis and Design with Applications"_</a>
</font>


## Software Design?

That is similar to what Sommerville says about _Software Engineering_:

  > **Engineering discipline** Engineers make things work. They **apply theories, methods, and tools** where these are appropriate. However, they use them selectively and always **try to discover solutions** to problems even when there are no applicable theories and methods. Engineers also recognize that they must **work within organizational and financial constraints**, and they must look for solutions within these constraints.<font size=3>
Source: I.Sommerville _"Software Engineering"_
</font>


## Software Design

  > The **final goal of any engineering activity** is the some type of **documentation**. When a design effort is complete, the design documentation is turned over to the manufacturing team. This is a completely different group with completely different skills from the design team. If the design documents truly represent a complete design, the manufacturing team can proceed to build the product. In fact, they can proceed to build lots of the product, all without any further intervention of the designers.
  > [...] the only software documentation that actually seems to satisfy the criteria of an engineering design is the source code listings.<font size=3>
Source: J. Reeves _"What is Software?"_
</font>


## Software Design

Note, other more object-oriented analysis and design advocates have a slightly other opinion on that:

  > Design involves **balancing a set of competing requirements**. The **products of design are models** that enable us to reason about our structures, make trade-offs when requirements conflict, and in general, provide **a blueprint for implementation**.<font size=3>
Source: <a href="https://www.informit.com/articles/article.aspx?p=726130&seqNum=6">G. Booch et al. _"Object-Oriented Analysis and Design with Applications"_</a>
</font>


## Task: One system/feature many different designs?

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 10 minutes
-->

- Read on task of this weeks [project work](./README_PROJECT.md#add-feature-forget-me)
- Brainstorm with your peers, how you could design such a feature.
  - What could be the most simple solution?
  - Can you foresee any issues?


## Note on Pseudonomization vs. Anonymization

> Pseudonymization is a data management and de-identification procedure by which personally identifiable information fields within a data record are replaced by one or more artificial identifiers, or pseudonyms. A single pseudonym for each replaced field or collection of replaced fields makes the data record less identifiable while remaining suitable for data analysis and data processing.
>
> [it] is one way to comply with the European Union's new General Data Protection Regulation (GDPR) demands for secure data storage of personal information. Pseudonymized data can be restored to its original state with the addition of information which allows individuals to be re-identified. In contrast, anonymization is intended to prevent re-identification of individuals within the dataset.
> <font size=3>
Source: <a href="https://en.wikipedia.org/wiki/Pseudonymization">Wikipedia</a>
</font>


## Software Architecture?

  > Architecture represents the set of **significant design decisions** that shape the form and the function of a system, where **significant is measured by cost of change.**<font size=3>
Source: <a href="https://twitter.com/Grady_Booch/status/1301810358819069952">G. Booch</a>
</font>


## Software Architecture?

  > Architecture is about **the important stuff**. Whatever that is. On first blush, that sounds trite, but I find it carries a lot of richness. It means that the heart of thinking architecturally about software is to decide what is important, (i.e. what is architectural), and then expend energy on keeping those architectural elements in good condition. For a developer to become an architect, they need to be able to recognize what elements are important, recognizing what elements are likely to result in serious problems should they not be controlled.<font size=3>
Source: <a href="https://ieeexplore.ieee.org/document/1231144">Martin Fowler _"Design - Who needs an architect?"_</a>
</font>


## Software Architecture?

  > Combining the concept of the **class and object structures** together with the five attributes of a complex system (hierarchy, relative primitives [i.e., multiple levels of abstraction], separation of concerns, patterns, and stable intermediate forms), we find that virtually all complex systems take on the same (canonical) form, [...]. Collectively, we speak of the **class and object structures of a system as its architecture**.<font size=3>
Source: <a href="https://www.informit.com/articles/article.aspx?p=726130&seqNum=4">G. Booch et al. _"Object-Oriented Analysis and Design with Applications"_</a>
</font>


## Software Architecture &mdash; Case: Coronapas App

An illustration of architecture in the large:

![w:500](https://github.com/itu-bdsa/lecture-notes/blob/main/sessions/swe_02/images/coronapas_app_arkitektur.png?raw=true)

<font size=3>
Source: <a href="https://digst.dk/media/24346/whitepaper-om-coronapas_290521.pdf">Whitepaper om coronapas-appen</a>
</font>


## Feedback: Use of Large Language Models?

In all of your commits, I found nine that stated to be co-authored with ChatGPT.
Is that true? I cannot believe that 😃

Let's get some data that I can use for next week. Please fillout the following survey:
https://www.menti.com/alete7oe13yv


## What to do now?

![w:400px](https://25.media.tumblr.com/47f546206bf9a8b5dc97e7fe1b6714b3/tumblr_mi7nkgP6NH1qmegz6o1_500.gif)

- If not done, complete the Tasks (blue slides) from this class
- Check the [reading material](./READING_MATERIAL.md)
- Work on the [project](./README_PROJECT.md)
