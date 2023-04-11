using Black.Domain.Core.Utils;

namespace Black.Domain.Enums
{
    public enum ExpenseControlReportEnum
    {
        [AttributeEnum("1", "Geral", true)]
        All = 1,
        [AttributeEnum("2", "Por Categoria", true)]
        Category = 2,
        [AttributeEnum("3", "Customizado", true)]
        Customized = 3,
    }
}
