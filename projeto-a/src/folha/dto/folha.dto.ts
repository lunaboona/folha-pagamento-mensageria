import { ApiProperty } from '@nestjs/swagger';

export class Funcionario {
  @ApiProperty()
  nome: string;
  @ApiProperty()
  cpf: string;
}

export class Folha {
  @ApiProperty()
  mes: number;
  @ApiProperty()
  ano: number;
  @ApiProperty()
  horas: number;
  @ApiProperty()
  valor: number;
  @ApiProperty()
  funcionario: Funcionario;
}
