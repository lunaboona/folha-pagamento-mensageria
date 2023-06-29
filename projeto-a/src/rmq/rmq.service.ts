import { Injectable, Inject } from '@nestjs/common';
import { ClientProxy } from '@nestjs/microservices';

@Injectable()
export class RabbitMQService {
  constructor(@Inject('projeto-a') private readonly client: ClientProxy) {}

  public send(data: any): void {
    this.client.send('', JSON.stringify(data)).toPromise();
  }
}
