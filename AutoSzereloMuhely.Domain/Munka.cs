using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.VisualBasic.CompilerServices;

namespace AutoSzereloMuhely.Domain;

public class Munka
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MunkaID { get; set; }

    [Required]
    [RegularExpression("^[A-Z]{3}-\\d{3}$$")]
    public string UgyfelId { get; set; }

    [Required]
    [Range(typeof(int), "1900", "9999")] 
    public int GyartasEve { get; set; }

    [Required]
    public EKategoria Kategoria { get; set; }
    
    [Required]
    public string Leiras { get; set; }
    
    [Required]
    [Range(1,10)]
    public int Sulyossag { get; set; }

    [Required]
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