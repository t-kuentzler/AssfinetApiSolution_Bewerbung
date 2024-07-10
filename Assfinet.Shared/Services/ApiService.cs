using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Assfinet.Shared.Contracts;
using Assfinet.Shared.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assfinet.Shared.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IAppLogger _logger;
        private static string? _bearerToken;
        private static DateTime _bearerExpireTimeUtc;
        private static string? _refreshToken;

        public ApiService(HttpClient httpClient, IConfiguration configuration, IAppLogger logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<List<KundeModel>> GetKundenAsync()
        {
            try
            {
                Uri baseUriAuth, baseUriApi;
                string userName, passwort, license, clientId, clientSecret;

                GetApiSettings(out baseUriAuth, out baseUriApi, out userName, out passwort, out license, out clientId, out clientSecret);

                (_bearerToken, _bearerExpireTimeUtc, _refreshToken) = await GetBearerToken(_httpClient, baseUriAuth, userName, passwort, clientId, clientSecret, _bearerToken, _bearerExpireTimeUtc, _refreshToken);
                _logger.LogInformation("Bearer Token abgerufen.");

                string apiPath = "v1/Ams/Kunde?orderBy=Id&byDescending=true&skip=0&take=10&accessMode=Admin";
                var requestData = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(baseUriApi, apiPath),
                };
                requestData.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_bearerToken}");

                _logger.LogInformation($"API-Anfrage wird gesendet an {requestData.RequestUri}");
                var results = await _httpClient.SendAsync(requestData);
                var apiErgebnis = await results.Content.ReadAsStringAsync();

                if (results.StatusCode != HttpStatusCode.OK)
                {
                    _logger.LogError($"Fehler bei der API-Anfrage: {apiErgebnis}, StatusCode: {results.StatusCode}, ReasonPhrase: {results.ReasonPhrase}");
                    throw new Exception($"Fehler: {apiErgebnis}");
                }

                _logger.LogInformation("API-Antwort erfolgreich empfangen.");
                return JsonConvert.DeserializeObject<List<KundeModel>>(apiErgebnis) ?? new List<KundeModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Abrufen der Kunden: {ex.Message}");
                throw;
            }
        }

        private void GetApiSettings(out Uri baseUriAuth, out Uri baseUriApi, out string userName, out string passwort, out string license, out string clientId, out string clientSecret)
        {
            license = _configuration["ApiSettings:License"] ?? throw new ArgumentNullException("ApiSettings:License");
            baseUriAuth = new Uri(_configuration["ApiSettings:BaseUriAuth"] ?? throw new ArgumentNullException("ApiSettings:BaseUriAuth"));
            baseUriApi = new Uri(_configuration["ApiSettings:BaseUriApi"] ?? throw new ArgumentNullException("ApiSettings:BaseUriApi"));
            userName = _configuration["ApiSettings:UserName"] ?? throw new ArgumentNullException("ApiSettings:UserName");
            passwort = _configuration["ApiSettings:Password"] ?? throw new ArgumentNullException("ApiSettings:Password");
            clientId = _configuration["ApiSettings:ClientId"] ?? throw new ArgumentNullException("ApiSettings:ClientId");
            clientSecret = _configuration["ApiSettings:ClientSecret"] ?? throw new ArgumentNullException("ApiSettings:ClientSecret");
        }

        private async Task<(string, DateTime, string)> GetBearerToken(HttpClient httpClient, Uri baseUriAuth, string userName, string passwort, string clientId, string clientSecret, string? bearerToken, DateTime bearerExpireTimeUtc, string? refreshToken)
        {
            var restGueltig = bearerExpireTimeUtc - DateTime.UtcNow;
            if (!string.IsNullOrEmpty(bearerToken) && !string.IsNullOrEmpty(refreshToken) && restGueltig.TotalSeconds > 20)
            {
                _logger.LogInformation("Aktuelles Bearer Token ist noch gültig.");
            }
            else
            {
                if (!string.IsNullOrEmpty(bearerToken) && !string.IsNullOrEmpty(refreshToken))
                {
                    _logger.LogInformation("Bearer Token ist abgelaufen, neues Token über Refresh Token wird angefordert.");
                    string grantStr = $"grant_type=refresh_token&refresh_token={Uri.EscapeDataString(refreshToken)}&scope=offline_access%20drive";
                    (bearerToken, bearerExpireTimeUtc, refreshToken) = await GetBearerTokenCall(httpClient, baseUriAuth, clientId, clientSecret, grantStr);
                }
                if (string.IsNullOrEmpty(bearerToken) || string.IsNullOrEmpty(refreshToken))
                {
                    _logger.LogInformation("Kein gültiger Bearer Token oder Refresh Token vorhanden, neues Token wird angefordert.");
                    string grantStr = $"grant_type=password&username={Uri.EscapeDataString(userName)}&password={Uri.EscapeDataString(passwort)}&scope=offline_access%20drive";
                    (bearerToken, bearerExpireTimeUtc, refreshToken) = await GetBearerTokenCall(httpClient, baseUriAuth, clientId, clientSecret, grantStr);
                }
            }
            return (bearerToken ?? string.Empty, bearerExpireTimeUtc, refreshToken ?? string.Empty);
        }

        private async Task<(string, DateTime, string)> GetBearerTokenCall(HttpClient httpClient, Uri baseUriAuth, string clientId, string clientSecret, string grantStr)
        {
            try
            {
                var encodedPair = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

                var requestToken = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(baseUriAuth, "connect/token"),
                    Content = new StringContent(grantStr)
                };
                requestToken.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded") { CharSet = "UTF-8" };
                requestToken.Headers.TryAddWithoutValidation("Authorization", $"Basic {encodedPair}");

                _logger.LogInformation($"Token-Anfrage wird gesendet an {requestToken.RequestUri}");
                var bearerResult = await httpClient.SendAsync(requestToken);
                var bearerData = await bearerResult.Content.ReadAsStringAsync();

                if (bearerResult.StatusCode != HttpStatusCode.OK)
                {
                    _logger.LogError($"Fehler bei der Token-Anfrage: StatusCode: {bearerResult.StatusCode}, ReasonPhrase: {bearerResult.ReasonPhrase}, Response: {bearerData}");
                    throw new Exception($"Fehler bei der Token-Anfrage: {bearerData}");
                }

                _logger.LogInformation("Token erfolgreich empfangen.");
                var tokenResponse = JObject.Parse(bearerData);
                _bearerToken = tokenResponse["access_token"]?.ToString();
                var expiresIn = int.Parse(tokenResponse["expires_in"]?.ToString() ?? "0");
                _bearerExpireTimeUtc = DateTime.UtcNow.AddSeconds(expiresIn);
                _refreshToken = tokenResponse["refresh_token"]?.ToString();

                return (_bearerToken ?? string.Empty, _bearerExpireTimeUtc, _refreshToken ?? string.Empty);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Abrufen des Bearer Tokens: {ex.Message}");
                throw;
            }
        }
    }
}
