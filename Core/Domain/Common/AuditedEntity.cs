using System;
using System.Collections.Generic;
using Core.Domain.Common.Interfaces;

namespace Core.Domain.Common
{
    public abstract class AuditedEntity<T> : BaseEntity, ICreateDate
    {
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
