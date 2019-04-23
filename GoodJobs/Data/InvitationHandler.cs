using Jobhunt.Controllers;
using Jobhunt.Data;
using Jobhunt.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Jobhunt.Data
{

    public class InvitationHandler
    {
        public User User = new User();
        public UsersController UsersController = new UsersController();
        public Utility Utility = new Utility();

        // Werk de status van de invitation bij.
        //Todo: friends field nog bijwerken bij geaccepteerde uitnodiging.
        public string UpdateInvitation(int senderId, int receiverId, string newInvitationStatus, string databaseField, string updateType, string id)
        {

            string updateInvitation = "";
            UsersController = new UsersController();
            //User = new User();
            //Utility = new Utility();
            string newInvitationString = "";
            // User = UsersController.GetUser(userToUpdateId);
            // -------------------------Create new invitation string:
            if (databaseField == "FriendsInvSend")
            {
                User = UsersController.GetUser(senderId);
            }
            else if (databaseField == "FriendsInvRecieved")
            {
                User = UsersController.GetUser(receiverId);
            }

            //Status (Accepted = A, Sended = S, Witdrawn = W, Denied = D"
            //Sender id
            //Receiver id
            //DateTime
            //Invitation Guid id 
            newInvitationString = newInvitationStatus + ":" + senderId.ToString() + ":" + receiverId.ToString() + ":" + DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture) + ":" + id;

            // -------------------------------Update the existing invitation strings:
            if (updateType == "new")
            {
                updateInvitation = UpdateTypeNew(User, databaseField, newInvitationString);
            }
            else if (updateType == "update")
            {
                updateInvitation = UpdateTypeUpdate(User, databaseField, newInvitationString, id);
            }

            return updateInvitation;
        }

        public string UpdateTypeNew(User _user, string databaseField, string newInvitationString)
        {
            UsersController = new UsersController();
            string updatedInvitationString = "";

            string oldInvitationString = "";
            if (databaseField == "FriendsInvSend")
            {
                oldInvitationString = Utility.Decrypt(_user.FriendsInvSend);
            }
            else if (databaseField == "FriendsInvRecieved")
            {
                oldInvitationString = Utility.Decrypt(_user.FriendsInvRecieved);
            }

            if (String.IsNullOrEmpty(oldInvitationString))
            {
                updatedInvitationString = newInvitationString;
            }
            else
            {
                updatedInvitationString = oldInvitationString + "," + newInvitationString;
            }

            return updatedInvitationString;
        }

        public string UpdateTypeUpdate(User _user, string databaseField, string newInvitationString, string id)
        {
             UsersController = new UsersController();
            string updatedInvitationString = "";
            string updateOldInvitationString = "";


            if (databaseField == "FriendsInvSend")
            {
                updateOldInvitationString = Utility.Decrypt(_user.FriendsInvSend);
            }
            else if (databaseField == "FriendsInvRecieved")
            {
                updateOldInvitationString = Utility.Decrypt(_user.FriendsInvRecieved);
            }

            string[] allInvitationStrings = updateOldInvitationString.Split(',');
            string[] invitationItems = null;
            string invitationStringToUpdate = "";
            foreach (string invitation in allInvitationStrings)
            {
                invitationItems = invitation.Split(':');
                if (invitationItems[4] == id)
                {
                    invitationStringToUpdate = invitation;
                }
            }
            updatedInvitationString = updateOldInvitationString.Replace(invitationStringToUpdate, newInvitationString);
            updatedInvitationString = Utility.Encrypt(updatedInvitationString);

            return updatedInvitationString;
        }


        public string AddReceiverContacts(int InvitationSenderID, int InvitationReceiverID)
        {
            UsersController = new UsersController();
            User InvReceiver = UsersController.GetUser(InvitationReceiverID);
            bool alreadyAdded = false;
            string[] contactIds = null;
            string contacts = "";

            if (Utility.Decrypt(InvReceiver.Friends) != null)
            {
                contacts = Utility.Decrypt(InvReceiver.Friends);
                if (contacts != null)
                {
                    contactIds = contacts.Split(',');
                    foreach (string contactId in contactIds)
                    {
                        if (contactId == InvitationSenderID.ToString())
                        {
                            alreadyAdded = true;
                        }
                    }
                }
            }

            if (alreadyAdded == false)
            {
                if (string.IsNullOrEmpty(contacts))
                {
                    contacts = InvitationSenderID.ToString();
                }
                else
                {
                    contacts = contacts + "," + InvitationSenderID.ToString();
                }
            }
            return contacts;
        }

        public string AddSenderContacts(int InvitationSenderID, int InvitationReceiverID)
        {
            UsersController = new UsersController();
            User Invsender = UsersController.GetUser(InvitationSenderID);
            string contacts = "";
            string[] contactIds = null;
            bool alreadyAdded = false;

            if (Utility.Decrypt(Invsender.Friends) != null)
            {
                contacts = Utility.Decrypt(Invsender.Friends);
                if (contacts != null)
                {
                    contactIds = contacts.Split(',');
                    foreach (string contactId in contactIds)
                    {
                        if (contactId == InvitationReceiverID.ToString())
                        {
                            alreadyAdded = true;
                        }
                    }
                }
            }

            if (alreadyAdded == false)
            {
                if (string.IsNullOrEmpty(contacts))
                {
                    contacts = InvitationReceiverID.ToString();
                }
                else
                {
                    contacts = contacts + "," + InvitationReceiverID.ToString();
                }
            }
            return contacts;
        }

        public string RemoveSenderContact(int InvitationSenderID, int InvitationReceiverID)
        {
            User InvSender = UsersController.GetUser(InvitationSenderID);
            string contacts = Utility.Decrypt(InvSender.Friends);
            string updatedContacts = "";
            if (contacts != null)
            {
                string[] contactIds = contacts.Split(',');
                List<String> activeContactIds = new List<String>();

                foreach (string contactId in contactIds)
                {
                    activeContactIds.Add(contactId);
                }

                activeContactIds.Remove(InvitationReceiverID.ToString());

               
                foreach (string contactId in activeContactIds)
                {
                    if (string.IsNullOrEmpty(updatedContacts))
                    {
                        updatedContacts = updatedContacts + contactId;
                    }
                    else
                    {
                        updatedContacts = updatedContacts + "," + contactId;
                    }
                }
            }
            return updatedContacts;
        }

        public string RemoveReceiverContact(int InvitationSenderID, int InvitationReceiverID)
        {
            User InvReceiver = UsersController.GetUser(InvitationReceiverID);
            string updatedContacts = "";
            string contacts = Utility.Decrypt(InvReceiver.Friends);
            if (contacts != null)
            {
                string[] contactIds = contacts.Split(',');
                List<String> activeContactIds = new List<String>();

                foreach (string contactId in contactIds)
                {
                    activeContactIds.Add(contactId);
                }

                activeContactIds.Remove(InvitationSenderID.ToString());

               
                foreach (string contactId in activeContactIds)
                {
                    if (string.IsNullOrEmpty(updatedContacts))
                    {
                        updatedContacts = updatedContacts + contactId;
                    }
                    else
                    {
                        updatedContacts = updatedContacts + "," + contactId;
                    }
                }
            }
            return updatedContacts;
        }

    }
}
