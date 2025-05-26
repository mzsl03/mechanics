using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSzereloMuhely.Domain;

public class Ugyfel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UgyfelId { get; set; }

    [Required(ErrorMessage = "Kérem létező nevet adjon meg, 'Abroncs Péter' formátumban!")]
    [RegularExpression("^[A-ZÁÉÍÓÖŐÚÜŰ][a-záéíóöőúüű]+ [A-ZÁÉÍÓÖŐÚÜŰ][a-záéíóöőúüű]+$",ErrorMessage = "Kérem létező nevet adjon meg, 'Abroncs Péter' formátumban!")]
    public string UgyfelNev { get; set; }
    
    [Required(ErrorMessage = "A lakcím megadásáa kötelező!")]
    public string Lakcim { get; set; }

    [Required(ErrorMessage = "Kérem érvényes e-mail címet adjon meg!")]
    [EmailAddress(ErrorMessage = "Kérem érvényes e-mail címet adjon meg!")] 
    public string Email { get; set; }

}