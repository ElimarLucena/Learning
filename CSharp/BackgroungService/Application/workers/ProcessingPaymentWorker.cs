using Application.services;

namespace Application.workers
{
    public class ProcessingPaymentWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public ProcessingPaymentWorker(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    using var scope = _serviceProvider.CreateScope();
                    IProcessingPaymentService? processingPaymentService =
                        scope.ServiceProvider.GetRequiredService<IProcessingPaymentService>();

                    if (HostedServiceQueue.QueueAccount.TryDequeue(out long result))
                        await processingPaymentService.ProcessingPayment(result);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("ProcessingPaymentWorker running!");

                    await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"Exception: {ex.Message}");
                throw;
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("ProcessingPaymentWorker stopping!");

            await base.StopAsync(stoppingToken);
        }
    }
}