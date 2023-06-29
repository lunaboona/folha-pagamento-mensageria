namespace ProjetoBApi.Models;

public class FolhaCalculada
{
  public long Id { get; set; }
  public int? Mes { get; set; }
  public int? Ano { get; set; }
  public int? Horas { get; set; }
  public double? Valor { get; set; }
  public double? Bruto { get; set; }
  public double? Irrf { get; set; }
  public double? Inss { get; set; }
  public double? Fgts { get; set; }
  public double? Liquido { get; set; }
  public string? Funcionario { get; set; }
}