# EWU-CSCD379-2024-Spring

Azure Web Site URL: https://aestheticwordle.com/

Azure API Site URL: https://aestheticwordle.azurewebsites.net/

## Assignment 5

The purpose of this assignment is to solidify your learning of:

- Creating CRUD interface in a SPA with auth
- ASP.NET Core Indentity
- Use of JWTs as a bearer token
- Using policy-based authorization

## Due Dates

- 100 points +5 EC points
- Assigned: 5/23
- Initial work complete: 6/2 11:59 pm
  - 50% for running pipeline with passing unit test
  - 50% for working website
- Code Reviews Due by: 6/4 11:59 pm
- Review in class: 6/6 2:00 pm
- Final turn-in: 6/6 11:59 pm

## Features

### Create an editor for the available words ❌✅

- Create a page named "WordEditor" that allows words to be edited ❌✅
  - Support deleting a word ❌✅
  - Support adding a new word ❌✅
  - Editing words is not supported ❌✅
  - Duplicate words should not be allowed ❌✅
  - Support changing the common word boolean flag ❌✅
  - Words should be sorted alphabetically ❌✅
- Provide a text box for searching words AS YOU TYPE which supports searching for words starting with letters specified ❌✅
- Provide a menu item for navigating to the WordEditor page ❌✅
  - Anyone can look at the word list ❌✅
  - Word list is paginated (10-100 per page) ❌✅
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
