using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.Domain
{
    public class Clinician : MFEntity
    {
        public PersonName FullName { get; set; }
        public EmailAddress Email {  get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public ClinicianSpecialization Specialization { get; set; }
        public WorkingShift WorkingShift { get; set; }
        public PersonAddress Address { get; set; }
    }
}
