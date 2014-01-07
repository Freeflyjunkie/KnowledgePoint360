Hi Glynn,

In order to create the database open the project in Visual Studio and go to Tools/Library Package Manager/Package Management Console. On the command line type 

PM> udpate-database

This should create a database on your local SQL Server and Seed it with test data. 

If you are having trouble with the Entity Framework in the Powershell, then I included the MDF file in the AppData Folder.

Open SQL Management Studio and log in to the server to which you want to attach the database. In the 'Object Explorer' window, right-click on the 'Databases' folder and select 'Attach...' The 'Attach Databases' window will open; inside that window click 'Add...' and then navigate to your .MDF file and click 'OK'. Click 'OK' once more to finish attaching the database and you are done. The database should be available for use.