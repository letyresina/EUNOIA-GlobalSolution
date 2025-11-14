using System.Runtime.Serialization;

namespace EUNOIA.Enums
{
    /// <summary>
    /// Setor de atuação de empresa.
    /// </summary>
    public enum CompanySector
    {
        /// <summary>
        /// Setor de tecnologia.
        /// </summary>
        Tecnologia = 1,

        /// <summary>
        /// Setor de saúde.
        /// </summary>
        [EnumMember(Value = "Saúde")]
        Saude = 2,

        /// <summary>
        /// Setor de educação.
        /// </summary>
        [EnumMember(Value = "Educação")]
        Educacao = 3,

        /// <summary>
        /// Setor financeiro.
        /// </summary>
        Financeiro = 4,

        /// <summary>
        /// Setor industrial.
        /// </summary>
        [EnumMember(Value = "Indústria")]
        Industria = 5,

        /// <summary>
        /// Setor de serviços.
        /// </summary>
        [EnumMember(Value = "Serviços")]
        Servicos = 6,

        /// <summary>
        /// Setor de comércio.
        /// </summary>
        [EnumMember(Value = "Comércio")]
        Comercio = 7
    }
}
