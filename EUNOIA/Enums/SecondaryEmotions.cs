using System.Runtime.Serialization;

namespace EUNOIA.Enums
{
    /// <summary>
    /// Enum das emoções secundárias.
    /// </summary>
    public enum SecondaryEmotions
    {
        [EnumMember(Value = "Nenhuma")]
        Nenhuma = 0,

        [EnumMember(Value = "Ciúmes")]
        Ciumes = 1 << 0,

        [EnumMember(Value = "Vergonha")]
        Vergonha = 1 << 1,

        [EnumMember(Value = "Culpa")]
        Culpa = 1 << 2,

        [EnumMember(Value = "Orgulho")]
        Orgulho = 1 << 3,

        [EnumMember(Value = "Inveja")]
        Inveja = 1 << 4,

        [EnumMember(Value = "Gratidão")]
        Gratidao = 1 << 5
    }
}
