using Black.Domain.Core.Utils;

namespace Black.Domain.Enums
{
    public enum EmployeeStatusEnum
    {
        [AttributeEnum("1", "Ativo", true)]
        Active = 1,
        [AttributeEnum("2", "Inativo", true)]
        Inactive = 2,
    }
}
