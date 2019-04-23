Server name: ROLAND-PC\SQLEXPRESS

0.
- Add new scalar property to model.
- Nullable op true zetten.

1. Creating Database based on Entity models:
- Right click in model
- Generate database from model


2. Create Model classes:
- Right click in model
- Update model from database
- Add -> Tables -> Finish


3. Creating Controller classes:

- Right-Click Controllers
- Add - New Scaffolded item
- Web api 2 controller with actions using entity framework
- Model class: 'users' or something else  --> Add

- GetJobapplications(int id)  functie even aanpassen
- Models ->     [Serializable]




tools:
Microsoft SQL Server Management Studio						13.0.16106.4
Microsoft Analysis Services Client Tools						13.0.1700.441
Microsoft Data Access Components (MDAC)						6.3.9600.16384
Microsoft MSXML						3.0 4.0 6.0 
Microsoft Internet Explorer						9.11.9600.17031
Microsoft .NET Framework						4.0.30319.42000
Operating System						6.3.9600


        // GET: api/Users/5
        [ResponseType(typeof(string))]
        public void TestDeleteAll()
        {
            string SQL = "DELETE FROM Users;" +
            " DBCC CHECKIDENT('Users', RESEED, 0);";
            db.Database.ExecuteSqlCommand(SQL);
        }

		        // GET: api/Users/5
        [ResponseType(typeof(string))]
        public void TestDeleteAll()
        {
            string SQL = "DELETE FROM JobApplications;" +
           " DBCC CHECKIDENT('JobApplications', RESEED, 0);";
            db.Database.ExecuteSqlCommand(SQL);
        }


Google maps api key:
AIzaSyDosSQDg_x8pTJMnz2DuvwzAyyfcydviRo



-- Tortoise

Repository (folder waar productie versie staat):
F:\Goodjobs-live\SVNRepository

Development folder:
D:\My software development projects\ASP.net\GoodJobs-dev


---Publishing:
- Publish website.
- Precompile during publishing aanvinken!