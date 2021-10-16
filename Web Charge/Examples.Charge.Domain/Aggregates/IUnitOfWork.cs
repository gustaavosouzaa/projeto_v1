using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates

{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
