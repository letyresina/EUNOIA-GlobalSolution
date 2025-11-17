using EUNOIA.Models;
using Microsoft.EntityFrameworkCore;

namespace EUNOIA.Data
{
    /// <summary>
    /// Contexto principal do banco de dados da aplicação Eunoia.
    /// Responsável por mapear as entidades (Models) para as tabelas do SQL Server.
    /// </summary>
    public class EunoiaDbContext(DbContextOptions<EunoiaDbContext> options) : DbContext(options)
    {
        /// <summary>
        /// Construtor do contexto do banco de dados Eunoia.
        /// </summary>
        /// <param name="options">Opções de configuração do contexto.</param>
        // Construtor primário utilizado (IDE0290)

        /// <summary>
        /// Tabela de usuários do sistema.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Tabela de empresas cadastradas.
        /// </summary>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Tabela de feedbacks das sessões de emoção.
        /// </summary>
        public DbSet<Feedback> Feedbacks { get; set; }

        /// <summary>
        /// Tabela de sessões de emoção dos usuários.
        /// </summary>
        public DbSet<EmotionSession> EmotionSessions { get; set; }

        /// <summary>
        /// Tabela de configurações de privacidade dos usuários.
        /// </summary>
        public DbSet<PrivacySetting> PrivacySettings { get; set; }

        /// <summary>
        /// Tabela de logs de auditoria do sistema.
        /// </summary>
        public DbSet<AuditLog> AuditLogs { get; set; }


        /// <summary>
        /// Tabela de emoções primárias detectadas nas sessões.
        /// </summary>
        public DbSet<Emotion> Emotions { get; set; }

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

            // Garante que cada usuário tenha apenas uma configuração de privacidade
            modelBuilder.Entity<PrivacySetting>()
                .HasIndex(p => p.UserId)
                .IsUnique();

            // 🔒 CPF deve ser único
            modelBuilder.Entity<User>()
                .HasIndex(u => u.CPF)
                .IsUnique();

            // 🔒 CNPJ deve ser único
            modelBuilder.Entity<Company>()
                .HasIndex(c => c.CNPJ)
                .IsUnique();
        }
    }
}
