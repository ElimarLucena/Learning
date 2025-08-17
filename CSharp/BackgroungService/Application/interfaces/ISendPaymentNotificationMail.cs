namespace Application.interfaces;

public interface ISendPaymentNotificationMail
{
    public Task PaymentNotificationMail(long account);
}