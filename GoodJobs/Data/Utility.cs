using Jobhunt.Controllers;
using Jobhunt.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Jobhunt.Data
{
    public class Utility
    {
        private string EncryptionKey = "YjR8uy2P444bEUib";
        public JobApplicationsController _JobApplicationsController;
        public UsersController _UsersController;
        public Utility _Utility;
        public DataTable ToDataTable(List<JobApplications> list)
        {
            DataTable MethodResult = null;

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("JobApplID", typeof(Int32)));
            dt.Columns.Add(new DataColumn("JobApplNumber", typeof(Int32)));
            dt.Columns.Add(new DataColumn("JobApplDateTime", typeof(String)));
            dt.Columns.Add(new DataColumn("JobApplTime", typeof(String)));
            dt.Columns.Add(new DataColumn("JobApplName", typeof(String)));
            dt.Columns.Add(new DataColumn("JobApplLetter", typeof(String)));
            dt.Columns.Add(new DataColumn("JobApplMethod", typeof(String)));
            dt.Columns.Add(new DataColumn("JobApplCat", typeof(String)));

            dt.Columns.Add(new DataColumn("JobApplInterviewDateTime", typeof(String)));
            dt.Columns.Add(new DataColumn("JobApplInterviewTime", typeof(String)));
            dt.Columns.Add(new DataColumn("JobApplInterviewPersons", typeof(String)));

            dt.Columns.Add(new DataColumn("JobApplSecInterviewDateTime", typeof(String)));
            dt.Columns.Add(new DataColumn("JobApplSecInterviewTime", typeof(String)));
            dt.Columns.Add(new DataColumn("JobApplSecInterviewPersons", typeof(String)));

            dt.Columns.Add(new DataColumn("JobApplThirdInterviewDateTime", typeof(String)));
            dt.Columns.Add(new DataColumn("JobApplThirdInterviewTime", typeof(String)));
            dt.Columns.Add(new DataColumn("JobApplThirdInterviewPersons", typeof(String)));

            dt.Columns.Add(new DataColumn("JobApplInterviewPreperation", typeof(String)));
            dt.Columns.Add(new DataColumn("JobApplMyQuestions", typeof(String)));
            dt.Columns.Add(new DataColumn("JobApplCompanyQuestions", typeof(String)));
            dt.Columns.Add(new DataColumn("JobApplInterviewNotes", typeof(String)));

            dt.Columns.Add(new DataColumn("JobApplStatus", typeof(String)));
            dt.Columns.Add(new DataColumn("JobApplFeedback", typeof(String)));

            dt.Columns.Add(new DataColumn("JobApplMyFollowUpEmails", typeof(String)));
            dt.Columns.Add(new DataColumn("JobApplFollowUpStatus", typeof(String)));

            dt.Columns.Add(new DataColumn("JobApplNote", typeof(String)));

            dt.Columns.Add(new DataColumn("JobApplMyRating", typeof(String)));


            dt.Columns.Add(new DataColumn("VacancyTitle", typeof(String)));
            dt.Columns.Add(new DataColumn("VacancyFunctionTitle", typeof(String)));
            dt.Columns.Add(new DataColumn("VacancyCareerField", typeof(String)));
            dt.Columns.Add(new DataColumn("VacancyText", typeof(String)));
            dt.Columns.Add(new DataColumn("VacancySalary", typeof(String)));

            dt.Columns.Add(new DataColumn("VacancyLink", typeof(String)));
            dt.Columns.Add(new DataColumn("VacancyContactPerson", typeof(String)));
            dt.Columns.Add(new DataColumn("VacancyContactPersonEmail", typeof(String)));
            dt.Columns.Add(new DataColumn("VacancyContactPersonLinkedIn", typeof(String)));

            dt.Columns.Add(new DataColumn("VacancyCompany", typeof(String)));
            dt.Columns.Add(new DataColumn("VacancyCompanyWebsite", typeof(String)));
            dt.Columns.Add(new DataColumn("VacancyCompanyCity", typeof(String)));
            dt.Columns.Add(new DataColumn("VacancyCompanyStreetName", typeof(String)));
            dt.Columns.Add(new DataColumn("VacancyCompanyStreetNumber", typeof(String)));
            dt.Columns.Add(new DataColumn("VacancyCompanyZipcode", typeof(String)));
            dt.Columns.Add(new DataColumn("VacancyCompanyCountry", typeof(String)));
            dt.Columns.Add(new DataColumn("VacancyCompanySummary", typeof(String)));


            int i = 1;
            foreach (JobApplications _JobApplicationItem in list)
            {
                if (_JobApplicationItem != null)
                {
                    DataRow dr = dt.NewRow();


                    dr["JobApplID"] = _JobApplicationItem.ID;
                    dr["JobApplNumber"] = i.ToString();
                    //dr["JobApplDateTime"] = DateTime.ParseExact(_JobApplicationItem.JobApplDateTime.Value.ToShortDateString(), "dd-MM-yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat).ToString();

                    dr["JobApplDateTime"] = _JobApplicationItem.JobApplDateTime.ToString();
                    dr["JobApplTime"] = _JobApplicationItem.JobApplTime;
                    dr["JobApplName"] = Decrypt(_JobApplicationItem.JobApplName);
                    dr["JobApplLetter"] = Decrypt(_JobApplicationItem.JobApplLetter);
                    dr["JobApplMethod"] = Decrypt(_JobApplicationItem.JobApplMethod);
                    dr["JobApplCat"] = Decrypt(_JobApplicationItem.JobApplCat);
                    dr["JobApplInterviewDateTime"] = _JobApplicationItem.JobApplInterviewDateTime.ToString();
                    dr["JobApplInterviewTime"] = _JobApplicationItem.JobApplInterviewTime.ToString();
                    dr["JobApplInterviewPersons"] = Decrypt(_JobApplicationItem.JobApplInterviewPersons);


                    dr["JobApplSecInterviewDateTime"] = _JobApplicationItem.JobApplSecInterviewDateTime.ToString();
                    dr["JobApplSecInterviewTime"] = _JobApplicationItem.JobApplSecInterviewTime.ToString();
                    dr["JobApplSecInterviewPersons"] = Decrypt(_JobApplicationItem.JobApplSecInterviewPersons.ToString());


                    dr["JobApplThirdInterviewDateTime"] = _JobApplicationItem.JobApplThirdInterviewDateTime.ToString();
                    dr["JobApplThirdInterviewTime"] = _JobApplicationItem.JobApplThirdInterviewTime.ToString();
                    dr["JobApplThirdInterviewPersons"] = Decrypt(_JobApplicationItem.JobApplThirdInterviewPersons);

                    dr["JobApplInterviewPreperation"] = Decrypt(_JobApplicationItem.JobApplInterviewPreperation);
                    dr["JobApplMyQuestions"] = Decrypt(_JobApplicationItem.JobApplMyQuestions);
                    dr["JobApplCompanyQuestions"] = Decrypt(_JobApplicationItem.JobApplCompanyQuestions);
                    dr["JobApplInterviewNotes"] = Decrypt(_JobApplicationItem.JobApplInterviewNotes);

                    dr["JobApplMyRating"] = _JobApplicationItem.JobApplMyRating;

                    dr["JobApplStatus"] = _JobApplicationItem.JobApplStatus;
                    dr["JobApplFeedback"] = Decrypt(_JobApplicationItem.JobApplFeedback);

                    dr["JobApplMyFollowUpEmails"] = Decrypt(_JobApplicationItem.JobApplMyFollowUpEmails);
                    dr["JobApplFollowUpStatus"] = Decrypt(_JobApplicationItem.JobApplFollowUpStatus);

                    dr["JobApplNote"] = Decrypt(_JobApplicationItem.JobApplNote);

                    dr["VacancyTitle"] = Decrypt(_JobApplicationItem.VacancyTitle);
                    dr["VacancyFunctionTitle"] = Decrypt(_JobApplicationItem.VacancyFunctionTitle);
                    dr["VacancyCareerField"] = Decrypt(_JobApplicationItem.VacancyCareerField);
                    dr["VacancyText"] = Decrypt(_JobApplicationItem.VacancyText);
                    dr["VacancySalary"] = Decrypt(_JobApplicationItem.VacancySalary);
                    dr["VacancyLink"] = Decrypt(_JobApplicationItem.VacancyLink);
                    dr["VacancyContactPerson"] = Decrypt(_JobApplicationItem.VacancyContactPerson);
                    dr["VacancyContactPersonEmail"] = Decrypt(_JobApplicationItem.VacancyContactPersonEmail);
                    dr["VacancyContactPersonLinkedIn"] = Decrypt(_JobApplicationItem.VacancyContactPersonLinkedIn);

                    dr["VacancyCompany"] = Decrypt(_JobApplicationItem.VacancyCompany);
                    dr["VacancyCompanyWebsite"] = Decrypt(_JobApplicationItem.VacancyCompanyWebsite);
                    dr["VacancyCompanyCity"] = Decrypt(_JobApplicationItem.VacancyCompanyCity);
                    dr["VacancyCompanyStreetName"] = Decrypt(_JobApplicationItem.VacancyCompanyStreetName);
                    dr["VacancyCompanyStreetNumber"] = Decrypt(_JobApplicationItem.VacancyCompanyStreetNumber);
                    dr["VacancyCompanyZipcode"] = Decrypt(_JobApplicationItem.VacancyCompanyZipCode);
                    dr["VacancyCompanyCountry"] = Decrypt(_JobApplicationItem.VacancyCompanyCountry);
                    dr["VacancyCompanySummary"] = Decrypt(_JobApplicationItem.VacancyCompanySummary);
                    dt.Rows.Add(dr);
                    i = i + 1;
                }

            }

            dt.AcceptChanges();

            MethodResult = dt;

            return MethodResult;

        }

        public string Encrypt(string textToEncrypt)
        {
            //try
            //{
            //    TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            //    byte[] key = System.Text.Encoding.UTF8.GetBytes(EncryptionKey);
            //    byte[] input = Encoding.UTF8.GetBytes(textToEncrypt);
            //    des.Mode = CipherMode.ECB;
            //    des.Padding = PaddingMode.Zeros;
            //    ICryptoTransform icp = des.CreateEncryptor(key, null);
            //    byte[] output = icp.TransformFinalBlock(input, 0, input.Length);
            //    return Convert.ToBase64String(output);
            //}
            //catch
            //{
            //    return null;
            //}

            return textToEncrypt;
        }

        /// <summary>
        /// Returns a decrypted string from Base64 and TripleDes
        /// </summary>

        public string Decrypt(string textToDecrypt)
        {
            //try
            //{
            //    string result = string.Empty;
            //    if (textToDecrypt != "")
            //    {
            //        //TripleDes Encoden
            //        TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            //        byte[] bKey = System.Text.Encoding.UTF8.GetBytes(EncryptionKey);
            //        //des mode zetten
            //        des.Mode = CipherMode.ECB;
            //        des.Padding = PaddingMode.Zeros;
            //        byte[] input = Convert.FromBase64String(textToDecrypt);
            //        ICryptoTransform transForm = des.CreateDecryptor(bKey, null);
            //        byte[] output = transForm.TransformFinalBlock(input, 0, input.Length);
            //        result = System.Text.Encoding.UTF8.GetString(output, 0, output.Length);
            //    }
            //    result = result.Trim('\0');
            //    return result;
            //}
            //catch
            //{
            //    return null;
            //}

            return textToDecrypt;

        }

        public SortedList GetUserCategories(int userId, bool optionAll)
        {
            _UsersController = new UsersController();
            _Utility = new Utility();
            User loggedInUser = _UsersController.GetUser(userId);

            SortedList userCategories = new SortedList();
            string userCats = "";
            if (optionAll == true)
            {
                userCategories.Add("All", "All");
            }
            else if (optionAll == false)
            {
                userCategories.Add("", "");
            }
            string[] userAllCats = null;
            if (_Utility.Decrypt(loggedInUser.Categories) != null)
            {
                userCats = _Utility.Decrypt(loggedInUser.Categories);
                userAllCats = userCats.Split('`');
                foreach (string cat in userAllCats)
                {
                    if (!string.IsNullOrEmpty(cat))
                    {
                        userCategories.Add(cat, cat);
                    }
                }
            }
           
            return userCategories;
        }

        public string NumberOfUserContacts(int userId)
        {
            _UsersController = new UsersController();
            _Utility = new Utility();
            string presentationNofContacts = "";
            User loggedInUser = _UsersController.GetUser(userId);

            string contacts = "";
            string[] contactIds = null;
            bool alreadyAdded = false;
            string nofContacts = "0";
            if (_Utility.Decrypt(loggedInUser.Friends) != null)
            {
                contacts = _Utility.Decrypt(loggedInUser.Friends);
                if (contacts != null)
                {
                    contactIds = contacts.Split(',');
                    if (contactIds.Count() > 0)
                    {
                        if (!string.IsNullOrEmpty(contactIds[0]))
                        {
                            nofContacts = contactIds.Count().ToString();
                        }
                        else
                        {
                            nofContacts = 0.ToString();
                        }
                    }
                }
            }
            presentationNofContacts = nofContacts;
            return presentationNofContacts;

        }


        public string NumberOfUserOpenInvitations(int userId)
        {
            _UsersController = new UsersController();
            _Utility = new Utility();
            string presentationNofOpenInvitations = "";
            User loggedInUser = _UsersController.GetUser(userId);

            int nofOpenSendInvitations = 0;
            int nofOpenReceivedInvitations = 0;

            string MyInvSend = _Utility.Decrypt(loggedInUser.FriendsInvSend);
            if (!string.IsNullOrEmpty(MyInvSend))
            {
                string[] MyInvsSend = MyInvSend.Split(',');
                foreach (string MyInv in MyInvsSend)
                {
                    string[] Myinvs = MyInv.Split(':');
                    if (Myinvs != null)
                    {
                        string status = Myinvs[0];
                        // Open invitations have status Send:
                        if (status == "S") 
                        {
                            nofOpenSendInvitations++;
                        }
                    }
                }
            }

            string MyInvReceived = _Utility.Decrypt(loggedInUser.FriendsInvRecieved);
            if (!string.IsNullOrEmpty(MyInvReceived))
            {
                string[] MyInvsReceived = MyInvReceived.Split(',');
                foreach (string MyInv in MyInvsReceived)
                {
                    string[] Myinvs = MyInv.Split(':');
                    if (Myinvs != null)
                    {
                        string status = Myinvs[0];
                        // Open invitations have status Send:
                        if (status == "S")
                        {
                            nofOpenReceivedInvitations++;
                        }
                    }
                }
            }

            presentationNofOpenInvitations = "Received: " + nofOpenReceivedInvitations + " Send: " + nofOpenSendInvitations;
            return presentationNofOpenInvitations;

        }
    }
}