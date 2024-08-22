namespace MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives
{
    public enum BillingStatus
    {
        Paid,
        PartiallyPaid,
        NotPaid
    }
    public enum ClinicianSpecialization
    {
        Dentist,
        Gyncologist,
        Pediatritian
    }
    public enum Gender
    {
        Male,
        Female
    }
    public enum AppointmentStatus
    {
        Canceled,
        Done,
        Awaiting
    }
    public enum Country
    {
        Syria,
        Turkey
    }
    public class Billing : MFEntity
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public BillingStatus Status { get; set; }
    }
    public class WorkingShift : MFEntity
    {
        public TimeOnly StartTime { get; set; }
        public DayOfWeek StartDay { get; set; }
        public TimeOnly EndTime { get; set; }
        public DayOfWeek EndDay { get; set; }
    }
    public class PersonName : MFEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {MiddleName} {LastName}";
        }
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
    public class PhoneNumber : MFEntity
    {
        public string RegionalCode { get; set; }
        public string Number { get; set; }
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
    public class EmailAddress : MFEntity
    {
        public string Identifier { get; set; }
        public string Domain { get; set; }
        public override string ToString()
        {
            return $"{Identifier}@{Domain}";
        }
    }
    public class PersonAddress : MFEntity
    {
        public Country Country { get; set; }
        public string City { get; set; }
        public string StreetNumber { get; set; }
        public string Building { get; set; }
    }
}
