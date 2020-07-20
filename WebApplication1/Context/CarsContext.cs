using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Context
{
    public class CarsContext : DbContext
    {
       public DbSet<Car> Cars { get; set; }


    }
}
