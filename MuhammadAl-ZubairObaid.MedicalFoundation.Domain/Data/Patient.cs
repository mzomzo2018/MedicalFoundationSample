using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.Domain
{
    public class Patient : MFEntity
    {
        public PersonName FullName { get; set; }
        public EmailAddress Email {  get; set; }
        public PersonAddress Address {  get; set; }
        public DateOnly DateOfBirth {  get; set; }
        public Gender Gender {  get; set; }
        public PhoneNumber PhoneNumber {  get; set; }
        public ICollection<PatientVisit> Visits { get; set; }
    }
}
