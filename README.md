# SofthouseMediatR

Simple CRUD implementation of **CQRS** by using **MediatR** patterns based on .Net 8.0 framework and C# language.
In this project I am using RabbitMQ messaging provider and to make it more reliable, I used Outbox pattern.

# Workflow

<div style="text-align:center">
    <img alt="Workflow" src="https://github.com/peymannj/SofthouseMediatR/blob/main/Documents/Images/Diagram.png?raw=true" />
</div>

1- Create/update/delete a car.

2- A message with a specific rout will be published.

3- Message broker (RabbitMQ) receives the message and rout it to a corresponding consumer.

4- The received message will be processed and an email will be created and send out.


## Requirement

- .Net 8.0 SDK or higher
- Docker desktop

## Preparation Of The DEV Environment
- After installing Docker desktop, Go to the root of the project where you have the solution file. You can find the 
docker-compose.yml file.
- Open a terminal and execute the command below. By doing that 2 containers will be appeared, up and running. RabbitMQ 
for messaging
and the other one is PaperCut which is a fake mail server.

1- RabbitMQ dashboard address: http://localhost:15672

2- PaperCut fake mailserver: http://localhost:37408/

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

4- Migrate database. I am using SQL database. In the **appsettings** put the right connection string and then run the following
command. It would create a database and a simple table. The migration files already created.

```bash
 dotnet ef database update
```

5- Run the application

```bash
  dotnet run
```

When you run the application, **CLI** shows you a URL and then you have to append **/swagger** to it and use it in your browser.
Example:

```bash
  http://localhost:5207/swagger
```

First run **SofthouseWorker** project and then run **SofthouseMediatR** project. Now you are able to try the endpoints through **Swagger**.


## Authentication/Authorization
I used Microsoft Identity to provide a authentication/authorization. And I used Bearer Token (Bearer token is not same as JWT).
You can try the endpoints that were added automatically into Swagger. And some settings in Swagger in order to add Authorization
button on top of the page to make it easier for testing the endpoints. In **.Net 8**, Microsoft made the settings of 
authentication/authorization so easy with minimal changes compare to older version of .Net.  

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
And the next step is copying the **access token** content and click on authorize button and paste the token into the field
and finally press the authorize button. Then you are able be authorized and test the endpoints

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

## Outbox Pattern & Messaging
The outbox pattern is a design pattern commonly used in distributed systems, particularly in scenarios where messages 
need to be reliably delivered to multiple recipients or systems. The primary goal of the outbox pattern is to ensure 
atomicity and reliability when publishing messages to an external message broker or queue.

In the context of message publishing, the outbox pattern involves two main components:

1- **Outbox Table**:
The outbox table is a database table that serves as a temporary storage for messages that need to be published. When an action
occurs within the application that requires a message to be published, instead of directly publishing the message to the 
message broker, the application inserts a record into the outbox table.

2- **Message Publisher**:
The message publisher is a separate process or service responsible for reading messages from the outbox table and publishing
them to the message broker. It periodically polls the outbox table for new records and publishes the corresponding messages.

By using the outbox pattern, applications can achieve the following benefits:

- Atomicity: Message publication and database updates are performed within the same transaction, ensuring atomicity and consistency.
- Reliability: Messages are reliably delivered to the message broker, even in the event of application failures or restarts.
- Scalability: The outbox pattern decouples message publication from the main application logic, allowing for better scalability
- and performance.

In this case I used MassTransit library. https://masstransit.io
MassTransit is a popular library the allow you to implement messaging solutions. MassTransit is an open-source distributed 
application framework for .NET that provides a consistent abstraction on top of the supported message transports. 
The interfaces provided by MassTransit reduce message-based application complexity and allow developers to focus their 
effort on adding business value.

MassTransit also provides Built-in patterns such as **Outbox** and **Saga**. And it is also integrated to Entity framework.
In this case that I use Outbox pattern, It creates 3 tables to track the messages. Since it uses EF it also create migration
files which were already added to the project. Otherwise you have to create a migration and then update the database.

I used **RabbitMQ** which is a messaging provider by using Topic exchange. For example when you create a car, you publish 
a message that a car with some specifications was created. The message will be received in Worker project. And then send 
an email which you can receive it in **PaperCut**.

## Note

If you use **VisualStudio** or **Jetbrains Rider** you can use **SofthouseMediatR.http** in the root the source code 
folder to test the endpoints instead of **Swagger**. Note that, you need to run your application in debug or release mode.
I didn't try it for **VS Code**. But the alternative is using **REST Client** extension in **VS Code**.

## Helpful links

 - [CQRS & MediatR] https://www.youtube.com/watch?v=sUjNZAYTZwI
 - [Outbox pattern] https://microservices.io/patterns/data/transactional-outbox.html
 - [.http file] https://www.youtube.com/watch?v=drwc2dF3u7I
 - [MassTransit] https://masstransit.io
 - [RabbitMQ] https://www.rabbitmq.com

