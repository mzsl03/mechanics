using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSzereloMuhely.Domain;

public class Ugyfel
{
    [Key]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UgyfelId { get; set; }

    [Required]
    public string UgyfelNev { get; set; }
    
    [Required]
    public string Lakcim { get; set; }

    [Required]
    [EmailAddress] 
    public string Email { get; set; }

}