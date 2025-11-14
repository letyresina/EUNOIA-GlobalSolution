using EUNOIA.Data;
using EUNOIA.Models;
using Microsoft.EntityFrameworkCore;

namespace EUNOIA.Repositories
{
    /// <summary>
    /// Repositório responsável pelas operações de acesso a dados da entidade PrivacySetting.
    /// </summary>
    public class PrivacySettingRepository
    {
        private readonly EunoiaDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância do repositório com o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados Eunoia.</param>
        public PrivacySettingRepository(EunoiaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todas as configurações de privacidade cadastradas.
        /// </summary>
        /// <returns>Lista de configurações de privacidade.</returns>
        public async Task<List<PrivacySetting>> GetAllAsync()
        {
            return await _context.PrivacySettings.ToListAsync();
        }

        /// <summary>
        /// Busca a configuração de privacidade de um usuário, incluindo os dados do usuário.
        /// </summary>
        /// <param name="userId">Identificador do usuário.</param>
        /// <returns>Configuração de privacidade correspondente ou null se não encontrada.</returns>
        public async Task<PrivacySetting?> GetByUserIdWithUserAsync(int userId)
        {
            return await _context.PrivacySettings
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.UserId == userId);
        }

        /// <summary>
        /// Adiciona uma nova configuração de privacidade ao banco de dados.
        /// </summary>
        /// <param name="setting">Configuração de privacidade a ser adicionada.</param>
        public async Task AddAsync(PrivacySetting setting)
        {
            _context.PrivacySettings.Add(setting);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza os dados de uma configuração de privacidade existente.
        /// </summary>
        /// <param name="setting">Configuração de privacidade com os dados atualizados.</param>
        public async Task UpdateAsync(PrivacySetting setting)
        {
            _context.PrivacySettings.Update(setting);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove a configuração de privacidade de um usuário com base no seu identificador.
        /// </summary>
        /// <param name="userId">Identificador do usuário.</param>
        public async Task DeleteByUserIdAsync(int userId)
        {
            var setting = await GetByUserIdWithUserAsync(userId);
            if (setting != null)
            {
                _context.PrivacySettings.Remove(setting);
                await _context.SaveChangesAsync();
            }
        }
    }
}