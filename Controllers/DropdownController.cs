using CourtWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CourtWebAPI.Controllers
{
    public class DropdownController : ApiController
    {
        [HttpGet]
        [System.Web.Http.Route("api/Dropdown/GetSuffixes/")]
        public IEnumerable<dimSuffix> GetSuffixes()
        {
            using (ServiceDBEntities2 entities = new ServiceDBEntities2())
            {
                return entities.dimSuffixes.ToList();
            }

        }
        [HttpGet]
        [System.Web.Http.Route("api/Dropdown/GetGenders/")]
        public IEnumerable<dimGender> GetGenders()
        {
            using (ServiceDBEntities2 entities = new ServiceDBEntities2())
            {
                return entities.dimGenders.ToList();
            }

        }
        [HttpGet]
        [System.Web.Http.Route("api/Dropdown/GetRaceData/")]
        public IEnumerable<dimEthnicity> GetRaceData()
        {
            using (ServiceDBEntities2 entities = new ServiceDBEntities2())
            {
                return entities.dimEthnicities.ToList();
            }

        }
        [HttpGet]
        [System.Web.Http.Route("api/Dropdown/GetEthnData/")]
        public IEnumerable<dimEthnicity> GetEthnData()
        {
            using (ServiceDBEntities2 entities = new ServiceDBEntities2())
            {
                return entities.dimEthnicities.ToList();
            }

        }
        [HttpGet]
        [System.Web.Http.Route("api/Dropdown/GetEyeData/")]
        public IEnumerable<dimEyeColor> GetEyeData()
        {
            using (ServiceDBEntities2 entities = new ServiceDBEntities2())
            {
                return entities.dimEyeColors.ToList();
            }

        }
        [HttpGet]
        [System.Web.Http.Route("api/Dropdown/GetHairData/")]
        public IEnumerable<dimHairColor> GetHairData()
        {
            using (ServiceDBEntities2 entities = new ServiceDBEntities2())
            {
                return entities.dimHairColors.ToList();
            }

        }
    }
}
