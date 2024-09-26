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
    /// An <see cref="IMFRepository{TMFEntity}"/> repository for <see cref="Patient"/>
    /// 
    /// The purpose of this repository is to organize and conditionalize CRUD operations on <see cref="Patient"/> objects.
    /// </summary>
    public class PatientRepository : IMFRepository<Patient>
    {
        private MedicalFoundationDBContext _context;
        private bool _saveChangesAutomatically;
        /// <summary>
        /// Initializes the repository alongside <see cref="MedicalFoundationDBContext"/> service
        /// </summary>
        /// <param name="context">An instance of <see cref="MedicalFoundationDBContext"/> service. Usually created using Dependency Injection.</param>
        /// <param name="saveChangesAutomatically">Saving changes automatically every database operation</param>
        public PatientRepository(MedicalFoundationDBContext context, bool saveChangesAutomatically = false)
        {
            _context = context;
            _saveChangesAutomatically = saveChangesAutomatically;
        }
        /// <summary>
        /// Adds <see cref="Patient"/> to <see cref="MedicalFoundationDBContext"/> database
        /// </summary>
        /// <param name="entity"><see cref="Patient"/> object to add</param>
        /// <returns>Operation result as <see cref="bool"/></returns>
        public async Task<bool> Add(Patient entity)
        {
            var result = await _context.Add(entity);
            if (_saveChangesAutomatically) await _context.SaveChangesAsync();
            return result;
        }
        /// <summary>
        /// Retreives all <see cref="Patient"/>s based on <paramref name="pageIndex"/> and <paramref name="countForEveryPage"/>
        /// </summary>
        /// <param name="pageIndex">Required page index</param>
        /// <param name="countForEveryPage"><see cref="Patient"/> count for every page</param>
        /// <returns>Retreived <see cref="Patient"/>s</returns>
        public async Task<IList<Patient>> All(int pageIndex, int countForEveryPage)
        {
            var newList = new List<Patient>();
            newList.AddRange(await _context.Set<Patient>().Take(new Range(pageIndex * countForEveryPage, (pageIndex + 1) * countForEveryPage)).ToArrayAsync());
            return newList;
        }
        /// <summary>
        /// Fetches <see cref="Patient"/> object based on <paramref name="entityID"/>
        /// </summary>
        /// <param name="entityID">Required <see cref="Patient"/> <see cref="Guid"/></param>
        /// <returns>Required <see cref="Patient"/> or null if not found</returns>
        public async Task<Patient> Get(Guid entityID) => await _context.Get<Patient>(entityID);
        /// <summary>
        /// Removes <see cref="Patient"/> from <see cref="MedicalFoundationDBContext"/> database
        /// </summary>
        /// <param name="entity">Existing <see cref="Patient"/> object to remove</param>
        /// <returns>Returns removing result as <see cref="bool"/>; True if found and removation succeeded or False if operation failed.</returns>
        public bool Remove(Patient entity)
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
        /// Updates existing <see cref="Patient"/> object in <see cref="MedicalFoundationDBContext"/> database
        /// </summary>
        /// <param name="entity">Existing <see cref="Patient"/> object to update</param>
        /// <returns>Returns updating result as <see cref="bool"/>; True if found and update succeeded or False if operation failed.</returns>
        public bool Update(Patient entity)
        {
            var result = _context.Update<Patient>(entity);
            if (_saveChangesAutomatically) _context.SaveChanges();
            return result;
        }
    }

}
