using AutoSzereloMuhely.Domain;

namespace AutoSzereloMuhely.API.Services;

public class MunkaService : IMunkaService
{

    private readonly DataContext _context;

    public MunkaService(DataContext munkak)
    {
        _context = munkak;
    }
    
    public void Add(Munka munka)
    {
        _context.Munkak.Add(munka);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var munka = _context.Munkak.Find(id);
        if (munka is not null)
        {
            _context.Munkak.Remove(munka);
            _context.SaveChanges();
        }
        
    }

    public List<Munka> GetAll()
    {
        return _context.Munkak.ToList();
    }

    public Munka Get(int id)
    {
        var munka = _context.Munkak.Find(id);
        return munka ?? throw new KeyNotFoundException($"Nem található munka azonosítóval: {id}");;
        
    }

    public void Update(Munka munka)
    {
        _context.Munkak.Update(munka);
        _context.SaveChanges();

    }
}