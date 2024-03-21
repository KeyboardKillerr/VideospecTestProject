using DataModel.DAOs;
using DataModel.Exceptions;
using Helpers.Examples;

namespace DataModelTests
{
    [TestClass]
    public class SqlServerTest
    {
        private static DaoBase Server { get; set; } = new SqlServer();

        [TestMethod]
        public async Task TestCRUD()
        {
            var itemToCreate = new ExampleReceipt();
            await Server.Receipts.CreateAsync(itemToCreate);

            var readItem = await Server.Receipts.GetItemByIdAsync(itemToCreate.Id);
            Assert.AreEqual(itemToCreate.Id, readItem.Id);

            readItem.Total = 1;
            await Server.Receipts.UpdateAsync(readItem);
            var updatedItem = await Server.Receipts.GetItemByIdAsync(readItem.Id);
            Assert.AreEqual(readItem.Inn, updatedItem.Inn);

            await Server.Receipts.DeleteAsync(itemToCreate.Id);
            await Assert.ThrowsExceptionAsync<ModelException>(
                () => Server.Receipts.GetItemByIdAsync(itemToCreate.Id));
        }
    }
}