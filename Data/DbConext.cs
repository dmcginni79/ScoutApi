using Microsoft.EntityFrameworkCore;
using ScoutApi.Awards;
using ScoutApi.Guardians;
using ScoutApi.PhoneNumbers;
using ScoutApi.Ranks;
using ScoutApi.Scouts;

namespace ScoutApi.Data
{
    public class ScoutApiContext : DbContext
    {
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Scout> Scouts { get; set; }
        public DbSet<EarnedRank> EarnedRanks { get; set; }
        public DbSet<EarnedAward> EarnedAwards { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Award> Awards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=scoutapi.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Guardian>()
                .HasKey(g => g.Id);
            
            modelBuilder.Entity<Scout>()
                .HasKey(s => s.Id);
            
            // Guardian - Scouts (many-to-many)
            modelBuilder.Entity<Guardian>()
                .HasMany(g => g.Scouts)
                .WithMany(s => s.Guardians)
                .UsingEntity(j => j.ToTable("GuardianScouts"));
            
            modelBuilder.Entity<Guardian>()
                .HasMany(g => g.PhoneNumbers)
                .WithOne(p => p.Guardian)
                .HasForeignKey(p => p.GuardianId);

            // Scout - EarnedRanks (one-to-many)
            modelBuilder.Entity<EarnedRank>()
                .HasOne(er => er.Scout)
                .WithMany(s  => s.EarnedRanks)
                .HasForeignKey(er => er.ScoutId);

            // Scout - EarnedAwards (one-to-many)
            modelBuilder.Entity<EarnedAward>()
                .HasOne(ea => ea.Scout)
                .WithMany(s => s.EarnedAwards)
                .HasForeignKey(ea => ea.ScoutId);

            // EarnedRank - Rank (many-to-one)
            modelBuilder.Entity<EarnedRank>()
                .HasOne(er => er.Rank)
                .WithMany(r => r.EarnedRanks)
                .HasForeignKey(er => er.RankId);

            // EarnedAward - Award (many-to-one)
            modelBuilder.Entity<EarnedAward>()
                .HasOne(ea => ea.Award)
                .WithMany(a => a.EarnedAwards)
                .HasForeignKey(ea => ea.AwardId);
        }
    }
}