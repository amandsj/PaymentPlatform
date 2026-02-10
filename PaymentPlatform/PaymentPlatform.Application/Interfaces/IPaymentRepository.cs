using PaymentPlatform.Domain.Entities;

namespace PaymentPlatform.Application.Interfaces;

public interface IPaymentRepository
{
    void Add(Payment payment);
    Payment? GetById(Guid id);
    void Update(Payment payment);
}
