using PaymentPlatform.Application.Interfaces;
using PaymentPlatform.Domain.Entities;

namespace PaymentPlatform.Infrastructure.Repositories;

public class InMemoryPaymentRepository : IPaymentRepository
{
    private readonly List<Payment> _payments = new();

    public void Add(Payment payment)
    {
        _payments.Add(payment);
    }

    public Payment? GetById(Guid id)
    {
        return _payments.FirstOrDefault(p => p.Id == id);
    }

    public void Update(Payment payment)
    {
        var existing = _payments.FirstOrDefault(p => p.Id == payment.Id);

        if (existing == null)
            throw new Exception("Pagamento não encontrado para atualização.");

        _payments.Remove(existing);
        _payments.Add(payment);
    }
}
