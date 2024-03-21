using DataModel.DataProviders.Ef.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.DAOs
{
    public class SqlServer : DaoBase
    {
        public SqlServer()
        {
            var sqlserverContext = new DataProviders.Ef.Contexts.SqlServerDbContext();
            sqlserverContext.Database.EnsureDeleted();
            sqlserverContext.Database.EnsureCreated();

            //CorrectionInfos = new EfCorrectionInfo(sqlserverContext);
            //CustomerReceipts = new EfCustomerReceipt(sqlserverContext);
            //CustomUserProperties = new EfCustomUserProperty(sqlserverContext);
            //Items = new EfItem(sqlserverContext);
            //PaymentAgentInfos = new EfPaymentAgentInfo(sqlserverContext);
            //PaymentItems = new EfPaymentItem(sqlserverContext);
            Receipts = new EfReceipt(sqlserverContext);
        }
    }
}
