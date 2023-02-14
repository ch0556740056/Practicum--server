using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IContext
    {
        DbSet<Child> Children { get; set; }

        DbSet<PersonalDetail> PersonalDetails { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
