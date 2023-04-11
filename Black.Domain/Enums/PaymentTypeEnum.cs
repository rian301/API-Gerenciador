using Black.Domain.Core.Utils;

namespace Black.Domain.Enums
{
    public enum PaymentTypeEnum
    {
        [AttributeEnum("1", "Cartão de crédito", true)]
        CreditCard = 1,
        [AttributeEnum("2", "Boleto", true)]
        Boleto = 2,
        [AttributeEnum("3", "Dinheiro", true)]
        Cash = 3,
        [AttributeEnum("4", "Cartão de débito", true)]
        DebitCard = 4,
        [AttributeEnum("5", "Pix", true)]
        Pix = 5,
        [AttributeEnum("6", "Outro", true)]
        Other = 6,
    }
}
