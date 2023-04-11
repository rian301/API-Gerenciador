using Black.Domain.Core.Utils;

namespace Black.Domain.Enums
{
    public enum CustomerStatusEnum
    {
        [AttributeEnum("1", "Bom", true)]
        Good = 1,
        [AttributeEnum("2", "Regular", true)]
        Regular = 2,
        [AttributeEnum("3", "Alerta", true)]
        Alert = 3,
        [AttributeEnum("4", "Inativo", true)]
        Inative = 4
    }
}
