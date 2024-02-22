# Lectures
- [Recording Links](https://intellitectsp.sharepoint.com/:f:/r/sites/EWU-CSCD379-2024-Spring/Shared%20Documents/General/Recordings?csf=1&web=1&e=DcoaGK)
- This is an MS Teams link and everyone in the class should have access. If not, please contact an instructor.

## Tentative Lecture Schedule

## Week 1
### Lecture 1: 4/4: Build the App (Assignment 1)
- Syllabus & expectations
- Wordle Requirements
- Set up front end and build out basic application. 
- Initial look at 
  - NPM
  - Vue
  - Vuetify
- Basic unit testing with Jest


### Lecture 2: 4/6: Deployment (Assignment 1)
- Complete application 
- Build deployment for front-end in Azure.
- Azure DevOps
- YAML
- Azure AppService
- Vue Build

## Week 2
### Lecture 3: 4/11: Vue (Assignment 2)
- Why Vue? What problem does is solve?
- What is Vue for and how does it work? Stop messing with the DOM
- {{ Interpolation }}
- Data Binding and Observables: https://vuejs.org/guide/essentials/template-syntax.html
  - Proxies
  - Attributes
  - Class and Style https://vuejs.org/guide/essentials/class-and-style.html
  - Functions
  - Conditional Rendering: https://vuejs.org/guide/essentials/conditional.html
  - Lists (For loops): https://vuejs.org/guide/essentials/list.html
  - Events: https://vuejs.org/guide/essentials/event-handling.html
  - Input: https://vuejs.org/guide/essentials/forms.html
- Computed properties https://vuejs.org/guide/essentials/computed.html
- Pages
- Component Basics
- Routing https://vuejs.org/guide/scaling-up/routing.html
- Lifecycle: https://vuejs.org/guide/essentials/lifecycle.html


### Lecture 4. 4/13: Vuetify (Assignment 2)
- Why CSS is the devil
- Grid System
- Display and sizing
- Icons
- Theming
- Elevation
- Height and width (h- & w-"
- Spacing (padding and margins) (CSS Box Model)
- Components: Containment
  - Buttons
  - Cards
  - Chips
  - Lists
- Components: Tables
- Components: Form Inputs
  - Selects
  - Switches
  - Text: Fields and Areas
  - Combos


## Week 3
### Lecture 5. 4/18: Vue Components (Assignment 2)
- Components: https://vuejs.org/guide/components/registration.html
  - Props https://vuejs.org/guide/components/props.html
  - Events https://vuejs.org/guide/components/events.html
  - v-model https://vuejs.org/guide/components/v-model.html
  - Slots https://vuejs.org/guide/components/slots.html
- Watchers: https://vuejs.org/guide/essentials/watchers.html
- Transitions: https://vuejs.org/guide/built-ins/transition.html


### Lecture 6. 4/20: ASP.NET Intro
- Starting an ASP.NET API Project
- Creating a simple API
- Unit Testing the API
- Program.cs
- Controllers
- Services (DI)


## Week 4
### Lecture 7. 4/25: Entity Framework Intro
- Creating a context
- Creating models
- Migrations
- Deployment (Site and Database)


### Lecture 8. 4/27: 
- More ASP.NET and EF and homework 3 material


## Week 5
### Lecture 9. 5/2: 
- Initial EF Context
- Word object
- Word migration
- Word Controller that returns a word
- Word Service
- Service Dependency Injection

### Lecture 10. 5/4: 
- API Post
- DTOs
- EF Migration Deltas to a table
- Basic EF Querying
- Axios using Post

## Week 6
### Lecture 11. 5/9: 
- API unit testing: database, services, integration.
- App Refactor:
  - Add game features like end and restart
  - Add solver and componentize
  - Handle the word API not responding
  - API configuration: Swagger in production
  - Action updates, versioning, file names, warnings
  - Sizing of letters/buttons with useDisplay
  - Unit testing letters with DI on useDisplay
  - New App bar and UI cleanup
  - New starting page and default route
  - Theme update and add of 'Unknown' color
  - Split LetterResult from LetterButton
  - Move AddWordTest to about page
  - Custom icon and favicon
  - Google Search Console and 

### Lecture 12. 5/11: 
- Troubleshooting Azure
- Vue services
- EF Parent-Child relationships
- Querying with Includes
- EF unit testing
- Model builder cascade deletes
- Adding of DateWord and Migration

## Week 7
### Lecture 13. 5/16: 
- Classes in C#/Java and TS/JS
- Redirecting root on API to the Wordle site
- Word of the day controller and tests
- Handling multi-threading issues with creating the word of the day.

### Lecture 14. 5/18:
- Unique indexes
- Reusing a view for multiple routes
- Parsing query parameters to determine game type
- Get method query parameters on API endpoints
- Load Word of the day in App
- Integration testing

## Week 8
### Lecture 15. 5/23: 
- EF multiple table queries (Getting Word of the Day stats)
- Using GroupBy, Sort
- Questions from the homework
- Lots of other stuff pertaining to homework

### Lecture 16, 5/25
- Database rollback and Migration consolidate
- Full page images with themes
- CSS deep dive
- Navigation when query changes
- v-model
- CSS animations using transition
- Creating revealing letters
- The problem of security and how to handle it
- ASP.NET Identity Intro

## Week 9
### Lecture 17. 5/30: 
- ASP.NET Identity
- Setup up EF Identity in an existing project
- JWT creation and verification
- Authorization attributes for roles and policies
- Setup of Swaqgger to take a bearer token

### Lecture 18. 6/1: 
- Front end bearer tokens
- Auth Service
- Route Guarding


### Next Topics
- Identity in a web project (not just API)
- Scaffolding EF
- Adding Identity to the API
- Scaffolding EF
- Cookies
- JWTs, validation, claims (UserId, Name)
- Create login component
- Managing state around logins, existing GUID, etc.
- Managing auth flow and various login cases
- Remembering login
- Refreshing the token
- Authorizing specific API calls
- API testing with service mocks and interfaces
- Graceful error handling when API is missing


## Week 10 
### Lecture 19. 6/6: 


### Lecture 20. 6/8: 
- Work on Final project
- Work on Assignment 4

Other Topics
  - Vuetify
    - Flex
    - Float
    - Dialogs
    - Menus
    - Tooltips
    - 

## Finals Week


# Other Notes from last year's class
## Lectures
### Lecture 8 (4/28/22)
- Finish covering EF
- Unit Testing with EF
- Homework #3
- Review Homework #2 due tonight

### Lecture 7 (4/26/22)
- Complete the Leaderboard API without spilling the beans on Homework #3
- ASP.NET Unit Testing
  - Unit testing the LeaderBoardService
  - Unit testing LeaderboardController
  - Creating a mock for ILeaderBoardService
  - Integration testing the LeaderBoard API endpoints
- Building a Statistics Controller
  - Setting up EF
  - Adding a Context and Statistics class
  - Migrations
- Deploying to Azure with an Azure SQL database
  - Set up Azure SQL Database
  - Set up Connection Strings

### Lecture 6 (4/21/22)
- Creating an API project in C# with .NET 6
- Introduction to APIs and program.cs
- Controllers and Routing (get and post)
- Creating an Azure Web App
- Setting up a CI/CD for the Web App from GitHub
- Adjusting CI/CD with 
- Creating an API for the leaderboard
- Ajusting the action with on: paths: - 'Wordle.api/**' and workflow_dispatch:

### Lecture 5 (4/19/22)
- npm run lintfix & it's importance
- Assignment 2 overview
- Vuetify Components Continued
  - v-dialog
  - v-menu
- Vuetify themes
- router-link
- created/mounted functions

### Lecture 4 (4/14/22)
- Keeping Git Fork in sync with class repo
- Vuetify components
  - v-card
  - v-row
  - v-col
  - v-btn
- Building your own components
- slots
- passing properties
- interacting with your TS within your vue code

### Lecture 3 (4/12/2022)
- TypeScript continued
- Jest Unit Testing
- Introduction to vuetify (More on this in the 4/14 lecture)

### Lecture 2 (4/7/2022)
- Clarify homework and how to do deployments.
- GitHub Actions/Workflows
- Secrets in GitHub
- Deployment Tokens in Azure Static Web Apps
- Why use tokens
- Authentication and authorization
- Introduction to Vue
- Intro to TypeScript

### Lecture 1 (4/5/2022)
- Introduction/Homework
- Create a front end Nuxt app and deploy it to azure
- NPM
- Nuxt
- Github Actions/YAML files
- Azure static web app

### Next Topics (This list is subject to change based on the pace of the class)
- TypeScript: Classes and Testing with Jest (4/7)
- Vue: Components, Events, Properties, Reactivity (4/12)
- Vuetify: Creating user interfaces, Component usage, UI/UX considerations, icons, animation, responsive design, etc. (4/14, 4/19)*
- UI Wrap up (4/21)
- ASP.Net Core API endpoint, Deploying and using the API endpoint (4/26)
- Entity Framework (2/28)*
- Creating an API backed with EF (5/3)
- Authentication (5/5)
- SignalR (5/10-5/12)
- Metrics using Application Insights (5/17)

