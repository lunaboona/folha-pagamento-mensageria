export interface Folha {
  mes: number;
  ano: number;
  horas: number;
  valor: number;
  funcionario: {
    nome: string;
    cpf: string;
  };
}
