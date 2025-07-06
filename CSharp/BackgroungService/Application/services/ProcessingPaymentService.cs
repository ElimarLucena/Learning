namespace Application.services
{
    public class ProcessingPaymentService : IProcessingPaymentService
    {
        public async Task ProcessingPayment()
        {
            int retry = 0;
            while (retry <= 20)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Processing payment: attempt {retry}");
                Thread.Sleep(1000);
                retry += 1;
            }
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("payment made successfully!");
        }
    }
}