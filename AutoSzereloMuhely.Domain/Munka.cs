using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace AutoSzereloMuhely.Domain;

public class Munka
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MunkaID { get; set; }
    
    
    public int UgyfelId { get; set; }
    
    [JsonIgnore]
    [ForeignKey(nameof(UgyfelId))]
    public Ugyfel? Ugyfel { get; set; }
    
    [Required(ErrorMessage = "Kérem a következő formátumban adja meg a rendszámot: 'AAA-111'!")]
    [RegularExpression("^[A-Z]{3}-\\d{3}$", ErrorMessage = "Kérem a következő formátumban adja meg a rendszámot: 'AAA-111'!")]
    public string Rendszam { get; set; }

    [Required(ErrorMessage = "Kérem adja meg a jármű gyártási évét! (min. 1900)")]
    [Range(typeof(int), "1900", "9999",ErrorMessage = "Kérem adja meg a jármű gyártási évét! (min. 1900)")] 
    public int GyartasEve { get; set; }

    [Required(ErrorMessage = "Kérem válasszon kategóriát!")]
    public EKategoria Kategoria { get; set; }
    
    [Required(ErrorMessage = "Kérem adjon egy rövid jellemzést a hibáról!")]
    public string Leiras { get; set; }
    
    [Required(ErrorMessage = "Kérem adja meg a hiba súlyosságát 1-10 között!")]
    [Range(1,10,ErrorMessage = "Kérem adja meg a hiba súlyosságát 1-10 között!")]
    public int Sulyossag { get; set; }

    [Required(ErrorMessage = "Kérem adja meg a munka állapotát!")]
    public EAllapot Allapot { get; set; } = EAllapot.Felvett;

}

public enum EKategoria
{
    Karosszeria,
    Motor,
    Futomu,
    Fekberendezes
}

public enum EAllapot
{
    Felvett,
    ElvegzesAlatt,
    Befejezett
}