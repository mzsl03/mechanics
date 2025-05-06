using AutoSzereloMuhely.Domain;

namespace AutoSzereloMuhely.API.Services;

public class UgyfelService : IUgyfelService
{
    private readonly DataContext _ugyfelek;

    public UgyfelService(DataContext ugyfelek)
    {
        _ugyfelek = ugyfelek;
    }
    
    public void Add(Ugyfel ugyfel)
    {
        _ugyfelek.Ugyfelek.Add(ugyfel);
        _ugyfelek.SaveChanges();
    }

    public List<Ugyfel> GetAll()
    {
        return _ugyfelek.Ugyfelek.ToList();
    }

    public Ugyfel Get(int id)
    {
        var ugyfel = _ugyfelek.Ugyfelek.Find(id);
        return ugyfel ?? throw new KeyNotFoundException($"Nem található ügyfél azonosítóval: {id}");;
        
    }

    public void Delete(int id)
    {
        var ugyfel = _ugyfelek.Ugyfelek.Find(id);
        if (ugyfel is not null)
        {
            _ugyfelek.Ugyfelek.Remove(ugyfel);
            _ugyfelek.SaveChanges();
        }
        
    }
}