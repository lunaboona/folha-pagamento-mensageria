import { Body, Controller, Post } from '@nestjs/common';
import { FolhaService } from './folha.service';
import { Folha } from './dto/folha.dto';

@Controller({ path: 'folha' })
export class FolhaController {
  constructor(private readonly folhaService: FolhaService) {}

  @Post('cadastrar')
  registrar(@Body() folha: Folha): void {
    return this.folhaService.cadastrar(folha);
  }
}
