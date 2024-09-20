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
    public class ClinicAppointmentRepository : IMFRepository<ClinicAppointment>
    {
        private MedicalFoundationDBContext _context;
        private bool _saveChangesAutomatically;

        public ClinicAppointmentRepository(MedicalFoundationDBContext context, bool saveChangesAutomatically = false)
        {
            _context = context;
            _saveChangesAutomatically = saveChangesAutomatically;
        }

        public async Task<bool> Add(ClinicAppointment entity)
        {
            var result = await _context.Add(entity);
            if (_saveChangesAutomatically) await _context.SaveChangesAsync();
            return result;
        }

        public async Task<IList<ClinicAppointment>> All() => await _context.Set<ClinicAppointment>().ToListAsync();

        public async Task<ClinicAppointment> Get(Guid entityID) => await _context.Get<ClinicAppointment>(entityID);

        public bool Remove(ClinicAppointment entity)
        {
            var result = _context.Remove(entity);
            if (_saveChangesAutomatically) _context.SaveChanges();
            return result;
        }

        public async Task SaveChanges() => await _context.SaveChangesAsync();

        public bool Update(ClinicAppointment entity)
        {
            var result = _context.Update(entity); 
            if (_saveChangesAutomatically) _context.SaveChanges();
            return result;
        }
    }
}
