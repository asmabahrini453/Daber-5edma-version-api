using Microsoft.EntityFrameworkCore;
using System;

namespace Daber_5edma_api.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Candidat> Candidats { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<JobOffer> JobOffers { get; set; }
        public virtual DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CANDIDAT
            modelBuilder.Entity<Candidat>().ToTable("TCandidat");
            modelBuilder.Entity<Candidat>().HasKey(h => h.Id);
            modelBuilder.Entity<Candidat>().Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30);
            modelBuilder.Entity<Candidat>().Property(p => p.Email)
                .IsRequired();
            modelBuilder.Entity<Candidat>().Property(p => p.Tel)
               .IsRequired()
               .HasMaxLength(8);
            modelBuilder.Entity<Candidat>().Property(p => p.Password)
              .IsRequired()
              .HasMaxLength(12);
            modelBuilder.Entity<Candidat>().Property(p => p.DateNaiss)
             .IsRequired();
            modelBuilder.Entity<Candidat>().Property(p => p.Speciality)
             .IsRequired();
            modelBuilder.Entity<Candidat>().Property(p => p.Experience)
             .IsRequired();
            modelBuilder.Entity<Candidat>().Property(p => p.Education)
            .IsRequired();
            modelBuilder.Entity<Candidat>()
                .HasMany(h => h.JobApplication)
                .WithOne(a => a.Candidat)
                .HasForeignKey(resto => resto.CandidatId);

            //COMPANY
            modelBuilder.Entity<Company>().ToTable("TCompany");
            modelBuilder.Entity<Company>().HasKey(h => h.Id);

            modelBuilder.Entity<Company>().Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Company>().Property(p => p.Email)
               .IsRequired();
            modelBuilder.Entity<Company>().Property(p => p.Tel)
              .IsRequired()
              .HasMaxLength(8);
            modelBuilder.Entity<Company>().Property(p => p.Password)
             .IsRequired()
             .HasMaxLength(12);
            modelBuilder.Entity<Company>().Property(p => p.Description)
              .IsRequired();
            modelBuilder.Entity<Company>().Property(p => p.Location)
             .IsRequired();
            modelBuilder.Entity<Company>()
               .HasMany(h => h.JobOffer)
               .WithOne(a => a.Company)
               .HasForeignKey(resto => resto.CompanyId);

            //JOB OFFER
            modelBuilder.Entity<JobOffer>().ToTable("TJobOffer");
            modelBuilder.Entity<JobOffer>().HasKey(h => h.Id);
            modelBuilder.Entity<JobOffer>().Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(30);
            modelBuilder.Entity<JobOffer>().Property(p => p.Description)
               .IsRequired();
            modelBuilder.Entity<JobOffer>().Property(p => p.PostedDate)
              .IsRequired();
            modelBuilder.Entity<JobOffer>().Property(p => p.Speciality)
             .IsRequired()
             .HasMaxLength(30);
            modelBuilder.Entity<JobOffer>().Property(p => p.Location)
                .HasMaxLength(50)
                .IsRequired();

            //JOB APPLICATION

            modelBuilder.Entity<JobApplication>().ToTable("JobApplication");
            modelBuilder.Entity<JobApplication>().HasKey(h => h.Id);
            modelBuilder.Entity<JobApplication>().Property(p => p.Status)
                .IsRequired();
            modelBuilder.Entity<JobApplication>()
               .HasOne(a => a.JobOffer)
                .WithMany(o => o.JobApplications)
                .HasForeignKey(a => a.JobOfferId);

            // ADD DATA
            modelBuilder.Entity<Candidat>().HasData(
                new Candidat
                {
                    Id = 1,
                    Name = "asma",
                    Email = "asma@gmail.com",
                    Tel = "25096055",
                    Password = "asma",
                    DateNaiss = new DateTime(2001, 5, 18),
                    Speciality = "GL",
                    Experience = "1 ans",
                    Education = "EPI"
                });

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "proxym",
                    Email = "proxym@gmail.com",
                    Tel = "1234567",
                    Location = "sousse",
                    Password = "proxym",
                    Description = "startup"
                });

            modelBuilder.Entity<JobOffer>().HasData(
                new JobOffer
                {
                    Id = 1,
                    Title = "software engineer",
                    Description = "looking for a software engineer",
                    PostedDate = new DateTime(2023, 12, 17),
                    Speciality = "development",
                    Location = "sousse",
                    CompanyId = 1
                });

            modelBuilder.Entity<JobApplication>().HasData(
                new JobApplication
                {
                    Id = 1,
                    Status = "pending",
                    CandidatId = 1,
                    JobOfferId = 1
                });
        }
    }
}
