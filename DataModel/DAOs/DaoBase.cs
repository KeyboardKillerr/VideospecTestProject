using DataModel.DataProviders.Ef.Core.Repositories;
using DataModel.Entities;
using DataModel.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.DAOs
{
    public abstract class DaoBase
    {
        //public IReposBase<CorrectionInfo> CorrectionInfos { get; protected set; }
        //public IReposBase<CustomerReceipt> CustomerReceipts { get; protected set; }
        //public IReposBase<CustomUserProperty> CustomUserProperties { get; protected set; }
        //public IReposBase<Item> Items { get; protected set; }
        //public IReposBase<PaymentAgentInfo> PaymentAgentInfos { get; protected set; }
        //public IReposBase<PaymentItem> PaymentItems { get; protected set; }
        public IReposBase<Receipt> Receipts { get; protected set; }
    }
}
