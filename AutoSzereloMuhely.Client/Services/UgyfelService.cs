using System.Net.Http.Json;
using AutoSzereloMuhely.Domain;

namespace AutoSzereloMuhely.Client.Services;

public class UgyfelService : IUgyfelService
{
    private readonly HttpClient _httpClient;

    public UgyfelService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Ugyfel>?> GetAllUgyfelAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Ugyfel>>("api/ugyfel");
    }

    public async Task<Ugyfel> GetUgyfelAsync(int id)
    {
        return (await _httpClient.GetFromJsonAsync<Ugyfel>($"api/ugyfel/{id}"))!;
    }

    public async Task AddUgyfelAsync(Ugyfel ugyfel)
    {
        await _httpClient.PostAsJsonAsync("api/ugyfel", ugyfel);
    }

    public async Task UpdateUgyfelAsync(int id, Ugyfel ugyfel)
    {
        await _httpClient.PutAsJsonAsync($"api/ugyfel/{id}", ugyfel);
    }

    public async Task DeleteUgyfelAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/ugyfel/{id}");
    }
}