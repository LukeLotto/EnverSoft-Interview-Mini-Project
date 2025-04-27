Setup instructions:
- Project > Configure Startup Projects > Select 'Multiple startup projects' > Set Mini-Project-UI to have the Action Start & Mini-Project-API to have the Action Start
- The database connection string will need to be altered in the appsettings.json of the API and then you will also need to alter the connection string in the MiniProjectDbContext.cs (Under the Data folder) file of the Mini-Project-Repository project
