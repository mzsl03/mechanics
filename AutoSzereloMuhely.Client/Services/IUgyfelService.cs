using AutoSzereloMuhely.Domain;

namespace AutoSzereloMuly.Client.Services;

public interface IUgyfelService
{
    Task<List<Ugyfel>> GetUgyfelAsync();

    Task<Ugyfel> GetUgyfelAsync(int id);

    Task AddUgyfelAsync(Ugyfel ugyfel);

    Task UpdateUgyfelAsync(int id, Ugyfel ugyfel);

    Task DeleteUgyfelAsync(int id);
}