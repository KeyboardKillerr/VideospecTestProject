using DataModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataModel.DataProviders.Ef.Core
{
    public class DataContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<CorrectionInfo> CorrectionInfos { get; set; }
        //public DbSet<CustomerReceipt> CustomerReceipts { get; set; }
        //public DbSet<CustomUserProperty> CustomUserProperties { get; set; }
        //public DbSet<Item> Items { get; set; }
        //public DbSet<PaymentAgentInfo> PaymentAgentInfos { get; set; }
        //public DbSet<PaymentItem> PaymentItems { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        public void Detach<T>(T t)
        where T : EntityBase
        {
            var local = Set<T>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(t.Id));
            if (local != null) Entry(local).State = EntityState.Detached;
        }

        public void AttachAsModified<T>(T t)
        where T : EntityBase
        {
            Entry(t).State = EntityState.Modified;
        }
    }
}
