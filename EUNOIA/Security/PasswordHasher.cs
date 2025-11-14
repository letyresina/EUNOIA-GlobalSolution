using System.Security.Cryptography;

namespace EUNOIA.Security
{
    /// <summary>
    /// Classe utilitária responsável por gerar e verificar hashes de senha com sal usando PBKDF2.
    /// </summary>
    public static class PasswordHasher
    {
        /// <summary>
        /// Gera um hash seguro para a senha fornecida, utilizando PBKDF2 com SHA256 e sal aleatório.
        /// </summary>
        /// <param name="password">Senha em texto puro a ser protegida.</param>
        /// <returns>Hash da senha codificado em Base64, contendo o sal e o hash concatenados.</returns>
        public static string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                100_000,
                HashAlgorithmName.SHA256,
                32);

            byte[] hashBytes = new byte[48];
            Buffer.BlockCopy(salt, 0, hashBytes, 0, 16);
            Buffer.BlockCopy(hash, 0, hashBytes, 16, 32);

            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// Verifica se a senha fornecida corresponde ao hash armazenado.
        /// </summary>
        /// <param name="password">Senha em texto puro a ser verificada.</param>
        /// <param name="storedHash">Hash armazenado em Base64 contendo sal e hash.</param>
        /// <returns>True se a senha for válida; caso contrário, false.</returns>
        public static bool VerifyPassword(string password, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);
            byte[] salt = new byte[16];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, 16);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                100_000,
                HashAlgorithmName.SHA256,
                32);

            for (int i = 0; i < 32; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }

            return true;
        }
    }
}