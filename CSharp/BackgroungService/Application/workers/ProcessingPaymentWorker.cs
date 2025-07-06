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
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    IProcessingPaymentService? processingPaymentService = scope.ServiceProvider.GetRequiredService<IProcessingPaymentService>();

                    await processingPaymentService.ProcessingPayment();
                    await Task.Delay(1000, stoppingToken);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    throw;
                }
            }
        }
    }
}