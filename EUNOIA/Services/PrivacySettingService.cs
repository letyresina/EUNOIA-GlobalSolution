using EUNOIA.DTOs;
using EUNOIA.Models;
using EUNOIA.Repositories;

namespace EUNOIA.Services
{
    /// <summary>
    /// Serviço responsável pelas operações de negócio relacionadas às configurações de privacidade dos usuários.
    /// </summary>
    public class PrivacySettingService
    {
        private readonly PrivacySettingRepository _repository;

        /// <summary>
        /// Inicializa uma nova instância do serviço com o repositório de configurações de privacidade.
        /// </summary>
        /// <param name="repository">Instância do repositório de configurações de privacidade.</param>
        public PrivacySettingService(PrivacySettingRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna todas as configurações de privacidade cadastradas.
        /// </summary>
        /// <returns>Lista de objetos <see cref="PrivacySettingDto"/>.</returns>
        public async Task<List<PrivacySettingDto>> GetAllAsync()
        {
            var settings = await _repository.GetAllAsync();
            return settings.Select(p => new PrivacySettingDto
            {
                SettingId = p.SettingId,
                UserId = p.UserId,
                AllowFacialRecognition = p.AllowFacialRecognition,
                AllowDataSharing = p.AllowDataSharing,
                AnonymizeReports = p.AnonymizeReports,
                UpdatedAt = p.UpdatedAt
            }).ToList();
        }

        /// <summary>
        /// Busca a configuração de privacidade de um usuário, incluindo os dados do usuário.
        /// </summary>
        /// <param name="userId">Identificador do usuário.</param>
        /// <returns>Objeto <see cref="PrivacySettingWithUserDto"/> ou null se não encontrado.</returns>
        public async Task<PrivacySettingWithUserDto?> GetByUserIdWithUserAsync(int userId)
        {
            var setting = await _repository.GetByUserIdWithUserAsync(userId);
            if (setting == null || setting.User == null) return null;

            return new PrivacySettingWithUserDto
            {
                SettingId = setting.SettingId,
                UserId = setting.UserId,
                AllowFacialRecognition = setting.AllowFacialRecognition,
                AllowDataSharing = setting.AllowDataSharing,
                AnonymizeReports = setting.AnonymizeReports,
                UpdatedAt = setting.UpdatedAt,
                UserName = setting.User.Name,
                UserEmail = setting.User.Email,
                UserCPF = setting.User.CPF
            };
        }

        /// <summary>
        /// Adiciona uma nova configuração de privacidade ao sistema.
        /// </summary>
        /// <param name="dto">DTO contendo os dados da configuração de privacidade.</param>
        public async Task AddAsync(CreatePrivacySettingDto dto)
        {
            var setting = new PrivacySetting
            {
                UserId = dto.UserId,
                AllowFacialRecognition = dto.AllowFacialRecognition,
                AllowDataSharing = dto.AllowDataSharing,
                AnonymizeReports = dto.AnonymizeReports,
                UpdatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(setting);
        }

        /// <summary>
        /// Atualiza a configuração de privacidade de um usuário existente.
        /// </summary>
        /// <param name="userId">Identificador do usuário.</param>
        /// <param name="dto">DTO com os dados atualizados.</param>
        public async Task UpdateAsync(int userId, CreatePrivacySettingDto dto)
        {
            var setting = await _repository.GetByUserIdWithUserAsync(userId);
            if (setting == null) return;

            setting.AllowFacialRecognition = dto.AllowFacialRecognition;
            setting.AllowDataSharing = dto.AllowDataSharing;
            setting.AnonymizeReports = dto.AnonymizeReports;
            setting.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(setting);
        }

        /// <summary>
        /// Remove a configuração de privacidade de um usuário com base no seu identificador.
        /// </summary>
        /// <param name="userId">Identificador do usuário.</param>
        public async Task DeleteByUserIdAsync(int userId)
        {
            await _repository.DeleteByUserIdAsync(userId);
        }
    }
}