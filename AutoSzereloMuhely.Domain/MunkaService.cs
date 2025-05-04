namespace AutoSzereloMuhely.Domain;

public class MunkaService : IMunkaService
{

    private readonly List<Munka> _munkak = [];
    
    public void Add(Munka munka)
    {
        _munkak.Add(munka);
    }

    public void Delete(int id)
    {
        _munkak.RemoveAll(x => x.MunkaID == id);
    }

    public List<Munka> GetAll()
    {
        return _munkak;
    }

    public Munka Get(int id)
    {
        var munka = _munkak.Find(x => x.MunkaID == id);
        return munka ?? throw new KeyNotFoundException($"Nem található munka azonosítóval: {id}");;
        
    }

    public void Update(Munka munka)
    {
        var oldMunka = Get(munka.MunkaID);

        oldMunka.MunkaID = munka.MunkaID;
        oldMunka.Allapot = munka.Allapot;
        oldMunka.Kategoria = munka.Kategoria;
        oldMunka.Leiras = munka.Leiras;
        oldMunka.UgyfelId = munka.UgyfelId;
        oldMunka.Sulyossag = munka.Sulyossag;
        oldMunka.GyartasEve = munka.GyartasEve;

    }
}