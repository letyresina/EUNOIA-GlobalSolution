using System.Runtime.Serialization;

namespace EUNOIA.Enums
{
    public enum AuditAction
    {
        [EnumMember(Value = "Criar Usuário")]
        CriarUsuario = 1,

        [EnumMember(Value = "Atualizar Usuário")]
        AtualizarUsuario = 2,

        [EnumMember(Value = "Deletar Usuário")]
        DeletarUsuario = 3,

        [EnumMember(Value = "Login")]
        Login = 4,

        [EnumMember(Value = "Logout")]
        Logout = 5,

        [EnumMember(Value = "Atualizar Configuração")]
        AtualizarConfiguracao = 6,

        [EnumMember(Value = "Criar Feedback")]
        CriarFeedback = 7,

        [EnumMember(Value = "Atualizar Feedback")]
        AtualizarFeedback = 8,

        [EnumMember(Value = "Deletar Feedback")]
        DeletarFeedback = 9
    }
}
