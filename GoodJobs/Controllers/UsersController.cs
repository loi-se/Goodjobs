using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Jobhunt.Models;

namespace Jobhunt.Controllers
{
    public class UsersController : ApiController
    {
        private JobHuntModelContainer db = new JobHuntModelContainer();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public User GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                // return NotFound();
            }

            return user;
        }

        // GET: api/Users/5
        [ResponseType(typeof(int))]
        public List<int> GetLoginUserId(string eMail, string Password)
        {

            // SELECT [UserId]
            //  FROM[JobHuntDatabase].[dbo].[Users]
            // WHERE[UserName] = 'Roland' AND[Password] = 'Necrid85';

            string SQL = "SELECT[UserId] FROM [dbo].[Users] WHERE [Email] = {0} AND [Password] = {1}";

            //SqlParameter UserNameParam = new SqlParameter("username", Username);
            // SqlParameter PasswordParam = new SqlParameter("password", Password);

            object[] parameters = new object[] { eMail, Password };


            List<int> user = db.Database.SqlQuery<int>(SQL, parameters).ToList();
            //if (user == null)
            //{
            //    return NotFound();
            //}

            return user;
        }

        // GET: api/Users/5
        [ResponseType(typeof(int))]
        public List<int> GetForgottenPasswordUserId(string eMail)
        {

            // SELECT [UserId]
            //  FROM[JobHuntDatabase].[dbo].[Users]
            // WHERE[UserName] = 'Roland' AND[Password] = 'Necrid85';

            string SQL = "SELECT[UserId] FROM [dbo].[Users] WHERE [Email] = {0}";

            //SqlParameter UserNameParam = new SqlParameter("username", Username);
            // SqlParameter PasswordParam = new SqlParameter("password", Password);

            object[] parameters = new object[] { eMail};


            List<int> user = db.Database.SqlQuery<int>(SQL, parameters).ToList();
            //if (user == null)
            //{
            //    return NotFound();
            //}

            return user;
        }


        // GET: api/Users/5
        [ResponseType(typeof(int))]
        public List<User> searchUsers(Dictionary<string, string> searchValues)
        {
            List<User> foundUsers = new List<User>();

            object[] objects = new object[searchValues.Count];
            int i = 0;
            int max = searchValues.Count - 1;
            string query = "";
            foreach (KeyValuePair<string, string> entry in searchValues)
            {
                if (i == 0)
                {
                    query = "AND (";
                }
                if (entry.Key == "mainCareer")
                {
                    query = query + "(dbo.Users.MainCareer = {" + i + "} )";
                    objects[i] = (object)entry.Value;
                }
                else if (entry.Key == "subCareer")
                {
                    query = query + "(dbo.Users.SubCareer = {" + i + "} )";
                    objects[i] = entry.Value;
                }
                else if (entry.Key == "searchTags")
                {
                    query = query + "(dbo.Users.SearchTag = {" + i + "} )";
                    objects[i] = entry.Value;
                }
                else if (entry.Key == "functionTitle")
                {
                    query = query + "(dbo.JobApplications.VacancyFunctionTitle = {" + i + "} )";
                    objects[i] = entry.Value;
                }
                else if (entry.Key == "companyName")
                {
                    query = query + "(dbo.JobApplications.VacancyCompany = {" + i + "} )";
                    objects[i] = entry.Value;
                }

                if (i < max)
                {
                    query = query + " AND ";
                }
                else
                {
                    query = query + ")";
                }

                i++;
            }

            string SQL = "SELECT DISTINCT dbo.Users.UserId " +
            "FROM dbo.Users INNER JOIN " +
            "dbo.JobApplications ON dbo.Users.UserId = dbo.JobApplications.UserUserId " +
            "WHERE(dbo.JobApplications.ShowToFriends = 'True')" + query;

            object[] parameters = objects;

            List<int> user = db.Database.SqlQuery<int>(SQL, parameters).ToList();

            foreach (int userId in user)
            {
                User founduser = this.GetUser(userId);
                foundUsers.Add(founduser);
            }

            return foundUsers;
        }

        // GET: api/Users/5
        [ResponseType(typeof(string))]
        public List<string> GetOldPassword(int UserId)
        {

            // SELECT [UserId]
            //  FROM[JobHuntDatabase].[dbo].[Users]
            // WHERE[UserName] = 'Roland' AND[Password] = 'Necrid85';

            string SQL = "SELECT[Password] FROM [dbo].[Users] WHERE [UserId] = {0}";

            //SqlParameter UserNameParam = new SqlParameter("username", Username);
            // SqlParameter PasswordParam = new SqlParameter("password", Password);

            object[] parameters = new object[] { UserId };


            List<string> password = db.Database.SqlQuery<string>(SQL, parameters).ToList();
            //if (user == null)
            //{
            //    return NotFound();
            //}

            return password;
        }

        public void editInvFriendsInvRecieved(int userId, string newInvitationString)
        {

            string SQL = "UPDATE [JobHuntDatabase].[dbo].[Users] SET [FriendsInvRecieved] = {0}" +
                " WHERE [UserId] = {1} ";

            object[] parameters = new object[] { newInvitationString, userId };

            int result = db.Database.ExecuteSqlCommand(SQL, parameters);
        }

        public void editInvFriendsInvSend(int userId, string newInvitationString)
        {

            string SQL = "UPDATE [JobHuntDatabase].[dbo].[Users] SET [FriendsInvSend] = {0}" +
                " WHERE [UserId] = {1} ";

            object[] parameters = new object[] { newInvitationString, userId };

           // string sqlQuery = db.Database.SqlQuery<string>(SQL, parameters);
            int result = db.Database.ExecuteSqlCommand(SQL, parameters);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.UserId == id) > 0;
        }

        // GET: api/Users/5
        [ResponseType(typeof(string))]
        public void TestDeleteAll()
        {
            string SQL = "DELETE FROM Users;" +
            " DBCC CHECKIDENT('Users', RESEED, 0);";
            db.Database.ExecuteSqlCommand(SQL);
        }
    }
}