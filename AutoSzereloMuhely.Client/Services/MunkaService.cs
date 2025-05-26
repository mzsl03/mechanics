using System.Net.Http.Json;
using AutoSzereloMuhely.Domain;

namespace AutoSzereloMuhely.Client.Services;

public class MunkaService : IMunkaService
{

    private readonly HttpClient _httpClient;

    public MunkaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Munka>> GetMunkaAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<Munka>>("api/munka");
        return response ?? new List<Munka>();
    }

    public async Task<Munka?> GetMunkaAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Munka>($"api/munka/{id}");
    }

    public async Task AddMunkaAsync(Munka munka)
    {
        await _httpClient.PostAsJsonAsync("api/munka", munka);
    }

    public async Task UpdateMunkaAsync(int id, Munka munka)
    {
        await _httpClient.PutAsJsonAsync($"api/munka/{id}", munka);
    }

    public async Task DeleteMunkaAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/munka/{id}");
    }
}