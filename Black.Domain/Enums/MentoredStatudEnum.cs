using Black.Domain.Core.Utils;

namespace Black.Domain.Enums
{
    public enum MentoredStatusEnum
    {
        [AttributeEnum("1", "Ativo", true)]
        Active = 1,
        [AttributeEnum("2", "Inativo", true)]
        Inactive = 2,
        [AttributeEnum("3", "Desligado", true)]
        Off = 3,
    }
}
