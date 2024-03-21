using DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.DataProviders.Ef.Core.Repositories
{
    public class EfReceipt : EfBase<Receipt>
    {
        public EfReceipt(DataContext context) : base(context, context.Receipts) { }
    }
}
