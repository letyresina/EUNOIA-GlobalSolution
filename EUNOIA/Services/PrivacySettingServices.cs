using EUNOIA.DTOs;
using EUNOIA.Models;
using EUNOIA.Repositories;

namespace EUNOIA.Services
{
    public class PrivacySettingService
    {
        private readonly PrivacySettingRepository _repository;

        public PrivacySettingService(PrivacySettingRepository repository)
        {
            _repository = repository;
        }

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

        public async Task<PrivacySettingDto?> GetByUserIdAsync(int userId)
        {
            var setting = await _repository.GetByUserIdAsync(userId);
            if (setting == null) return null;

            return new PrivacySettingDto
            {
                SettingId = setting.SettingId,
                UserId = setting.UserId,
                AllowFacialRecognition = setting.AllowFacialRecognition,
                AllowDataSharing = setting.AllowDataSharing,
                AnonymizeReports = setting.AnonymizeReports,
                UpdatedAt = setting.UpdatedAt
            };
        }

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

        public async Task UpdateAsync(int userId, CreatePrivacySettingDto dto)
        {
            var setting = await _repository.GetByUserIdAsync(userId);
            if (setting == null) return;

            setting.AllowFacialRecognition = dto.AllowFacialRecognition;
            setting.AllowDataSharing = dto.AllowDataSharing;
            setting.AnonymizeReports = dto.AnonymizeReports;
            setting.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(setting);
        }

        public async Task DeleteByUserIdAsync(int userId)
        {
            await _repository.DeleteByUserIdAsync(userId);
        }
    }
}