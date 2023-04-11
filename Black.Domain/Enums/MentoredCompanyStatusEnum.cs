using Black.Domain.Core.Utils;

namespace Black.Domain.Enums
{
    public enum MentoredCompanyStatusEnum
    {
        [AttributeEnum("1", "Em análise", true)]
        InAnalisys = 1,
        [AttributeEnum("2", "Rejeitado", true)]
        Rejected = 2,
        [AttributeEnum("3", "Ativo", true)]
        Active = 3
    }
}
