using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Common
{
    public interface IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }

    public class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
