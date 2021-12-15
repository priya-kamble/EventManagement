using Microsoft.EntityFrameworkCore;
using OrderApi.Data;
using OrderAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAPI.Data
{
    public static class MigrateDatabase
    {
        public static void EnsureCreated(OrdersContext context)
        {
            context.Database.Migrate();
        }
    }
}
