using Black.Domain.Core.Utils;

namespace Black.Domain.Enums
{
    public enum AgentCategoryEnum
    {
        [AttributeEnum("1", "Blue", true)]
        Blue = 1,
        [AttributeEnum("2", "Gold", true)]
        Gold = 2,
        [AttributeEnum("3", "Black", true)]
        Black = 3
    }
}
