using Microsoft.EntityFrameworkCore;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives;
namespace MuhammadAl_ZubairObaid.MedicalFoundation.Contexts
{
    public class MedicalFoundationDBContext : DbContext
    {
        public static MedicalFoundationDBContext Context { get; } = new MedicalFoundationDBContext();
        DbSet<Patient> Patients { get; set; }
        DbSet<PatientVisit> PatientVisits { get; set; }
        DbSet<Clinician> Clinicians { get; set; }
        DbSet<ClinicAppointment> ClinicAppointments { get; set; }
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
                await SaveChangesAsync();
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
                await SaveChangesAsync();
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
                await SaveChangesAsync();
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
        /// <param name="Patient">Object of type <see cref="Patient"/></param>
        /// <returns>Task representing the adding process</returns>
        public async Task Add(Patient Patient)
        {
            // Querying for Patients that matches the parameter object
            // To add required object, it must not exist in the database
            if (!await Patients.Where(queryingPatient => queryingPatient == Patient).AnyAsync())
            {
                // Adds the parameter object to the database, then applies underlying changes.
                await Patients.AddAsync(Patient);
                await SaveChangesAsync();
            }
            // If required object is found on the database, it will be automatically updated.
            else
                await Update(Patient); 
        }
        /// <summary>
        /// Updates <see cref="Patient"/> object on the database
        /// </summary>
        /// <param name="Patient">Object of type <see cref="Patient"/></param>
        /// <returns>Task representing the updating process</returns>
        public async Task Update(Patient Patient)
        {
            // Querying for Patients that matches the parameter object
            // To update required object, it must exist in the database
            if (await Patients.Where(queryingPatient => queryingPatient == Patient).AnyAsync())
            {
                await Patients.AddAsync(Patient);
                await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be updated.");
        }
        /// <summary>
        /// Removes <see cref="Patient"/> object from the database
        /// </summary>
        /// <param name="Patient">Object of type <see cref="Patient"/></param>
        /// <returns>Task representing the removing process</returns>
        public async Task Remove(Patient Patient)
        {
            // Querying for Patients that matches the parameter object
            // To remove required object from the database, it must exist in the database.
            if (await Patients.Where(queryingPatient => queryingPatient == Patient).AnyAsync())
            {
                Patients.Remove(Patient);
                await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be deleted.");
        }
        /// <summary>
        /// Retreives <see cref="Patient"/> object from the database
        /// </summary>
        /// <param name="PatientID"><see cref="Patient"/> <see cref="Guid"/></param>
        /// <returns>Task representing the retreiving process</returns>
        public async Task<Patient?> GetPatient(Guid PatientID)
        {
            // Querying for Patients that matches the parameter object
            // To remove required object from the database, it must exist in the database; Otherwise the method will return value as null.
            var result = Patients.Where(queryingPatient => queryingPatient.ID == PatientID);
            return await result.AnyAsync() ? await result.FirstOrDefaultAsync() : null;
        }    
        /// <summary>
        /// Adds <see cref="ClinicAppointment"/> object to the database
        /// </summary>
        /// <param name="ClinicAppointment">Object of type <see cref="ClinicAppointment"/></param>
        /// <returns>Task representing the adding process</returns>
        public async Task Add(ClinicAppointment ClinicAppointment)
        {
            // Querying for ClinicAppointments that matches the parameter object
            // To add required object, it must not exist in the database
            if (!await ClinicAppointments.Where(queryingClinicAppointment => queryingClinicAppointment == ClinicAppointment).AnyAsync())
            {
                // Adds the parameter object to the database, then applies underlying changes.
                await ClinicAppointments.AddAsync(ClinicAppointment);
                await SaveChangesAsync();
            }
            // If required object is found on the database, it will be automatically updated.
            else
                await Update(ClinicAppointment); 
        }
        /// <summary>
        /// Updates <see cref="ClinicAppointment"/> object on the database
        /// </summary>
        /// <param name="ClinicAppointment">Object of type <see cref="ClinicAppointment"/></param>
        /// <returns>Task representing the updating process</returns>
        public async Task Update(ClinicAppointment ClinicAppointment)
        {
            // Querying for ClinicAppointments that matches the parameter object
            // To update required object, it must exist in the database
            if (await ClinicAppointments.Where(queryingClinicAppointment => queryingClinicAppointment == ClinicAppointment).AnyAsync())
            {
                await ClinicAppointments.AddAsync(ClinicAppointment);
                await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be updated.");
        }
        /// <summary>
        /// Removes <see cref="ClinicAppointment"/> object from the database
        /// </summary>
        /// <param name="ClinicAppointment">Object of type <see cref="ClinicAppointment"/></param>
        /// <returns>Task representing the removing process</returns>
        public async Task Remove(ClinicAppointment ClinicAppointment)
        {
            // Querying for ClinicAppointments that matches the parameter object
            // To remove required object from the database, it must exist in the database.
            if (await ClinicAppointments.Where(queryingClinicAppointment => queryingClinicAppointment == ClinicAppointment).AnyAsync())
            {
                ClinicAppointments.Remove(ClinicAppointment);
                await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be deleted.");
        }
        /// <summary>
        /// Retreives <see cref="ClinicAppointment"/> object from the database
        /// </summary>
        /// <param name="ClinicAppointmentID"><see cref="ClinicAppointment"/> <see cref="Guid"/></param>
        /// <returns>Task representing the retreiving process</returns>
        public async Task<ClinicAppointment?> GetClinicAppointment(Guid ClinicAppointmentID)
        {
            // Querying for ClinicAppointments that matches the parameter object
            // To remove required object from the database, it must exist in the database; Otherwise the method will return value as null.
            var result = ClinicAppointments.Where(queryingClinicAppointment => queryingClinicAppointment.ID == ClinicAppointmentID);
            return await result.AnyAsync() ? await result.FirstOrDefaultAsync() : null;
        }     
        /// <summary>
        /// Adds <see cref="PatientVisit"/> object to the database
        /// </summary>
        /// <param name="PatientVisit">Object of type <see cref="PatientVisit"/></param>
        /// <returns>Task representing the adding process</returns>
        public async Task Add(PatientVisit PatientVisit)
        {
            // Querying for PatientVisits that matches the parameter object
            // To add required object, it must not exist in the database
            if (!await PatientVisits.Where(queryingPatientVisit => queryingPatientVisit == PatientVisit).AnyAsync())
            {
                // Adds the parameter object to the database, then applies underlying changes.
                await PatientVisits.AddAsync(PatientVisit);
                await SaveChangesAsync();
            }
            // If required object is found on the database, it will be automatically updated.
            else
                await Update(PatientVisit); 
        }
        /// <summary>
        /// Updates <see cref="PatientVisit"/> object on the database
        /// </summary>
        /// <param name="PatientVisit">Object of type <see cref="PatientVisit"/></param>
        /// <returns>Task representing the updating process</returns>
        public async Task Update(PatientVisit PatientVisit)
        {
            // Querying for PatientVisits that matches the parameter object
            // To update required object, it must exist in the database
            if (await PatientVisits.Where(queryingPatientVisit => queryingPatientVisit == PatientVisit).AnyAsync())
            {
                await PatientVisits.AddAsync(PatientVisit);
                await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be updated.");
        }
        /// <summary>
        /// Removes <see cref="PatientVisit"/> object from the database
        /// </summary>
        /// <param name="PatientVisit">Object of type <see cref="PatientVisit"/></param>
        /// <returns>Task representing the removing process</returns>
        public async Task Remove(PatientVisit PatientVisit)
        {
            // Querying for PatientVisits that matches the parameter object
            // To remove required object from the database, it must exist in the database.
            if (await PatientVisits.Where(queryingPatientVisit => queryingPatientVisit == PatientVisit).AnyAsync())
            {
                PatientVisits.Remove(PatientVisit);
                await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be deleted.");
        }
        /// <summary>
        /// Retreives <see cref="PatientVisit"/> object from the database
        /// </summary>
        /// <param name="PatientVisitID"><see cref="PatientVisit"/> <see cref="Guid"/></param>
        /// <returns>Task representing the retreiving process</returns>
        public async Task<PatientVisit?> GetPatientVisit(Guid PatientVisitID)
        {
            // Querying for PatientVisits that matches the parameter object
            // To remove required object from the database, it must exist in the database; Otherwise the method will return value as null.
            var result = PatientVisits.Where(queryingPatientVisit => queryingPatientVisit.ID == PatientVisitID);
            return await result.AnyAsync() ? await result.FirstOrDefaultAsync() : null;
        }
        /// <summary>
        /// Adds <see cref="Billing"/> object to the database
        /// </summary>
        /// <param name="Billing">Object of type <see cref="Billing"/></param>
        /// <returns>Task representing the adding process</returns>
        public async Task Add(Billing Billing)
        {
            // Querying for Billings that matches the parameter object
            // To add required object, it must not exist in the database
            if (!await Billings.Where(queryingBilling => queryingBilling == Billing).AnyAsync())
            {
                // Adds the parameter object to the database, then applies underlying changes.
                await Billings.AddAsync(Billing);
                await SaveChangesAsync();
            }
            // If required object is found on the database, it will be automatically updated.
            else
                await Update(Billing); 
        }
        /// <summary>
        /// Updates <see cref="Billing"/> object on the database
        /// </summary>
        /// <param name="Billing">Object of type <see cref="Billing"/></param>
        /// <returns>Task representing the updating process</returns>
        public async Task Update(Billing Billing)
        {
            // Querying for Billings that matches the parameter object
            // To update required object, it must exist in the database
            if (await Billings.Where(queryingBilling => queryingBilling == Billing).AnyAsync())
            {
                await Billings.AddAsync(Billing);
                await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be updated.");
        }
        /// <summary>
        /// Removes <see cref="Billing"/> object from the database
        /// </summary>
        /// <param name="Billing">Object of type <see cref="Billing"/></param>
        /// <returns>Task representing the removing process</returns>
        public async Task Remove(Billing Billing)
        {
            // Querying for Billings that matches the parameter object
            // To remove required object from the database, it must exist in the database.
            if (await Billings.Where(queryingBilling => queryingBilling == Billing).AnyAsync())
            {
                Billings.Remove(Billing);
                await SaveChangesAsync();
            }
            // If required object is not found on the database, an exception will be thrown.
            else
                throw new InvalidOperationException("Object that does not exist in the database cannot be deleted.");
        }
        /// <summary>
        /// Retreives <see cref="Billing"/> object from the database
        /// </summary>
        /// <param name="BillingID"><see cref="Billing"/> <see cref="Guid"/></param>
        /// <returns>Task representing the retreiving process</returns>
        public async Task<Billing?> GetBilling(Guid BillingID)
        {
            // Querying for Billings that matches the parameter object
            // To remove required object from the database, it must exist in the database; Otherwise the method will return value as null.
            var result = Billings.Where(queryingBilling => queryingBilling.ID == BillingID);
            return await result.AnyAsync() ? await result.FirstOrDefaultAsync() : null;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MF.db");
        }
    }
}
