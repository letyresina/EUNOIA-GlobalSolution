using EUNOIA.DTOs;
using EUNOIA.Models;
using EUNOIA.Repositories;

namespace EUNOIA.Services
{
    /// <summary>
    /// Serviço para operações relacionadas a logs de auditoria.
    /// </summary>
    public class AuditLogService
    {
        private readonly AuditLogRepository _repository;

        /// <summary>
        /// Inicializa uma nova instância do serviço de auditoria com o repositório fornecido.
        /// </summary>
        /// <param name="repository">Repositório responsável pelas operações de persistência de logs de auditoria.</param>
        public AuditLogService(AuditLogRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna todos os logs de auditoria com dados do usuário.
        /// </summary>
        /// <returns>Lista de objetos <see cref="AuditLogDto"/> contendo os dados dos logs.</returns>
        public async Task<List<AuditLogDto>> GetAllAsync()
        {
            var logs = await _repository.GetAllAsync();
            return logs.Select(log => new AuditLogDto
            {
                LogId = log.LogId,
                UserId = log.UserId,
                UserName = log.User.Name,
                Action = log.Action.ToString(),
                Timestamp = log.Timestamp,
                IpAddress = log.IpAddress,
                IsSuccessful = log.IsSuccessful
            }).ToList();
        }

        /// <summary>
        /// Retorna os logs de auditoria de um usuário específico.
        /// </summary>
        /// <param name="userId">Identificador do usuário.</param>
        /// <returns>Lista de <see cref="AuditLogDto"/> relacionados ao usuário informado.</returns>
        public async Task<List<AuditLogDto>> GetByUserIdAsync(int userId)
        {
            var logs = await _repository.GetByUserIdAsync(userId);
            return logs.Select(log => new AuditLogDto
            {
                LogId = log.LogId,
                UserId = log.UserId,
                UserName = log.User.Name,
                Action = log.Action.ToString(),
                Timestamp = log.Timestamp,
                IpAddress = log.IpAddress,
                IsSuccessful = log.IsSuccessful
            }).ToList();
        }

        /// <summary>
        /// Adiciona um novo log de auditoria.
        /// </summary>
        /// <param name="dto">Objeto <see cref="CreateAuditLogDto"/> contendo os dados do log a ser criado.</param>
        public async Task AddAsync(CreateAuditLogDto dto)
        {
            var log = new AuditLog
            {
                UserId = dto.UserId,
                Action = dto.Action,
                IpAddress = dto.IpAddress,
                IsSuccessful = dto.IsSuccessful,
                Timestamp = DateTime.UtcNow
            };

            await _repository.AddAsync(log);
        }
    }
}