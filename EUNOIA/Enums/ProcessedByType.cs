using System.Runtime.Serialization;

namespace EUNOIA.Enums
{
    /// <summary>
    /// Enum de quem processou a sessão de emoção.
    /// </summary>
    public enum ProcessedByType
    {
        IA = 1,
        RH = 2,
        Gestor = 3,
        [EnumMember(Value = "Sistema Externo")]
        SistemaExterno = 4
    }
}
