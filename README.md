#Website:
https://lively-sea-0f3b4921e.5.azurestaticapps.net/game

**1. Create a leaderboard API Controller** ❌✅
- Create an endpoint that returns the top 10 scores (HttpGet) ❌✅
  - Results should include Name, average guesses, and number of games played ❌✅
- Create an endpoint that allows for posting a score (HttpPost) with data in the body ❌✅
  - A new name should add a new record ❌✅
  - An existing name should update that record ❌✅
- Save and load all data with Entity Framework to an Azure SQL database or LocalDb for debugging ❌✅
  - Class should be named "Player" and "Players" for the DbSet ❌✅
  - Fields should be: 
    - int PlayerId ❌✅
    - string Name ❌✅
    - int GameCount ❌✅
    - double AverageAttempts ❌✅
    - int AverageSecondsPerGame ❌✅(OPTIONAL)
- The logic should reside in a service that is injected via dependency injection into the controller ❌✅
- Set up CORS (Cross Origin Resource Sharing) ❌✅

**2. Create a dialog for getting the user's name** ❌✅
- If we don't have the user's name, present the user with a dialog that allows them to type in their name ❌✅
- The users current name should show on the game page (upper right) ❌✅
  - This should be visible when setting/changing the name. It should change as the user types ❌✅
- The user should be able to click on their name to change it (with the same dialog) ❌✅
- Save the name in local storage and load it for the next game if it is set ❌✅
- If the name is not set, display Guest as the name. ❌✅
  - Clicking on this allows for preemptive setting of the name before the end of the game ❌✅
- Dialog must be persistent, doesn't close by clicking off the dialog ❌✅

**3. Save the Score and Seconds to complete** ❌✅
- Save the score and time to complete in seconds at the end of the game if we have a name. ❌✅
- If the user hasn't set a name, save the score and seconds as "Guest". (Be sure to prompt first) ❌✅
- Save should be done with an Axios Post ❌✅

**4. Create a Leaderboard Page** ❌✅
- Create a /leaderboard page in the application that shows the top scores ❌✅
- Use Axios to call the leaderboard API ❌✅
- Make a nice display of the returned data ❌✅
- Add a link on the front page to access the leaderboard ❌✅
- Add a link to the app bar to access the leaderboard ❌✅

**5. Unit testing** ❌✅ (OPTIONAL) (Not covered in class, but in instructor's repo: https://github.com/granterickson/EWU-CSCD379-2024-Spring)
- Tests for the service ❌✅ (OPTIONAL)
- Integration tests for the controller ❌✅ (OPTIONAL)

**6. Deploy site to Azure** ❌✅
- Deploy API site with Github Action to Azure Web App ❌✅
- Unit Tests should run on build ❌✅


## Extra Credit

- Unit testing on the client side (3) ❌✅
- Animate the leaderboard (3) ❌✅
- Create a logo (3) ❌✅
- Add Average Seconds to win in score (3) ❌✅


### Azure Issues
If you are having issues gettig Azure setup correctly and everything working, please check out this document: https://github.com/IntelliTect-Samples/EWU-CSCD379-2024-Spring/blob/main/SettingUpAzure.md
