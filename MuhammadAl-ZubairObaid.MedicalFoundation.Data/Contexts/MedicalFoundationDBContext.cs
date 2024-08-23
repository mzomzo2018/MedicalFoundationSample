using Microsoft.EntityFrameworkCore;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives;
namespace MuhammadAl_ZubairObaid.MedicalFoundation.Contexts
{
    public class MedicalFoundationDBContext : DbContext
    {
        /// <summary>
        /// Singleton property to access <see cref="MedicalFoundationDBContext"/>
        /// </summary>
        public static MedicalFoundationDBContext Context { get; } = new MedicalFoundationDBContext();
        /// <summary>
        /// Database set of type <see cref="Patient"/>
        /// </summary>
        DbSet<Patient> Patients { get; set; }
        /// <summary>
        /// Database set of type <see cref="PatientVisit"/>
        /// </summary>
        DbSet<PatientVisit> PatientVisits { get; set; }
        /// <summary>
        /// Database set of type <see cref="Clinician"/>
        /// </summary>
        DbSet<Clinician> Clinicians { get; set; }
        /// <summary>
        /// Database set of type <see cref="ClinicAppointment"/>
        /// </summary>
        DbSet<ClinicAppointment> ClinicAppointments { get; set; }
        /// <summary>
        /// Database set of type <see cref="Billing"/>
        /// </summary>
        DbSet<Billing> Billings { get; set; }
        /// <summary>
        /// Adds <see cref="Clinician"/> object to the database
        /// </summary>
        /// <param name="clinician">Object of type <see cref="Clinician"/></param>
        /// <returns>Task representing the adding process</returns>
        public async Task Add(Clinician clinician)
        {
            // Querying for clinicians that matches the parameter object
            // To add required object, it must not exist in the database
            if (!await Clinicians.Where(queryingClinician => queryingClinician == clinician).AnyAsync())
            {
                // Adds the parameter object to the database, then applies underlying changes.
                await Clinicians.AddAsync(clinician);
                // All operations on required object are stored in memory until calling SaveChanges                 await SaveChangesAsync();
            }
            // If required object is found on the database, it will be automatically updated.
            else
                await Update(clinician);
        }
        /// <summary>
        /// Updates <see cref="Clinician"/> object on the database
        /// </summary>
        /// <param name="clinician">Object of type <see cref="Clinician"/></param>
        /// <returns>Task representing the updating process</returns>
        public async Task Update(Clinician clinician)
        {
            // Querying for clinicians that matches the parameter object
            // To update required object, it must exist in the database
            if (await Clinicians.Where(queryingClinician => queryingClinician == clinician).AnyAsync())
            {
                await Clinicians.AddAsync(clinician);
                // All operations on required object are stored in memory until calling SaveChanges                 await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be updated.");
        }
        /// <summary>
        /// Removes <see cref="Clinician"/> object from the database
        /// </summary>
        /// <param name="clinician">Object of type <see cref="Clinician"/></param>
        /// <returns>Task representing the removing process</returns>
        public async Task Remove(Clinician clinician)
        {
            // Querying for clinicians that matches the parameter object
            // To remove required object from the database, it must exist in the database.
            if (await Clinicians.Where(queryingClinician => queryingClinician == clinician).AnyAsync())
            {
                Clinicians.Remove(clinician);
                // All operations on required object are stored in memory until calling SaveChanges                 await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be deleted.");
        }
        /// <summary>
        /// Retreives <see cref="Clinician"/> object from the database
        /// </summary>
        /// <param name="clinicianID"><see cref="Clinician"/> <see cref="Guid"/></param>
        /// <returns>Task representing the retreiving process</returns>
        public async Task<Clinician?> GetClinician(Guid clinicianID)
        {
            // Querying for clinicians that matches the parameter object
            // To remove required object from the database, it must exist in the database; Otherwise the method will return value as null.
            var result = Clinicians.Where(queryingClinician => queryingClinician.ID == clinicianID);
            return await result.AnyAsync() ? await result.FirstOrDefaultAsync() : null;
        }
        /// <summary>
        /// Adds <see cref="Patient"/> object to the database
        /// </summary>
        /// <param name="patient">Object of type <see cref="Patient"/></param>
        /// <returns>Task representing the adding process</returns>
        public async Task Add(Patient patient)
        {
            // Querying for Patients that matches the parameter object
            // To add required object, it must not exist in the database
            if (!await Patients.Where(queryingPatient => queryingPatient == Patient).AnyAsync())
            {
                // Adds the parameter object to the database, then applies underlying changes.
                await Patients.AddAsync(Patient);
                // All operations on required object are stored in memory until calling SaveChanges
                await SaveChangesAsync();
            }
            // If required object is found on the database, it will be automatically updated.
            else
                await Update(Patient);
        }
        /// <summary>
        /// Updates <see cref="Patient"/> object on the database
        /// </summary>
        /// <param name="patient">Object of type <see cref="Patient"/></param>
        /// <returns>Task representing the updating process</returns>
        public async Task Update(Patient patient)
        {
            // Querying for Patients that matches the parameter object
            // To update required object, it must exist in the database
            if (await Patients.Where(queryingPatient => queryingPatient == Patient).AnyAsync())
            {
                await Patients.AddAsync(Patient);
                // All operations on required object are stored in memory until calling SaveChanges
                await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be updated.");
        }
        /// <summary>
        /// Removes <see cref="Patient"/> object from the database
        /// </summary>
        /// <param name="patient">Object of type <see cref="Patient"/></param>
        /// <returns>Task representing the removing process</returns>
        public async Task Remove(Patient patient)
        {
            // Querying for Patients that matches the parameter object
            // To remove required object from the database, it must exist in the database.
            if (await Patients.Where(queryingPatient => queryingPatient == patient).AnyAsync())
            {
                Patients.Remove(patient);
                // All operations on required object are stored in memory until calling SaveChanges
                await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be deleted.");
        }
        /// <summary>
        /// Retreives <see cref="Patient"/> object from the database
        /// </summary>
        /// <param name="patientID"><see cref="Patient"/> <see cref="Guid"/></param>
        /// <returns>Task representing the retreiving process</returns>
        public async Task<Patient?> GetPatient(Guid patientID)
        {
            // Querying for Patients that matches the parameter object
            // To remove required object from the database, it must exist in the database; Otherwise the method will return value as null.
            var result = Patients.Where(queryingPatient => queryingPatient.ID == patientID);
            return await result.AnyAsync() ? await result.FirstOrDefaultAsync() : null;
        }
        /// <summary>
        /// Adds <see cref="ClinicAppointment"/> object to the database
        /// </summary>
        /// <param name="clinicAppointment">Object of type <see cref="ClinicAppointment"/></param>
        /// <returns>Task representing the adding process</returns>
        public async Task Add(ClinicAppointment clinicAppointment)
        {
            // Querying for ClinicAppointments that matches the parameter object
            // To add required object, it must not exist in the database
            if (!await ClinicAppointments.Where(queryingClinicAppointment => queryingClinicAppointment == clinicAppointment).AnyAsync())
            {
                // Adds the parameter object to the database, then applies underlying changes.
                await ClinicAppointments.AddAsync(clinicAppointment);
                // All operations on required object are stored in memory until calling SaveChanges
                await SaveChangesAsync();
            }
            // If required object is found on the database, it will be automatically updated.
            else
                await Update(clinicAppointment);
        }
        /// <summary>
        /// Updates <see cref="ClinicAppointment"/> object on the database
        /// </summary>
        /// <param name="clinicAppointment">Object of type <see cref="ClinicAppointment"/></param>
        /// <returns>Task representing the updating process</returns>
        public async Task Update(ClinicAppointment clinicAppointment)
        {
            // Querying for ClinicAppointments that matches the parameter object
            // To update required object, it must exist in the database
            if (await ClinicAppointments.Where(queryingClinicAppointment => queryingClinicAppointment == clinicAppointment).AnyAsync())
            {
                await ClinicAppointments.AddAsync(clinicAppointment);
                // All operations on required object are stored in memory until calling SaveChanges
                await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be updated.");
        }
        /// <summary>
        /// Removes <see cref="ClinicAppointment"/> object from the database
        /// </summary>
        /// <param name="clinicAppointment">Object of type <see cref="ClinicAppointment"/></param>
        /// <returns>Task representing the removing process</returns>
        public async Task Remove(ClinicAppointment clinicAppointment)
        {
            // Querying for ClinicAppointments that matches the parameter object
            // To remove required object from the database, it must exist in the database.
            if (await ClinicAppointments.Where(queryingClinicAppointment => queryingClinicAppointment == clinicAppointment).AnyAsync())
            {
                ClinicAppointments.Remove(clinicAppointment);
                // All operations on required object are stored in memory until calling SaveChanges
                await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be deleted.");
        }
        /// <summary>
        /// Retreives <see cref="ClinicAppointment"/> object from the database
        /// </summary>
        /// <param name="clinicAppointmentID"><see cref="ClinicAppointment"/> <see cref="Guid"/></param>
        /// <returns>Task representing the retreiving process</returns>
        public async Task<ClinicAppointment?> GetClinicAppointment(Guid clinicAppointmentID)
        {
            // Querying for ClinicAppointments that matches the parameter object
            // To remove required object from the database, it must exist in the database; Otherwise the method will return value as null.
            var result = ClinicAppointments.Where(queryingClinicAppointment => queryingClinicAppointment.ID == clinicAppointmentID);
            return await result.AnyAsync() ? await result.FirstOrDefaultAsync() : null;
        }
        /// <summary>
        /// Adds <see cref="PatientVisit"/> object to the database
        /// </summary>
        /// <param name="patientVisit">Object of type <see cref="PatientVisit"/></param>
        /// <returns>Task representing the adding process</returns>
        public async Task Add(PatientVisit patientVisit)
        {
            // Querying for PatientVisits that matches the parameter object
            // To add required object, it must not exist in the database
            if (!await PatientVisits.Where(queryingPatientVisit => queryingPatientVisit == patientVisit).AnyAsync())
            {
                // Adds the parameter object to the database, then applies underlying changes.
                await PatientVisits.AddAsync(patientVisit);
                // All operations on required object are stored in memory until calling SaveChanges
                await SaveChangesAsync();
            }
            // If required object is found on the database, it will be automatically updated.
            else
                await Update(patientVisit);
        }
        /// <summary>
        /// Updates <see cref="PatientVisit"/> object on the database
        /// </summary>
        /// <param name="patientVisit">Object of type <see cref="PatientVisit"/></param>
        /// <returns>Task representing the updating process</returns>
        public async Task Update(PatientVisit patientVisit)
        {
            // Querying for PatientVisits that matches the parameter object
            // To update required object, it must exist in the database
            if (await PatientVisits.Where(queryingPatientVisit => queryingPatientVisit == patientVisit).AnyAsync())
            {
                await PatientVisits.AddAsync(patientVisit);
                // All operations on required object are stored in memory until calling SaveChanges
                await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be updated.");
        }
        /// <summary>
        /// Removes <see cref="PatientVisit"/> object from the database
        /// </summary>
        /// <param name="patientVisit">Object of type <see cref="PatientVisit"/></param>
        /// <returns>Task representing the removing process</returns>
        public async Task Remove(PatientVisit patientVisit)
        {
            // Querying for PatientVisits that matches the parameter object
            // To remove required object from the database, it must exist in the database.
            if (await PatientVisits.Where(queryingPatientVisit => queryingPatientVisit == patientVisit).AnyAsync())
            {
                PatientVisits.Remove(patientVisit);
                // All operations on required object are stored in memory until calling SaveChanges
                await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be deleted.");
        }
        /// <summary>
        /// Retreives <see cref="PatientVisit"/> object from the database
        /// </summary>
        /// <param name="patientVisitID"><see cref="PatientVisit"/> <see cref="Guid"/></param>
        /// <returns>Task representing the retreiving process</returns>
        public async Task<PatientVisit?> GetPatientVisit(Guid patientVisitID)
        {
            // Querying for PatientVisits that matches the parameter object
            // To remove required object from the database, it must exist in the database; Otherwise the method will return value as null.
            var result = PatientVisits.Where(queryingPatientVisit => queryingPatientVisit.ID == patientVisitID);
            return await result.AnyAsync() ? await result.FirstOrDefaultAsync() : null;
        }
        /// <summary>
        /// Adds <see cref="Billing"/> object to the database
        /// </summary>
        /// <param name="billing">Object of type <see cref="Billing"/></param>
        /// <returns>Task representing the adding process</returns>
        public async Task Add(Billing billing)
        {
            // Querying for Billings that matches the parameter object
            // To add required object, it must not exist in the database
            if (!await Billings.Where(queryingBilling => queryingBilling == billing).AnyAsync())
            {
                // Adds the parameter object to the database, then applies underlying changes.
                await Billings.AddAsync(billing);
                // All operations on required object are stored in memory until calling SaveChanges
                await SaveChangesAsync();
            }
            // If required object is found on the database, it will be automatically updated.
            else
                await Update(billing);
        }
        /// <summary>
        /// Updates <see cref="Billing"/> object on the database
        /// </summary>
        /// <param name="billing">Object of type <see cref="Billing"/></param>
        /// <returns>Task representing the updating process</returns>
        public async Task Update(Billing billing)
        {
            // Querying for Billings that matches the parameter object
            // To update required object, it must exist in the database
            if (await Billings.Where(queryingBilling => queryingBilling == billing).AnyAsync())
            {
                await Billings.AddAsync(billing);
                // All operations on required object are stored in memory until calling SaveChanges
                await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be updated.");
        }
        /// <summary>
        /// Removes <see cref="Billing"/> object from the database
        /// </summary>
        /// <param name="billing">Object of type <see cref="Billing"/></param>
        /// <returns>Task representing the removing process</returns>
        public async Task Remove(Billing billing)
        {
            // Querying for Billings that matches the parameter object
            // To remove required object from the database, it must exist in the database.
            if (await Billings.Where(queryingBilling => queryingBilling == billing).AnyAsync())
            {
                Billings.Remove(billing);
                // All operations on required object are stored in memory until calling SaveChanges
                await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be deleted.");
        }
        /// <summary>
        /// Retreives <see cref="Billing"/> object from the database
        /// </summary>
        /// <param name="billingID"><see cref="Billing"/> <see cref="Guid"/></param>
        /// <returns>Task representing the retreiving process</returns>
        public async Task<Billing?> GetBilling(Guid billingID)
        {
            // Querying for Billings that matches the parameter object
            // To remove required object from the database, it must exist in the database; Otherwise the method will return value as null.
            var result = Billings.Where(queryingBilling => queryingBilling.ID == billingID);
            return await result.AnyAsync() ? await result.FirstOrDefaultAsync() : null;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MF.db");
        }
    }
}
