using EUNOIA.Data;
using EUNOIA.Models;
using Microsoft.EntityFrameworkCore;

namespace EUNOIA.Repositories
{
    /// <summary>
    /// Repositório responsável pelas operações de acesso a dados da entidade Company.
    /// </summary>
    public class CompanyRepository
    {
        private readonly EunoiaDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância do repositório com o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados Eunoia.</param>
        public CompanyRepository(EunoiaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todas as empresas cadastradas.
        /// </summary>
        /// <returns>Lista de empresas.</returns>
        public async Task<List<Company>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        /// <summary>
        /// Busca uma empresa pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador da empresa.</param>
        /// <returns>Empresa correspondente ou null se não encontrada.</returns>
        public async Task<Company?> GetByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        /// <summary>
        /// Busca uma empresa pelo seu CNPJ.
        /// </summary>
        /// <param name="cnpj">CNPJ da empresa.</param>
        /// <returns>Empresa correspondente ou null se não encontrada.</returns>
        public async Task<Company?> GetByCNPJAsync(string cnpj)
        {
            return await _context.Companies
                .FirstOrDefaultAsync(c => c.CNPJ == cnpj);
        }

        /// <summary>
        /// Adiciona uma nova empresa ao banco de dados.
        /// </summary>
        /// <param name="company">Empresa a ser adicionada.</param>
        public async Task AddAsync(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Atualiza os dados de uma empresa existente.
        /// </summary>
        /// <param name="company">Empresa com os dados atualizados.</param>
        public async Task UpdateAsync(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove uma empresa com base no seu identificador.
        /// </summary>
        /// <param name="id">Identificador da empresa a ser removida.</param>
        public async Task DeleteAsync(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }
    }
}