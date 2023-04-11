using Black.Domain.Core.Utils;

namespace Black.Domain.Enums
{
    public enum EmployeeGenderEnum
    {
        [AttributeEnum("1", "Masculino", true)]
        Man = 1,
        [AttributeEnum("2", "Feminino", true)]
        Women = 2,
        [AttributeEnum("3", "Outro", true)]
        Other = 3
    }
}
