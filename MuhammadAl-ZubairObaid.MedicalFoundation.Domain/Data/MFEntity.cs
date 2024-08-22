namespace MuhammadAl_ZubairObaid.MedicalFoundation.Domain
{
    public abstract class MFEntity
    {
        public Guid ID { get; set; } = Guid.NewGuid();
    }
}
