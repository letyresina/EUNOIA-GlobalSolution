using EUNOIA.Models;
using Microsoft.EntityFrameworkCore;

namespace EUNOIA.Data
{
    /// <summary>
    /// Contexto principal do banco de dados da aplicação Eunoia.
    /// Responsável por mapear as entidades (Models) para as tabelas do SQL Server.
    /// </summary>
    public class EunoiaDbContext : DbContext
    {
        public EunoiaDbContext(DbContextOptions<EunoiaDbContext> options)
            : base(options)
        {
        }

        // Tabelas principais
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<EmotionSession> EmotionSessions { get; set; }
        public DbSet<PrivacySetting> PrivacySettings { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }

        /// <summary>
        /// Configurações adicionais de mapeamento entre Models e Banco de Dados.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relacionamento: Empresa → Usuários
            modelBuilder.Entity<User>()
                .HasOne(u => u.Company)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento: Usuário → Configuração de Privacidade
            modelBuilder.Entity<User>()
                .HasOne(u => u.PrivacySetting)
                .WithOne(p => p.User)
                .HasForeignKey<PrivacySetting>(p => p.UserId);

            // Relacionamento: Usuário → Sessões de Emoção
            modelBuilder.Entity<EmotionSession>()
                .HasOne(e => e.User)
                .WithMany(u => u.EmotionSessions)
                .HasForeignKey(e => e.UserId);

            // Relacionamento: Sessão → Feedback
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.EmotionSession)
                .WithMany(e => e.Feedbacks)
                .HasForeignKey(f => f.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relacionamento: Usuário → Logs de Auditoria
            modelBuilder.Entity<AuditLog>()
                .HasOne(a => a.User)
                .WithMany(u => u.AuditLogs)
                .HasForeignKey(a => a.UserId);
        }
    }
}
