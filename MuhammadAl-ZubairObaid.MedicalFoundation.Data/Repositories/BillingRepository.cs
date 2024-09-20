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
    public class BillingRepository : IMFRepository<Billing>
    {
        private MedicalFoundationDBContext _context;
        private bool _saveChangesAutomatically;

        public BillingRepository(MedicalFoundationDBContext context, bool saveChangesAutomatically = false)
        {
            _context = context;
            _saveChangesAutomatically = saveChangesAutomatically;
        }

        public async Task<bool> Add(Billing entity)
        {
            var result = await _context.Add(entity);
            if (_saveChangesAutomatically) await _context.SaveChangesAsync();
            return result;
        }

        public async Task<IList<Billing>> All() => await _context.Set<Billing>().ToListAsync();

        public async Task<Billing> Get(Guid entityID) => await _context.Get<Billing>(entityID);

        public bool Remove(Billing entity)
        {
            var result = _context.Remove(entity);
            if (_saveChangesAutomatically) _context.SaveChanges();
            return result;
        }

        public async Task SaveChanges() => await _context.SaveChangesAsync();

        public bool Update(Billing entity)
        {
            var result = _context.Update<Billing>(entity); 
            if (_saveChangesAutomatically) _context.SaveChanges();
            return result;
        }
    }
}
