using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PsychologyPatientSystem.Core.Entities;

namespace PsychologyPatientSystem.Core.DataAccess
{
   public interface IAsyncEntityRepository<T> where T:class,IEntity,new()
   {
       Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
       Task<T> GetAsync(Expression<Func<T, bool>> filter);
       Task AddAsync(T entity);
       Task UpdateAsync(T entity);
       Task DeleteAsync(T entity);
   }
}
