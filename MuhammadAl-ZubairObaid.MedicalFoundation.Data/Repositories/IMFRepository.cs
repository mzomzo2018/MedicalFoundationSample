using MuhammadAl_ZubairObaid.MedicalFoundation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuhammadAl_ZubairObaid.MedicalFoundation.Data.Repositories
{
    public interface IMFRepository<TMFEntity> where TMFEntity : MFEntity 
    {
        public Task<bool> Add(TMFEntity entity);
        public Task<TMFEntity> Get(Guid entityID);
        public Task<IList<TMFEntity>> All();
        public bool Remove(TMFEntity entity);
        public bool Update(TMFEntity entity);
        public Task SaveChanges();
    }
}
