using System.Runtime.Serialization;

namespace EUNOIA.Enums
{
    /// <summary>
    /// Setor de atuação de empresa.
    /// </summary>
    public enum CompanySector
    {
        Tecnologia = 1,

        [EnumMember(Value = "Saúde")]
        Saude = 2,

        [EnumMember(Value = "Educação")]
        Educacao = 3,

        Financeiro = 4,

        [EnumMember(Value = "Indústria")]
        Industria = 5,

        [EnumMember(Value = "Serviços")]
        Servicos = 6,

        [EnumMember(Value = "Comércio")]
        Comercio = 7
    }
}
