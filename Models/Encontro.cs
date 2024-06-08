using System.ComponentModel.DataAnnotations;

public class Encontro
{
    [Key]
    public int CdEncontro { get; set; }

    public DateTime DtEncontro { get; set; }

    [MaxLength(100)]
    public string DsLocal { get; set; }

    [MaxLength(50)]
    public string DsStatus { get; set; }

    public ICollection<EncontroUsuario> EncontrosUsuarios { get; set; }

    public ICollection<Oferta> Ofertas { get; set; }
}