This is a sample project I am building for a video for DataTier.Net.

In case anyone finds this before I create any documentation, here are the instructions to run this sample.

1. Create a SQL Server database named BlazorList.
2. Execute the file BlazorToDo\SQL\BlazorList.Schema.sql to create the tables and stored procedures.
3. Build a connection string to this database. Tip: Clone DataTier.Net and use the connection string builder program located in the
tools folder.
4. Create a system environment variable named BlazorToDoConnection and set the value to the connection string created in step 3
5. Run the program, it should work after you restore the Nuget packages for:





