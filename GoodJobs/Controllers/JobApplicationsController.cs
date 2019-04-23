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
    public class JobApplicationsController : ApiController
    {
        private JobHuntModelContainer db = new JobHuntModelContainer();

        // GET: api/JobApplications
        public IQueryable<JobApplications> GetJobApplications()
        {
            return db.JobApplications;
        }

        // GET: api/JobApplications/5
        [ResponseType(typeof(JobApplications))]
        public JobApplications GetJobApplications(int id)
        {
            JobApplications jobApplications = db.JobApplications.Find(id);
            if (jobApplications == null)
            {
                // return NotFound();
            }

            return jobApplications;
        }


        // GET: api/Users/5
        [ResponseType(typeof(string))]
        public List<JobApplications> GetMyJobApplications(int UserId)
        {

            // SELECT [UserId]
            //  FROM[JobHuntDatabase].[dbo].[Users]
            // WHERE[UserName] = 'Roland' AND[Password] = 'Necrid85';

            string SQL = "SELECT * FROM [dbo].[JobApplications] WHERE [UserUserId] = {0} ORDER BY [JobApplDateTime] DESC"; 

            //SqlParameter UserNameParam = new SqlParameter("username", Username);
            // SqlParameter PasswordParam = new SqlParameter("password", Password);

            object[] parameters = new object[] { UserId };


            List<JobApplications> myJobApplications = db.Database.SqlQuery<JobApplications>(SQL, parameters).ToList();
            //if (user == null)
            //{
            //    return NotFound();
            //}

            return myJobApplications;
        }


        // GET: api/Users/5
        [ResponseType(typeof(int))]
        public int CountMyJobApplications(int UserId)
        {

            // SELECT [UserId]
            //  FROM[JobHuntDatabase].[dbo].[Users]
            // WHERE[UserName] = 'Roland' AND[Password] = 'Necrid85';

            string SQL = "SELECT * FROM [dbo].[JobApplications] WHERE [UserUserId] = {0}";

            //SqlParameter UserNameParam = new SqlParameter("username", Username);
            // SqlParameter PasswordParam = new SqlParameter("password", Password);

            object[] parameters = new object[] { UserId };


            List<JobApplications> myJobApplications = db.Database.SqlQuery<JobApplications>(SQL, parameters).ToList();
            //if (user == null)

            int countMyJobApplications = myJobApplications.Count;
            //int countMyJobApplications = db.Database.SqlQuery<int>(SQL, parameters);

            //if (user == null)
            //{
            //    return NotFound();
            //}

            return countMyJobApplications;
        }



        // PUT: api/JobApplications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJobApplications(int id, JobApplications jobApplications)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobApplications.ID)
            {
                return BadRequest();
            }

            db.Entry(jobApplications).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobApplicationsExists(id))
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

        // POST: api/JobApplications
        [ResponseType(typeof(JobApplications))]
        public IHttpActionResult PostJobApplications(JobApplications jobApplications)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JobApplications.Add(jobApplications);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = jobApplications.ID }, jobApplications);
        }

        // DELETE: api/JobApplications/5
        [ResponseType(typeof(JobApplications))]
        public IHttpActionResult DeleteJobApplications(int id)
        {
            JobApplications jobApplications = db.JobApplications.Find(id);
            if (jobApplications == null)
            {
                return NotFound();
            }

            db.JobApplications.Remove(jobApplications);
            db.SaveChanges();

            return Ok(jobApplications);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobApplicationsExists(int id)
        {
            return db.JobApplications.Count(e => e.ID == id) > 0;
        }

        // GET: api/Users/5
        [ResponseType(typeof(string))]
        public void TestDeleteAll()
        {
            string SQL = "DELETE FROM JobApplications;" +
           " DBCC CHECKIDENT('JobApplications', RESEED, 0);";
            db.Database.ExecuteSqlCommand(SQL);
        }

    }
}