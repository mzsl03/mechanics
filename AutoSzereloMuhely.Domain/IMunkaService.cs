namespace AutoSzereloMuhely.Domain;

public interface IMunkaService
{
    void Add(Munka munka);

    void Delete(int id);

    List<Munka> GetAll();
    Munka Get(int id);

    void Update(Munka munka);

}