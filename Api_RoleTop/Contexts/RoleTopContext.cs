using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Api_RoleTop.Domains;

namespace Api_RoleTop.Contexts
{
    public partial class RoleTopContext : DbContext
    {
        public RoleTopContext()
        {
        }

        public RoleTopContext(DbContextOptions<RoleTopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estadio> Estadio { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Jogo> Jogo { get; set; }
        public virtual DbSet<Selecao> Selecao { get; set; }
        public virtual DbSet<Show> Show { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-EQ5L120\\SQLEXPRESS; Initial Catalog=RoleTopWST; user Id=sa; pwd=123;");
                //optionsBuilder.UseSqlServer("Data Source=DESKTOP-FVTHN55\\SQLEXPRESS; Initial Catalog=RoleTopWST;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estadio>(entity =>
            {
                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Foto).HasColumnType("image");

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.EventoNavigation)
                    .WithMany(p => p.Estadio)
                    .HasForeignKey(d => d.Evento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estadio__Evento__33D4B598");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.JogoNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.Jogo)
                    .HasConstraintName("FK__Evento__Jogo__300424B4");

                entity.HasOne(d => d.ShowNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.Show)
                    .HasConstraintName("FK__Evento__Show__30F848ED");
            });

            modelBuilder.Entity<Jogo>(entity =>
            {
                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.SelecaoCasaNavigation)
                    .WithMany(p => p.JogoSelecaoCasaNavigation)
                    .HasForeignKey(d => d.SelecaoCasa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Jogo__SelecaoCas__2A4B4B5E");

                entity.HasOne(d => d.SelecaoVisitanteNavigation)
                    .WithMany(p => p.JogoSelecaoVisitanteNavigation)
                    .HasForeignKey(d => d.SelecaoVisitante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Jogo__SelecaoVis__2B3F6F97");
            });

            modelBuilder.Entity<Selecao>(entity =>
            {
                entity.Property(e => e.Foto).HasColumnType("image");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Show>(entity =>
            {
                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasIndex(e => e.Apelido)
                    .HasName("UQ__Usuario__571DBAE6E1EAE58C")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D10534B3D943E8")
                    .IsUnique();

                entity.Property(e => e.Apelido)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
