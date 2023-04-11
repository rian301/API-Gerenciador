using Black.Domain.Core.Utils;

namespace Black.Domain.Enums
{
    public enum EmployeeTypeEnum
    {
        [AttributeEnum("1", "CLT", true)]
        CLT = 1,
        [AttributeEnum("2", "PJ", true)]
        PJ = 2,
        [AttributeEnum("3", "Free-lancer", true)]
        FREE_LANCER = 3,
    }
}
