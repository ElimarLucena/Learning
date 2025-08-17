using Application.interfaces;

namespace Application.services;

public class ProcessingPaymentService(
    ISendPaymentNotificationMail sendPaymentNotificationMail
) 
    : IProcessingPaymentService
{
    private readonly ISendPaymentNotificationMail _sendPaymentNotificationMail = sendPaymentNotificationMail;

    public async Task ProcessingPayment(long account)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Processing payment for account number: {account}.");

        // do work here.
        await Task.Delay(TimeSpan.FromSeconds(15));

        // Fire-and-forget: https://techcommunity.microsoft.com/blog/educatordeveloperblog/fire-and-forget-methods-in-c-%E2%80%94-best-practices--pitfalls/4299605
        _ = Task.Run(async () => await _sendPaymentNotificationMail.PaymentNotificationMail(account));

        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("Payment made successfully!");
    }
}
