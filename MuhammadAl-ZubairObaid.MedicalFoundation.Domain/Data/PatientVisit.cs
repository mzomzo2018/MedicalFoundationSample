using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.Domain
{
    public class PatientVisit : MFEntity
    {
        public Clinician Clinician { get; set; }
        public ClinicAppointment Appointment { get; set; }
    }
}
