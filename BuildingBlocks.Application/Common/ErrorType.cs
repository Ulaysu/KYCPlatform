using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Application.Common
{
    public enum ErrorType
    {
        Validation,
        Conflict,
        NotFound,
        Unauthorized,
        Forbidden,
        Failure
    }
}
