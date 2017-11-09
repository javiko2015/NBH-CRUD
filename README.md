# NBH-CRUD
Test-Build CRUD

- I made a design of the business model consisting of the following:

      There are two user roles  
      Applicants: After registering as a user they will have control in their dashboard to manage their work applications. They will only have access to see the list of their own applications. An Applicant can only register one application per company
      Managers: After registering as a user they will have control in their dashboard to manage the applications that have been made in the name of their company.

- I used MVC Pattern whit 3 layer Architecture ( Bussines Logic, Acces Data, and Presentation ) (I added additional Test Layers for future tests).

- I used database first to generate the model classes from the database.

- The database is running in the cloud hosting. To run the solution the connection string is configured with the following privileges:
   Server: sql5036.site4now.net
User: DB_9DA5EF_applicationTest_admin
Password: Javier1985
- I used Pascal Casing as a coding standard.

- I developed my own simple user Registration and Authentication system.

- I developed Multilanguage filter using the potential of Resources as a good tool from .Net ( Note: I didn't substitute all characters because the time)

- I developed some validations on the server side through annotations and others on the client side using JQuery.

- The constant values of the business flow like fixed values of radio button and checkbox remain in the database.

- Some functionalities were implemented in the business logic layer to show some algorithmization and programming logic capabilities. For example Encrypt( to encrypt the passwords value to the db, ConcatBuilds to concat a List of string, and others).

- I implemented other additional functionalities (CRUD) as part of the management of applications such as Delete and Details.
