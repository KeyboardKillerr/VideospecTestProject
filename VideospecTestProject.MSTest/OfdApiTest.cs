using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Api;
using Services.Models.Examples;
using Services.Models.Items;
using Services.Models.Receipt;

namespace VideospecTestProject.MSTest
{
    [TestClass]
    public class OfdApiTest
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
}
