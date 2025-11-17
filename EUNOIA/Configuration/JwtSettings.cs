namespace EUNOIA.Configuration
{
    /// <summary>
    /// Configurações para JWT (JSON Web Token).
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Chave secreta utilizada para assinar o token.
        /// </summary>
        public string Key { get; set; } = string.Empty;
        /// <summary>
        /// Issuer do token.
        /// </summary>
        public string Issuer { get; set; } = string.Empty;
        /// <summary>
        /// Audiência do token.
        /// </summary>
        public string Audience { get; set; } = string.Empty;
        /// <summary>
        /// Tempo de expiração do token em minutos.
        /// </summary>
        public int ExpireMinutes { get; set; }
    }

}
