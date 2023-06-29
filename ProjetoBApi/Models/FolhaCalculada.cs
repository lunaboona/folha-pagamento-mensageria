using Newtonsoft.Json;

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

  public static FolhaCalculada fromDTO(FolhaCalculadaDTO dto) {
    var folha = new FolhaCalculada();
    folha.Mes = dto.Mes;
    folha.Ano = dto.Ano;
    folha.Horas = dto.Horas;
    folha.Valor = dto.Valor;
    folha.Bruto = dto.Bruto;
    folha.Irrf = dto.Irrf;
    folha.Inss = dto.Inss;
    folha.Fgts = dto.Fgts;
    folha.Liquido = dto.Liquido;
    folha.Funcionario = JsonConvert.SerializeObject(dto.Funcionario);
    return folha;
  }

  public FolhaCalculadaDTO toDTO() {
    var dto = new FolhaCalculadaDTO();
    dto.Mes = this.Mes;
    dto.Ano = this.Ano;
    dto.Horas = this.Horas;
    dto.Valor = this.Valor;
    dto.Bruto = this.Bruto;
    dto.Irrf = this.Irrf;
    dto.Inss = this.Inss;
    dto.Fgts = this.Fgts;
    dto.Liquido = this.Liquido;
    dto.Funcionario = JsonConvert.DeserializeObject<Funcionario>(this.Funcionario);
    return dto;
  }
}