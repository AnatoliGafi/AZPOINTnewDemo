using CourtWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CourtWebAPI.Controllers
{
    [Authorize]
    public class PetitionController : ApiController
    {

        public IEnumerable<Petition> Get()
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                return entities.Petitions.ToList();
            }
        }
        public IEnumerable<Petition> GetPetitionsByZip(string zip)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                return entities.Petitions.Where(p => p.PetitionerZip.Equals(zip)).ToList();
            }
        }
        [HttpGet]
        [System.Web.Http.Route("api/Petition/GetUser/")]
        public ApplicationUser GetUser()
        {
            return new ApplicationUser();
        }
        public Petition Get(int Id)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                return entities.Petitions.FirstOrDefault(p => p.PetitionID.Equals(Id));
            }
        }
        [HttpGet]
        [System.Web.Http.Route("api/Petition/GetPersonByID/")]
        public Person GetPersonByID(int Id)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                return entities.People.FirstOrDefault(p => p.ID == Id);
            }
        }
        //=====================================================================================PERSON
        [HttpGet]
        [System.Web.Http.Route("api/Petition/GetNewPerson/")]
        public Person GetNewPerson()
        {
            Person person = new Person();
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                person.IssModDateTime = DateTime.Now;
                entities.People.Add(person);
                entities.SaveChanges();
                person.PersonUID = person.ID;
                return person;

            }
        }

        [HttpPost]
        [System.Web.Http.Route("api/Petition/UpdatePerson/")]
        public Person UpdatePerson(Person person)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                person.IssModDateTime = DateTime.Now;
                entities.People.Attach(person);
                entities.Entry(person).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                return person;
            }
        }
        [HttpGet]
        [System.Web.Http.Route("api/Petition/DeletePersonByID/")]
        public void DeletePersonByID(int Id)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                Person person = entities.People.FirstOrDefault(p => p.ID == Id);
                entities.People.Remove(person);
                entities.SaveChanges();
            }
        }
        //==========================================================================PETITION
        [HttpGet]
        [System.Web.Http.Route("api/Petition/GetNewPetition/")]
        public Petition GetNewPetition()
        {
            Petition petition = new Petition();
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                
                try
                {
                    petition.IssModDateTime = DateTime.Now;
                    entities.Petitions.Add(petition);
                    entities.SaveChanges();

                    return petition;
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }
                    }
                    throw;
                }

            }
        }
        [HttpGet]
        [System.Web.Http.Route("api/Petition/GetPetitionByUser/")]
        public List<Petition> GetPetitionByUser(string username)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                return entities.Petitions.Where(p => p.IssModUserID == username).ToList();
            }
        }
        [HttpGet]
        [System.Web.Http.Route("api/Petition/GetPetitionsByZIP/")]
        public List<Petition> GetPetitionsByZIP(string zip)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                return entities.Petitions.Where(p => p.PetitionerZip == zip && p.PetitionStatus== "Submitted").ToList();
            }
        }
 
        [HttpPost]
        [System.Web.Http.Route("api/Petition/UpdatePetition/")]
        public Petition UpdatePetition(Petition petition)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                    petition.IssModDateTime = DateTime.Now;
                    entities.Petitions.Attach(petition);
                    entities.Entry(petition).State = System.Data.Entity.EntityState.Modified;
                    entities.SaveChanges();
                    return petition;
            }
        }
        //========================================================================ADDRESS
        [HttpGet]
        [System.Web.Http.Route("api/Petition/GetNewAddress/")]
        public Address GetNewAddress()
        {
            Address adr = new Address();
            adr.Country = "US";
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                adr.IssModDateTime = DateTime.Now;
                entities.Addresses.Add(adr);
                entities.SaveChanges();
                adr.AddressUID = adr.ID;
                return adr;
            }
        }
        [HttpGet]
        [System.Web.Http.Route("api/Petition/GetAddressByID")]
        public Address GetAddressByID(int Id)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                return entities.Addresses.FirstOrDefault(p => p.AddressUID == Id);
            }
        }

        [HttpPost]
        [System.Web.Http.Route("api/Petition/UpdateAddress/")]
        public Address UpdateAddress(Address address)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                address.IssModDateTime = DateTime.Now;
                entities.Addresses.Attach(address);
                entities.Entry(address).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                return address;
            }
        }

        [HttpGet]
        [System.Web.Http.Route("api/Petition/DeleteAddressByID")]
        public string DeleteAddressByID(int Id)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                Address address = entities.Addresses.FirstOrDefault(p => p.ID == Id);
                entities.Addresses.Remove(address);
                entities.SaveChanges();
                return "success";
            }
        }
        //====================================================== Incident
        [HttpGet]
        [System.Web.Http.Route("api/Petition/GetNewIncident/")]
        public Incident GetNewIncident()
        {
            Incident incid = new Incident();

            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                incid.IssModDate = DateTime.Now;
                entities.Incidents.Add(incid);
                entities.SaveChanges();
                incid.IncidentUID = incid.ID;
                return incid;
            }
        }
        [HttpGet]
        [System.Web.Http.Route("api/Petition/GetIncidentByID")]
        public Incident GetIncidentByID(int Id)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                return entities.Incidents.FirstOrDefault(p => p.IncidentUID == Id);
            }
        }

        [HttpPost]
        [System.Web.Http.Route("api/Petition/UpdateIncident/")]
        public Incident UpdateIncident(Incident incident)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                incident.IssModDate = DateTime.Now;
                entities.Incidents.Attach(incident);
                entities.Entry(incident).State = System.Data.Entity.EntityState.Modified;
                entities.SaveChanges();
                return incident;
            }
        }

        [HttpGet]
        [System.Web.Http.Route("api/Petition/DeleteIncidentByID")]
        public string DeleteIncidentByID(int Id)
        {
            using (ServiceDBEntities entities = new ServiceDBEntities())
            {
                Incident incident = entities.Incidents.FirstOrDefault(p => p.ID == Id);
                entities.Incidents.Remove(incident);
                entities.SaveChanges();
                return "success";
            }
        }









    }
}












