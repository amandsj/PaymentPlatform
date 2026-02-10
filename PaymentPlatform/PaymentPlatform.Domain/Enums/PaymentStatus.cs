using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentPlatform.Domain.Enums
{
    public enum PaymentStatus
    {
        Pending = 0,
        Paid = 1,
        Refused = 2,
        Cancelled = 3
    }
}
