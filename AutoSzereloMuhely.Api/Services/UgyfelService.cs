using AutoSzereloMuhely.Domain;

namespace AutoSzereloMuhely.API.Services;

public class UgyfelService : IUgyfelService
{
    private readonly DataContext _context;

    public UgyfelService(DataContext ugyfelek)
    {
        _context = ugyfelek;
    }
    
    public void Add(Ugyfel ugyfel)
    {
        _context.Ugyfelek.Add(ugyfel);
        _context.SaveChanges();
    }

    public List<Ugyfel> GetAll()
    {
        return _context.Ugyfelek.ToList();
    }

    public Ugyfel? Get(int id)
    {
        return _context.Ugyfelek.Find(id); 
    }

    public void Delete(int id)
    {
        var ugyfel = _context.Ugyfelek.Find(id);
        if (ugyfel is not null)
        {
            _context.Ugyfelek.Remove(ugyfel);
            _context.SaveChanges();
        }
        
    }
}