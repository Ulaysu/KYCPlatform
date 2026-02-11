using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Application.Common
{
    public sealed record Error
    (
        string Code,
        string Message,
        ErrorType Type
    );
        
    
}
