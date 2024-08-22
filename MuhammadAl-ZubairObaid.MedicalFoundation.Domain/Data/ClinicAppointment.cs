using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.Domain
{
    public class ClinicAppointment : MFEntity
    {
        Billing billing;
        public AppointmentStatus Status { get; set; }
        public DateTime Date { get; set; }
        public Billing Billing
        {
            get => billing; set
            {
                // Billing must be after preserving appointment and before treatment
                if (Status == AppointmentStatus.Awaiting)
                    billing = value;
                else
                    billing = null;
            }
        }
    }
}
