using System.ComponentModel.DataAnnotations;

public class Pescaria
{
    [Key]
    public int CdPescaria { get; set; }

    public DateTime DtPescaria { get; set; }

    [MaxLength(300)]
    public string DsLocalizacao { get; set; }

    public string DsCondicoesClimaticas { get; set; }

    [MaxLength(50)]
    public string TpPesca { get; set; }

    [MaxLength(100)]
    public string DsMetodoPesca { get; set; }

    public string DsDetalhes { get; set; }

    public ICollection<Usuario> Usuarios { get; set; }

    public ICollection<Captura> Capturas { get; set; }
}