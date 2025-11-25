using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core.Dto
{
    public record AuthenticationResponse(
        Guid UserId,
        string? Name, 
        string? Email,
        string? Gender,
        string? Token,
        bool sucess
        );
}
