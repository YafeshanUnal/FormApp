namespace Core.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Core.Domain.Common;
    using Core.Domain.Common.Interfaces;

    public class User : AuditedEntity<Guid>
    {
        [StringLength(50)]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
