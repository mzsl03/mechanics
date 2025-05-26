using AutoSzereloMuhely.Domain;

namespace AutoSzereloMuhely.Client.Services;

public class MunkaOraEstimator
{
    public static string CountMunkaora(Munka munka)
    {
        double kategoriaOra = munka.Kategoria switch
        {
            EKategoria.Karosszeria => 3,
            EKategoria.Motor => 8,
            EKategoria.Futomu => 6,
            EKategoria.Fekberendezes => 4,
            _ => 0
        };

        int ev = DateTime.Now.Year - munka.GyartasEve;
        double korSzorzo = ev switch
        {
            <= 5 => 0.5,
            <= 10 => 1,
            <= 20 => 1.5,
            _ => 2
        };

        double sulyossagSzorzo = munka.Sulyossag switch
        {
            <= 2 => 0.2,
            <= 4 => 0.4,
            <= 7 => 0.6,
            <= 9 => 0.8,
            10 => 1,
            _ => 0
        };

        var eredmeny = Math.Round(kategoriaOra * korSzorzo * sulyossagSzorzo, 2);
        
        return $"Munkaóra becslés: {eredmeny:0.##} óra";
    }
}