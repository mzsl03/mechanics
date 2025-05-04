namespace AutoSzereloMuhely.Domain;

public class UgyfelService : IUgyfelService
{
    private readonly List<Ugyfel> _ugyfelek = [];
    
    public void Add(Ugyfel ugyfel)
    {
        _ugyfelek.Add(ugyfel);
    }

    public List<Ugyfel> GetAll()
    {
        return _ugyfelek;
    }

    public Ugyfel Get(int id)
    {
        var ugyfel = _ugyfelek.Find(x => x.UgyfelId == id);
        return ugyfel ?? throw new KeyNotFoundException($"Nem található ügyfél azonosítóval: {id}");;
        
    }
}