using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Usuario
{
    [Key]
    public int CdUsuario { get; set; }

    [Required, MaxLength(150)]
    public string NmUsuario { get; set; }

    [Required, MaxLength(200)]
    public string DsEmail { get; set; }

    [Required, MaxLength(20)]
    public string DsSenha { get; set; }

    [Required, MaxLength(10)]
    public string DsTipo { get; set; }

    [MaxLength(2)]
    public string DsLocalizacao { get; set; }

    [MaxLength(500)]
    public string DsFotoPerfil { get; set; }

    public int CdPescaria { get; set; }

    [ForeignKey("CdPescaria")]
    public Pescaria Pescaria { get; set; }

    public ICollection<EncontroUsuario> EncontrosUsuarios { get; set; }
}


