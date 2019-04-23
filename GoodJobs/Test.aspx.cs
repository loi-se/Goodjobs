using Jobhunt.Controllers;
using Jobhunt.Data;
using Jobhunt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jobhunt
{
    public partial class Test : System.Web.UI.Page
    {

        public JobApplicationsController _JobApplicationsController;
       // public JobApplications _JobApplication;
        public UsersController _UsersController;
        public GridViewUtility _GridViewUtility;
        public Utility _Utility;
        //public User _User;
        private int _UserId;

        Dictionary<int, UserData> userDataInfo;

        public int NofUsers = 6;

        protected void Page_Load(object sender, EventArgs e)
        {

            _GridViewUtility = new GridViewUtility();
            _Utility = new Utility();
            _JobApplicationsController = new JobApplicationsController();
           // _JobApplication = new JobApplications();
            _UsersController = new UsersController();
           



            userDataInfo = new Dictionary<int, UserData>();
            UserData userData = new UserData();
            userData.city = " Woerden";
            userData.country = "Netherlands";
            userData.streetName = "Boterbloemweide";
            userData.streetNumber = "17";
            userData.postalCode = "3448 HZ";
            userData.email = "rolandmeijerink@gmail.com";
            // userData.email = "wmvanWoerdt@gmail.com";

            userData.mainCareer = "4";
            userData.subCareer = "Software developer";
            userData.searchTags = "C#,ASP.net,SQL";

            userDataInfo.Add(1, userData);

            userData = new UserData();
            userData.city = "Waddinxveen";
            userData.country = "Netherlands";
            userData.streetName = "Peuleyen";
            userData.streetNumber = "200";
            userData.postalCode = "2742ES";
            userData.email = "rolandmeijerink@gmail.com";
            //userData.email = " pieterVanderPol@yahoo.co.uk";

            userData.mainCareer = "8";
            userData.subCareer = "Nuclear engineer";
            userData.searchTags = "Atoms,Nuclear";

            userDataInfo.Add(2, userData);

            userData = new UserData();
            userData.city = "Hoogeveen";
            userData.country = "Netherlands";
            userData.streetName = "Bieleveldlaan";
            userData.streetNumber = "53";
            userData.postalCode = "7906 HS";
            userData.email = "rolandmeijerink@gmail.com";
            //userData.email = "BarryBotterbloem@live.nl";

            userData.mainCareer = "4";
            userData.subCareer = "Quality engineer";
            userData.searchTags = "TMap,C#,SQL";

            userDataInfo.Add(3, userData);

            userData = new UserData();
            userData.city = "Hardenberg";
            userData.country = "Netherlands";
            userData.streetName = "Oosteinde";
            userData.streetNumber = "29";
            userData.postalCode = "7772CB";
            userData.email = "rolandmeijerink85@gmail.com";

            userData.mainCareer = "5";
            userData.subCareer = "Architect";
            userData.searchTags = "Public buildings, housing";

            userDataInfo.Add(4, userData);

            userData = new UserData();
            userData.city = "Leiden";
            userData.country = "Netherlands";
            userData.streetName = "Pieterskerkgracht";
            userData.streetNumber = "17";
            userData.postalCode = "2311 SZ";
            userData.email = "rolandmeijerink@gmail.com";
            //userData.email = "vanderboom@gmail.com";

            userData.mainCareer = "6";
            userData.subCareer = "Photographer";
            userData.searchTags = "Canon";

            userDataInfo.Add(5, userData);


            deleteAllData();
            CreateUsers();
        }

        public void deleteAllData()
        {
            _JobApplicationsController.TestDeleteAll();
            _UsersController.TestDeleteAll();


            //List<JobApplications> AllJobApplications = _JobApplicationsController.GetJobApplications().ToList();
            //foreach(JobApplications _jobapplications in AllJobApplications)
            //{
            //    _JobApplicationsController.DeleteJobApplications(_jobapplications.ID);
            //}

            //List<User> AllUsers = _UsersController.GetUsers().ToList();

            //foreach (User _user in AllUsers)
            //{
            //    _UsersController.DeleteUser(_user.UserId);
            //}
            
        }

        public void testInvitations()
        {

            //InvitationHandler invitationHandler = new InvitationHandler();

            // Use case 1:
            // Send a new invitation to a user:
            // De verzender friendsinvSend bijwerken:
            //invitationHandler.UpdateInvitation(1, "S", "FriendsInvSend", "new");
            // De ontvanger friendsInsRecieved bijwerken:
            //invitationHandler.UpdateInvitation(1, "S", "FriendsInvRecieved", "new");

            // Use case 2: 
            // Accept invitation:
            //invitationHandler.UpdateInvitation(1, "A", "FriendsInvSend", "update");
            //invitationHandler.UpdateInvitation(1, "A", "FriendsInvRecieved", "update");

            //Use case 2:
            // Deny invitation:
            //invitationHandler.UpdateInvitation(1, "D", "FriendsInvSend", "update");
            //invitationHandler.UpdateInvitation(1, "D", "FriendsInvRecieved", "update");

            //Use Case 3:
            // Withdraw invitation:
            //invitationHandler.UpdateInvitation(1, "W", "FriendsInvSend", "update");
            //invitationHandler.UpdateInvitation(1, "W", "FriendsInvRecieved", "update");
 


        }
        public void CreateUsers()
        {
            User _newuser;
            JobApplications _jobApplication;

            int i = 1;
            for (i = 1; i < NofUsers; i++)
            {

                _newuser = new User();
                _newuser.BirthDate = DateTime.Now;
                _newuser.City = _Utility.Encrypt(userDataInfo[i].city);
                _newuser.Country = _Utility.Encrypt(userDataInfo[i].country);
                _newuser.StreetName = _Utility.Encrypt(userDataInfo[i].streetName);
                _newuser.StreetNumber = _Utility.Encrypt(userDataInfo[i].streetNumber);
                _newuser.ZipCode = _Utility.Encrypt(userDataInfo[i].postalCode);

                _newuser.Email = _Utility.Encrypt(userDataInfo[i].email);

                _newuser.FirstName = _Utility.Encrypt("Roland" + i.ToString());
                _newuser.LastName = _Utility.Encrypt("Meijerink" + i.ToString());
                _newuser.Password = _Utility.Encrypt("necrid" + i.ToString());
                _newuser.UserName = _Utility.Encrypt("roland");
                _newuser.UserId = i;
                //_newuser.Friends = _Utility.Encrypt("1,2,3,4,5");
                _newuser.Friends = _Utility.Encrypt("");
                _newuser.Categories = _Utility.Encrypt("categorie 1`categorie 2`categorie 3`categorie 4`categorie 5`categorie 6`categorie 7`categorie 8`categorie 9");
                // From
                //_newuser.FriendsInvRecieved = _Utility.Encrypt("S:1:14/07/2018:22,S:2:14/07/2018:33,S:3:14/07/2018:44,S:4:14/07/2018:55,S:5:14/07/2018:77");
                _newuser.FriendsInvRecieved = _Utility.Encrypt("");

                // To
                //_newuser.FriendsInvSend = _Utility.Encrypt("S:1:14/07/2018:45,S:2:14/07/2018:32,S:3:14/07/2018:12,S:4:14/07/2018:87,S:5:14/07/2018:90");
                _newuser.FriendsInvSend = _Utility.Encrypt("");

                _newuser.LinkedIn = _Utility.Encrypt("https://www.linkedin.com/in/roland-meijerink-75a97661/");

                _newuser.MainCareer = _Utility.Encrypt(userDataInfo[i].mainCareer);
                _newuser.SubCareer = _Utility.Encrypt(userDataInfo[i].subCareer);
                _newuser.SearchTag = _Utility.Encrypt(userDataInfo[i].searchTags);

                _UsersController.PostUser(_newuser);
            }


            List<User> AllUsers = _UsersController.GetUsers().ToList();

            foreach (User _user in AllUsers)
            {
                int nofJobApplications = 150;

                for (i = 1; i < nofJobApplications; i++)
                {

                    _jobApplication = new JobApplications();

                    _jobApplication.JobApplCompanyQuestions = _Utility.Encrypt("Over de functie: - Hoeveel ontwikkelaars zijn er nu" +
                    "-Is het een SAAS product?");

                    _jobApplication.JobApplDateTime = DateTime.Now.AddDays(-i * 6);
                    _jobApplication.JobApplFeedback = _Utility.Encrypt(" We zijn op zoek naar uitbreiding van ons team met een junior programmeur php die geïnteresseerd is door te groeien naar een senior development rol."
                        + "Afhankelijk van de snelheid waarmee je e.a kan oppakken begint het met testen van de applicatie en bug fixen en mee ontwikkelen van nieuwe functionaliteit");

                    _jobApplication.JobApplFollowUpStatus = "Not sended";
                    _jobApplication.JobApplInterviewDateTime = DateTime.Now.AddDays(-i * 5);
                    _jobApplication.JobApplInterviewNotes = _Utility.Encrypt(" We zijn op zoek naar uitbreiding van ons team met een junior programmeur php die geïnteresseerd is door te groeien naar een senior development rol."
                        + "Afhankelijk van de snelheid waarmee je e.a kan oppakken begint het met testen van de applicatie en bug fixen en mee ontwikkelen van nieuwe functionaliteit");

                    _jobApplication.JobApplInterviewPersons = _Utility.Encrypt("Pieter werkdam");
                    _jobApplication.JobApplInterviewPreperation = _Utility.Encrypt(" We zijn op zoek naar uitbreiding van ons team met een junior programmeur php die geïnteresseerd is door te groeien naar een senior development rol."
                        + "Afhankelijk van de snelheid waarmee je e.a kan oppakken begint het met testen van de applicatie en bug fixen en mee ontwikkelen van nieuwe functionaliteit");

                    _jobApplication.JobApplInterviewTime = "12" + ":" + "30";
                    _jobApplication.JobApplLetter = _Utility.Encrypt("LinkedIn: http://nl.linkedin.com/pub/roland-meijerink/61/976/75a");

                    _jobApplication.JobApplMethod = _Utility.Encrypt("Bedrijfs website");
                    _jobApplication.JobApplMyFollowUpEmails = _Utility.Encrypt(" We zijn op zoek naar uitbreiding van ons team met een junior programmeur php die geïnteresseerd is door te groeien naar een senior development rol."
                        + "Afhankelijk van de snelheid waarmee je e.a kan oppakken begint het met testen van de applicatie en bug fixen en mee ontwikkelen van nieuwe functionaliteit");

                    _jobApplication.JobApplMyQuestions = _Utility.Encrypt("Over de functie: - Hoeveel ontwikkelaars zijn er nu" +
                    "-Is het een SAAS product?");

                    _jobApplication.JobApplMyRating = "5";
                    _jobApplication.JobApplName = _Utility.Encrypt("Solicitatie" + i.ToString() + " " + _Utility.Decrypt(_user.FirstName) + " " + _Utility.Decrypt(_user.LastName));
                    _jobApplication.JobApplNote = _Utility.Encrypt("Over de functie: - Hoeveel ontwikkelaars zijn er nu" +
                    "-Is het een SAAS product?");

                    _jobApplication.JobApplSecInterviewDateTime = DateTime.Now.AddDays(-i * 4);
                    _jobApplication.JobApplSecInterviewPersons = _Utility.Encrypt("Pieter werkdam");
                    _jobApplication.JobApplSecInterviewTime = "12" + ":" + "40";

                    _jobApplication.JobApplStatus = "Job application sended";
                    _jobApplication.JobApplThirdInterviewDateTime = DateTime.Now.AddDays(-i * 3);
                    _jobApplication.JobApplThirdInterviewPersons = _Utility.Encrypt("Pieter werkdam");
                    _jobApplication.JobApplThirdInterviewTime = "15" + ":" + "40";

                    _jobApplication.JobApplTime = "15" + ":" + "40";
                    _jobApplication.ShowToFriends = "True";
                    _jobApplication.UserUserId = _user.UserId;
                    _jobApplication.VacancyCareerField = _Utility.Encrypt("Software development");
                    _jobApplication.VacancyCompany = _Utility.Encrypt("DeGroSolutions");
                    _jobApplication.VacancyCompanyCity = _Utility.Encrypt(" Hardenberg");
                    _jobApplication.VacancyCompanyCountry = _Utility.Encrypt("Netherlands");
                    _jobApplication.VacancyCompanyStreetName = _Utility.Encrypt("Lange Spruit");
                    _jobApplication.VacancyCompanyStreetNumber = _Utility.Encrypt("1a");
                    _jobApplication.VacancyCompanySummary = _Utility.Encrypt("Over de functie: - Hoeveel ontwikkelaars zijn er nu" +
                    "-Is het een SAAS product?");

                    _jobApplication.VacancyCompanyWebsite = _Utility.Encrypt("http://www.degrosolutions.nl/");
                    _jobApplication.VacancyCompanyZipCode = _Utility.Encrypt("7773 NE");
                    _jobApplication.VacancyContactPerson = _Utility.Encrypt("Pieter werkdam");
                    _jobApplication.VacancyContactPersonEmail = _Utility.Encrypt("rolandmeijerink@gmail.com");
                    _jobApplication.VacancyContactPersonLinkedIn = _Utility.Encrypt("https://www.linkedin.com/in/roland-meijerink-75a97661/");
                    _jobApplication.VacancyFunctionTitle = _Utility.Encrypt("C# developer");
                    _jobApplication.VacancyLink = _Utility.Encrypt("http://www.degrosolutions.nl/werken-bij-degrosolutions/");
                    _jobApplication.VacancySalary = _Utility.Encrypt(" 2300");
                    _jobApplication.VacancyText = _Utility.Encrypt("Vacature Software Engineer" +
                   "Wij zijn op zoek naar een enthousiaste software engineer voor de volgende werkzaamheden:" +
                    "•	Ontwikkelen, dat wil zeggen analyse, ontwerp en realisatie van gebruiksvriendelijke, aantrekkelijke systemen in overleg met opdrachtgevers en collega's." +
                    "•	Innoveren en optimaliseren van het ontwikkelproces bij IDgis." +
                    "Ons aanbod" +
                    "•	Werken aan innovatieve GIS-toepassingen met state-of - the - art technieken zoals HTML5 / JavaScript, JQuery, Dojo, Meteor.JS, Java, Spring, Gradle, JAXB, GitHub, TeamCity, Docker, etc" +
                    "•	Werken in een open, informele, integere en professionele organisatie" +
                    "•	Sterke afwisseling in opdrachten" +
                    "•	Werken aan interessante opdrachten van aansprekende opdrachtgevers(Provincies, Politie, etc)" +
                    "•	Kantoor in een prettige omgeving(centrum Rijssen)" +
                    "•	Goed bereikbaar per auto en met openbaar vervoer" +
                    "•	Volop kansen voor persoonlijke ontwikkeling" +
                    "•	Prima arbeidsvoorwaarden" +
                    "IDgis als werkgever" +
                    "IDgis ontwikkelt geografische informatiesystemen(GIS) en heeft o.a.gemeenten, provincies, ministeries, Kadaster, Politie en semi - overheid instellingen als klant.Vaak gaat het om toepassing van nieuwe technologieën in uitdagende projecten." +
                    " Onze aanpak is doelgericht en pragmatisch volgens de LEAN principes met tegelijk aandacht voor duurzame, herbruikbare oplossingen. Daarom zijn onze oplossingen altijd gebaseerd op open standaarden(o.a.OGC).Nauwe samenwerking met eindgebruikers " +
                     "en een iteratieve werkwijze zien we als noodzakelijk voor succes.IDgis ontwikkelt eigen producten zoals PlanoView en DynaCAP, ontwikkelt open source toepassingen op verzoek van klanten zoals CDS - INSPIRE en GeoPublisher en ontwikkelt mee aan" +
                     "grotere open source projecten zoals deegree. " +
                     "Online voorbeelden van door IDgis ontwikkelde toepassingen zijn: PlanoView bij o.a.Limburg en Zuid - Holland, het Geoloket op www.milieudienstzou.nl en www.roermond.nl." +
                    "Functieomschrijving" +
                    "•	Als ontwikkelaar/ programmeur maak je gebruiksvriendelijke, aantrekkelijke systemen in overleg met opdrachtgevers en collega's." +
                    "•	Innoveren en optimaliseren van het ontwikkelproces bij IDgis." +
                    "Functie - eisen" +
                    "•	Aantoonbaar HBO of WO werk - en denkniveau; " +
                    "•	Aantoonbare programmeerervaring*met Java, JavaScript, Python en/ of SQL; " +
                    "•	Kennis van GIS - concepten en –technieken is een pré; " +
                    "•	Goede mondelinge en schriftelijke beheersing van Nederlands en Engels." +
                    "* Ook starters worden uitgenodigd te solliciteren.Je hebt bijvoorbeeld programmeerervaring opgedaan tijdens stages en studie." +
                    "Persoonskenmerken" +
                    "Teamgeest, leergierig, pragmatisch, analytisch.");

                    _jobApplication.VacancyTitle = _Utility.Encrypt("Junior software developer");

                    _JobApplicationsController.PostJobApplications(_jobApplication);
                }

            }

        }
    }

    public class UserData
    {
        public string streetName;
        public string streetNumber;
        public string city;
        public string postalCode;
        public string country;
        public string email;
        public string mainCareer;
        public string subCareer;
        public string searchTags;
    }
    }
