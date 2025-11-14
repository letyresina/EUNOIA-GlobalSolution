using EUNOIA.Data;
using EUNOIA.Models;
using Microsoft.EntityFrameworkCore;

namespace EUNOIA.Repositories
{
    /// <summary>
    /// Repositório responsável pelas operações de acesso a dados da entidade User.
    /// </summary>
    public class UserRepository
    {
        private readonly EunoiaDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância do repositório com o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados Eunoia.</param>
        public UserRepository(EunoiaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os usuários cadastrados.
        /// </summary>
        /// <returns>Lista de usuários.</returns>
        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        /// <summary>
        /// Busca um usuário pelo CPF.
        /// </summary>
        /// <param name="cpf">CPF do usuário.</param>
        /// <returns>Usuário correspondente ou null se não encontrado.</returns>
        public async Task<User?> GetByCPFAsync(string cpf)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.CPF == cpf);
        }

        /// <summary>
        /// Adiciona um novo usuário ao banco de dados.
        /// </summary>
        /// <param name="user">Usuário a ser adicionado.</param>
        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza os dados de um usuário existente.
        /// </summary>
        /// <param name="user">Usuário com os dados atualizados.</param>
        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove um usuário com base no CPF.
        /// </summary>
        /// <param name="cpf">CPF do usuário a ser removido.</param>
        public async Task DeleteByCPFAsync(string cpf)
        {
            var user = await GetByCPFAsync(cpf);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Busca um usuário pelo CPF, incluindo os dados da empresa associada.
        /// </summary>
        /// <param name="cpf">CPF do usuário.</param>
        /// <returns>Usuário com dados da empresa ou null se não encontrado.</returns>
        public async Task<User?> GetByCPFWithCompanyAsync(string cpf)
        {
            return await _context.Users
                .Include(u => u.Company)
                .FirstOrDefaultAsync(u => u.CPF == cpf);
        }

        /// <summary>
        /// Busca um usuário pelo CPF, incluindo as configurações de privacidade.
        /// </summary>
        /// <param name="cpf">CPF do usuário.</param>
        /// <returns>Usuário com configurações de privacidade ou null se não encontrado.</returns>
        public async Task<User?> GetByCPFWithPrivacySettingAsync(string cpf)
        {
            return await _context.Users
                .Include(u => u.PrivacySetting)
                .FirstOrDefaultAsync(u => u.CPF == cpf);
        }
    }
}