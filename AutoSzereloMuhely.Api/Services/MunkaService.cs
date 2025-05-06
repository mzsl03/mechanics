using AutoSzereloMuhely.Domain;

namespace AutoSzereloMuhely.API.Services;

public class MunkaService : IMunkaService
{

    private readonly DataContext _munkak;

    public MunkaService(DataContext munkak)
    {
        _munkak = munkak;
    }
    
    public void Add(Munka munka)
    {
        _munkak.Munkak.Add(munka);
        _munkak.SaveChanges();
    }

    public void Delete(int id)
    {
        var munka = _munkak.Munkak.Find(id);
        if (munka is not null)
        {
            _munkak.Munkak.Remove(munka);    
        }
        
    }

    public List<Munka> GetAll()
    {
        return _munkak.Munkak.ToList();
    }

    public Munka Get(int id)
    {
        var munka = _munkak.Munkak.Find(id);
        return munka ?? throw new KeyNotFoundException($"Nem található munka azonosítóval: {id}");;
        
    }

    public void Update(Munka munka)
    {
        _munkak.Munkak.Update(munka);
        _munkak.SaveChanges();

    }
}