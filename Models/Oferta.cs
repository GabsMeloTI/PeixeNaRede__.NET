using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Oferta
{
    [Key]
    public int CdOferta { get; set; }

    [MaxLength(100)]
    public string DsEspecie { get; set; }

    public int DsQuantidade { get; set; }

    public float VlPreco { get; set; }

    [MaxLength(50)]
    public string DsStatus { get; set; }

    public int CdEncontro { get; set; }

    [ForeignKey("CdEncontro")]
    public Encontro Encontro { get; set; }
}