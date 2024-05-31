URL:
https://purple-plant-006657c1e.5.azurestaticapps.net/

# EWU-CSCD378-2022-Spring

## Assignment 5

The purpose of this assignment is to solidify your learning of:

- Creating CRUD interface in a SPA with auth
- ASP.NET Core Indentity
- Use of JWTs as a bearer token
- Using policy-based authorization

## Features

### Create an editor for the available words ✅

- Create a page named "WordEditor" that allows words to be edited ✅
  - Support deleting a word ✅
  - Support adding a new word ✅
  - Editing words is not supported ✅
  - Duplicate words should not be allowed ✅
  - Add & support changing the common word boolean flag ✅
    - Filter the list of returned words by common words ✅
  - Words should be sorted alphabetically ✅
- Provide a text box for searching words AS YOU TYPE which supports searching for words starting with letters specified ❌✅
- Provide a menu item for navigating to the WordEditor page ✅
  - Anyone can look at the word list ✅
  - Word list is paginated (10-100 per page) ❌✅
- Any logged in user can change the common word flag ✅
  - There is a login page/component/popup/etc for users to sign in ✅
- Only users over 21 years of age (based on birthday) with a claim of MasterOfTheUniverse can add and remove words ✅
- Users can be set up at start up in the API project as a seed (apriori), there does not need to be a sign up mechanism ✅

## Extra Credit

- Find a bug in the application, create an issue, submit a pull request against the issue
- Add the ability to sign up for an account by inputting an email and password
- Allow the user to elevate their level of privelage by inputting a secret phrase
- Select pagination record count
