using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Captura
{
    [Key]
    public int CdCaptura { get; set; }

    public int DsQuantidade { get; set; }

    public float DsPeso { get; set; }

    [MaxLength(500)]
    public string DsFoto { get; set; }

    public int CdEspecie { get; set; }

    [ForeignKey("CdEspecie")]
    public Especie Especie { get; set; }

    public int CdPescaria { get; set; }

    [ForeignKey("CdPescaria")]
    public Pescaria Pescaria { get; set; }
}

