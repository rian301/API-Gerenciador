
using Black.Domain.Core.Utils;

namespace Procard.Domain.Enums
{
    public enum PatrimonyStatusEnum
    {
        [AttributeEnum("1", "Ativo", true)]
        Active = 1,
        [AttributeEnum("2", "Inativo", true)]
        Inactive = 2,
        [AttributeEnum("3", "Cessão de Uso", true)]
        Used = 3,
        [AttributeEnum("4", "Devolvido", true)]
        Returned = 4,
        [AttributeEnum("5", "Doado", true)]
        GiveAway = 5,
    }
}
