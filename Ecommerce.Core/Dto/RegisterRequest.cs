using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Dto
{
    public record RegisterRequest(
        string? Name,
        string? Password,
        string? Email,
        GenderOptions Gender);

}
