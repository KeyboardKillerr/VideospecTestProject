using Newtonsoft.Json;
using Services.Exceptions;
using Services.Models.Auth;
using Services.Models.Receipt;
using Services.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Services.Api
{
    public class OfdApi : IApi
    {
        private static readonly string authPath = "Authorization/CreateAuthToken";
        private static readonly string receiptPostPath = "kkt/cloud/receipt";
        private readonly HttpDataService client = new HttpDataService("https://ferma-test.ofd.ru/api");
        private string token = "";

        public async Task<bool> AuthAsync(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password)) return false;

            var authData = new AuthRequestBody() { Login = login, Password = password };

            var response = await client.PostAsJsonAsync(authData, authPath);

            if (!response.IsSuccessStatusCode) return false;

            var content = await response.Content.ReadAsStringAsync();
            var authResponse = JsonConvert.DeserializeObject<AuthResponse>(content);
            token = authResponse.Data.AuthToken;

            return true;
        }

        public async Task AddReceiptAsync(ReceiptData receipt)
        {
            if (!IsAuthorized) throw new UnauthorizedAccessException("Пользователь не авторизован.");
            if (receipt == null) throw new NullReferenceException("Receipt was null.");

            var requestBody = new ReceiptRequestBody() { Request = receipt };

            var response = await client.PostAsJsonAsync(requestBody, AddTokenToUri(receiptPostPath, token));

            if (!response.IsSuccessStatusCode) await ProccesUnsuccessfulRequest(response);
        }

        private bool IsAuthorized { get { return !string.IsNullOrEmpty(token); } }

        private string AddTokenToUri(string uri, string token)
        {
            if (string.IsNullOrEmpty(token)) return "";
            return $"{uri}?AuthToken={token}";
        }

        private async Task ProccesUnsuccessfulRequest(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                var exception = JsonConvert.DeserializeObject<UnsuccessfulRequestException>(content);
                throw exception;
            }
            catch (Exception exception)
            {
                throw new UnexpectedException(innerException: exception);
            }
        }
    }
}
