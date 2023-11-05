namespace EstevezGayosoRosanaTarea3.Models
{
    //Creo clase modelo que contiene todas las clases con datos necesarios para mi curriculum
    public class CurriculmViewModel

    {
        //inicializo aqui listas con los datos de cada clase

        //lista experiencia laboral
        public List<Job> Jobs = new List<Job>
        {
                new Job{ CompanyName="Royal Mail",Position="Postperson",StartDate= new DateTime(2019,1,3),EndDate= null,JobDescription="Sorting and setting up mail and parcels ready for delivery. Dealing with sensible pieces of information, attending all due diligence and confidentiality procedures. Assisting and checking on costumers on a regular basis as part of the community.", City="London"},
                new Job{ CompanyName="Wilkes",Position="Childminder",StartDate= new DateTime(2010,10,1),EndDate= new DateTime(2018,12,2),JobDescription="Coordinated everyday activities, supervised children while parents away or at work. Created a fun, secure, inspiring and comfortable environment. Asisting  them while on holidays.",City="London"},
                new Job{ CompanyName="Escola Infantil O Xardin",Position="Nursery-School Assistant Teacher",StartDate= new DateTime(2007,1,1),EndDate= new DateTime(2010,8,2),JobDescription="Managed classroom activities and planned and developed daily tasks according individual. Monitored children in outdoor activities and during bus transportation.",City="Vigo"},
                new Job{ CompanyName="SOS Children Villages Spain (NGO)",Position="Social Counselor",StartDate= new DateTime(2006,1,1),EndDate= new DateTime(2006,12,2),JobDescription="Created and coordinated workshops in young offenders institutions with 12 to 16y teenagers. Provided academic and psychological support.",City="Vigo"},
             };
        //lista educacion
        public List<Education> Educations = new List<Education>
        {
                new Education{SchoolName="Colegio Montecastelo",Degree="BTEC Level 3 equivalent Web-Based App Developer", DegreeDate= null,City="Vigo"},
                new Education{SchoolName="Colegio San Jose ",Degree="BTEC Level 3 equivalent Social Intregation", DegreeDate= new DateTime(2006,6,1),City="Vigo"}
            };
        //lista lenguajes
        public List<Languages> Languages = new List<Languages>
        {
            new Languages{LanguageName="Spanish",LanguageLevel="Native"},
            new Languages{LanguageName="Galician", LanguageLevel="Native"},
            new Languages{LanguageName="English",LanguageLevel="Proficient"},
            new Languages{LanguageName="Portuguese",LanguageLevel="Elementary"}

        };


        //Objeto personalinformation

        public PersonalInformation personalInformation = new PersonalInformation { RutaImage = "/img/fototarea.jpg", Name = "Rosana Estevez", Address = "E11 4BQ - London", TelephoneNumber = "+447733631969", Email = "restevezgayoso@outlook.com" };

        //lista de strings para el perfil profesional

        public List<string> profesionalProfile = new List<string>()
        {
            "Versatile and multi-skilled individual with a vast working experience. ","Proven ability to assume responsabilities, time management, deliver a polite and correct approach to people of any background. ","Serious,punctual,efficient and meticulous are the base of my work approach. ","Friendly and cooperative as a member of a team. ","Work under pressure."
        };
        //lista de string para intereses
        public List<string> interests = new List<string>()
        {
            "Travel","Reading","Outdoors","Gaming"

        };
        //lista de logos para intereses
        public List<string> logos = new List<string>()
        {
            "fa-solid fa-earth-asia","fa-solid fa-book-open","fa-solid fa-person-hiking","fa-solid fa-gamepad"

        };



    }
    //mis clases:
    //clase datos personales
    public class PersonalInformation

    {
        public string RutaImage { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }


    }
    //clase experiencia laboral
    public class Job
    {
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string City { get; set; }
        public string JobDescription { get; set; }


    }
    //clase Educacion
    public class Education
    {
        public string SchoolName { get; set; }
        public string Degree { get; set; }
        public DateTime? DegreeDate { get; set; }
        public string City { get; set; }

    }
    //clase idiomas
    public class Languages
    {
        public string LanguageName { get; set; }
        public string LanguageLevel { get; set; }
    }


}

