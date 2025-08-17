namespace Application.interfaces
{
    public interface IProcessingPaymentService
    {
        public Task ProcessingPayment(long account);
    }
}