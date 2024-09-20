using Microsoft.EntityFrameworkCore;
using MuhammadAl_ZubairObaid.MedicalFoundation.Contexts;
using MuhammadAl_ZubairObaid.MedicalFoundation.Domain;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.Data.Repositories
{
    public class PatientRepository : IMFRepository<Patient>
    {
        private MedicalFoundationDBContext _context;
        private bool _saveChangesAutomatically;

        public PatientRepository(MedicalFoundationDBContext context, bool saveChangesAutomatically = false)
        {
            _context = context;
            _saveChangesAutomatically = saveChangesAutomatically;
        }

        public async Task<bool> Add(Patient entity)
        {
            var result = await _context.Add(entity);
            if (_saveChangesAutomatically) await _context.SaveChangesAsync();
            return result;
        }

        public async Task<IList<Patient>> All() => await _context.Set<Patient>().ToListAsync();

        public async Task<Patient> Get(Guid entityID) => await _context.Get<Patient>(entityID);

        public bool Remove(Patient entity)
        {
            var result = _context.Remove(entity);
            if (_saveChangesAutomatically) _context.SaveChanges();
            return result;
        }

        public async Task SaveChanges() => await _context.SaveChangesAsync();

        public bool Update(Patient entity)
        {
            var result = _context.Update<Patient>(entity); 
            if (_saveChangesAutomatically) _context.SaveChanges();
            return result;
        }
    }
}
