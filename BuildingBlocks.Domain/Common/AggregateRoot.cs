using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.Domain.Common
{
    public abstract class AggregateRoot : BaseEntity
    {
        protected AggregateRoot() : base()
        {
            
        }
    }
}
