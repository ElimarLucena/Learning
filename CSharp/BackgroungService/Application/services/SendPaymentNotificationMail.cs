using Application.interfaces;

namespace Application.services;

public class SendPaymentNotificationMail : ISendPaymentNotificationMail
{
    public async Task PaymentNotificationMail(long account)
    {
        int count = 0;

        while (count <= 10)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Sending payment notification mail for account number: {account}.");

            // Create logic (saving to DB, etc...)

            count += 1;
            await Task.Delay(TimeSpan.FromSeconds(10));
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Sending payment notification mail completed.");
    }
}