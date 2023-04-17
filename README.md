= INTERTHREAD NOTES API README =
Jim Browne

- How to run - 

The project source code can be downloaded from GitHub (https://github.com/JJBProjects/InterthreadNotesApi) and built in Visual Studio.
Navigate to the package manager console and run 'update-database' to create a database instance.
The application can be run from Visual Studio allowing requests to be sent to localhost:{portnumber}. 
Please find postman collection containing some test requests included in repository.

- Approach Taken -

My approach was to create a .Net core 7.0 API application, this allowed for built in dependency injection, SQL server database support, and easy access to rich libraries. 
I began by creating the project structure, defining entities and using entity framework to create a database and test data.
Prototype API controllers were created to understand the required back-end services and then test driven-development was used to implement the required services.
Services were made more robust by implementing asynchronous methods.
API services were dressed and tidied then tested again using Postman.

- Time Spent -

I spent approximately 4.5 hours of total work time on this project separated approximately into the following time instances.

0.5h Understanding requirements, considering design options and planning data structure.
0.5h Creating unit tests.
0.5h Setting up project and creating entities.
1.5h Implementing services and API endpoints.
0.5h Tidying and converting to Async methods.
0.5h Source code documentation.
0.5h Committing code and hosting.

- Issues and limitations -

- Clearly the user functionality of this application is very limited. If given more time I would focus on extending to include login and authorisation capability.
- Given the back end nature of the project I decided to focus on the API only, the framework and project structure were selected to allow easy implementation of user interface if required.
- I opted to provide a more general update service for the user entity using the patch HTTP method to align with best practices in API interface.
- The code could benefit from more comments and documentation especially for the API services.
- Ideally additional logging would be added.
