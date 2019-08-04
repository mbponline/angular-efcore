using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Entities;
using ProAgil.Domain.Entities.Identity;

namespace ProAgil.Data
{

    public class ProAgilContext : IdentityDbContext<User, Role, int,
                                                    IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                    IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options) : base(options) { }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<PalestranteEvento> PalestranteEventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // relacionamento "* para *" entre as tabelas User e Role dá origem a essa tabela UserRole
            // onde as chaves estrangeiras estão definidas abaixo
            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                // entitidade Role tem muitos UserRoles e para cada um deles há uma chave dos roleId que é obrigatória
                userRole.HasOne(r => r.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(r => r.RoleId)
                .IsRequired();

                // entitidade User tem muitos UserRoles e para cada um deles há uma chave dos UserId que é obrigatória
                userRole.HasOne(u => u.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(u => u.UserId)
                .IsRequired();
            });

            // relacionamento " * para * " entre as tabelas Evento e Palestrante dá origem a essa tabela 
            // palestranteEvento com as respectivas chaves estrangeiras definidas abaixo               
            modelBuilder.Entity<PalestranteEvento>()
            .HasKey(PE => new { PE.EventoId, PE.PalestranteId });
        }

    }
}