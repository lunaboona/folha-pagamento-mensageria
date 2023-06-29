import { Injectable } from '@nestjs/common';
import { FolhaCalculada } from './dto/folha-calculada.dto';
import { Folha } from './dto/folha.dto';
import { RabbitMQService } from 'src/rmq/rmq.service';

@Injectable()
export class FolhaService {
  constructor(private readonly rmq: RabbitMQService) {}

  public cadastrar(folha: Folha): void {
    const bruto = this.getSalarioBruto(folha.horas, folha.valor);

    const folhaCalculada: FolhaCalculada = {
      ...folha,
      bruto: bruto,
      fgts: this.getValorFGTS(bruto),
      inss: this.getValorINSS(bruto),
      irrf: this.getValorIR(bruto),
    };

    folhaCalculada.liquido =
      folhaCalculada.bruto - folhaCalculada.irrf - folhaCalculada.inss;

    return this.rmq.send(folhaCalculada);
  }

  private getSalarioBruto(horas: number, valor: number): number {
    return horas * valor;
  }

  private getValorIR(bruto: number): number {
    if (bruto >= 4664.68) {
      return bruto * 0.275 - 869.36;
    } else if (bruto >= 3751.06 && bruto <= 4664.68) {
      return bruto * 0.225 - 636.13;
    } else if (bruto >= 2826.66 && bruto <= 3751.05) {
      return bruto * 0.15 - 354.8;
    } else if (bruto >= 1903.99 && bruto <= 2826.65) {
      return bruto * 0.075 - 142.8;
    } else {
      return 0;
    }
  }

  private getValorINSS(bruto: number): number {
    if (bruto >= 5645.81) {
      return 621.03;
    } else if (bruto >= 2822.91 && bruto <= 5645.8) {
      return bruto * 0.11;
    } else if (bruto >= 1693.73 && bruto <= 2822.9) {
      return bruto * 0.9;
    } else {
      return bruto * 0.8;
    }
  }

  private getValorFGTS(bruto: number): number {
    return bruto * 0.08;
  }
}
