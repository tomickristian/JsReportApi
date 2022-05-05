using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JsReportApi.Models
{
    public partial class TVRASPOREDContext : DbContext
    {
        public TVRASPOREDContext()
        {
        }

        public TVRASPOREDContext(DbContextOptions<TVRASPOREDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Emisija> Emisijas { get; set; }
        public virtual DbSet<Korisnik> Korisniks { get; set; }
        public virtual DbSet<Pretplatum> Pretplata { get; set; }
        public virtual DbSet<TipKorisnika> TipKorisnikas { get; set; }
        public virtual DbSet<Tvpostaja> Tvpostajas { get; set; }
        public virtual DbSet<Zanr> Zanrs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER01;Database=TVRASPORED;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Emisija>(entity =>
            {
                entity.ToTable("emisija");

                entity.HasIndex(e => e.TvpostajaId, "fk_emisija_tvpostaja1_idx");

                entity.HasIndex(e => e.ZanrId, "fk_emisija_zanr1_idx");

                entity.Property(e => e.EmisijaId).HasColumnName("emisija_id");

                entity.Property(e => e.DatumVrijemePocetka)
                    .HasPrecision(0)
                    .HasColumnName("datum_vrijeme_pocetka");

                entity.Property(e => e.DatumVrijemeZavrsetka)
                    .HasPrecision(0)
                    .HasColumnName("datum_vrijeme_zavrsetka");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("naziv");

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("opis");

                entity.Property(e => e.TvpostajaId).HasColumnName("tvpostaja_id");

                entity.Property(e => e.ZanrId).HasColumnName("zanr_id");

                entity.HasOne(d => d.Tvpostaja)
                    .WithMany(p => p.Emisijas)
                    .HasForeignKey(d => d.TvpostajaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_emisija_tvpostaja1");

                entity.HasOne(d => d.Zanr)
                    .WithMany(p => p.Emisijas)
                    .HasForeignKey(d => d.ZanrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_emisija_zanr1");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.ToTable("korisnik");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

                entity.Property(e => e.DatumPrijave)
                    .HasColumnType("datetime")
                    .HasColumnName("datum_prijave");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ime");

                entity.Property(e => e.KorisnickoIme)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("korisnicko_ime");

                entity.Property(e => e.Lozinka)
                    .HasMaxLength(256)
                    .HasColumnName("lozinka");

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("prezime");

                entity.Property(e => e.Slika)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("slika");

                entity.Property(e => e.TipId).HasColumnName("tip_id");

                entity.HasOne(d => d.Tip)
                    .WithMany(p => p.Korisniks)
                    .HasForeignKey(d => d.TipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_korisnik_tip_korisnika");
            });

            modelBuilder.Entity<Pretplatum>(entity =>
            {
                entity.HasKey(e => e.PretplataId)
                    .HasName("PK__pretplat__AD2693D3A1E3F819");

                entity.ToTable("pretplata");

                entity.HasIndex(e => e.EmisijaId, "fk_korisnik_has_emisija_emisija1_idx");

                entity.HasIndex(e => e.KorisnikId, "fk_korisnik_has_emisija_korisnik1_idx");

                entity.Property(e => e.PretplataId).HasColumnName("pretplata_id");

                entity.Property(e => e.EmisijaId).HasColumnName("emisija_id");

                entity.Property(e => e.KorisnikId).HasColumnName("korisnik_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Emisija)
                    .WithMany(p => p.Pretplata)
                    .HasForeignKey(d => d.EmisijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_korisnik_has_emisija_emisija1");

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Pretplata)
                    .HasForeignKey(d => d.KorisnikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_korisnik_has_emisija_korisnik1");
            });

            modelBuilder.Entity<TipKorisnika>(entity =>
            {
                entity.HasKey(e => e.TipId)
                    .HasName("pk_tip_korisnika");

                entity.ToTable("tip_korisnika");

                entity.Property(e => e.TipId).HasColumnName("tip_id");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("naziv");
            });

            modelBuilder.Entity<Tvpostaja>(entity =>
            {
                entity.ToTable("tvpostaja");

                entity.HasIndex(e => e.ModeratorId, "fk_tvpostaja_korisnik1_idx");

                entity.Property(e => e.TvpostajaId).HasColumnName("tvpostaja_id");

                entity.Property(e => e.ModeratorId).HasColumnName("moderator_id");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("naziv");

                entity.HasOne(d => d.Moderator)
                    .WithMany(p => p.Tvpostajas)
                    .HasForeignKey(d => d.ModeratorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tvpostaja_korisnik1");
            });

            modelBuilder.Entity<Zanr>(entity =>
            {
                entity.ToTable("zanr");

                entity.Property(e => e.ZanrId).HasColumnName("zanr_id");

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("naziv");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
