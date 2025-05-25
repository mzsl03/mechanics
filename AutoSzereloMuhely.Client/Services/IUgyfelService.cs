using AutoSzereloMuhely.Domain;

namespace AutoSzereloMuhely.Client.Services;

public interface IUgyfelService
{
    Task<List<Ugyfel>?> GetAllUgyfelAsync();

    Task<Ugyfel> GetUgyfelAsync(int id);

    Task AddUgyfelAsync(Ugyfel ugyfel);

    Task UpdateUgyfelAsync(int id, Ugyfel ugyfel);

    Task DeleteUgyfelAsync(int id);
}