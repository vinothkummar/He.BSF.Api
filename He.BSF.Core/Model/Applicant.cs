
using He.BSF.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace He.BSF.Core.Model
{
    public class Applicant : Entity
    {

        public string ApplicantId { get; set; }
        public string Type { get; set; }
        public string FullName { get; set; }
        public string OrganisationName { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string ApplicantBased { get; set; }
        public Address Address { get; set; }
        public string ApplicantRole { get; set; }
        public Boolean SocialHousingRegisteredProvider { get; set; }
        public Boolean ResponsibilityEntityNotified { get; set; }
    }
}
