using DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Repositories
{
    public interface IReposBase<TTable> where TTable : EntityBase
    {
        IQueryable<TTable> Items { get; }
        Task CreateAsync(TTable table);
        Task<TTable> GetItemByIdAsync(Guid id);
        Task UpdateAsync(TTable table);
        Task DeleteAsync(Guid id);
    }
}
