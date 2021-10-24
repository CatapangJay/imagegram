# Imagegram
## _A system for posting images and commenting on them_


Imagegram is a serverless social media API system for uploading images and commenting on them (Definetly not IG).

## Features

- Create a user (No security checks implemented for now)
- Users can create posts with images uploaded to a File System (Current implementation is only for Local File System but it can easily be extended if for example we want to implement cloud storage saving functionalities)
- Users (Including self) can comment on posts and delete them as well.
- Posts can be viewed in order of the highest comments count descending.



## Tech

Dillinger uses a number of open source projects to work properly:

- [Azure Functions] - Azure serverless Function As A Service (FAAS) offering.
- [.NET Core 3.1] - Sticked with the LTS version of .NET Core.
- [Entity Framework] - ORM for database transactions since I am more familiar with this. (It is recommended to use Graph Database for this but I have no suffecient knowledge in it and I am time-bound)
- [Automapper] - For mapping models and DTOs
- [xUnit] - For the unit testings
- [Moq] - For mocking dependencies
- [FluentAssertions] - For more readable validations in the unit tests

## Setup
In order to make the app work...

1. We have to have SQL installed in the environment. The setup process is documented by Microsoft in this link [https://docs.microsoft.com/en-us/sql/database-engine/install-windows/install-sql-server?view=sql-server-ver15]

2. An environment variable is required by the system to read the sql connection string in order to connect to the database. Please add the environment variable manually or by running the following script in Command Prompt with Admin Privileges
```cmd
setx IMGRAM_SQL_CONNECTIONSTRING "Data Source=[[Datasource]];Initial Catalog=ImagegramDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

refreshenv
```

This will create the environment variable. Be sure to swap out [[Datasource]] with the actual Datasource value.

If when you run the app but it throws an error with missing sql connection string, please restart visual studio.

3. Once that is setup, we are ready to create our database. Open the Package Manager Console in Visual Studio and run the command:
```
Update-Database
```
This should create the system's necessary database and tables.
Unfortunately, I wasn't able to do a seeding functionality on the db context creation. So please fill in the data by using the CRUD functionalities of the app.


