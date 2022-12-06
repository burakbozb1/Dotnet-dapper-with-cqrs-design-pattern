## Summary  
This web api includes CQRS design pattern implementation. Dabase connections was prepared with dapper micro orm.  

## What is CQRS Design pattern  
Command Query Responsibility Segregation  
The main focus of the CQRS design pattern is the separation of write and read responsibilities. If the developed application is created with the CQRS design pattern, scalability is maximized. In this approach, methods are prepared with two different approaches.  
Commands and queries.  
Commands are used to add new data and modify existing data. Insert, Update, and Delete are examples of commands.  
Queries are used to fetch data from the database. Select is an example of this.  

# MediatR
One of the easiest and the most effective ways to implement the CQRS design pattern in Dotnet is the mediatR package. You can access MediatR packages from the link below:  
https://github.com/jbogard/MediatR  

## Database  
MSSQL was used as database in the project. You can find the database creation script in the STATICS folder in the project. After creating the database, you can write your connection string to the defaultConnection value in ConnectionStrings.cs located in the service folder.

## What is Dapper  
Dapper is a lightweight micro orm tool. Made by StackOverflow developers. You can use the link below for detailed review:  
https://github.com/DapperLib/Dapper  

# Why Dapper
Orm tools are often cumbersome. Even a frequently used framework such as Entity Framework has trouble fetching data quickly in tables containing large amounts of data. It is a bad factor that database indexes cannot be used. For this reason, using ado.net or dapper in comprehensive projects provides faster results.  

## Slapper.Automapper  
Dapper already provides a mapping library, but in some cases we may need to use tables together to get different results. In such cases, our models and query outputs do not match. In our project, slapper.automapper was used to solve this problem. Within the project, there are categories, products and comments on the products. There is a one-to-many relationship between the product and its comments. To examine how this structure is mapped to data, you can examine the example in GetProductsWithDetailsByCategoryIdQueryHandler.cs.  

## Contact
If you have a question, you can ask me your question on my linkedin or twitter account. @burakbozb1
