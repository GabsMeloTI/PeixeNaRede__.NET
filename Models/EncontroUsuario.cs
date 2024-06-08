using System.ComponentModel.DataAnnotations.Schema;

public class EncontroUsuario
{
    public int CdUsuario { get; set; }

    public int CdEncontro { get; set; }

    [ForeignKey("CdUsuario")]
    public Usuario Usuario { get; set; }

    [ForeignKey("CdEncontro")]
    public Encontro Encontro { get; set; }
}
