# Lectures
- [Recording Links](https://intellitectsp.sharepoint.com/:f:/r/sites/EWU-CSCD379-2024-Spring/Shared%20Documents/General/Recordings?csf=1&web=1&e=DcoaGK)
- This is an MS Teams link and everyone in the class should have access. If not, please contact an instructor.

## TENTATIVE Lecture Schedule
(Do not attend or not attend class based on this list. There is a high chance we will cover other topics.)

## Week 1
### Lecture 1: 4/2: Build the App (Assignment 1) 🟢🟣
- Syllabus & expectations
- Wordle Requirements
- Set up front end and build out basic application. 
- Initial look at 
  - NPM
  - Vue
- VS Code Extensions
  - Code Spell Checker
  - Prettier
  - GitHub CoPilot
  - ViTest
  - Vite
  - Vue - Official
- Details
  - Create Nuxt app: `npx nuxi@latest init <project-name>`


### Lecture 2: 4/4: Deployment (Assignment 1) 🟢
- Complete application 
- Classes in C#/Java and TS/JS
- Basic unit testing with Jest
  - Add testing: `npm i --save-dev @nuxt/test-utils vitest @vue/test-utils happy-dom playwright-core`
- Build deployment for front-end in Azure.
- Azure DevOps
- YAML
- Azure AppService
- Vue Build / `npm run generate`
- Vuetify
  - `https://nuxt.com/modules/vuetify`
  - `https://www.codybontecou.com/how-to-use-vuetify-with-nuxt-3.html`


## Week 2
### Lecture 3: 4/09: Vue (Assignment 2) 🟢🟣
- Why Vue? What problem does is solve?
- HTML Primer: elements, classes, styling
- CSS Primer
- Why CSS is the devil
- Chrome debugger
- What is Vue for and how does it work? Stop messing with the DOM
- {{ Interpolation }}
- Data Binding and Observables: https://vuejs.org/guide/essentials/template-syntax.html
  - Creating the word and letter elements
  - Changing these into components
  - Class and Style https://vuejs.org/guide/essentials/class-and-style.html
- Computed properties https://vuejs.org/guide/essentials/computed.html
- Pages
- Component Basics (MG)
- Routing https://vuejs.org/guide/scaling-up/routing.html
- Lifecycle: https://vuejs.org/guide/essentials/lifecycle.html
- Lists (For loops): https://vuejs.org/guide/essentials/list.html


### Lecture 4. 4/11: More Vue (Assignment 2) 🟢🟣
- Add Additional Wordle Functionality
  - Word list
  - Random word selection
  - Showing all 6 guess lines
  - Entering letters not in a text box
  - Determine win & loss
  - Game state
  - Restart game
- Attributes
- Observables
- Proxies
- Functions
- Conditional Rendering: https://vuejs.org/guide/essentials/conditional.html
- Events: https://vuejs.org/guide/essentials/event-handling.html
- Spacing (padding and margins) (CSS Box Model)


## Week 3
### Lecture 5. 4/16: Vue Components (Assignment 2) 🟣
- Components: https://vuejs.org/guide/components/registration.html
  - Props https://vuejs.org/guide/components/props.html
  - Events https://vuejs.org/guide/components/events.html
  - v-model https://vuejs.org/guide/components/v-model.html
  - Slots https://vuejs.org/guide/components/slots.html
- Watchers: https://vuejs.org/guide/essentials/watchers.html
- Transitions: https://vuejs.org/guide/built-ins/transition.html

### Lecture 6. 4/18: More components 🟣
- Grid System
- Display and sizing
- Icons
- Theming
- Elevation
- Height and width (h- & w-"
- Components: Containment
  - Buttons
  - Cards
  - Chips
  - Lists
- Animation


## Week 4
### Lecture 7. 4/23: Wrap up UI and ASP.NET Intro 🟢🟣
- Input: https://vuejs.org/guide/essentials/forms.html
- Components: Tables
- Components: Form Inputs
  - Selects
  - Switches
  - Text: Fields and Areas
  - Combos
- Slots and Emits
- What is MVC and why are we doing a SPA
  - Quick Intro to ASP.NET MVC
- Starting an ASP.NET API Project
  - Build the Word of the Day API endpoint
  - Creating a simple API
  - Program.cs
  - Controllers
  - Basic Routing
  - Services (DI)
- CORS

### Lecture 8. 4/25: 🟣
- DevOps
- More ASP.NET and EF and homework 3 material
- Unit Testing the API
  - Basic Unit Testing
  - Unit testing with services
  - Unit testing with WebApplicationFactory
- Unit vs Integration Testing


## Week 5
### Lecture 9. 3/30: 🟢
- What is EF
- Creating a context
- Creating models
- Migrations

- Initial EF Context
- Word object
- Word migration
- EF Migration Deltas to a table

### Lecture 10. 5/2: 🟢
- Word Service
- Word Controller that returns a word
- Handling multi-threading issues with creating the word of the day.
- Service Dependency Injection
- Deployment (Site and Database)
- API configuration: Swagger in production
- Troubleshooting Azure

## Week 6
### Lecture 11. 5/7: 
- Meg's Awesome Changes
  - Global Base URL for Axios
  - Restructure App Async in Constructor

- Unit Testing with Databases
  - API unit testing: database, services, integration.
  - Testing with DI and Services

- EF Parent/Child (Word with child Game)
  - Adding additional migrations
  - API Post
  - DTOs

--- After this point is subject to significant change ---


### Lecture 12. 5/09: 
- EF Querying
  - Querying with Includes
- EF unit testing
- EF unit test base
- Model builder cascade deletes

## Week 7
### Lecture 13. 5/14: 
- Posting the results of a game
- Returning a DTO with statistics for a word/WOTD
- Axios using Post
- Redirecting root on API to the Wordle site
- Word of the day controller and tests
- Miscellaneous
  - Custom favicon
  - New starting page and default route
- Vue services (Provide and Inject)

### Lecture 14. 5/16:
- Unique indexes
- Reusing a view for multiple routes
- Parsing query parameters to determine game type
- Get method query parameters on API endpoints
- Load Word of the day in App
- Integration testing

## Week 8
### Lecture 15. 5/21: 
- EF multiple table queries (Getting Word of the Day stats)
- Using GroupBy, Sort
- Questions from the homework
- Lots of other stuff pertaining to homework
- Google Analytics

### Lecture 16, 5/23
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
### Lecture 17. 5/28: 
- ASP.NET Identity
- Setup up EF Identity in an existing project
- JWT creation and verification
- Authorization attributes for roles and policies
- Setup of Swaqgger to take a bearer token

### Lecture 18. 5/30: 
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
### Lecture 19. 6/4: 


### Lecture 20. 6/6: 
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
