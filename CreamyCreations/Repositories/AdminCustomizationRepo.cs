using CreamyCreations.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreamyCreations.Repositories
{
    public class AdminCustomizationRepo
    {
        ApplicationDbContext _context;
        public AdminCustomizationRepo(ApplicationDbContext context)
        {
            this._context = context;
        }

    }
}
