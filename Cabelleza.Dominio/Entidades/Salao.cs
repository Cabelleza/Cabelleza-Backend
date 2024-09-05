using System.ComponentModel.DataAnnotations;

namespace Cabelleza.Dominio.Entidades;

public class Salao
{
    [Key]
    public Guid Guid { get; set; }
    public string? NomeSalao { get; set; }
    public string? CNPJ { get; set; }
    public string? TelefoneSalao { get; set; }
    public string? NomeProprietario { get; set; }
    public string? EmailSalao { get; set; }
    public string? Senha { get; set; }
    public byte[]? Imagem { get; set; } 
    public string? CEP { get; set; }
    public string? Endereco { get; set; }
    public string? Numero { get; set; }
    public string? Cidade { get; set; }
    public string? Bairro { get; set; }
    public string? Complemento { get; set; }
}
