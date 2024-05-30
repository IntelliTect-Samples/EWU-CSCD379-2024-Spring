Link to site: 

# EWU-CSCD378-2022-Spring

## Assignment 5

The purpose of this assignment is to solidify your learning of:

- Creating CRUD interface in a SPA with auth
- ASP.NET Core Indentity
- Use of JWTs as a bearer token
- Using policy-based authorization

## Features

### Create an editor for the available words ❌✅
  - Create a page named "WordEditor" that allows words to be edited ❌✅
    - Support deleting a word ❌✅
    - Support adding a new word ❌✅
    - Editing words is not supported ❌✅
    - Duplicate words should not be allowed ❌✅
    - Add & support changing the common word boolean flag ❌✅
      - Filter the list of returned words by common words ❌✅ 
    - Words should be sorted alphabetically ❌✅
  - Provide a text box for searching words AS YOU TYPE which supports searching for words starting with letters specified ❌✅
  - Provide a menu item for navigating to the WordEditor page ❌✅
    - Anyone can look at the word list ❌✅
    - Word list is paginated on the server side (10-100 per page) ❌✅
  - Any logged in user can change the common word flag ❌✅
    - There is a login page/component/popup/etc for users to sign in ❌✅
  - Only users over 21 years of age (based on birthday) with a claim of MasterOfTheUniverse can add and remove words ❌✅
  - Users can be set up at start up in the API project as a seed (apriori), there does not need to be a sign up mechanism ❌✅

## Turn in Process

- On your fork, create an Assignment5 branch
- Update this branch (Fetch upstream) from the Assignment5 branch in the class repo. [Assignment5 in class repo](https://github.com/IntelliTect-Samples/EWU-CSCD379-2022-Spring/tree/Assignment5)
- Do your homework in your Assignment5 branch
- Submit your pull request against Assignment5 in the class repo
- Ask in Teams chat if you have questions or issues

## Extra Credit

- Find a bug in the application, create an issue, submit a pull request against the issue
- Add the ability to sign up for an account by inputting an email and password
- Allow the user to elevate their level of privelage by inputting a secret phrase
- Select pagination record count


## Assignment 4

The purpose of this assignment is to solidify your learning of:

- Responsive design for a variety of devices.
- Using a more complex API
- Creating services that use multiple EF classes (GET and POST)

## Features

- Make all pages responsive ❌✅
  - 1080p desktop ❌✅
  - iPad Air ❌✅
  - Samsung Galaxy S20 Ultra Super Mega Excellent ❌✅
  - IPhone SE ❌✅
- Create a improved landing page and site theme (Background, make it look attractive to play) ❌✅
  - Theme should extend all pages ❌✅
- Add an instructions page that is available via the hamburger menu that details the features of the game and how to play ❌✅
- Create a new Wordle game page that reuses components but will provide the same word for a specific day. Everyone going to the page that day will get the same word. The page should indicate Wordle of the Day or something like that ❌✅
- Create a page that lists the last 10 daily words with statistics. Number of plays, Average score, Average time. (just list the date, don't show the word silly) ❌✅
  - It should indicate if the user has played that day ❌✅
  - Clicking on the item should take the player to that game (Extra Credit) ❌✅

## Turn in Process

- On your fork, create an Assignment4 branch
- Update this branch (Fetch upstream) from the Assignment4 branch in the class repo. [Assignment4 in class repo](https://github.com/IntelliTect-Samples/EWU-CSCD379-2022-Spring/tree/Assignment4)
- Do your homework in your Assignment4 branch
- Submit your pull request against Assignment4 in the class repo
- Ask in Teams chat if you have questions or issues

## Hints

For this assignment, fewer guidelines are going to be given. If we discuss ideas in class, feel free to PR them here and we will merge into the assignment.

- We want to push you to learn to make architectural decisions and follow the patterns we have applied in the past. However, if this is too hard, please let us know.
- It will be necessary to create a controller (and a service) for the daily words stats page
- Look a using a URL parameter to jump to the game at a specific date. [Stack Overflow](https://stackoverflow.com/questions/48068520/nuxt-js-how-to-get-route-url-params-in-a-page)

## Extra Credit

- Clicking on an item in the daily word stats page should take the player to that game and allow them to play it
- Create another ad page and choose one at rando