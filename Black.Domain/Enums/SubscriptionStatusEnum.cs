
using Black.Domain.Core.Utils;

namespace Black.Domain.Enums
{
    public enum SubscriptionStatusEnum
    {
        [AttributeEnum("1", "Pendente", true)]
        Pending = 1,
        [AttributeEnum("2", "Ativo", true)]
        Active = 2,
        [AttributeEnum("3", "Inativo", true)]
        Inactive = 3,
        [AttributeEnum("4", "Cancelado", true)]
        Canceled = 4,
        [AttributeEnum("4", "Concluído", true)]
        Conclude = 5
    }
}
