using PermissionApi.Domain.Common;

namespace PermissionApi.Domain.Entities
{
    public class PermissionType : BaseId
    {
        public string Description { get; set; }
        public virtual ICollection<Permission> Permission { get; set; }
    }
}
