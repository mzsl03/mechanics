namespace AutoSzereloMuhely.Domain;

public interface IUgyfelService
{
    
    void Add(Ugyfel ugyfel);

    List<Ugyfel> GetAll();

    Ugyfel? Get(int id);

    void Delete(int id);

}