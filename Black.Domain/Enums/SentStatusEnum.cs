using Black.Domain.Core.Utils;

namespace Black.Domain.Enums
{
    public enum SentStatusEnum
    {
        [AttributeEnum("1", "Enviado", true)]
        Sent = 1,
        [AttributeEnum("2", "Pendente", true)]
        InProgress = 2,
        [AttributeEnum("3", "Recebido", true)]
        Receiving = 3,
    }
}
