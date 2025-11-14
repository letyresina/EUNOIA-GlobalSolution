using System.Runtime.Serialization;

namespace EUNOIA.Enums
{
    /// <summary>
    /// Define as ações de auditoria disponíveis no sistema.
    /// </summary>
    public enum AuditAction
    {
        /// <summary>
        /// Representa a ação de criar um usuário.
        /// </summary>
        [EnumMember(Value = "Criar Usuário")]
        CriarUsuario = 1,

        /// <summary>
        /// Representa a ação de atualizar um usuário.
        /// </summary>
        [EnumMember(Value = "Atualizar Usuário")]
        AtualizarUsuario = 2,

        /// <summary>
        /// Representa a ação de deletar um usuário.
        /// </summary>
        [EnumMember(Value = "Deletar Usuário")]
        DeletarUsuario = 3,

        /// <summary>
        /// Representa a ação de login.
        /// </summary>
        [EnumMember(Value = "Login")]
        Login = 4,

        /// <summary>
        /// Representa a ação de logout.
        /// </summary>
        [EnumMember(Value = "Logout")]
        Logout = 5,

        /// <summary>
        /// Representa a ação de atualizar configuração.
        /// </summary>
        [EnumMember(Value = "Atualizar Configuração")]
        AtualizarConfiguracao = 6,

        /// <summary>
        /// Representa a ação de criar feedback.
        /// </summary>
        [EnumMember(Value = "Criar Feedback")]
        CriarFeedback = 7,

        /// <summary>
        /// Representa a ação de atualizar feedback.
        /// </summary>
        [EnumMember(Value = "Atualizar Feedback")]
        AtualizarFeedback = 8,

        /// <summary>
        /// Representa a ação de deletar feedback.
        /// </summary>
        [EnumMember(Value = "Deletar Feedback")]
        DeletarFeedback = 9
    }
}
