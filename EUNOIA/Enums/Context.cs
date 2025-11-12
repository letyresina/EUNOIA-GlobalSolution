using System.Runtime.Serialization;

namespace EUNOIA.Enums
{
    /// <summary>
    /// Enum de qual contexto foi analisado a emoção
    /// </summary>
    public enum Context
    {
        Trabalho = 1,

        [EnumMember(Value = "Reunião")]
        Reuniao = 2,

        Pausa = 3,

        [EnumMember(Value = "Home Office")]
        HomeOffice = 4,

        Presencial = 5
    }
}
