using Jobhunt.Controllers;
using Jobhunt.Data;
using Jobhunt.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Jobhunt.Data
{

    public class MailHandler
    {
        public User User = new User();
        public UsersController UsersController = new UsersController();
        public Utility Utility = new Utility();


        public void forgottenPasswordEmail(User toUser)
        {
            string _receiverMail = Utility.Decrypt(toUser.Email);
            string _userName = Utility.Decrypt(toUser.UserName);

            string body = "<table><tr>" +
               "Hello: " + _userName +
               "</tr>" +
           " <tr><td><br/></td></tr>" +
               "<tr> " +
               "You have forgotten your password. Here is a reminder:" +
              "<tr/>" +
           " <tr><td><br/></td></tr>" +
            "<tr> " +
               "<td> Your email is:</td>" +
               "<td>" + _receiverMail + "</td>" +
            "</tr>" +
            "<tr> " +
               "<td> Your password is:</td>" +
               "<td>" + Utility.Decrypt(toUser.Password) + "</td>" +
            "</tr>" +
            "</table>";

            string subject = "Forgotten password";
            string receiverMail = _receiverMail;
            string userName = _userName;

            sendEmail(body, subject, receiverMail, userName);

        }


        public void welcomeEMail(User toUser)
        {

            string _receiverMail = Utility.Decrypt(toUser.Email);
            string _userName = Utility.Decrypt(toUser.UserName);

            string body = "<table><tr>" +
                 "Welcome: " + _userName +
                 "</tr>" +
             " <tr><td><br/></td></tr>" +
                 "<tr> " +
                 "Thank you for creating an account at good jobs!" +
                "<tr/>" +
             " <tr><td><br/></td></tr>" +
                "<tr>" +
                 "<td> Your user name is:</td>" +
                 "<td>" + _userName + "</td>" +
              "</tr>" +
              "<tr> " +
                 "<td> Your email is:</td>" +
                 "<td>" + _receiverMail + "</td>" +
              "</tr>" +
              "<tr> " +
                 "<td> Your password is:</td>" +
                 "<td>" + Utility.Decrypt(toUser.Password) + "</td>" +
              "</tr>" +
             " <tr><td><br/></td></tr>" +
              "<tr> " +
                 "<td> Please login and start connecting the dots in your job search:</td>" +
              "</tr>" +
              "<tr> " +
              "http://good-jobs-webapp.com/Login.aspx" +
                 "</tr>" +
              "</table>";

            string subject = "Welcome to GoodJobs";
            string receiverMail = _receiverMail;
            string userName = _userName;

            sendEmail(body, subject, receiverMail, userName);
        }


        public void sendEmail(string body, string subject, string receiverMail, string userName)
        {
            try
            {
                MailMessage Message = new MailMessage();
                SmtpClient Smtp = new SmtpClient();
                System.Net.NetworkCredential SmtpUser = new System.Net.NetworkCredential();

                // Basis gegevens email
                Message.From = new MailAddress("GoodJobsWebapp@good-jobs-webapp.com", "Good-jobs-webapp");
                Message.To.Add(new MailAddress(receiverMail, userName));
                Message.IsBodyHtml = true;

                // Gegevens onderwerp & Body
                Message.Subject = subject;
                Message.Body = body;

                // SMTP Authenticatie, een e-mailadres welke is aangemaakt in het control panel
                SmtpUser.UserName = "GoodJobsWebapp@good-jobs-webapp.com";
                SmtpUser.Password = "Goodjobsadmin85!";

                // Bericht verzenden
                Smtp.UseDefaultCredentials = false;
                Smtp.Credentials = SmtpUser;
                Smtp.Host = "smtp.mijnhostingpartner.nl";
                Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                Smtp.Send(Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in sendEmail:" + ex.Message);
            }

        }
    }
}
