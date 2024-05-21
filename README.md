# SofthouseMediatR

Simple `CRUD` implementation of `CQRS` by using `MediatR` patterns based on `.Net 8.0` framework and `C#` language.
In this project I am using `RabbitMQ` messaging provider. To make it more reliable, I used `Outbox` pattern.

**Note**: In this project I covered 2 contracts of **[MediatR](https://github.com/jbogard/MediatR?tab=readme-ov-file#using-contracts-only-package)**:
* `IRequest`
* `INotification`

# Workflow

<p align="center">
    <img alt="Workflow" src="https://github.com/peymannj/SofthouseMediatR/blob/main/Documents/Images/Diagram.png?raw=true" />
</p>


1- Create/update/delete a car. (`IRequest` contract)

2- A message with a specific rout will be published.

3- Message broker `RabbitMQ` receives the message and routs it to a corresponding consumer.

4- The consumer broadcasts the message to 2 services. `Email` and `Log` service.


## Requirement

- `.Net 8.0 SDK` or higher
- `Docker Desktop`

## Preparation Of The DEV Environment
- After installing `Docker desktop`, Go to the root of the project where you have the solution file. You can find the 
`docker-compose.yml` file.
- Open a terminal and execute the command below. By doing that 2 containers will be appeared, up and running. `RabbitMQ`
for messaging and the other one is `Smtp4dev` which is a fake mail server.

1- `RabbitMQ` dashboard address: http://localhost:15672

2- `Smtp4dev` fake mailserver: http://localhost:5000/

```bash
docker-compose up .
```


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

4- Migrate database. I am using SQL database. In the `appsettings.json` file put the right connection string and then run
the following command. It would create a database and a simple table. The migration files already created.

```bash
 dotnet ef database update
```

5- Run the application

```bash
  dotnet run
```

When you run the application, `CLI` shows you a URL and then you have to append `/swagger` to it and use it in your browser.
Example:

```bash
  http://localhost:5207/swagger
```

First run `SofthouseWorker` project and then run `SofthouseMediatR` project. Now you are able to try the endpoints through `Swagger`.


## Authentication/Authorization
I used `Microsoft Identity` to provide authentication and role-based authorization layer for the application. And I used
Bearer Token (`Bearer` token is not same as `JWT`).

**Note**: I already added an extension method which seeds the database with 2 users and 2 different roles. `Admin` and `Basic`. 
To find the usernames and passwords go to `SofthouseMediatR/Extensions/DatabaseContextExtensions.cs`

You can try the endpoints that were added automatically into `Swagger`. And some settings in `Swagger` in order to add 
authorization button on top of the page to make it easier for testing the endpoints. In `.Net 8`, Microsoft made the settings
of authentication/authorization so easy with minimal changes compare to older version of `.Net`.  

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

4- Copy the `accessToken` content and click on authorize button and paste the token into the field
and finally press the authorize button. Then you are able be authorized and test the endpoints

**Note**: The database migration for `Microsoft Identity` already created. The only thing that you need is running the
following command:

```bash
 dotnet ef database update
```

**Note**: `GET /api/Cars` is the only accessible endpoint that you can use both Admin and Basic role. Please look at 
the controller and annotations. 

**Note**: The `.HTTP` file updated respectfully. So you can use it to send requests instead of using `Swagger`.

## Outbox Pattern & Messaging
The `outbox` pattern is a design pattern commonly used in distributed systems, particularly in scenarios where messages 
need to be reliably delivered to multiple recipients or systems. The primary goal of the outbox pattern is to ensure 
atomicity and reliability when publishing messages to an external message broker or queue.

In the context of message publishing, the outbox pattern involves two main components:

1- `Outbox Table`:
The outbox table is a database table that serves as a temporary storage for messages that need to be published. When an action
occurs within the application that requires a message to be published, instead of directly publishing the message to the 
message broker, the application inserts a record into the outbox table.

2- `Message Publisher`:
The message publisher is a separate process or service responsible for reading messages from the outbox table and publishing
them to the message broker. It periodically polls the outbox table for new records and publishes the corresponding messages.

By using the `outbox` pattern, applications can achieve the following benefits:

* `Atomicity`: Message publication and database updates are performed within the same transaction, ensuring atomicity and consistency.
* `Reliability`: Messages are reliably delivered to the message broker, even in the event of application failures or restarts.
* `Scalability`: The outbox pattern decouples message publication from the main application logic, allowing for better scalability and performance.

In this case I used [**MassTransit**]([subfolder/subsubfolder/relevantfolder/](https://masstransit.io)) library.
MassTransit is a popular library the allow you to implement messaging solutions. MassTransit is an open-source distributed 
application framework for `.NET` that provides a consistent abstraction on top of the supported message transports. 
The interfaces provided by `MassTransit` reduce `message-based` application complexity and allow developers to focus their 
effort on adding business value.

`MassTransit` also provides Built-in patterns such as `Outbox` and `Saga`. And it is also integrated with `Entity framework`.
In this case I use `Outbox` pattern, It creates 3 tables to track the messages states. Since it uses EF it also creates database migration
files which were already added to the project. Otherwise, you have to create a migration and then update the database.

I used `RabbitMQ` which is a messaging provider by using `Topic exchange`. For example when you create a car, you publish 
a message that a car with some specifications was created. The message will be received in Worker project. And then send 
an email which you can receive it in `Smtp4dev` dashboard.

**Note:** In general the direct exchange is faster than the topic exchange. And the main differences are, in topic exchange you can use wildcard
and easier to maintain the queues. But since the examples of `MassTranist` and `RabbitMQ` based on topic exchange are rare, 
I decided to implement it in this project.

## Note

If you use `VisualStudio` or `Jetbrains Rider` you can use `SofthouseMediatR.http` in the root the source code 
folder to test the endpoints instead of `Swagger`. Note that, you need to run your application in debug or release mode.
I didn't try it for `VS Code`. But the alternative is using `REST Client` extension in `VS Code`.

## Helpful links

 - [CQRS & MediatR] https://www.youtube.com/watch?v=sUjNZAYTZwI
 - [Outbox pattern] https://microservices.io/patterns/data/transactional-outbox.html
 - [.http file] https://www.youtube.com/watch?v=drwc2dF3u7I
 - [MassTransit] https://masstransit.io
 - [RabbitMQ] https://www.rabbitmq.com
 - [Smtp4dev] https://github.com/rnwood/smtp4dev
 - [MimeKit] https://github.com/jstedfast/MailKit

