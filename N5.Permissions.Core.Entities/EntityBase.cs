using System.ComponentModel.DataAnnotations;

namespace N5.Permissions.Core.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
