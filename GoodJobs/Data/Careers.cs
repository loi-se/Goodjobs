using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jobhunt
{
    public class Careers
    {

        public Dictionary<int, string> GetMainCareers()
        {

            Dictionary<int, string> mainCareers = new Dictionary<int, string>();
            mainCareers.Add(1, "Administration, business and management");
            mainCareers.Add(2, "Alternative therapies");
            mainCareers.Add(3, "Animals, land and environment");
            mainCareers.Add(4, "Computing and ICT");
            mainCareers.Add(5, "Construction and building");
            mainCareers.Add(6, "Design, arts and crafts");
            mainCareers.Add(7, "Education and training");
            mainCareers.Add(8, "Engineering");
            mainCareers.Add(9, "Facilities and property services");
            mainCareers.Add(10, "Financial services");
            mainCareers.Add(11, "Garage services");
            mainCareers.Add(12, "Hairdressing and beauty");
            mainCareers.Add(13, "Healthcare");
            mainCareers.Add(14, "Heritage, culture and libraries");
            mainCareers.Add(15, "Hospitality, catering and tourism");
            mainCareers.Add(16, "languages");
            mainCareers.Add(17, "Legal and court services");
            mainCareers.Add(18, "Manufacturing and production");
            mainCareers.Add(19, "Performing arts and media");
            mainCareers.Add(20, "Print and publishing, marketing and advertising");
            mainCareers.Add(21, "Retail and customer services");
            mainCareers.Add(22, "Science, mathematics and statistics");
            mainCareers.Add(23, "Security, uniformed and protective services");
            mainCareers.Add(24, "Social sciences and religion");
            mainCareers.Add(25, "Social work and caring services");
            mainCareers.Add(26, "Sport and leisure");
            mainCareers.Add(27, "Transport, distribution and logistics");

            return mainCareers;
        }


        public List<string> GetSubCareers(int mainCareerId)
        {

            List<string> subCareers = new List<string>();

            switch (mainCareerId)
            {
                case 1:
                    subCareers.Add("Administrative assistant");
                    subCareers.Add("Car rental agent");
                    subCareers.Add("Charity fundraiser");
                    subCareers.Add("Civil service administrative officer");
                    subCareers.Add("Civil service executive officer");
                    subCareers.Add("Company secretary");
                    subCareers.Add("Diplomatic service officer");
                    subCareers.Add("Economic development officer");
                    subCareers.Add("Environmental health officer");
                    subCareers.Add("European Union official");
                    subCareers.Add("Health and safety adviser");
                    subCareers.Add("Health records clerk");
                    subCareers.Add("Health service manager");
                    subCareers.Add("Human resources officer");
                    subCareers.Add("Legal secretary");
                    subCareers.Add("Local government administrative assistant");
                    subCareers.Add("Local government officer");
                    subCareers.Add("Local government revenues officer");
                    subCareers.Add("Management consultant");
                    subCareers.Add("Medical secretary");
                    subCareers.Add("Member of Parliament(MP)");
                    subCareers.Add("Operational researcher");
                    subCareers.Add("Personal assistant");
                    subCareers.Add("Project manager");
                    subCareers.Add("Purchasing manager");
                    subCareers.Add("Receptionist");
                    subCareers.Add("Recruitment consultant");
                    subCareers.Add("Registrar of births, deaths, marriages and civil partnerships");
                    subCareers.Add("Secretary");
                    subCareers.Add("Trade union official");
                    subCareers.Add("Trading standards officer");
                    break;
                case 2:
                    subCareers.Add("Alternative therapies");
                    subCareers.Add("Acupuncturist");
                    subCareers.Add("Homeopath");
                    subCareers.Add("Hypnotherapist");
                    subCareers.Add("Medical herbalist");
                    subCareers.Add("Naturopath");
                    subCareers.Add("Osteopath");
                    subCareers.Add("Reflexologist");
                    break;

                case 3:
                    subCareers.Add("Agricultural engineer");
                    subCareers.Add("Animal care worker");
                    subCareers.Add("Animal technician");
                    subCareers.Add("Assistance dog trainer");
                    subCareers.Add("Cemetery worker");
                    subCareers.Add("Countryside officer");
                    subCareers.Add("Countryside ranger");
                    subCareers.Add("Diver");
                    subCareers.Add("Dog groomer");
                    subCareers.Add("Dog handler");
                    subCareers.Add("Environmental consultant");
                    subCareers.Add("Farm manager");
                    subCareers.Add("Farm worker");
                    subCareers.Add("Farrier");
                    subCareers.Add("Fence installer");
                    subCareers.Add("Fish farm worker");
                    subCareers.Add("Fishing vessel skipper");
                    subCareers.Add("Forest officer");
                    subCareers.Add("Forest worker");
                    subCareers.Add("Gamekeeper");
                    subCareers.Add("Gardener");
                    subCareers.Add("Geoscientist");
                    subCareers.Add("Greenkeeper");
                    subCareers.Add("Horse groom");
                    subCareers.Add("Horse riding instructor");
                    subCareers.Add("Horticultural worker");
                    subCareers.Add("Jockey");
                    subCareers.Add("Kennel worker");
                    subCareers.Add("Landscaper");
                    subCareers.Add("Meteorologist");
                    subCareers.Add("Oceanographer");
                    subCareers.Add("Pest control technician");
                    subCareers.Add("Rural surveyor");
                    subCareers.Add("SSPCA inspector");
                    subCareers.Add("Tree surgeon");
                    subCareers.Add("Veterinary nurse");
                    subCareers.Add("Veterinary surgeon");
                    subCareers.Add("Zookeeper");
                    break;


                case 4:

                    subCareers.Add("Audio - visual technician");
                    subCareers.Add("CAD technician");
                    subCareers.Add("Computer games developer");
                    subCareers.Add("Computer games tester");
                    subCareers.Add("Computer service and repair technician");
                    subCareers.Add("Database administrator");
                    subCareers.Add("Forensic computer analyst");
                    subCareers.Add("Helpdesk professional");
                    subCareers.Add("IT support technician");
                    subCareers.Add("IT trainer");
                    subCareers.Add("Network manager");
                    subCareers.Add("Office equipment service technician");
                    subCareers.Add("Software developer");
                    subCareers.Add("Systems analyst");
                    subCareers.Add("Web developer");
                    subCareers.Add("Web editor");
                    subCareers.Add("Quality engineer");
                    break;

                case 5:
                    subCareers.Add("Architect");
                    subCareers.Add("Architectural technician");
                    subCareers.Add("Architectural technologist");
                    subCareers.Add("Bricklayer");
                    subCareers.Add("Builders merchant");
                    subCareers.Add("Building control officer");
                    subCareers.Add("Building surveyor");
                    subCareers.Add("Building technician");
                    subCareers.Add("Carpenter or joiner");
                    subCareers.Add("Carpet fitter or floor layer");
                    subCareers.Add("Cavity insulation installer");
                    subCareers.Add("Ceiling fixer");
                    subCareers.Add("Civil engineer");
                    subCareers.Add("Civil engineering technician");
                    subCareers.Add("Clerk of works");
                    subCareers.Add("Construction manager");
                    subCareers.Add("Construction operative");
                    subCareers.Add("Construction plant mechanic");
                    subCareers.Add("Construction plant operator");
                    subCareers.Add("Demolition operative");
                    subCareers.Add("Dry liner");
                    subCareers.Add("Electricity distribution worker");
                    subCareers.Add("General practice surveyor");
                    subCareers.Add("Glazier");
                    subCareers.Add("Land surveyor");
                    subCareers.Add("Landscape architect");
                    subCareers.Add("Leakage operative");
                    subCareers.Add("Minerals surveyor");
                    subCareers.Add("Painter and decorator");
                    subCareers.Add("Planning and development surveyor");
                    subCareers.Add("Plasterer");
                    subCareers.Add("Plumber");
                    subCareers.Add("Quantity surveyor");
                    subCareers.Add("Road worker");
                    subCareers.Add("Roofer");
                    subCareers.Add("Scaffolder");
                    subCareers.Add("Shopfitter");
                    subCareers.Add("Steeplejack or lightning conductor engineer");
                    subCareers.Add("Stonemason");
                    subCareers.Add("Structural engineer");
                    subCareers.Add("Technical surveyor");
                    subCareers.Add("Town planner");
                    subCareers.Add("Town planning support staff");
                    subCareers.Add("Wall and floor tiler");
                    subCareers.Add("Water treatment worker");
                    subCareers.Add("Window fitter");
                    break;
                case 6:
                    subCareers.Add("Animator");
                    subCareers.Add("Art gallery curator");
                    subCareers.Add("Blacksmith");
                    subCareers.Add("Cabinet maker");
                    subCareers.Add("Ceramics designer or maker");
                    subCareers.Add("Clothing alteration hand");
                    subCareers.Add("Costume designer");
                    subCareers.Add("Dressmaker");
                    subCareers.Add("Exhibition designer");
                    subCareers.Add("Fashion designer");
                    subCareers.Add("Fine artist");
                    subCareers.Add("French polisher");
                    subCareers.Add("Furniture designer");
                    subCareers.Add("Glassmaker");
                    subCareers.Add("Graphic designer");
                    subCareers.Add("Illustrator");
                    subCareers.Add("Interior designer");
                    subCareers.Add("Jewellery designer-maker");
                    subCareers.Add("Medical illustrator");
                    subCareers.Add("Model maker");
                    subCareers.Add("Musical instrument maker or repairer");
                    subCareers.Add("Photographer");
                    subCareers.Add("Photographic stylist");
                    subCareers.Add("Photographic technician");
                    subCareers.Add("Picture framer");
                    subCareers.Add("Product designer");
                    subCareers.Add("Set designer");
                    subCareers.Add("Signwriter");
                    subCareers.Add("Tattooist");
                    subCareers.Add("Textile designer");
                    subCareers.Add("Watch or clock repairer");
                    break;
                case 7:

                    subCareers.Add("Careers adviser");
                    subCareers.Add("Classroom assistant");
                    subCareers.Add("Community education coordinator");
                    subCareers.Add("Early years teacher");
                    subCareers.Add("EFL teacher");
                    subCareers.Add("Further education lecturer");
                    subCareers.Add("Higher education lecturer");
                    subCareers.Add("Learning support assistant");
                    subCareers.Add("Nursery manager");
                    subCareers.Add("Primary school teacher");
                    subCareers.Add("Secondary school teacher");
                    subCareers.Add("Secondary school teacher – Physical education");
                    subCareers.Add("Secondary school teacher- Art and design");
                    subCareers.Add("Secondary school teacher- Biology");
                    subCareers.Add("Secondary school teacher- Business studies");
                    subCareers.Add("Secondary school teacher- Chemistry");
                    subCareers.Add("Secondary school teacher- Drama");
                    subCareers.Add("Secondary school teacher- English");
                    subCareers.Add("Secondary school teacher- Geography");
                    subCareers.Add("Secondary school teacher- History");
                    subCareers.Add("Secondary school teacher- Home economics");
                    subCareers.Add("Secondary school teacher- Mathematics");
                    subCareers.Add("Secondary school teacher- Modern foreign languages");
                    subCareers.Add("Secondary school teacher- Modern studies");
                    subCareers.Add("Secondary school teacher- Music");
                    subCareers.Add("Secondary school teacher- Physics");
                    subCareers.Add("Secondary school teacher- Religious education");
                    subCareers.Add("Training manager");
                    subCareers.Add("Training officer");

                    break;
                case 8:

                    subCareers.Add("Aerospace engineer");
                    subCareers.Add("Aircraft maintenance engineer");
                    subCareers.Add("Automotive engineer");
                    subCareers.Add("Building services engineer");
                    subCareers.Add("Chemical engineer");
                    subCareers.Add("Chemical engineering technician");
                    subCareers.Add("Design engineer");
                    subCareers.Add("Drilling engineer");
                    subCareers.Add("Electrical engineer");
                    subCareers.Add("Electrical engineering technician");
                    subCareers.Add("Electrician");
                    subCareers.Add("Electronics engineer");
                    subCareers.Add("Electronics engineering technician");
                    subCareers.Add("Energy engineer");
                    subCareers.Add("Engineering craft machinist");
                    subCareers.Add("Engineering maintenance technician");
                    subCareers.Add("Engineering operative");
                    subCareers.Add("Gas service technician");
                    subCareers.Add("Heating and ventilation engineer");
                    subCareers.Add("Manufacturing systems engineer");
                    subCareers.Add("Marine craftsperson");
                    subCareers.Add("Marine engineer");
                    subCareers.Add("Materials engineer");
                    subCareers.Add("Materials technician");
                    subCareers.Add("Measurement and control engineer");
                    subCareers.Add("Measurement and control technician");
                    subCareers.Add("Mechanical engineer");
                    subCareers.Add("Mechanical engineering technician");
                    subCareers.Add("Merchant navy engineering officer");
                    subCareers.Add("Naval architect");
                    subCareers.Add("Nuclear engineer");
                    subCareers.Add("Offshore drilling worker");
                    subCareers.Add("Offshore roustabout");
                    subCareers.Add("Offshore service technician");
                    subCareers.Add("Quarry engineer");
                    subCareers.Add("Rail engineering technician");
                    subCareers.Add("Refrigeration and air conditioning engineer");
                    subCareers.Add("ROV pilot technician");
                    subCareers.Add("Satellite systems technician");
                    subCareers.Add("Security systems installer");
                    subCareers.Add("Sheet metal worker");
                    subCareers.Add("Smart meter installer");
                    subCareers.Add("Telecoms engineer");
                    subCareers.Add("Thermal insulation engineer");
                    subCareers.Add("Track maintenance operative");
                    subCareers.Add("Welder");
                    break;
                case 9:

                    subCareers.Add("Accommodation warden");
                    subCareers.Add("Caretaker");
                    subCareers.Add("Cleaner");
                    subCareers.Add("Dry - cleaner");
                    subCareers.Add("Facilities manager");
                    subCareers.Add("Highways cleaner");
                    subCareers.Add("Laundry worker");
                    subCareers.Add("Locksmith");
                    subCareers.Add("Recycling operative");
                    subCareers.Add("Refuse collector");
                    subCareers.Add("Window cleaner");
                    break;
                case 10:

                    subCareers.Add("Accounting technician");
                    subCareers.Add("Actuary");
                    subCareers.Add("Bank manager");
                    subCareers.Add("Banking customer service adviser");
                    subCareers.Add("Credit manager");
                    subCareers.Add("Economist");
                    subCareers.Add("Financial adviser");
                    subCareers.Add("Insurance account manager");
                    subCareers.Add("Insurance broker");
                    subCareers.Add("Insurance claims handler");
                    subCareers.Add("Insurance loss adjuster");
                    subCareers.Add("Insurance risk surveyor");
                    subCareers.Add("Insurance underwriter");
                    subCareers.Add("Investment analyst");
                    subCareers.Add("Investment banker");
                    subCareers.Add("Management accountant");
                    subCareers.Add("Private practice accountant");
                    subCareers.Add("Public finance accountant");
                    subCareers.Add("Stockbroker");
                    subCareers.Add("Tax inspector");
                    break;
                case 11:


                    subCareers.Add("Car valet");
                    subCareers.Add("Cycle mechanic");
                    subCareers.Add("Motor vehicle body repairer");
                    subCareers.Add("Motor vehicle breakdown engineer");
                    subCareers.Add("Motor vehicle parts person");
                    subCareers.Add("Motor vehicle technician");
                    subCareers.Add("Tyre or exhaust fitter");
                    subCareers.Add("Vehicle spray painter");
                    break;
                case 12:
                    subCareers.Add("Aromatherapist");
                    subCareers.Add("Beauty consultant");
                    subCareers.Add("Beauty therapist");
                    subCareers.Add("Body piercer");
                    subCareers.Add("Fashion model");
                    subCareers.Add("Hairdresser");
                    subCareers.Add("Make - up artist");
                    subCareers.Add("Nail technician");

                    break;
                case 13:


                    subCareers.Add("Adult nurse");
                    subCareers.Add("Ambulance care assistant");
                    subCareers.Add("Ambulance paramedic");
                    subCareers.Add("Ambulance technician");
                    subCareers.Add("Anatomical pathology technician");
                    subCareers.Add("Art therapist");
                    subCareers.Add("Audiologist");
                    subCareers.Add("Children nurse");
                    subCareers.Add("Chiropodist");
                    subCareers.Add("Chiropractor");
                    subCareers.Add("Clinical engineer");
                    subCareers.Add("Clinical perfusionist");
                    subCareers.Add("Clinical psychologist");
                    subCareers.Add("Dance movement psychotherapist");
                    subCareers.Add("Dental hygienist");
                    subCareers.Add("Dental nurse");
                    subCareers.Add("Dental technician");
                    subCareers.Add("Dental therapist");
                    subCareers.Add("Dentist");
                    subCareers.Add("Dietitian");
                    subCareers.Add("Dispensing optician");
                    subCareers.Add("District nurse");
                    subCareers.Add("Doctor - GP");
                    subCareers.Add("Dramatherapist");
                    subCareers.Add("Emergency call handler");
                    subCareers.Add("Emergency medical dispatcher");
                    subCareers.Add("Ergonomist");
                    subCareers.Add("Forensic psychologist");
                    subCareers.Add("Health promotion specialist");
                    subCareers.Add("Health visitor");
                    subCareers.Add("Healthcare assistant");
                    subCareers.Add("Hospital doctor");
                    subCareers.Add("Hospital porter");
                    subCareers.Add("Learning disability nurse");
                    subCareers.Add("Medical physicist");
                    subCareers.Add("Mental health nurse");
                    subCareers.Add("Midwife");
                    subCareers.Add("Music therapist");
                    subCareers.Add("Occupational therapist");
                    subCareers.Add("Occupational therapy support worker");
                    subCareers.Add("Offshore medic");
                    subCareers.Add("Operating department practitioner");
                    subCareers.Add("Optometrist");
                    subCareers.Add("Orthoptist");
                    subCareers.Add("Pathologist");
                    subCareers.Add("Patient transport service controller");
                    subCareers.Add("Pharmacist");
                    subCareers.Add("Pharmacy technician");
                    subCareers.Add("Phlebotomist");
                    subCareers.Add("Physiotherapist");
                    subCareers.Add("Physiotherapy assistant");
                    subCareers.Add("Play therapist");
                    subCareers.Add("Practice nurse");
                    subCareers.Add("Prosthetist - orthotist");
                    subCareers.Add("Radiographer");
                    subCareers.Add("Speech and language therapist");
                    subCareers.Add("Sterile services technician");
                    subCareers.Add("Surgeon");

                    break;
                case 14:

                    subCareers.Add("Archaeologist");
                    subCareers.Add("Archivist");
                    subCareers.Add("Conservator");
                    subCareers.Add("Librarian");
                    subCareers.Add("Library assistant");
                    subCareers.Add("Museum assistant");
                    subCareers.Add("Museum curator");
                    break;
                case 15:

                    subCareers.Add("Air cabin crew");
                    subCareers.Add("Airline customer service agent");
                    subCareers.Add("Airport information assistant");
                    subCareers.Add("Baker");
                    subCareers.Add("Bar person");
                    subCareers.Add("Butler");
                    subCareers.Add("Cake decorator");
                    subCareers.Add("Catering manager");
                    subCareers.Add("Chef");
                    subCareers.Add("Counter service assistant");
                    subCareers.Add("Croupier");
                    subCareers.Add("Fairground worker");
                    subCareers.Add("Hotel manager");
                    subCareers.Add("Hotel porter");
                    subCareers.Add("Hotel receptionist");
                    subCareers.Add("Hotel room attendant");
                    subCareers.Add("Kitchen assistant");
                    subCareers.Add("Kitchen manager(head chef)");
                    subCareers.Add("Resort representative");
                    subCareers.Add("Restaurant manager");
                    subCareers.Add("Riding holiday centre manager");
                    subCareers.Add("Tour manager");
                    subCareers.Add("Tourist guide");
                    subCareers.Add("Tourist information centre assistant");
                    subCareers.Add("Travel agent");
                    subCareers.Add("Waiting staff");
                    break;
                case 16:
                    subCareers.Add("Interpreter");
                    subCareers.Add("Translator");
                    break;
                case 17:


                    subCareers.Add("Administrative officer(courts)");
                    subCareers.Add("Advocate");
                    subCareers.Add("Advocate clerk");
                    subCareers.Add("Court officer");
                    subCareers.Add("Judge or sheriff");
                    subCareers.Add("Paralegal");
                    subCareers.Add("Patent attorney");
                    subCareers.Add("Procurator fiscal");
                    subCareers.Add("Reporter to the Children’s Panel");
                    subCareers.Add("Sheriff officer");
                    subCareers.Add("Solicitor");
                    break;
                case 18:

                    subCareers.Add("Brewery worker");
                    subCareers.Add("Butcher");
                    subCareers.Add("Distillery manager");
                    subCareers.Add("Food packaging operative");
                    subCareers.Add("Garment technologist");
                    subCareers.Add("Heat treatment operator ");
                    subCareers.Add("Meat process worker");
                    subCareers.Add("Packer");
                    subCareers.Add("Pattern cutter");
                    subCareers.Add("Pattern grader");
                    subCareers.Add("Production manager(manufacturing)");
                    subCareers.Add("Production worker(manufacturing)");
                    subCareers.Add("Quality control technician");
                    subCareers.Add("Sewing machinist");
                    subCareers.Add("Tailor");
                    subCareers.Add("Technical brewer");
                    subCareers.Add("Textile dyeing technician");
                    subCareers.Add("Textile operative");
                    subCareers.Add("Textile technologist");
                    subCareers.Add("Toolmaker");
                    subCareers.Add("Upholsterer");
                    subCareers.Add("Wood machinist");

                    break;
                case 19:



                    subCareers.Add("Actor");
                    subCareers.Add("Arts administrator");
                    subCareers.Add("Broadcast engineer");
                    subCareers.Add("Broadcast journalist");
                    subCareers.Add("Choreographer");
                    subCareers.Add("Classical musician");
                    subCareers.Add("Community arts worker");
                    subCareers.Add("Dance teacher");
                    subCareers.Add("Dancer");
                    subCareers.Add("DJ");
                    subCareers.Add("Lighting technician");
                    subCareers.Add("Music promotions manager");
                    subCareers.Add("Pop musician");
                    subCareers.Add("Prop maker");
                    subCareers.Add("Radio broadcast assistant");
                    subCareers.Add("Roadie");
                    subCareers.Add("Stage manager");
                    subCareers.Add("Stagehand");
                    subCareers.Add("Studio sound engineer");
                    subCareers.Add("Stunt performer");
                    subCareers.Add("TV or film assistant director");
                    subCareers.Add("TV or film camera operator ");
                    subCareers.Add("TV or film director");
                    subCareers.Add("TV or film producer");
                    subCareers.Add("TV or film production assistant");
                    subCareers.Add("TV or film sound technician");
                    subCareers.Add("TV presenter");
                    subCareers.Add("TV production runner");
                    subCareers.Add("Wardrobe assistant");

                    break;
                case 20:


                    subCareers.Add("Advertising account executive");
                    subCareers.Add("Advertising account planner");
                    subCareers.Add("Advertising copywriter");
                    subCareers.Add("Bookbinder or print finisher");
                    subCareers.Add("Commissioning editor");
                    subCareers.Add("Conference and exhibition organiser");
                    subCareers.Add("Copy editor");
                    subCareers.Add("Events manager");
                    subCareers.Add("Image consultant");
                    subCareers.Add("Indexer");
                    subCareers.Add("Literary agent");
                    subCareers.Add("Machine printer");
                    subCareers.Add("Magazine journalist");
                    subCareers.Add("Market research data analyst");
                    subCareers.Add("Market research executive");
                    subCareers.Add("Market research interviewer");
                    subCareers.Add("Marketing manager");
                    subCareers.Add("Media researcher");
                    subCareers.Add("Medical sales representative");
                    subCareers.Add("Newspaper journalist");
                    subCareers.Add("Newspaper or magazine editor");
                    subCareers.Add("Pre - press operator");
                    subCareers.Add("Printing administrator");
                    subCareers.Add("Public relations officer");
                    subCareers.Add("Reprographic assistant");
                    subCareers.Add("Sub - editor");
                    subCareers.Add("Technical author");
                    subCareers.Add("Video editor");
                    subCareers.Add("Writer");

                    break;
                case 21:

                    subCareers.Add("Antique dealer");
                    subCareers.Add("Bookmaker");
                    subCareers.Add("Bookseller");
                    subCareers.Add("Call centre operator ");
                    subCareers.Add("Car salesperson");
                    subCareers.Add("Checkout operator");
                    subCareers.Add("Cinema or theatre attendant");
                    subCareers.Add("Customer service assistant");
                    subCareers.Add("Estate agent");
                    subCareers.Add("Florist");
                    subCareers.Add("Market trader");
                    subCareers.Add("Pet shop assistant");
                    subCareers.Add("Petrol service sales assistant");
                    subCareers.Add("Post Office customer service assistant");
                    subCareers.Add("Retail buyer");
                    subCareers.Add("Retail jeweller");
                    subCareers.Add("Retail manager");
                    subCareers.Add("Sales assistant");
                    subCareers.Add("Sales manager");
                    subCareers.Add("Sales representative");
                    subCareers.Add("Shoe repairer");
                    subCareers.Add("Shopkeeper");
                    subCareers.Add("Train conductor");
                    subCareers.Add("Train station staff");
                    subCareers.Add("Visual merchandiser");
                    subCareers.Add("Wine merchant");
                    break;
                case 22:
                    subCareers.Add("Astronaut");
                    subCareers.Add("Astronomer");
                    subCareers.Add("Biochemist");
                    subCareers.Add("Biologist");
                    subCareers.Add("Biomedical scientist");
                    subCareers.Add("Biotechnologist");
                    subCareers.Add("Botanist");
                    subCareers.Add("Cartographer");
                    subCareers.Add("Chemical plant process operator");
                    subCareers.Add("Chemist");
                    subCareers.Add("Data analyst-statistician");
                    subCareers.Add("Food scientist or food technologist");
                    subCareers.Add("Forensic scientist");
                    subCareers.Add("Geneticist");
                    subCareers.Add("Laboratory technician");
                    subCareers.Add("Marine biologist");
                    subCareers.Add("Microbiologist");
                    subCareers.Add("Pharmacologist");
                    subCareers.Add("Physicist");
                    subCareers.Add("Zoologist");

                    break;
                case 23:

                    subCareers.Add("Army officer");
                    subCareers.Add("Army soldier");
                    subCareers.Add("Assistant immigration officer");
                    subCareers.Add("Bodyguard");
                    subCareers.Add("Border Force officer or assistant officer");
                    subCareers.Add("CCTV operator");
                    subCareers.Add("Civil enforcement officer");
                    subCareers.Add("Coastguard");
                    subCareers.Add("Community warden");
                    subCareers.Add("Criminal intelligence analyst");
                    subCareers.Add("Customs officer");
                    subCareers.Add("Firefighter");
                    subCareers.Add("Immigration officer");
                    subCareers.Add("Merchant navy deck officer");
                    subCareers.Add("Merchant navy rating");
                    subCareers.Add("Police officer");
                    subCareers.Add("Prison governor");
                    subCareers.Add("Prison officer");
                    subCareers.Add("Private investigator");
                    subCareers.Add("RAF airman or airwoman");
                    subCareers.Add("RAF officer");
                    subCareers.Add("Royal Marines commando");
                    subCareers.Add("Royal Marines officer");
                    subCareers.Add("Royal Navy officer");
                    subCareers.Add("Royal Navy rating");
                    subCareers.Add("Scenes of crime officer");
                    subCareers.Add("Security officer");
                    subCareers.Add("Store detective");
                    break;
                case 24:
                    subCareers.Add("Counselling psychologist");
                    subCareers.Add("Educational psychologist");
                    subCareers.Add("Health psychologist");
                    subCareers.Add("Occupational psychologist");
                    subCareers.Add("Psychotherapist");
                    subCareers.Add("Sport and exercise psychologist");
                    break;
                case 25:

                    subCareers.Add("Care home practitioner");
                    subCareers.Add("Care service manager");
                    subCareers.Add("Care support worker");
                    subCareers.Add("Childminder");
                    subCareers.Add("Community development worker");
                    subCareers.Add("Counsellor");
                    subCareers.Add("Crematorium technician");
                    subCareers.Add("Early years practitioner");
                    subCareers.Add("Embalmer");
                    subCareers.Add("Funeral director");
                    subCareers.Add("Housing officer");
                    subCareers.Add("Nanny");
                    subCareers.Add("Playworker");
                    subCareers.Add("Social worker");
                    subCareers.Add("Volunteer organiser");
                    subCareers.Add("Welfare rights officer");
                    break;
                case 26:


                    subCareers.Add("Fitness instructor");
                    subCareers.Add("Footballer");
                    subCareers.Add("Leisure centre assistant");
                    subCareers.Add("Leisure centre manager");
                    subCareers.Add("Lifeguard");
                    subCareers.Add("Outdoor activities instructor");
                    subCareers.Add("Personal trainer");
                    subCareers.Add("Sport and exercise scientist");
                    subCareers.Add("Sports coach");
                    subCareers.Add("Sports development officer");
                    subCareers.Add("Sports professional");
                    subCareers.Add("Sports therapist");
                    subCareers.Add("Swimming teacher or coach");
                    subCareers.Add("Yoga teacher");
                    break;

                case 27:

                    subCareers.Add("Air traffic controller");
                    subCareers.Add("Airline pilot");
                    subCareers.Add("Airport baggage handler");
                    subCareers.Add("Bus or coach driver");
                    subCareers.Add("Chauffeur");
                    subCareers.Add("Courier");
                    subCareers.Add("Delivery van driver");
                    subCareers.Add("Driving examiner");
                    subCareers.Add("Driving instructor");
                    subCareers.Add("Dynamic positioning operator ");
                    subCareers.Add("Flight dispatcher");
                    subCareers.Add("Forklift truck operator ");
                    subCareers.Add("Freight forwarder");
                    subCareers.Add("Helicopter pilot");
                    subCareers.Add("Large goods vehicle driver");
                    subCareers.Add("Postal delivery worker");
                    subCareers.Add("Removals worker");
                    subCareers.Add("Road transport manager");
                    subCareers.Add("Signalling technician");
                    subCareers.Add("Taxi driver");
                    subCareers.Add("Train driver");
                    subCareers.Add("Warehouse operative");
                    break;
            }

            return subCareers;

        }


    }
}