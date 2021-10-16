using Examples.Charge.Domain.Aggregates;
using Examples.Charge.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExampleContext _context;

        public UnitOfWork(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
