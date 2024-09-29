using Microsoft.EntityFrameworkCore;
using MuhammadAl_ZubairObaid.MedicalFoundation.Contexts;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain.Primitives;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.Data.Repositories
{
    /// <summary>
    /// An <see cref="IMFRepository{TMFEntity}"/> repository for <see cref="ClinicAppointment"/>
    /// 
    /// The purpose of this repository is to organize and conditionalize CRUD operations on <see cref="ClinicAppointment"/> objects.
    /// </summary>
    public class ClinicAppointmentRepository : IMFRepository<ClinicAppointment>
    {
        private MedicalFoundationDBContext _context;
        private bool _saveChangesAutomatically;
        /// <summary>
        /// Initializes the repository alongside <see cref="MedicalFoundationDBContext"/> service
        /// </summary>
        /// <param name="context">An instance of <see cref="MedicalFoundationDBContext"/> service. Usually created using Dependency Injection.</param>
        /// <param name="saveChangesAutomatically">Saving changes automatically every database operation</param>
        public ClinicAppointmentRepository(MedicalFoundationDBContext context, bool saveChangesAutomatically = false)
        {
            _context = context;
            _saveChangesAutomatically = saveChangesAutomatically;
        }
        /// <summary>
        /// Adds <see cref="ClinicAppointment"/> to <see cref="MedicalFoundationDBContext"/> database
        /// </summary>
        /// <param name="entity"><see cref="ClinicAppointment"/> object to add</param>
        /// <returns>Operation result as <see cref="bool"/></returns>
        public async Task<bool> Add(ClinicAppointment entity)
        {
            // DTO objects must match its original representaion objects by ID
            if (_context.Billings.Where(e => e.ID == entity.Billing.ID).Any() && _context.Clinicians.Where(e => e.ID == entity.Clinician.ID).Any())
            {
                var result = await _context.Add(entity);
                if (_saveChangesAutomatically) await _context.SaveChangesAsync();
                return result;
            }
            else
                return false;
        }
        /// <summary>
        /// Retreives all <see cref="ClinicAppointment"/>s based on <paramref name="pageIndex"/> and <paramref name="countForEveryPage"/>
        /// </summary>
        /// <param name="pageIndex">Required page index</param>
        /// <param name="countForEveryPage"><see cref="ClinicAppointment"/> count for every page</param>
        /// <returns>Retreived <see cref="ClinicAppointment"/>s</returns>
        public async Task<IList<ClinicAppointment>> All(int pageIndex, int countForEveryPage)
        {
            var newList = new List<ClinicAppointment>();
            newList.AddRange(await _context.Set<ClinicAppointment>().Take(new Range(pageIndex * countForEveryPage, (pageIndex + 1) * countForEveryPage)).ToArrayAsync());
            return newList;
        }
        /// <summary>
        /// Fetches <see cref="ClinicAppointment"/> object based on <paramref name="entityID"/>
        /// </summary>
        /// <param name="entityID">Required <see cref="ClinicAppointment"/> <see cref="Guid"/></param>
        /// <returns>Required <see cref="ClinicAppointment"/> or null if not found</returns>
        public async Task<ClinicAppointment> Get(Guid entityID) => await _context.Get<ClinicAppointment>(entityID);
        /// <summary>
        /// Removes <see cref="ClinicAppointment"/> from <see cref="MedicalFoundationDBContext"/> database
        /// </summary>
        /// <param name="entity">Existing <see cref="ClinicAppointment"/> object to remove</param>
        /// <returns>Returns removing result as <see cref="bool"/>; True if found and removation succeeded or False if operation failed.</returns>
        public bool Remove(ClinicAppointment entity)
        {
            var result = _context.Remove(entity);
            if (_saveChangesAutomatically) _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// Saves all changes made to <see cref="MedicalFoundationDBContext"/> database. Not necessary when <see cref="saveChangesAutomatically"/> is True  
        /// </summary>
        /// <returns></returns>
        public async Task SaveChanges() => await _context.SaveChangesAsync();
        /// <summary>
        /// Updates existing <see cref="ClinicAppointment"/> object in <see cref="MedicalFoundationDBContext"/> database
        /// </summary>
        /// <param name="entity">Existing <see cref="ClinicAppointment"/> object to update</param>
        /// <returns>Returns updating result as <see cref="bool"/>; True if found and update succeeded or False if operation failed.</returns>
        public bool Update(ClinicAppointment entity)
        {
            // DTO objects must match its original representaion objects by ID
            if (_context.Billings.Where(e => e.ID == entity.Billing.ID).Any() && _context.Clinicians.Where(e => e.ID == entity.Clinician.ID).Any())
            {
                var result = _context.Update<ClinicAppointment>(entity);
                if (_saveChangesAutomatically) _context.SaveChanges();
                return result;
            }
            else
                return false;
        }
    }
}
