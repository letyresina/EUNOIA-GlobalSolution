namespace EUNOIA.DTOs
{
    /// <summary>
    /// DTO para autenticação de usuário via CPF e senha.
    /// </summary>
    public class LoginDto
    {
        /// <summary>
        /// CPF do usuário.
        /// </summary>
        public string CPF { get; set; } = string.Empty;

        /// <summary>
        /// Senha do usuário.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}