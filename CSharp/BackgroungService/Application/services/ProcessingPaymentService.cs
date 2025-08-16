namespace Application.services
{
    public class ProcessingPaymentService : IProcessingPaymentService
    {
        public async Task ProcessingPayment(long account)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Processing payment for account number: {account}.");

            // do work here.
            await Task.Delay(TimeSpan.FromSeconds(15));

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Payment made successfully!");
        }
    }
}