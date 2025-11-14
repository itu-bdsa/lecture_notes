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

  section.centered {
    display: flex;
    flex-direction: column;
    justify-content: center;
    text-align: center;
  }

  div.mermaid { all: unset; }
---

# **Analysis, Design and Software Architecture (BDSA)**
Session 11
[Sven Peldszus](svpe@itu.dk)


## Plan for this week

- Requirements Engineering
- Structural Modeling
- Behavioral Modeling

<!-- First hour -->

# Requirements vs. Reality

![w:750px](https://deliveringresults.leeds.ac.uk/wp-content/uploads/sites/8/2017/02/Requirements2.png)

## Requirements more formally

<style scoped>
section {
   font-size: 21.5px;
}
</style>

  > **requirement**
  >
  > statement which translates or expresses a need and its associated constraints (3.1.7) and conditions (3.1.6)
  >
  > Note 1 to entry: Requirements exist at different levels in the system structure.
  >
  > Note 2 to entry: A requirement is an expression of one or more particular needs in a very specific, precise and unambiguous manner.
  >
  > Note 3 to entry: A requirement always relates to a system, software or service, or other item of interest.

*Source: <a href="https://www.iso.org/obp/ui/#iso:std:iso-iec-ieee:29148:ed-2:v1:en">ISO/IEC/IEEE 29148:2018(en) Systems and software engineering — Life cycle processes — Requirements engineering</a>*

  > **software requirements specification (SRS)**. (1) documentation of the essential requirements (functions, performance, design constraints, and attributes) of the software and its external interfaces

*Source: <a href="https://standards.ieee.org/ieee/1012/5609/">IEEE 1012-2016 IEEE Standard for System, Software, and Hardware Verification and Validation, 3.1.29</a>*

## Types of Non-functional Requirements

![w:800px](images/non_func_reqs.png)
Image source: I. Sommerville <i>Software Engineering</i>


## Functional vs. Non-functional requirements

> * _Functional requirements._ These are statements of services the system should provide, how the system should react to particular inputs, and how the system should behave in particular situations. In some cases, the functional requirements may also explicitly state what the system should not do.
> * _Non-functional requirements._ These are constraints on the services or functions offered by the system. They include timing constraints, constraints on the development process, and constraints imposed by standards. Non-functional requirements often apply to the system as a whole rather than individual system features or services.

*Source: I. Sommerville <i>Software Engineering</i>*



## Metrics for Specifying Non-functional Requirements

![w:800px](images/non_func_reqs2.png)

Image source: I. Sommerville <i>Software Engineering</i>

## Task: What kind of requirement?

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 10 minutes
-->

- Read [today's project description](./README_PROJECT.md#add-feature-users-can-follow-and-unfollow-each-other) for implementing the new un-/follow feature of _Chirp!_.
- Discuss with your neighbors: What kind of requirement is specified there?

- In next week's guest lecture, we will realize that the _Chirp!_ application has to be  [General Data Protection Regulation (GDPR)](https://en.wikipedia.org/wiki/General_Data_Protection_Regulation) compliant.
- Discuss with your neighbors: What kind of requirement is this?


<!--## Feedback: **Requirement** for Authentication

<style scoped>
section {
   font-size: 18px;
}
</style>
#### As a user, I have to be able to login with GitHub so that I can send cheeps.

There are multiple ways to perform authentication via third parties (here via GitHub).
The lecture and the book present:
a) Idendity Core, see [ticket #XYZ](...)
b) Idendity Core with GitHub OAuth
...

The project task provides a code snippet for the Razor view. It illustrates that there has to be a link that initiates the authentication functionality, which has to contain the text `login` and which is located in the navigation bar.

```html
... Code example from task comes here ...
```

... More description that you deem necessary ...

**Acceptance Criteria**:
- There is a _link_ with text `login` displayed in the navigation bar of _Chirp!_
- If logged into GitHub in another browser window/tab and after clicking the `login` link, a user is authenticated to _Chirp!_.
- After authentication, a cheepbox appears above the list of cheeps, see [ticket #XYZ](...).
- After authentication, the `login` link in the navigation bar turns into a link to `logout` displaying the text `logout`.
- After clicking logout, the cheepbox disappears again from the top of the list of cheeps.
-->

<!-- Second hour -->

## Visual languages for design and architecture

Eventually, you have to document your system's design and architecture so that your colleagues, customers or other stakeholders have a chance of understanding how your system is structured and how it works.

<!--Remember Martin's guest lecture from two weeks ago? He said that he believes it is the most important task that you have.-->

Since it is such a common task, various visual notations were developed over time. One of them is the _Unified Modeling Language_ (UML). I will give you a whirlwind tour through some of its diagram types today.

But why do we need a _Unified Modeling Language_?


## Visualizing structure or behavior with your own notations?

![bg right 50% 100%](./images/authenticated_request.png)

Drawback of own notation:
* What is the meaning of note symbols?
* What is the meaning of rounded rectangles?
* What is the meaning of color?
* Separation of concerns/single responsibility? The diagram mixes structural with behavioral concerns?

*Image source: Andrew Lock <i>ASP.NET Core in Action</i>*


## Visualizing structure or behavior with your own notations?
<style scoped>
pre {
   font-size: 20px;
}
section {
   font-size: 20px;
}

</style>
Best practice:
- You have to provide a legend together with your visualization.
- It it has to describe all used symbols and their meaning.

![w:600px](./images/bpmn.png)
![bg right:30% 100%](./images/bpmn_legend.png)


*Image source: <a href="https://camunda.com/bpmn/reference/">BPMN 2.0 Symbol Reference</a>*

<!--
## Visualizing structure or behavior with your own notations?

<style scoped>
pre {
   font-size: 20px;
}
section {
   font-size: 20px;
}
</style>

Best practice:
- You have to provide a legend together with your visualization.
- It it has to describe all used symbols and their meaning.

![bg right:50% 100%](./images/feature_model.png)

Image source: <a href="https://www.researchgate.net/publication/271737676_The_design_space_of_multi-language_development_environments">H. Pfeiffer et al. <i>The design space of multi-language development environments</i></a>
-->

## Unified Modeling Language (UML)

- What is the UML?
  - General purpose modeling language for developing software systems
  - Provides a standard way to visualize the design of a system
- Detailed specification in the UML Super Structure: https://www.omg.org/spec/UML/ 

![w:700px](https://upload.wikimedia.org/wikipedia/commons/d/d6/Uml_diagram2.png)

## Structural Diagrams
<!-- _class: centered -->


## Design: UML Class diagrams — Class with Fields
<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

```csharp
public class Student
{
    public string Name;
    public Image photo;
    private List<int> courses;

    public void enroll(int courseID)
    {
        courses.Add(courseID);
    }
}
```

![bg right:30% 80%](./images/class.png)


## Design: UML Class diagrams — Inheritance
<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

```csharp
public class Student
{

}
public class GuestStudent : Student
{

}
```

![bg right:30% 50%](./images/class_inheritance.png)


## Design: UML Class diagrams — Associations
<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

<style scoped>
pre {
   font-size: 22px;
}
section {
   font-size: 21px;
}
</style>

```csharp
public class Student
{
    public string Name;
    public Image photo;
    private List<Course> courses;

    public void enroll(Course course)
    {
        courses.Add(course);
    }
}

public class Course
{
    public int Id;
}
```

![bg right:40% 100%](./images/class_association.png)

If you have bi-directional references in your code, then the association becomes just a line, i.e., no arrows, with the names of the respective references at the opposite end of the association.


## Modeling Best Practices
- Classes
  - Names are singular, e.g., *Cheep*

- Associations
  - At least one association end name
  - At least one multiplicity
  - Names reflect multiplicities, e.g., \* *courses*

![width:700px](./images/class_association.png)


## Domain Models

Systematically capture the entities, their properites, and their relationships that exist in the domain in which the system will operate.
- Help to create a common knowledge about the domain
- Describe the problem domain, i.e., what is the problem that will be addressed by the system
- First step towards developing a solution (e.g., models describing the application domain)

## Task: Entity Diagram

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 10 minutes
-->

- For drawing: Navigate to https://app.diagrams.net/
- **Hint:** From the UML elements in the bottom left, choose classes, associations, and if necessary inheritance relations.
- Draft an illustration of the domain model of your _Chirp!_ application.
- Once done, send an image to our Teams chat (all in one thread), so that we can discuss some of the diagrams.


## Design: UML Class diagrams to illustrate Domain model

<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

![width:1000px](./images_private/domain_model_with_identity.png)

- Note, the above is likely not a complete entity diagrams once you decide to implement an un-/follow feature to your systems.


What are alternatives to entity diagrams with UML class diagrams?
* ER diagrams as you saw them in your database class.


## Models are more than pictures

In practice you will often sketch models by hand, e.g., brainstorming on a white board

But you have to stick to the syntax

- **Question:** How easy was it to stick to the UML syntax?

Models can be more powerful
- Multiple views on the same model (in the UML, model and view are decoupled)
- Reuse of elements between views
- A lot of automation


## Computer-Aided Software Engineering (CASE) Tools

Assist developers and analysts in creating and managing models (like UML class diagrams) and other artifacts throughout the software development life cycle (SDLC).

Functions
  - **Modeling:**	Create and edit UML diagrams (class, use case, sequence, activity, state, etc.).
  - **Code Generation:**	Automatically generate source code from UML diagrams.
  - **Reverse Engineering:**	Generate UML diagrams from existing source code.
  - **Consistency Checking:**	Verify relationships and constraints across diagrams.
  - **Documentation:**	Automatically produce technical documentation from models.
  - **Collaboration:**	Working together on the same UML project with version control.

In this course, we use the community edition of Visual Paradigm
 - https://www.visual-paradigm.com/download/community.jsp


## UML Component diagrams
<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

![bg 70%](images/client_server_comp_db.png)


## Detour: What is a _component_???


  > A software element that conforms to a standard component model and can be **independently deployed and composed** without modification according to a composition standard.
  *Source:  W.T. Councill et al. _"Definition of a Software Component and Its Elements."_*

  > A software component is a unit of composition with contractually-specified interfaces and explicit context dependencies only. A software component can be **deployed independently and is subject to composition** by third parties.
  *Source:  C. Szyperski _"Component Software: Beyond Object-Oriented Programming"_*


## Detour: Characteristics of Components

  > 1. The component is an **independent executable entity** that is defined by its interfaces. You don’t need any knowledge of its source code to use it. It can either be referenced as an **external service or included directly** in a program.
  >
  > 2. The services offered by a component are made available through an interface, and all interactions are through that interface. The component interface is expressed in terms of parameterized operations, and its internal state is never exposed.
  *Source: I. Sommerville _Software Engineering_*


## Task: What are components in your _Chirp!_ applications?

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 5 minutes
-->

Discuss with each other, what are components in your _Chirp!_ applications?


## Architecture in the small vs. in the large

  > 1. **Architecture in the small** is concerned with the architecture of individual programs. At this level, we are concerned with the way that an individual program is decomposed into components.
  > 2. **Architecture in the large** is concerned with the architecture of complex enterprise systems that include other systems, programs, and program components. These enterprise systems may be distributed over different computers, which may be owned and managed by different companies.
  
Source: *I. Sommerville _Software Engineering_*

<!--@Helge: Name what maps to components in the small and in the large.-->


## Design: UML Deployment diagrams
<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

> [A] Node is a deployment target which represents computational resource upon which artifacts may be deployed for execution.
*Source: <a href="https://www.uml-diagrams.org/deployment-diagrams.html">uml-diagrams.org</a>*

![bg right:50% 100%](./images/multi_clients_server_comp.png)

In your cases, you can consider each service that you receive from Azure as a Node.


## Behavioral Diagrams
<!-- _class: centered -->


## Design: UML Statecharts (State Machines)
<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

- States can be state of your entire application, of some of its components, etc.
* Below is the state of a user of your application. From a starting state (black dot), a user's state transitions between the two states `LoggedIn` and `LoggedOut`.
  ![width:500px](./images/login_logout_sm.png)
* Note, likely a state machine diagram does not map directly to code in the same way that the class diagram for your domain model does, at least not for your _Chirp!_ applications.


## Design: Nested UML Statecharts (State Machines)
<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

  ![width:500px](./images/state_follow.png)


## UML Activity diagrams
<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

* Initial state
* Activity. Can be anything from what is done in a single method all the way up to long running (even manual) processes.
* Condition (◇)
* Final state

![bg right:50% 80%](./images/activity_syntax.png)

## Design: UML Activity Diagrams
<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

An example of sequence of activities for sending (sharing) a cheep could look like.
Note, in your implementations, activities might be in a different order or different activities.

Again, activities do likely map to larger parts of your source code, e.g., controller methods in C♯, Razor views, etc.

![bg right:50% 90%](./images/activity.png)


## UML Activity Diagrams combined with Wireframes
<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

Can be used as screen transition diagrams that may be used during design of user centered flow of screens.

Note, the following is an incomplete activity diagram.

![w:1000px](./images/wireframe_online_editor.png)



## Task: Activity Diagram

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 10 minutes
-->

![bg right:30% 100%](./images/activity.png)
- Read again [today's project description](./README_PROJECT.md#add-feature-users-can-follow-and-unfollow-each-other) for implementing the new un-/follow feature of _Chirp!_.

- Use Visual Paradigm

- Draft an activity diagram that illustrates a sequence of activities when a user is choosing to follow another user.
<!-- - Once done, send an image to our Teams chat (all in one thread), so that we can discuss some of the diagrams. -->


<!-- Third hour -->


## UML Sequence diagrams — Mapping of visual elements to code
<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

<style scoped>
pre {
   font-size: 22px;
}
section {
   font-size: 22px;
}
</style>

```csharp
public class Student
{
    public string Name;
    public Image photo;
    private List<Course> courses;

    public Status enroll(Course course)
    {
        courses.Add(course);
        return Status.Sucess;
    }
}

public class Manager
{
    private List<Student> students;

    public void SignUp(string Name, Course course) {
        student = students.Where(s -> s.Name == Name).First();
        student.enroll(course);
    }
}
```

![bg right:35% 80%](./images/sd_call.png)


## Sub-system sequence diagrams
<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

You saw a quite complex diagram that was inspired by sequence diagrams already earlier. It illustrates the sequence of calls between different systems in OAuth authentication.

![bg right:50% 70%](../session_08/images/oauth_dance.png)


## Sub-system sequence diagrams
<!--
_backgroundImage: "linear-gradient(to bottom, #deb887, #d17e12)"
_color: white
-->

Note, sub-system sequence diagrams are more abstract than "normal" sequence diagrams. The former are on the level of (sub-)systems and the latter on the level of objects (in terms of object-orientation).

![bg right:60% 100%](./images/sd_oauth_dance.png)


## Illustrating Structure vs. Behavior

What did we do in the previous slides?

- There are two major concerns of a system that you want to illustrate:
  - Structure: UML class diagrams
  - Behavior: UML statecharts, activity diagrams, sequence diagrams

## Intro to project work

- From now on, tasks in project work are formulated more openly.
- That is, you have to _analyze_ what is written there to be able to design a suitable solution and to implement it correctly.

- If the illustration tools that were presented today help you in analyzing project descriptions and designing suitable solutions, then use them.


## Next week, guest lecture: GDPR and "Privacy by Design"


![w:400px](https://assets.swoogo.com/uploads/full/1642938-622b4a6ee2364.png)

Jakob Krabbe Sørensen from [ComplyCloud](https://www.complycloud.com/) will give a guest lecture on "Privacy by Design" and why GDPR matters to you as software engineers.

## Task: Privacy by Design?

<!--
_backgroundImage: "linear-gradient(to bottom, #67b8e3, #0288d1)"
_color: white
_header: 10 minutes
-->

Next week, we will have a guest lecture about GDPR and privacy by design. To motivate that lecture, we conduct this task.

- What precisely do you know about your users?
- Where do you have to check?
- Inspect your data model, i.e., all entities on what you store about your users.
  - Is there somewhere else to check?
- With a database browser, investigate what your database really contains about users.


## What to do now?

![w:400px](https://25.media.tumblr.com/47f546206bf9a8b5dc97e7fe1b6714b3/tumblr_mi7nkgP6NH1qmegz6o1_500.gif)

- If not done, complete the Tasks (blue slides) from this class
- Check the [reading material](./READING_MATERIAL.md)
- Work on the [project](./README_PROJECT.md)

- *We are done reading chapters from [Andrew Lock _ASP.NET Core in Action, Third Edition_](https://www.manning.com/books/asp-net-core-in-action-third-edition)!*
