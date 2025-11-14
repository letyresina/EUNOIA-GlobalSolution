using System.Runtime.Serialization;

namespace EUNOIA.Enums
{
    /// <summary>
    /// Enum das emoções secundárias.
    /// </summary>
    public enum SecondaryEmotions
    {
        /// <summary>
        /// Nenhuma emoção secundária.
        /// </summary>
        [EnumMember(Value = "Nenhuma")]
        Nenhuma = 0,

        /// <summary>
        /// Emoção de ciúmes.
        /// </summary>
        [EnumMember(Value = "Ciúmes")]
        Ciumes = 1 << 0,

        /// <summary>
        /// Emoção de vergonha.
        /// </summary>
        [EnumMember(Value = "Vergonha")]
        Vergonha = 1 << 1,

        /// <summary>
        /// Emoção de culpa.
        /// </summary>
        [EnumMember(Value = "Culpa")]
        Culpa = 1 << 2,

        /// <summary>
        /// Emoção de orgulho.
        /// </summary>
        [EnumMember(Value = "Orgulho")]
        Orgulho = 1 << 3,

        /// <summary>
        /// Emoção de inveja.
        /// </summary>
        [EnumMember(Value = "Inveja")]
        Inveja = 1 << 4,

        /// <summary>
        /// Emoção de gratidão.
        /// </summary>
        [EnumMember(Value = "Gratidão")]
        Gratidao = 1 << 5
    }
}
