# Scrummage #
This is my Scrum Management Tools suite.  
This is designed to help manage a development team using the Scrum framework.
Tools include Administring users, teams and sprints, as well as Product Backlog planning, Sprint Backlog planning, Sprint Execution and review meetings.

## Technologies and Patterns used ##
Based on ScrummageV1, this version simply updates to the latest tech and libraries.
This project was a test bed for implementing the Repository and Unit of Work Pattern for an MVC 5 project.
It uses Code First approach through Entity Framework 6.
There are aslo examples of how to use Async Awaits repository and Controller calls (not currently implemented).
Twitter Bootstrap has been used for presentation.

## Development ##
* Create Management of Members
* Create Management of Teams
* Create Management of Statuses
* Create Management of Products
* Apply a common Look and feel
* Create Management of Sprints
* Create Authentication layer

### ToDo: ###
* investigate if i can use a flag to determine one level deep of related model conversion (apply this to all explicit conversions)
* Investigate using Mock DbSet instead of having a fake Repository
* investigate option of creating view model layer (this will clean up password field on Member for example)
* verify of username, password on create of member without causing a post back
* add functionality to Member edit for Password and Avatar (including validation)
* investigate creating unit tests for the repository, by creating a fake contaxt/dbset class, which can be dependancy injected in?

## Resources ##
### Roles: ###
This allows administrators to have basic CRUDL functionality of user/member Roles

### Members: ###
This allows administrators to have basic CRUDL functionality of Members

## Notes: ##
### Migration ###
The migration commands to run from the 'Package Manager Console'  

**Enable-Migrations**  
This will enable migrations to be used  

**Add-Migration**  
This will scaffold the next migration based on changes you have made to your model.  
Or this will create the initial migration if run for the first time.  

**Update-Database**  
This will apply any pending changes to and or create the database.  

## Errors: ##
### cannot attach the file as database  ###
Ensure the Data Connection is deleted in 'Server Explorer' in VS2012
Ensure Database is deleted in all versions of localdb from 'SQL Server Object Explorer' in VS2012
Ensure the database is not attached in SqlExpress

If this does not solve the issue, open the "Developer Command Propmpt for VisualStudio" under your start/programs menu.
Run the following commands:

sqllocaldb.exe stop v11.0
sqllocaldb.exe delete v11.0
