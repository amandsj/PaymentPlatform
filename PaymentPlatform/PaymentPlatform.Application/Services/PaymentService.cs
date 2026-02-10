using PaymentPlatform.Application.Interfaces;
using PaymentPlatform.Domain.Entities;

namespace PaymentPlatform.Application.Services;

public class PaymentService
{
    private readonly IPaymentRepository _repository;

    public PaymentService(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public Payment Create(decimal amount, string description)
    {
        var payment = new Payment(amount, description);

        _repository.Add(payment);

        return payment;
    }

    public void Process(Guid id, bool approved)
    {
        var payment = _repository.GetById(id);

        if (payment == null)
            throw new Exception("Pagamento não encontrado.");

        if (approved)
            payment.MarkAsPaid();
        else
            payment.Refuse();

        _repository.Update(payment);
    }
}
