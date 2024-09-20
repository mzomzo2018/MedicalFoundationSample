using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives;
using System.ComponentModel;
namespace MuhammadAl_ZubairObaid.MedicalFoundation.Contexts
{
    public class MedicalFoundationDBContext : DbContext
    {
        private ILogger<MedicalFoundationDBContext> _logger;

        public MedicalFoundationDBContext(ILogger<MedicalFoundationDBContext> logger)
        {
            _logger = logger;
            Database.EnsureCreated();
        }
        [Obsolete("Used in MedicalFoundation console application, which is deprecated")]
        public MedicalFoundationDBContext() { }
        /// <summary>
        /// Singleton property to access <see cref="MedicalFoundationDBContext"/>
        /// </summary>
        [Obsolete("Used in MedicalFoundation console application, which is deprecated")]
        public static MedicalFoundationDBContext Context { get; } = new MedicalFoundationDBContext();
        /// <summary>
        /// Database set of type <see cref="Patient"/>
        /// </summary>
        public DbSet<Patient> Patients { get; set; }
        /// <summary>
        /// Database set of type <see cref="PatientVisit"/>
        /// </summary>
        public DbSet<PatientVisit> PatientVisits { get; set; }
        /// <summary>
        /// Database set of type <see cref="Clinician"/>
        /// </summary>
        public DbSet<Clinician> Clinicians { get; set; }
        /// <summary>
        /// Database set of type <see cref="ClinicAppointment"/>
        /// </summary>
        public DbSet<ClinicAppointment> ClinicAppointments { get; set; }
        /// <summary>
        /// Database set of type <see cref="Billing"/>
        /// </summary>
        public DbSet<Billing> Billings { get; set; }
        /// <summary>
        /// Adds <typeparamref name="TMFEntity"/> object to the database
        /// </summary>
        /// <param name="mfObject">Object of type <typeparamref name="TMFEntity"/></param>
        /// <returns><c>true</c> if succeeded; Otherwise <c>false</c></returns>
        public async Task<bool> Add<TMFEntity>(TMFEntity mfObject) where TMFEntity : MFEntity
        {
            try
            {
                var entityEntry = await AddAsync(mfObject);
                // Checking if entity is added
                return entityEntry.State == EntityState.Added;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Updates <typeparamref name="TMFEntity"/> object on the database
        /// </summary>
        /// <param name="mfObject">Object of type <typeparamref name="TMFEntity"/></param>
        /// <returns><c>true</c> if succeeded; Otherwise <c>false</c></returns>
        public bool Update<TMFEntity>(TMFEntity mfObject) where TMFEntity : MFEntity
        {
            try
            {
                var entityEntry = base.Update(mfObject);
                // Checking if entity is updated
                return entityEntry.State == EntityState.Modified;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Removes <typeparamref name="TMFEntity"/> object from the database
        /// </summary>
        /// <param name="mfObject">Object of type <typeparamref name="TMFEntity"/></param>
        /// <returns><c>true</c> if succeeded; Otherwise <c>false</c></returns>
        public bool Remove<TMFEntity>(TMFEntity mfObject) where TMFEntity : MFEntity
        {
            try
            {
                var entityEntry = base.Remove(mfObject);
                // Checking if entity is deleted
                return entityEntry.State == EntityState.Deleted;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Saves all changes made to <see cref="MedicalFoundationDBContext"/> database
        /// </summary>
        /// <returns><c>true</c> if all pending changes are saved; Otherwise <c>false</c></returns>
        public async Task<bool> SaveChangesAsync()
        {
            try 
            {
                return await base.SaveChangesAsync() > 0;
            }
            catch 
            {
                return false;
            }
        }
        /// <summary>
        /// Retreives <typeparamref name="TMFEntity"/> object from the database
        /// </summary>
        /// <param name="entityID"><typeparamref name="TMFEntity"/> <see cref="Guid"/></param>
        /// <returns>Found <typeparamref name="TMFEntity"/> object or null value if not found</returns>
        public async Task<TMFEntity?> Get<TMFEntity>(Guid entityID) where TMFEntity : MFEntity
        {
            return await FindAsync<TMFEntity>(entityID);
        }
        protected override async void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=MF.db");
        }
    }
}
