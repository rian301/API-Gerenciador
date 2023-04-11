using Black.Domain.Core.Utils;

namespace Black.Domain.Enums
{
    public enum PendencyStatusEnum
    {
        [AttributeEnum("1", "Resolvido", true)]
        Resolved = 1,
        [AttributeEnum("2", "Em Andamento", true)]
        InProgress = 2,
    }
}
