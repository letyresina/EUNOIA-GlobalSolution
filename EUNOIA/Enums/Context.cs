using System.Runtime.Serialization;

namespace EUNOIA.Enums
{
    /// <summary>
    /// Enum de qual contexto foi analisado a emoção
    /// </summary>
    public enum Context
    {
        /// <summary>
        /// Contexto de trabalho.
        /// </summary>
        Trabalho = 1,

        /// <summary>
        /// Contexto de reunião.
        /// </summary>
        [EnumMember(Value = "Reunião")]
        Reuniao = 2,

        /// <summary>
        /// Contexto de pausa.
        /// </summary>
        Pausa = 3,

        /// <summary>
        /// Contexto de home office.
        /// </summary>
        [EnumMember(Value = "Home Office")]
        HomeOffice = 4,

        /// <summary>
        /// Contexto presencial.
        /// </summary>
        Presencial = 5
    }
}
