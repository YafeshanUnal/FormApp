using System.ComponentModel.DataAnnotations;
using Core.Domain.Common;

namespace Core.Domain.Entities
{
    public class Form : AuditedEntity<Guid>
    {
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public string Fields { get; set; }
    }
}
