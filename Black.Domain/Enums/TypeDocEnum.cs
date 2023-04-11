
using Black.Domain.Core.Utils;

namespace Black.Domain.Enums
{
    public enum TypeDocEnum
    {
        [AttributeEnum("1", "Documento Pessoal", true)]
        PersonalDocument = 1,
        [AttributeEnum("2", "Contrato", true)]
        Contract = 2,
        [AttributeEnum("3", "Recibo", true)]
        Receipt = 3,
        [AttributeEnum("4", "NF", true)]
        NF = 4,
        [AttributeEnum("5", "Aditivo", true)]
        Adictive = 5,
        [AttributeEnum("6", "Boleto", true)]
        Boleto = 6,
        [AttributeEnum("7", "Termo cessão de uso", true)]
        Term = 7,
        [AttributeEnum("8", "Relatório", true)]
        Report = 8,
        [AttributeEnum("9", "Descritivo", true)]
        Discritive = 9,
    }
}
