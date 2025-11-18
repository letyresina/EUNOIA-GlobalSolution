using EUNOIA.DTOs;
using EUNOIA.Models;
using EUNOIA.Repositories;
using EUNOIA.Security;
using Microsoft.AspNetCore.Identity;

namespace EUNOIA.Services
{
    /// <summary>
    /// Serviço responsável pelas operações de negócio relacionadas à entidade User.
    /// </summary>
    public class UserService
    {
        private readonly UserRepository _repository;
        private readonly PrivacySettingRepository _privacyRepository;

        /// <summary>
        /// Inicializa uma nova instância do serviço com os repositórios de usuários e configurações de privacidade.
        /// </summary>
        /// <param name="repository">Repositório de usuários.</param>
        /// <param name="privacyRepository">Repositório de configurações de privacidade.</param>
        public UserService(UserRepository repository, PrivacySettingRepository privacyRepository)
        {
            _repository = repository;
            _privacyRepository = privacyRepository;
        }

        /// <summary>
        /// Retorna todos os usuários cadastrados.
        /// </summary>
        /// <returns>Lista de objetos <see cref="UserDto"/>.</returns>
        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return users.Select(u => new UserDto
            {
                CPF = u.CPF,
                Name = u.Name,
                Email = u.Email,
                Role = u.Role,
                Department = u.Department,
                CreatedAt = u.CreatedAt,
                IsActive = u.IsActive,
                CompanyId = u.CompanyId
            }).ToList();
        }

        /// <summary>
        /// Busca um usuário pelo CPF.
        /// </summary>
        /// <param name="cpf">CPF do usuário.</param>
        /// <returns>Objeto <see cref="UserDto"/> ou null se não encontrado.</returns>
        public async Task<UserDto?> GetByCPFAsync(string cpf)
        {
            var user = await _repository.GetByCPFAsync(cpf);
            if (user == null) return null;

            return new UserDto
            {
                CPF = user.CPF,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                Department = user.Department,
                CreatedAt = user.CreatedAt,
                IsActive = user.IsActive,
                CompanyId = user.CompanyId
            };
        }

        /// <summary>
        /// Adiciona um novo usuário ao sistema e cria automaticamente sua configuração de privacidade.
        /// </summary>
        /// <param name="dto">DTO contendo os dados do novo usuário.</param>
        public async Task AddAsync(CreateUserDto dto)
        {
            var hashedPassword = PasswordHasher.HashPassword(dto.PasswordHash);

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = hashedPassword,
                Role = dto.Role,
                Department = dto.Department,
                CPF = dto.CPF,
                IsActive = dto.IsActive,
                CompanyId = dto.CompanyId
            };

            await _repository.AddAsync(user);

            var privacySetting = new PrivacySetting
            {
                UserId = user.UserId,
                AllowFacialRecognition = true,
                AllowDataSharing = false,
                AnonymizeReports = false,
                UpdatedAt = DateTime.UtcNow
            };

            await _privacyRepository.AddAsync(privacySetting);
        }

        /// <summary>
        /// Atualiza os dados de um usuário com base no CPF.
        /// </summary>
        /// <param name="cpf">CPF do usuário.</param>
        /// <param name="dto">DTO com os dados atualizados.</param>
        public async Task UpdateByCPFAsync(string cpf, CreateUserDto dto)
        {
            var user = await _repository.GetByCPFAsync(cpf);
            if (user == null) return;

            var hashedPassword = PasswordHasher.HashPassword(dto.PasswordHash);

            user.Name = dto.Name;
            user.Email = dto.Email;
            user.PasswordHash = hashedPassword;
            user.Role = dto.Role;
            user.Department = dto.Department;
            user.IsActive = dto.IsActive;
            user.CompanyId = dto.CompanyId;

            await _repository.UpdateAsync(user);
        }

        /// <summary>
        /// Remove um usuário com base no CPF.
        /// </summary>
        /// <param name="cpf">CPF do usuário a ser removido.</param>
        public async Task DeleteByCPFAsync(string cpf)
        {
            await _repository.DeleteByCPFAsync(cpf);
        }

        /// <summary>
        /// Obtém um usuário pelo CPF, incluindo informações da empresa associada.
        /// </summary>
        /// <param name="cpf">CPF do usuário a ser consultado.</param>
        /// <returns>Um <see cref="UserWithCompanyDto"/> contendo os dados do usuário e da empresa, ou null se não encontrado.</returns>
        public async Task<UserWithCompanyDto?> GetByCPFWithCompanyAsync(string cpf)
        {
            var user = await _repository.GetByCPFWithCompanyAsync(cpf);
            if (user == null || user.Company == null) return null;

            return new UserWithCompanyDto
            {
                CPF = user.CPF,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                Department = user.Department,
                CreatedAt = user.CreatedAt,
                IsActive = user.IsActive,
                CompanyId = user.CompanyId,
                CompanyName = user.Company.Name,
                CompanyCNPJ = user.Company.CNPJ
            };
        }

        /// <summary>
        /// Obtém um usuário pelo CPF, incluindo suas configurações de privacidade.
        /// </summary>
        /// <param name="cpf">CPF do usuário.</param>
        /// <returns>Um <see cref="UserWithPrivacySettingDto"/> com os dados do usuário e suas configurações de privacidade, ou null se não encontrado.</returns>
        public async Task<UserWithPrivacySettingDto?> GetByCPFWithPrivacySettingAsync(string cpf)
        {
            var user = await _repository.GetByCPFWithPrivacySettingAsync(cpf);
            if (user == null || user.PrivacySetting == null) return null;

            return new UserWithPrivacySettingDto
            {
                CPF = user.CPF,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role,
                Department = user.Department,
                CreatedAt = user.CreatedAt,
                IsActive = user.IsActive,
                CompanyId = user.CompanyId,
                AllowFacialRecognition = user.PrivacySetting.AllowFacialRecognition,
                AllowDataSharing = user.PrivacySetting.AllowDataSharing,
                AnonymizeReports = user.PrivacySetting.AnonymizeReports,
                PrivacyUpdatedAt = user.PrivacySetting.UpdatedAt
            };
        }
    }
}