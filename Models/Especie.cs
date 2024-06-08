using System.ComponentModel.DataAnnotations;

public class Especie
{
    [Key]
    public int CdEspecie { get; set; }

    [MaxLength(100)]
    public string NmCientifico { get; set; }

    [MaxLength(100)]
    public string NmPopular { get; set; }

    [MaxLength(500)]
    public string DsFoto { get; set; }

    [MaxLength(500)]
    public string DsDescricao { get; set; }

    public ICollection<Captura> Capturas { get; set; }
}
