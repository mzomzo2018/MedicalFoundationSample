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
    public class ClinicianRepository : IMFRepository<Clinician>
    {
        private MedicalFoundationDBContext _context;
        private bool _saveChangesAutomatically;

        public ClinicianRepository(MedicalFoundationDBContext context, bool saveChangesAutomatically = false)
        {
            _context = context;
            _saveChangesAutomatically = saveChangesAutomatically;
        }

        public async Task<bool> Add(Clinician entity)
        {
            var result = await _context.Add(entity);
            if (_saveChangesAutomatically) await _context.SaveChangesAsync();
            return result;
        }

        public async Task<IList<Clinician>> All() => await _context.Set<Clinician>().ToListAsync();

        public async Task<Clinician> Get(Guid entityID) => await _context.Get<Clinician>(entityID);

        public bool Remove(Clinician entity)
        {
            var result = _context.Remove(entity);
            if (_saveChangesAutomatically) _context.SaveChanges();
            return result;
        }

        public async Task SaveChanges() => await _context.SaveChangesAsync();

        public bool Update(Clinician entity)
        {
            var result = _context.Update<Clinician>(entity); 
            if (_saveChangesAutomatically) _context.SaveChanges();
            return result;
        }
    }
}
