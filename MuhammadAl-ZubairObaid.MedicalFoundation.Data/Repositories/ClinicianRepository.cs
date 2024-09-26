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
    /// An <see cref="IMFRepository{TMFEntity}"/> repository for <see cref="Clinician"/>
    /// 
    /// The purpose of this repository is to organize and conditionalize CRUD operations on <see cref="Clinician"/> objects.
    /// </summary>
    public class ClinicianRepository : IMFRepository<Clinician>
    {
        private MedicalFoundationDBContext _context;
        private bool _saveChangesAutomatically;
        /// <summary>
        /// Initializes the repository alongside <see cref="MedicalFoundationDBContext"/> service
        /// </summary>
        /// <param name="context">An instance of <see cref="MedicalFoundationDBContext"/> service. Usually created using Dependency Injection.</param>
        /// <param name="saveChangesAutomatically">Saving changes automatically every database operation</param>
        public ClinicianRepository(MedicalFoundationDBContext context, bool saveChangesAutomatically = false)
        {
            _context = context;
            _saveChangesAutomatically = saveChangesAutomatically;
        }
        /// <summary>
        /// Adds <see cref="Clinician"/> to <see cref="MedicalFoundationDBContext"/> database
        /// </summary>
        /// <param name="entity"><see cref="Clinician"/> object to add</param>
        /// <returns>Operation result as <see cref="bool"/></returns>
        public async Task<bool> Add(Clinician entity)
        {
            var result = await _context.Add(entity);
            if (_saveChangesAutomatically) await _context.SaveChangesAsync();
            return result;
        }
        /// <summary>
        /// Retreives all <see cref="Clinician"/>s based on <paramref name="pageIndex"/> and <paramref name="countForEveryPage"/>
        /// </summary>
        /// <param name="pageIndex">Required page index</param>
        /// <param name="countForEveryPage"><see cref="Clinician"/> count for every page</param>
        /// <returns>Retreived <see cref="Clinician"/>s</returns>
        public async Task<IList<Clinician>> All(int pageIndex, int countForEveryPage)
        {
            var newList = new List<Clinician>();
            newList.AddRange(await _context.Set<Clinician>().Take(new Range(pageIndex * countForEveryPage, (pageIndex + 1) * countForEveryPage)).ToArrayAsync());
            return newList;
        }
        /// <summary>
        /// Fetches <see cref="Clinician"/> object based on <paramref name="entityID"/>
        /// </summary>
        /// <param name="entityID">Required <see cref="Clinician"/> <see cref="Guid"/></param>
        /// <returns>Required <see cref="Clinician"/> or null if not found</returns>
        public async Task<Clinician> Get(Guid entityID) => await _context.Get<Clinician>(entityID);
        /// <summary>
        /// Removes <see cref="Clinician"/> from <see cref="MedicalFoundationDBContext"/> database
        /// </summary>
        /// <param name="entity">Existing <see cref="Clinician"/> object to remove</param>
        /// <returns>Returns removing result as <see cref="bool"/>; True if found and removation succeeded or False if operation failed.</returns>
        public bool Remove(Clinician entity)
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
        /// Updates existing <see cref="Clinician"/> object in <see cref="MedicalFoundationDBContext"/> database
        /// </summary>
        /// <param name="entity">Existing <see cref="Clinician"/> object to update</param>
        /// <returns>Returns updating result as <see cref="bool"/>; True if found and update succeeded or False if operation failed.</returns>
        public bool Update(Clinician entity)
        {
            var result = _context.Update<Clinician>(entity);
            if (_saveChangesAutomatically) _context.SaveChanges();
            return result;
        }
    }
}
