using AutoSzereloMuhely.Domain;

namespace AutoSzereloMuhely.Client.Services;

public interface IMunkaService
{
    Task<List<Munka>> GetMunkaAsync();

    Task<Munka> GetMunkaAsync(int id);

    Task AddMunkaAsync(Munka munka);

    Task UpdateMunkaAsync(int id, Munka munka);

    Task DeleteMunkaAsync(int id);
}