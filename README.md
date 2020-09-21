# Online Quiz
 ISD project 3.2
 
To implement our project, Online Quiz System
we have used SQL Server Management Studio (version 2014) & Microsoft Visual Studio (version 2019).
### Database setup:
After downloading the whole project, the database model have to be executed. At first the sql queries of entities must be created. As we have used SQL Server Authentication, #####SetupLogin.sql file has to be executed first in Windows Authentication mode. After executing, the management studio has to restart and select SQL Server Authentication and set the Login and Password as the name in the setup file.
Now, the sql file of our project has to be executed, which is onlinequiz.sql. In the sql file, queries for database creating and entity creating is given properly. So, it won’t be any problem to create the entities for the project.

### Database model Update:
After downloading the whole project there will be an OnlineQuizSystem.sln file which is the solution file for visual studio. After opening the file, the visual studio will be on and then the database model according to the different servers is needed to be updated. In the solution explorer of the Visual Studio, into the Models folder there is a file called Model.edmx. The file is needed to be opened and inside the file, we need to press the right button of mouse and then there will come so many options and then we have to select the option, Update Model from Database. After that, a window will pop-up and we have to set the Data source as Microsoft SQL Server (SqlClient). Then in the place of the Server name, the server name of the SQL management Studio has to be put. 
After that we need to log into the server. So, in that window, we have to select the Authentication to SQL Server Authentication and set the User Name and Password as set in the database. Then we have to select the option of Connect to a database and select the database name from the dropdown list, ONLINEQUIZ. Then we can click OK.
 After that another window will pop up where we have to refresh the tables and then click ok. Then there will be a dialogue box popping up as Security question when we run the simulation. Every time we need to click ok and after that, the project will run smoothly. And also the project is needed to be run from any controller in the Controller folder.

