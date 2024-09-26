using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.Domain
{
    /// <summary>
    /// Medical Foundation service provider
    /// </summary>
    public class Clinician : MFEntity
    {
        /// <summary>
        /// Clinican name
        /// </summary>
        public PersonName Name { get; set; }
        /// <summary>
        /// Clinicaian email address
        /// </summary>
        public EmailAddress Email {  get; set; }
        /// <summary>
        /// Clinician birth date
        /// </summary>
        public DateOnly DateOfBirth { get; set; }
        /// <summary>
        /// Clinician gender
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Clinician work phone number
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; }
        /// <summary>
        /// Clinician specialization
        /// </summary>
        public ClinicianSpecialization Specialization { get; set; }
        /// <summary>
        /// Clinician working shift
        /// </summary>
        public WorkingShift WorkingShift { get; set; }
        /// <summary>
        /// Clinician home address
        /// </summary>
        public PersonAddress Address { get; set; }
    }
}
