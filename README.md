
# SofthouseMediatR

Simple implementation of **CQRS** by using **MediatR** by using .Net 8.0 and C#.


## Requirement

- .Net 8.0 SDK or higher


## Installation & Run The Application

To run the application go to the source code folder and run these commands in order:

1- First make sure you installed **EF tool** or run this command (You just need it once)

```bash
dotnet tool update --global dotnet-ef
```

2- Restore the **Nuget** packages

```bash
  dotnet restore
```

3- Build the application to make sure the application is buildable.

```bash
  dotnet build
```

4- Migrate database. I am using SQL database. In the **appsettings** put the right connection string and then run the following command. It would create a database and a simple table. The migration files already created.

```bash
 dotnet ef database update
```

5- Run the application

```bash
  dotnet run
```

When you run the application, **CLI** shows you a URL and then you have to append **/swagger** to it and use it in your browser. Example:

```bash
  http://localhost:5207/swagger
```

Then you can try the endpoints through **Swagger**.


## Authentication/Authorization
I used Microsoft Identity to provide a authentication/authorization. And I used Bearer Token (Bearer token is not same as JWT). You can try the endpoints that were added automatically into Swagger. And some settings in Swagger in order to add Authorization button on top of the page to make it easier for testing the endpoints. In **.Net 8**, Microsoft made the settings of authentication/authorization so easy with minimal changes compare to older version of .Net.  

Steps:

1- Register a user. The payload, For example: 
```bash
{
  "email": "test@email.io",
  "password": "String!1"
}
```


2- Login. The payload, For example:
```bash
{
  "email": "test@email.io",
  "password": "String!1"
}
```

3- After a successful login you would get a response:
```bash
{
  "tokenType": "Bearer",
  "accessToken": "CfDJ8Da69wvg96tFjvtQBbQjikx...",
  "expiresIn": 3600,
  "refreshToken": "CfDJ8Da69wvg96tFjvtQBbQjik..."
}
```
And the next step is copying the **access token** content and click on authorize button and paste the token into the field and finally press the authorize button. Then you are able be authorized and test the endpoints

```bash

[Authorize]
and
[AllowAnonymous] or simple way [HttpGet, AllowAnonymous]

```

**Note**
The database migration for **Microsoft Identity** already created. The only thing that you need is running the following command:
```bash
 dotnet ef database update
```

**Note**: The only endpoint that you don't need access token for is **/api/Cars**. Please look at the controller and annotations. 

**Note**: The **.Http file** updated respectfully. So you can use it to send the request instead of using **Swagger**.


## Note

If you use **VisualStudio** or **Jetbrains Rider** you can use **SofthouseMediatR.http** in the root the source code folder to test the endpoints instead of **Swagger**. Note that, you need to run your application in debug or release mode. I didn't try it for **VS Code**. But the alternative is using **REST Client** extension in **VS Code**.

## Helpful links

 - [CQRS & MediatR] https://www.youtube.com/watch?v=sUjNZAYTZwI
 - [.http file] https://www.youtube.com/watch?v=drwc2dF3u7I

