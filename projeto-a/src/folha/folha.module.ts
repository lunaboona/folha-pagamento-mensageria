import { Module } from '@nestjs/common';
import { FolhaController } from './folha.controller';
import { FolhaService } from './folha.service';
import { RabbitMQModule } from 'src/rmq/rmq.module';

@Module({
  imports: [RabbitMQModule],
  controllers: [FolhaController],
  providers: [FolhaService],
})
export class FolhaModule {}
