using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.Domain
{
    /// <summary>
    /// DTO representation of <see cref="Clinician"/>
    /// </summary>
    public class ClinicianDto : MFEntity;
    /// <summary>
    /// Medical foundation clinic appointment
    /// </summary>
    public class ClinicAppointment : MFEntity
    {
        AppointmentStatus status;
        /// <summary>
        /// The state of the appointment
        /// </summary>
        public AppointmentStatus Status
        {
            get => status;
            set
            {
                // Billing must be after preserving appointment and before treatment
                if (Billing != null)
                    Status = AppointmentStatus.Done;
                else
                    Status = value;

            }
        }
        /// <summary>
        /// Appointment date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Charges regarding appointment
        /// </summary>
        public BillingDto Billing { get; set; }
        /// <summary>
        /// Appointment service provider
        /// </summary>
        public ClinicianDto Clinician { get; set; }
    }
}
