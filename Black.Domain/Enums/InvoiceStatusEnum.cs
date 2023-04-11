using Black.Domain.Core.Utils;

namespace Black.Domain.Enums
{
    public enum InvoiceStatusEnum
    {
        [AttributeEnum("1", "Aguardando Pagamento", true)]
        Pending = 1,
        [AttributeEnum("2", "Pago", true)]
        Approved = 2,
        [AttributeEnum("3", "Cancelado", true)]
        Canceled = 3,
        [AttributeEnum("4", "Pendente de Aprovação", true)]
        PendingManualApproval = 4,
    }
}
