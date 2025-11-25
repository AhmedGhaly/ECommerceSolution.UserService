using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Dto
{
    public record LoginRequest (
        string? Email,
        string? Password);
}
