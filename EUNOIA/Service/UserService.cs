using EUNOIA.DTOs;
using EUNOIA.Models;
using EUNOIA.Repositories;
using EUNOIA.Security;
using Microsoft.AspNetCore.Identity;

namespace EUNOIA.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

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
        }

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

        public async Task DeleteByCPFAsync(string cpf)
        {
            await _repository.DeleteByCPFAsync(cpf);
        }

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
    }
}