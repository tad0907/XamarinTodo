using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinTodo.SQLite.Contexts;

namespace XamarinTodo.SQLite.Persistence.Common
{
    public abstract class SimpleIncrementalFactory<TDataModel> where TDataModel : class
    {
        private readonly LocalDbContext _context;

        protected SimpleIncrementalFactory(LocalDbContext context)
        {
            _context = context;
        }

        protected abstract int IdToInt(TDataModel data);

        protected abstract DbSet<TDataModel> GetDbSet(LocalDbContext context);

        protected string AssignNumber()
        {
            var dbSet = GetDbSet(_context);

            if (!dbSet.Any())
            {
                return "1";
            }

            var max = dbSet.Select(IdToInt).Max();
            var id = max + 1;

            return id.ToString();
        }
    }
}
