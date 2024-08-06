using System.Collections;
using System.Net;
using System.Net.Http.Headers;
using Assfinet.Shared.Contracts;
using Assfinet.Shared.Models;
using Assfinet.Shared.Configurations;
using Assfinet.Shared.Enums;
using Assfinet.Shared.Exceptions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Assfinet.Shared.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly AssfinetApiSettings _apiSettings;
        private readonly IAppLogger _logger;
        private static string? _bearerToken;
        private static DateTime _bearerExpireTimeUtc;
        private static string? _refreshToken;

        public ApiService(HttpClient httpClient, IOptions<AssfinetApiSettings> apiSettings, IAppLogger logger)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings.Value;
            _logger = logger;
        }

        public async Task<List<KundeModel>> GetKundenAsync(int skip, int take)
        {
            try
            {
                (_bearerToken, _bearerExpireTimeUtc, _refreshToken) = await GetBearerToken(_httpClient,
                    new Uri(_apiSettings.BaseUriAuth), _apiSettings.UserName, _apiSettings.Password,
                    _apiSettings.ClientId, _apiSettings.ClientSecret, _bearerToken, _bearerExpireTimeUtc,
                    _refreshToken);
                _logger.LogInformation("Bearer Token abgerufen.");

                string apiPath =
                    $"v1/Ams/Kunde?orderBy=Id&byDescending=true&skip={skip}&take={take}&accessMode=Admin";
                var requestData = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(new Uri(_apiSettings.BaseUriApi), apiPath),
                };
                requestData.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_bearerToken}");

                _logger.LogInformation($"API-Anfrage wird gesendet an {requestData.RequestUri}");
                var results = await _httpClient.SendAsync(requestData);
                var apiErgebnis = await results.Content.ReadAsStringAsync();

                if (results.StatusCode != HttpStatusCode.OK)
                {
                    _logger.LogError(
                        $"Fehler bei der API-Anfrage: {apiErgebnis}, StatusCode: {results.StatusCode}, ReasonPhrase: {results.ReasonPhrase}");
                    throw new Exception($"Fehler: {apiErgebnis}");
                }

                var kunden = JsonConvert.DeserializeObject<List<KundeModel>>(apiErgebnis) ?? new List<KundeModel>();

                _logger.LogInformation("API-Antwort erfolgreich empfangen.");
                return kunden;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Abrufen der Kunden: {ex.Message}");
                throw;
            }
        }

        public async Task<List<VertragModel>> GetVertraegeAsync(int skip, int take)
        {
            try
            {
                (_bearerToken, _bearerExpireTimeUtc, _refreshToken) = await GetBearerToken(_httpClient,
                    new Uri(_apiSettings.BaseUriAuth), _apiSettings.UserName, _apiSettings.Password,
                    _apiSettings.ClientId, _apiSettings.ClientSecret, _bearerToken, _bearerExpireTimeUtc,
                    _refreshToken);
                _logger.LogInformation("Bearer Token abgerufen.");

                string apiPath =
                    $"v1/Ams/Vertrag?orderBy=LastSynchronisation&byDescending=true&skip={skip}&take={take}&accessMode=Admin&pendingDrafts=false";
                var requestData = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(new Uri(_apiSettings.BaseUriApi), apiPath),
                };
                requestData.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_bearerToken}");

                _logger.LogInformation($"API-Anfrage wird gesendet an {requestData.RequestUri}");
                var results = await _httpClient.SendAsync(requestData);
                var apiErgebnis = await results.Content.ReadAsStringAsync();

                if (results.StatusCode != HttpStatusCode.OK)
                {
                    _logger.LogError(
                        $"Fehler bei der API-Anfrage: {apiErgebnis}, StatusCode: {results.StatusCode}, ReasonPhrase: {results.ReasonPhrase}");
                    throw new Exception($"Fehler: {apiErgebnis}");
                }

                _logger.LogInformation("API-Antwort erfolgreich empfangen.");
                return JsonConvert.DeserializeObject<List<VertragModel>>(apiErgebnis) ?? new List<VertragModel>();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Abrufen der Verträge: {ex.Message}");
                throw;
            }
        }

        // Im ApiService
        public async Task<List<object>> GetSpartenDatenAsync(Spartentypen sparte, int skip, int take)
        {
            try
            {
                (_bearerToken, _bearerExpireTimeUtc, _refreshToken) = await GetBearerToken(_httpClient,
                    new Uri(_apiSettings.BaseUriAuth), _apiSettings.UserName, _apiSettings.Password,
                    _apiSettings.ClientId, _apiSettings.ClientSecret, _bearerToken, _bearerExpireTimeUtc,
                    _refreshToken);
                _logger.LogInformation("Bearer Token abgerufen.");

                string apiPath =
                    $"v1/Ams/Vertrag/Sparte?orderBy=Id&byDescending=true&skip={skip}&take={take}&sparte={sparte}&accessMode=Admin";
                var requestData = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(new Uri(_apiSettings.BaseUriApi), apiPath),
                };
                requestData.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_bearerToken}");

                _logger.LogInformation($"API-Anfrage wird gesendet an {requestData.RequestUri}");
                var results = await _httpClient.SendAsync(requestData);
                var apiErgebnis = await results.Content.ReadAsStringAsync();

                if (results.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(
                        $"Fehler bei der API-Anfrage: {apiErgebnis}, StatusCode: {results.StatusCode}, ReasonPhrase: {results.ReasonPhrase}");
                }
                
                var parseSpartenResponse = ParseSpartenResponse(apiErgebnis, sparte);
                _logger.LogInformation("API-Antwort erfolgreich empfangen.");
                
                return parseSpartenResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim Abrufen der Daten: {ex.Message}", ex);
                throw new Exception($"Fehler beim Abrufen der Daten: {ex.Message}", ex);
            }
        }

        private List<object> ParseSpartenResponse(string responseContent, Spartentypen spartentyp)
        {
            var sparteModelTypes = new Dictionary<Spartentypen, Type>
            {
                { Spartentypen.KRV, typeof(KrvModel) },
                { Spartentypen.DEP, typeof(DepModel) },
                { Spartentypen.IMO, typeof(ImoModel) },
                { Spartentypen.UNF, typeof(UnfModel) }
                // Weitere Spartentypen hier hinzufügen
            };

            if (!sparteModelTypes.TryGetValue(spartentyp, out var modelType))
            {
                _logger.LogWarning("Unbekannte Sparte");
                throw new UnknownSparteException("Unbekannte Sparte");
            }

            var deserializedListType = typeof(List<>).MakeGenericType(modelType);
            var spartenModels = (IList?)JsonConvert.DeserializeObject(responseContent, deserializedListType);

            return spartenModels?.Cast<object>().ToList() ?? new List<object>();
        }


        private async Task<(string, DateTime, string)> GetBearerToken(HttpClient httpClient, Uri baseUriAuth,
            string userName, string passwort, string clientId, string clientSecret, string? bearerToken,
            DateTime bearerExpireTimeUtc, string? refreshToken)
        {
            var restGueltig = bearerExpireTimeUtc - DateTime.UtcNow;
            if (!string.IsNullOrEmpty(bearerToken) && !string.IsNullOrEmpty(refreshToken) &&
                restGueltig.TotalSeconds > 20)
            {
                _logger.LogInformation("Aktuelles Bearer Token ist noch gültig.");
            }
            else
            {
                if (!string.IsNullOrEmpty(bearerToken) && !string.IsNullOrEmpty(refreshToken))
                {
                    _logger.LogInformation(
                        "Bearer Token ist abgelaufen, neues Token über Refresh Token wird angefordert.");
                    string grantStr =
                        $"grant_type=refresh_token&refresh_token={Uri.EscapeDataString(refreshToken)}&scope=offline_access%20drive";
                    (bearerToken, bearerExpireTimeUtc, refreshToken) =
                        await GetBearerTokenCall(httpClient, baseUriAuth, clientId, clientSecret, grantStr);
                }

                if (string.IsNullOrEmpty(bearerToken) || string.IsNullOrEmpty(refreshToken))
                {
                    _logger.LogInformation(
                        "Kein gültiger Bearer Token oder Refresh Token vorhanden, neues Token wird angefordert.");
                    string grantStr =
                        $"grant_type=password&username={Uri.EscapeDataString(userName)}&password={Uri.EscapeDataString(passwort)}&scope=offline_access%20drive";
                    (bearerToken, bearerExpireTimeUtc, refreshToken) =
                        await GetBearerTokenCall(httpClient, baseUriAuth, clientId, clientSecret, grantStr);
                }
            }

            return (bearerToken ?? string.Empty, bearerExpireTimeUtc, refreshToken ?? string.Empty);
        }

        private async Task<(string, DateTime, string)> GetBearerTokenCall(HttpClient httpClient, Uri baseUriAuth,
            string clientId, string clientSecret, string grantStr)
        {
            try
            {
                var encodedPair =
                    Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

                var requestToken = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(baseUriAuth, "connect/token"),
                    Content = new StringContent(grantStr)
                };
                requestToken.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded")
                    { CharSet = "UTF-8" };
                requestToken.Headers.TryAddWithoutValidation("Authorization", $"Basic {encodedPair}");

                _logger.LogInformation($"Token-Anfrage wird gesendet an {requestToken.RequestUri}");
                var bearerResult = await httpClient.SendAsync(requestToken);
                var bearerData = await bearerResult.Content.ReadAsStringAsync();

                if (bearerResult.StatusCode != HttpStatusCode.OK)
                {
                    _logger.LogError(
                        $"Fehler bei der Token-Anfrage: StatusCode: {bearerResult.StatusCode}, ReasonPhrase: {bearerResult.ReasonPhrase}, Response: {bearerData}");
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