using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.Domain
{
    /// <summary>
    /// Medical foundation patient
    /// </summary>
    public class Patient : MFEntity
    {
        /// <summary>
        /// Patient name
        /// </summary>
        public PersonName Name { get; set; }
        /// <summary>
        /// Patient email address
        /// </summary>
        public EmailAddress Email {  get; set; }
        /// <summary>
        /// Patient home address
        /// </summary>
        public PersonAddress Address {  get; set; }
        /// <summary>
        /// Patient birth date
        /// </summary>
        public DateOnly DateOfBirth {  get; set; }
        /// <summary>
        /// Patient gender
        /// </summary>
        public Gender Gender {  get; set; }
        /// <summary>
        /// Patient phone number
        /// </summary>
        public PhoneNumber PhoneNumber {  get; set; }
        /// <summary>
        /// Patient clinic appointments
        /// </summary>
        public ICollection<ClinicAppointment> Appointments { get; set; }
    }
}
