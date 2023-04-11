using Black.Domain.Core.Utils;

namespace Black.Domain.Enums
{
    public enum DeletedEnum
    {
        [AttributeEnum("1", "Não", true)]
        No = 0,
        [AttributeEnum("2", "Sim", true)]
        Yes = 1,
    }
}
