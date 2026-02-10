using PaymentPlatform.Domain.Enums;

namespace PaymentPlatform.Domain.Entities;

public class Payment
{
    public Guid Id { get; private set; }
    public decimal Amount { get; private set; }
    public string Description { get; private set; }
    public PaymentStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Payment(decimal amount, string description)
    {
        if (amount <= 0)
            throw new ArgumentException("O valor do pagamento deve ser maior que zero.");

        Id = Guid.NewGuid();
        Amount = amount;
        Description = description;
        Status = PaymentStatus.Pending;
        CreatedAt = DateTime.UtcNow;
    }

    public void MarkAsPaid()
    {
        Status = PaymentStatus.Paid;
    }

    public void Refuse()
    {
        Status = PaymentStatus.Refused;
    }

    public void Cancel()
    {
        if (Status == PaymentStatus.Paid)
            throw new InvalidOperationException("Não é possível cancelar um pagamento já pago.");

        Status = PaymentStatus.Cancelled;
    }
}
