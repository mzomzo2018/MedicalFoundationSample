using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.Domain
{
    public class ClinicAppointment : MFEntity
    {
        AppointmentStatus status;
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
        public DateTime Date { get; set; }
        public Billing Billing { get; set; }
    }
}
