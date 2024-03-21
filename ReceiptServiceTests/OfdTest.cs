using ReceiptService.Api;
using Helpers.Examples;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReceiptServiceTests;

[TestClass]
public class OfdTest
{
    [TestMethod]
    public async Task SuccesfulAuth()
    {
        var api = new OfdApi();
        var username = "fermatest1";
        var password = "Hjsf3321klsadfAA";
        var result = await api.AuthAsync(username, password);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public async Task SuccesfulAuthV2()
    {
        var api = new OfdApi();
        var username = "fermatest2";
        var password = "Go2999483Mb";
        var result = await api.AuthAsync(username, password);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public async Task UnsuccesfulAuth()
    {
        var api = new OfdApi();
        var username = "wrongusername";
        var password = "wrongpassword";
        var result = await api.AuthAsync(username, password);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public async Task SuccesfulReceiptPost()
    {
        var api = new OfdApi();
        var username = "fermatest1";
        var password = "Hjsf3321klsadfAA";
        var exampleReceipt = new ExampleReceipt();
        await api.AuthAsync(username, password);
        await api.AddReceiptAsync(exampleReceipt);
    }

    [TestMethod]
    public async Task SuccesfulReceiptPostV2()
    {
        var api = new OfdApi();
        var username = "fermatest2";
        var password = "Go2999483Mb";
        var exampleReceipt = new ExampleReceipt();
        await api.AuthAsync(username, password);
        await api.AddReceiptAsync(exampleReceipt);
    }
}
