using System.Net.Http.Json;
using AutoSzereloMuhely.Domain;

namespace AutoSzereloMuly.Client.Services;

public class UgyfelService : IUgyfelService
{

    private readonly HttpClient _httpClient;

    public UgyfelService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<Ugyfel>> GetUgyfelAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Ugyfel>>("ugyfel");
    }

    public async Task<Ugyfel> GetUgyfelAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Ugyfel>($"ugyfel/{id}");
    }

    public async Task AddUgyfelAsync(Ugyfel ugyfel)
    {
        await _httpClient.PostAsJsonAsync("ugyfel", ugyfel);
    }

    public async Task UpdateUgyfelAsync(int id, Ugyfel ugyfel)
    {
        await _httpClient.PutAsJsonAsync($"ugyfel/{id}", ugyfel);
    }

    public async Task DeleteUgyfelAsync(int id)
    {
        await _httpClient.DeleteAsync($"ugyfel/{id}");
    }
}