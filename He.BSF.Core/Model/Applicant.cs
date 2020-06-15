
using He.BSF.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace He.BSF.Core.Model
{
    public class Applicant : Entity
    {
        /// <summary>
        /// Applicant Identifier
        /// </summary>
        /// <example>5fe3fc2a-cbac-4df0-8031-fdca0f682989</example>
        public string ApplicantId => Id;
        /// <summary>
        /// Applicant Type
        /// </summary>
        /// <example>Applicant</example>
        public string Type { get; set; }
        public string FullName { get; set; }
        public string OrganisationName { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public string ApplicantBased { get; set; }
        public Address Address { get; set; }
        /// <summary>
        /// Applicant Role in connection to the Property
        /// </summary>
        /// <example>leaseHolder</example>
        public string ApplicantRole { get; set; }
        /// <summary>
        /// Applicant Registered in Social Housing Provider
        /// </summary>
        /// <example>false</example>
        public Boolean SocialHousingRegisteredProvider { get; set; }
        /// <summary>
        /// Applicant Notified
        /// </summary>
        /// <example>false</example>
        public Boolean ResponsibilityEntityNotified { get; set; }
    }
}
