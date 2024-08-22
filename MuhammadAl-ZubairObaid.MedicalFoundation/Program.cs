using MuhammadAl_ZubairObaid.MedicalFoundation.Contexts;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives;

public static class Program
{
    static async Task Main(string[] args)
    {
        // Creating instance of Clinician, Patient, PatientVisit and Billing class then filling data
        Clinician clinician = new Clinician()
        {
            DateOfBirth = DateOnly.Parse("1/1/1989"),
            Email = new MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives.EmailAddress() { Identifier = "ahmed1989", Domain = "gmail.com" },
            FullName = new MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives.PersonName() { FirstName = "Ahmed", MiddleName = "Khaled", LastName = "Samra" },
            Gender = MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives.Gender.Male,
            PhoneNumber = new MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives.PhoneNumber() { RegionalCode = "90", Number = "5233243242" },
            Address = new MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives.PersonAddress() { Country = MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives.Country.Syria, Building = "Al-Khalil 1121", City = "Aleppo", StreetNumber = "Bestan El-zahra"}
        };
        Billing billing = new Billing()
        {
            Status = BillingStatus.NotPaid,
            Amount = 200,
            Date = DateTime.Now
        };
        ClinicAppointment clinicAppointment = new ClinicAppointment()
        {
            Date = DateTime.Now,
            Status = AppointmentStatus.Awaiting
        };
        PatientVisit patientVisit = new PatientVisit()
        {
            Appointment = clinicAppointment,
            Clinician = clinician
        };
        Patient patient = new Patient()
        {
            DateOfBirth = DateOnly.Parse("3/2/1991"),
            Email = new MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives.EmailAddress() { Identifier = "khalil1231", Domain = "gmail.com" },
            FullName = new MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives.PersonName() { FirstName = "Khalil", MiddleName = "Ramzy", LastName = "Doghaem" },
            Gender = MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives.Gender.Male,
            PhoneNumber = new MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives.PhoneNumber() { RegionalCode = "963", Number = "9433232121" },
            Address = new MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives.PersonAddress() { Country = MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives.Country.Syria, Building = "Al-Abrash 3241", City = "Aleppo", StreetNumber = "Hamdaniah" },
            Visits = [patientVisit]
        };
        await MedicalFoundationDBContext.Context.Add(clinician);
        await MedicalFoundationDBContext.Context.Add(billing);
        await MedicalFoundationDBContext.Context.Add(clinicAppointment);
        await MedicalFoundationDBContext.Context.Add(patientVisit);
        await MedicalFoundationDBContext.Context.Add(patient);
    }
}
