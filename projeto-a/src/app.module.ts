import { Module } from '@nestjs/common';
import { FolhaModule } from './folha/folha.module';

@Module({
  imports: [FolhaModule],
})
export class AppModule {}
