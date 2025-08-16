namespace Application.services
{
    public interface IProcessingPaymentService
    {
        public Task ProcessingPayment(long account);
    }
}