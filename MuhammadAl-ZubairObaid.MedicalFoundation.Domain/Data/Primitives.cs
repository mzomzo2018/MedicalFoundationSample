using System.ComponentModel.DataAnnotations;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives
{
    /// <summary>
    /// Medical foundation billing status
    /// </summary>
    public enum BillingStatus
    {
        /// <summary>
        /// The billing price has been completely fufilled
        /// </summary>
        Paid,
        /// <summary>
        /// The billing price has been partially fufilled
        /// </summary>
        PartiallyPaid,
        /// <summary>
        /// The billing price has been not been fufilled
        /// </summary>
        NotPaid
    }
    /// <summary>
    /// Medical foundation clinician specialization
    /// </summary>
    public enum ClinicianSpecialization
    {
        /// <summary>
        /// The clinician is dentist
        /// </summary>
        Dentist,
        /// <summary>
        /// The clinician is gyncologist
        /// </summary>
        Gyncologist,
        /// <summary>
        /// The clinician is pediatritian
        /// </summary>
        Pediatritian
    }
    /// <summary>
    /// Person gender
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// The person is male
        /// </summary>
        Male,
        /// <summary>
        /// The person is female
        /// </summary>
        Female
    }
    /// <summary>
    /// Medical foundation appointment status
    /// </summary>
    public enum AppointmentStatus
    {
        /// <summary>
        /// The appointment has been canceled
        /// </summary>
        Canceled,
        /// <summary>
        /// The appointment has been completed
        /// </summary>
        Done,
        /// <summary>
        /// The appointment is not completed
        /// </summary>
        Awaiting
    }
    /// <summary>
    /// Country where person or facility exists or planned to exist in
    /// </summary>
    public enum Country
    {
        /// <summary>
        /// The specified country is Syria
        /// </summary>
        Syria,
        /// <summary>
        /// The specified country is Turkey
        /// </summary>
        Turkey
    }
    /// <summary>
    /// Operation billing
    /// </summary>
    public class Billing : MFEntity
    {
        /// <summary>
        /// Billing price amount
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// Billing creation date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Billing fufillment state
        /// </summary>
        public BillingStatus Status { get; set; }
    }
    /// <summary>
    /// Service provider working shift
    /// </summary>
    public class WorkingShift : MFEntity
    {
        /// <summary>
        /// Working shift start time
        /// </summary>
        public TimeOnly StartTime { get; set; }
        /// <summary>
        /// Working shift start day
        /// </summary>
        public DayOfWeek StartDay { get; set; }
        /// <summary>
        /// Working shift end time
        /// </summary>
        public TimeOnly EndTime { get; set; }
        /// <summary>
        /// Working shift end day
        /// </summary>
        public DayOfWeek EndDay { get; set; }
    }
    /// <summary>
    /// Person name divided into parts for simplified querying operations
    /// </summary>
    public class PersonName : MFEntity
    {
        /// <summary>
        /// Person first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Person middle name (Father name)
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Person last name (Family name)
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Converting <see cref="PersonName"/> into ({FirstName} {MiddleName} {LastName})
        /// </summary>
        /// <returns>Full name as string</returns>
        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName}";
        }
        /// <summary>
        /// Parses full person name ({FirstName} {MiddleName} {LastName}) and converts it to <see cref="PersonName"/> object
        /// </summary>
        /// <param name="fullName">Full person name</param>
        /// <returns><see cref="PersonName"/> object</returns>
        public static PersonName Parse(string fullName)
        {
            string[] names = fullName.Split(' ');
            PersonName personName = new PersonName();
            personName.FirstName = names[0];
            if (names.Length > 1)
                personName.LastName = names[2];
            if (names.Length > 2)
                personName.MiddleName = names[1];
            return personName;
        }
    }
    /// <summary>
    /// Person/Facility phone number
    /// </summary>
    public class PhoneNumber : MFEntity
    {
        /// <summary>
        /// Phone number regional code. Must be valid.
        /// </summary>
        [MaxLength(3)]
        public string RegionalCode { get; set; }
        /// <summary>
        /// Base phone number.
        /// </summary>
        [MaxLength(11)]
        public string Number { get; set; }
        /// <summary>
        /// Converts <see cref="PhoneNumber"/> into (+{RegionalCode} {Number})
        /// </summary>
        /// <returns>Formatted phone number string</returns>
        public override string ToString()
        {
            string number = "";
            if (Number.Length == 9)
                for (int i = 0; i < Number.Length; i += 3)
                    number += Number.Substring(i, 3);
            else if (Number.Length == 10)
            {
                for (int i = 0; i < 6; i += 3)
                    number += Number.Substring(i, 3);
                for (int i = 6; i < 10; i += 2)
                    number += Number.Substring(i, 2);
            }
            return $"+{RegionalCode} {number}";
        }
    }
    /// <summary>
    /// Person/Facility email address
    /// </summary>
    public class EmailAddress : MFEntity
    {
        /// <summary>
        /// Email identifier
        /// </summary>
        public string Identifier { get; set; }
        /// <summary>
        /// Email domain (e.g gmail.com)
        /// </summary>
        public string Domain { get; set; }
        /// <summary>
        /// Converts <see cref="EmailAddress"/> into ({Identifier}@{Domain})
        /// </summary>
        /// <returns>Formatted email address string</returns>
        public override string ToString()
        {
            return $"{Identifier}@{Domain}";
        }
    }
    /// <summary>
    /// Person address
    /// </summary>
    public class PersonAddress : MFEntity
    {
        /// <summary>
        /// Address country
        /// </summary>
        public Country Country { get; set; }
        /// <summary>
        /// Address city
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Address street number
        /// </summary>
        public string StreetNumber { get; set; }
        /// <summary>
        /// Address building
        /// </summary>
        public string Building { get; set; }
        /// <summary>
        /// Converts <see cref="PersonAddress"/> into ({Building}, {StreetNumber}, {City}, {Country})
        /// </summary>
        /// <returns>Formatted address string</returns>
        public override string ToString()
        {
            return $"{Building}, {StreetNumber}, {City}, {Enum.GetName(Country)}";
        }
    }
}
