# Setting up Azure

The process for setting up Azure can be tricky if not followed carefully. There are many pitfalls where a wrong selection will 
cause the application not to start correctly. Typically, if the application starts correctly it is going to work right and any
issues you have will be in your code. 

This guide has setup and troubleshooting information for getting an Azure App Service and Azure SQL database to work well 
together. We also use a Static Web App, but those are typically simple to set up.

The following steps are a fast way to get it going, and allow the steps to be done in a logical order. This is not the only way.

## Getting an Azure subscription set up
Follow the instructions here to get your student credits set up. https://azure.microsoft.com/en-us/free/students/

All instructions assume you are logged into the portal at https://portal.azure.com


## Setting up the App Service
1. Create a Resource
2. Web App
3. Subscription should be the student one
4. Resource Group: click Create new. Provide a name
5. Name the web app
6. Runtime stack: .NET 7
7. For the OS choose Linux. Windows will also work but has different options once created
8. Region: West US (none, 2, or 3)
9. Linux Plan: click Create new and provide a name. Probably like the name above. Many apps can run on an App service Plan. To change the pricing plan, navigate to the App Service Plan and choose Scale up and choose another option. App Services run on App Service Plans. You pay for App Service Plans regardless of number of App Services running on it, but they are resourece constrained.
10. Pricing Plan: Basic B1
11. Click Review+Create
12. Click Create
13. It will take several minutes to deploy the resources (also Application Insights will be added automatically)
14. Navigate to the App Service
15. Click Identity on the left side
16. Change the System assigned status to On and click Save and then Yes
17. Note the object principal Id or at least the first few characters of the GUID
18. Click Overview
19. Near the center top click Download publish profile
20. Paste entire content of this file into the secret for the GitHub action deployment
21. Note the Default Domain: This is the URL of the website. Note if this is an API website there will not be a default page unless you specifically create one. Use a public get endpoint to test.


## Set up your AAD security group for database access
1. In the search bar type 'aad' and click Azure Active Directory
2. Click Groups on the left
3. Click New Group
4. Group name: choose a name
5. Group description: This group controls access to the Wordle database
6. Click no members selected
7. Search for your app service name
8. Click on the name making sure the GUID matches the one noted above
9. Click Select
10. Add more members (this will give you access to the database from tools like SSMS)
11. Search for you name
12. Click your name and click the Select button
13. Add any other members necessary (a partner for example)
14. Click Create
15. Note the GUID of this group


## Set up the Azure SQL database
1. Click Create Resource
2. Click SQL Database
3. Subscription: Should be set
4. Resource Group: Select the one created above
5. Database name: choose a name
6. Server: click Create new (Databases run on Database Servers, you pay per database)
   1. Server name: pick a name, again globally unique
   2. Location: West US (none, 2 or 3) should be the same region as above to minimize latency.
   3. For authentication method leave the option for AAD only. You can choose hybrid if you want to use SQL authentication, but it is less secure.
   4. Click Set admin
   5. Search for the group created in the last step, click it and then click Select. GUID should match above.
   6. Click OK
9. No elastic pool (default)
10. Workload environment: Development
11. Compute + Storage: click Configure database (price should be about $5/month)
    1. Service Tier: Choose Basic
    2. Click Apply 
13. Click Review + Create
14. Click Create
15. Deployment will take a few minutes
16. Navigate to the database once it is created
17. Click Set server Firewall
    1. Public network access: Selected Networks
    2. If you want to access the server from your computer, click Add your client IPv4 address
    4. Check the Allow Azure services and resources to access this server
    5. Click Save
    6. You will be back at the SQL Server level and will need to click SQL Databases and then the database name to navigate back to the actual database

## Set the App Service database connection string
1. Navigate to your Azure SQL database and the Overview page (default)
2. Next to Connection strings, click Show database connection strings. Copy the first entry.
3. Navigate to your App Service
4. On the left, choose Configuration
5. Near the bottom in the Connection Strings area, click New Connection String
   1. Name: DefaultConnection  All one word
   2. Value: Paste from above
   3. Type: SQLAzure
   4. Click OK
6. Click Save
7. Click Continue

Now, once you deploy your site to the App Service, it should hook up to the database and you should be able to make API calls.

## Troubleshooting
So, if this doesn't work, here is how to test things out.
1. Try connecting with SSMS. The hostname is in the connection string and will look something like this: wordle.database.windows.net. Use one of the AAD auth options in SSMS until it works.
   1. If you can't get a connection at all, the hostname is wrong or the firewall rule isn't set. Recent versions of SSMS will add the firewall rule for you.
   2. If you get an authentication error, then you likely have an issue with not setting the admin group on the database, not adding yourself to the AAD security group, or keying in a user name or password wrong.
2. You can see the logs for the app service
   1. Select App Service logs from the left bar
   2. Click File System and then click save
   3. Click Log Stream from the left bar
   4. This will show you the logs from the app. Look for errrors about SQLClient and use similar troubleshooting instructions as above
3. Sometimes restarting the app service makes a difference
4. Sometimes recreating the database and app service helps eliminate the chance of a misconfigured service.

Getting Azure set up can be tricky for those not accustomed to the environment. Hopefully this guide will help get you onto the right track.

