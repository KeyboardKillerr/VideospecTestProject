using DataModel.Entities;
using DataModel.Exceptions;
using DataModel.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DataProviders.Ef.Core.Repositories
{
    public abstract class EfBase<TTable> : IReposBase<TTable> where TTable : EntityBase
    {
        private readonly DataContext context;
        private readonly IQueryable<TTable> items;

        public EfBase(DataContext context, IQueryable<TTable> items)
        {
            this.context = context;
            this.items = items;
        }

        public IQueryable<TTable> Items => items;

        public async Task CreateAsync(TTable table)
        {
            TTable item;

            item = await Items.FirstOrDefaultAsync(x => x.Id == table.Id);

            if (item != null) throw
                    new ModelException(
                        innerException:
                        new ItemExistsException(item.Id));

            await context.AddAsync(table);
            await context.SaveChangesAsync();
        }

        public async Task<TTable> GetItemByIdAsync(Guid id)
        {
            var item = await Items.FirstOrDefaultAsync(x => x.Id == id);

            if (item is null) throw
                    new ModelException(
                        innerException:
                        new ItemNotFoundException(id));

            return item;
        }

        public async Task UpdateAsync(TTable table)
        {
            var item = await Items.FirstOrDefaultAsync(x => x.Id == table.Id);

            if (item is null) throw
                    new ModelException(
                        innerException:
                        new ItemNotFoundException(table.Id));

            context.Update(table);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await Items.FirstOrDefaultAsync(x => x.Id == id);

            if (item is null) throw
                    new ModelException(
                        innerException:
                        new ItemNotFoundException(id));

            context.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
