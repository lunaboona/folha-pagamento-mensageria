using System.Text;
using ProjetoBApi.Controllers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjetoBApi.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ProjetoNetApi.Services;

public class RabbitMQService : BackgroundService
{
  private readonly FolhaContext _context;

  public RabbitMQService(IDbContextFactory<FolhaContext> folhaContextFactory)
  {
    _context = folhaContextFactory.CreateDbContext();
  }

  protected override Task ExecuteAsync(CancellationToken stoppingToken)
  {
      ConnectionFactory factory = new ConnectionFactory
      {
          HostName = "localhost"
      };
      var connection = factory.CreateConnection();

      var channel = connection.CreateModel();

      var consumer = new EventingBasicConsumer(channel);
      consumer.Received += async (model, message) =>
      {
          var body = message.Body.ToArray();
          var conteudoString = Encoding.UTF8.GetString(body);
          var messageJson = JsonConvert.DeserializeObject<MessageJson>(conteudoString);
          var folhaDTO = JsonConvert.DeserializeObject<FolhaCalculadaDTO>(messageJson.Data);

          if (folhaDTO != null) {
            var folha = FolhaCalculada.fromDTO(folhaDTO);
            _context.Folhas.Add(folha);
            await _context.SaveChangesAsync();
          }
          
          Console.WriteLine(conteudoString);
      };
      channel.BasicConsume(
          queue: "folha-pagamento",
          autoAck: true,
          consumer: consumer
      );
      return Task.CompletedTask;
  }
}