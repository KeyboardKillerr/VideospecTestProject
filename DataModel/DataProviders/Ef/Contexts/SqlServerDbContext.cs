using DataModel.DataProviders.Ef.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.DataProviders.Ef.Contexts
{
    public class SqlServerDbContext : DataContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source = localhost; Initial Catalog = ReceiptsDB; Integrated Security = True; TrustServerCertificate = True;");
        }
    }
}
