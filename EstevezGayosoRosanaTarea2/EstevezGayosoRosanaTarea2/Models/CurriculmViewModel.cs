



namespace EstevezGayosoRosanaTarea2.Models
{
    //Creo clase modelo que contiene todas las clases con datos necesarios para mi curriculum
    public class CurriculmViewModel

    {
        //clase datos personales
        public class PersonalInformation
        {
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
        //clase perfil profesional

        //inicializo aqui listas con los datos de cada clase
        //lista experiencia laboral
        public List<Job> Jobs = new List<Job>
        {
                new Job{ CompanyName="Royal Mail",Position="Postperson",StartDate= new DateTime(2019,1,3),EndDate= null,JobDescription="Sorting and setting up mail and parcels ready for delivery.Dealing with sensible pieces of information ,attending all due diligence and confidentiality procedures.Assisting and checking on costumers on a regular basis as part of the community.", City="London"},
                new Job{ CompanyName="Wilkes",Position="Childminder",StartDate= new DateTime(2010,10,1),EndDate= new DateTime(2018,12,2),JobDescription="Coordinated everyday activities, supervised children while parents away or at work.Created a fun, secure, inspiring and comfortable environment. Asisting  them while on holidays.",City="London"},
                new Job{ CompanyName="Escola Infantil O Xardin",Position="Nursery-School Assistant Teacher",StartDate= new DateTime(2007,1,1),EndDate= new DateTime(2010,8,2),JobDescription="Managed classroom activities and planned and developed daily tasks according individual. Monitored children in outdoor activities and during bus transportation.",City="Vigo"},
                new Job{ CompanyName="SOS Children Villages Spain (NGO)",Position="Social Counselor",StartDate= new DateTime(2006,1,1),EndDate= new DateTime(2006,12,2),JobDescription="Created and coordinated workshops in young offenders institutions with 12 to 16y teenagers.Provided academic and psychological support.",City="Vigo"},
             };
        //lista educacion
        public List<Education> Educations = new List<Education>
        {
                new Education{SchoolName="Montecastelo",Degree="BTEC Level 3 equivalent Web-Based App Developer", DegreeDate= null,City="Vigo"},
                new Education{SchoolName="Colegio San Jose ",Degree="BTEC Level 3 equivalent Social Intregation", DegreeDate= new DateTime(2006,6,1),City="Vigo"}
            };
        //lista informacion personal
        public List<PersonalInformation >Personal = new List<PersonalInformation>
        { 
            new PersonalInformation{Name="Rosana Estevez", Address="E11 4BQ - London",TelephoneNumber="+447733631969", Email="restevezgayoso@outlook.com"}
        };





    }


}

