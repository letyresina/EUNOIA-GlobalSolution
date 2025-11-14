using System.Runtime.Serialization;

namespace EUNOIA.Enums
{
    /// <summary>
    /// Enum de quem processou a sessão de emoção.
    /// </summary>
    public enum ProcessedByType
    {
        /// <summary>
        /// Processado por Inteligência Artificial.
        /// </summary>
        IA = 1,

        /// <summary>
        /// Processado pelo setor de Recursos Humanos.
        /// </summary>
        RH = 2,

        /// <summary>
        /// Processado pelo gestor responsável.
        /// </summary>
        Gestor = 3,

        /// <summary>
        /// Processado por sistema externo.
        /// </summary>
        [EnumMember(Value = "Sistema Externo")]
        SistemaExterno = 4
    }
}
