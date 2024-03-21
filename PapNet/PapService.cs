using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using PapNet.Models;

namespace PapNet;

public class PapService : IPapService
{
    private readonly IHttpClientFactory _clientFactory;
    public PapService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<T> SendRequestAsync<T>(PapRequest request) where T : PapResponse
    {
        var client = _clientFactory.CreateClient("PapService");
        var response = await client.PostAsync("server.php", request.ToFormData());
        var papResponse = await response.Content.ReadFromJsonAsync<PapGenericResponse>();
        if (papResponse is null) throw new ArgumentNullException("Pap returned null");
        if (!papResponse.Success) throw new Exception("Pap error");
        return (T)Activator.CreateInstance(typeof(T), papResponse)!;
    }

    public async Task TrackAsync(PapParamRequest request)
    {
        var client = _clientFactory.CreateClient("PapTracking");
        var response = await client.GetAsync("?" + request.ToQueryParameters());
        if (!response.IsSuccessStatusCode) throw new Exception("Pap error");
    }
}
