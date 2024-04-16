
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

## Note

If you use **VisualStudio** or **Jetbrains Rider** you can use **SofthouseMediatR.http** in the root the source code folder to test the endpoints instead of **Swagger**. Not that, you need to run your application in debug or release mode. I didn't try it for **VS Code**. But the alternative is using **REST Client** extension in **VS Code**.

## Helpful links

 - [CQRS & MediatR] https://www.youtube.com/watch?v=sUjNZAYTZwI
 - [.http file] https://www.youtube.com/watch?v=drwc2dF3u7I

