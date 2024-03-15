using VideospecTestProject.Core.Tests.NUnit.TestFiles;
using Services.Api;
using Services.Models.Receipt;
using Services.Models.Items;

namespace VideospecTestProject.Core.Tests.NUnit;

[TestFixture]
public class OfdApiTests
{
    [Test]
    public async Task SuccesfulAuth()
    {
        var api = new OfdApi();
        var username = "fermatest1";
        var password = "Hjsf3321klsadfAA";
        var result = await api.AuthAsync(username, password);
        Assert.IsTrue(result);
    }

    [Test]
    public async Task SuccesfulAuthV2()
    {
        var api = new OfdApi();
        var username = "fermatest2";
        var password = "Go2999483Mb";
        var result = await api.AuthAsync(username, password);
        Assert.IsTrue(result);
    }

    [Test]
    public async Task UnsuccesfulAuth()
    {
        var api = new OfdApi();
        var username = "wrongusername";
        var password = "wrongpassword";
        var result = await api.AuthAsync(username, password);
        Assert.IsFalse(result);
    }

    [Test]
    public async Task SuccesfulReceiptPost()
    {
        var api = new OfdApi();
        var username = "fermatest1";
        var password = "Hjsf3321klsadfAA";
        var exampleReceipt = BuildExampleReceipt();
        await api.AuthAsync(username, password);
        Assert.DoesNotThrowAsync(async () => await api.AddReceiptAsync(exampleReceipt));
    }

    [Test]
    public async Task SuccesfulReceiptPostV2()
    {
        var api = new OfdApi();
        var username = "fermatest2";
        var password = "Go2999483Mb";
        var exampleReceipt = BuildExampleReceipt();
        await api.AuthAsync(username, password);
        Assert.DoesNotThrowAsync(async () => await api.AddReceiptAsync(exampleReceipt));
    }

    private ReceiptData BuildExampleReceipt()
    {
        var item = new Item();
        item.Label = "Оплата услуг по страхованию.";
        item.Price = 5328.53f;
        item.Quantity = 1.0f;
        item.Amount = 5328.53f;
        item.Vat = "VatNo";
        item.MarkingCode = null;
        item.PaymentMethod = 0;

        var customerReceipt = new CustomerReceipt();
        customerReceipt.TaxationSystem = "Common";
        customerReceipt.Email = "example@ya.ru";
        customerReceipt.Phone = "+79000000001";
        customerReceipt.PaymentType = 4;
        customerReceipt.Items = [item];
        customerReceipt.PaymentItems = null;
        customerReceipt.CustomUserProperty = null;

        var receiptData = new ReceiptData();
        receiptData.Inn = "0123456789";
        receiptData.Type = "Income";
        receiptData.InvoiceId = Guid.NewGuid().ToString();
        receiptData.CallbackUrl = null;
        receiptData.CustomerReceipt = customerReceipt;

        return receiptData;
    }
}