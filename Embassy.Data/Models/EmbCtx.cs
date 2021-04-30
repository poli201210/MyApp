// <copyright file="EmbCtx.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Embassy.Program.Models
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;

    /// <summary>
    /// Database implementation class EmbCtx as
    /// EmbassyContext.
    /// </summary>
    public partial class EmbCtx : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmbCtx"/> class.
        /// Empty constructor of the class.
        /// </summary>
        public EmbCtx()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmbCtx"/> class.
        /// Empty constructor with Db
        /// ContextOptions method with entity.
        /// </summary>
        /// <param name="options">database.</param>
        public EmbCtx(DbContextOptions<EmbCtx> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets for agency database table.
        /// </summary>
        public virtual DbSet<Agency> Agency { get; set; }

        /// <summary>
        /// Gets or sets for applicant database table.
        /// </summary>
        public virtual DbSet<Applicant> Applicant { get; set; }

        /// <summary>
        /// Gets or sets for payment database table.
        /// </summary>
        public virtual DbSet<Payment> Payment { get; set; }

        /// <summary>
        /// Gets or sets for visa database table.
        /// </summary>
        public virtual DbSet<Visa> Visa { get; set; }

        /// <summary>
        /// Override method for able to Use
        /// lazyLoadingProxies() method.
        /// </summary>
        /// <param name="optionsBuilder">DBContextOptions.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ApplicationsDB.mdf;Integrated Security=True");
            }
        }

        /// <summary>
        /// Override method to create model and entity.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder class.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agency>(entity =>
            {
                entity.HasKey(e => e.AgenId)
                    .HasName("PK__agency__1DA5B6942FD01B2B");

                entity.ToTable("agency");

                entity.Property(e => e.AgenId)
                    .HasColumnName("agen_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AgenAddress)
                    .IsRequired()
                    .HasColumnName("agen_address")
                    .HasMaxLength(200);

                entity.Property(e => e.AgenEmail)
                    .IsRequired()
                    .HasColumnName("agen_email")
                    .HasMaxLength(200);

                entity.Property(e => e.AgenName)
                    .IsRequired()
                    .HasColumnName("agen_name")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Applicant>(entity =>
            {
                entity.HasKey(e => e.ApplId)
                    .HasName("PK__applican__ABDB16D66A80FE40");

                entity.ToTable("applicant");

                entity.Property(e => e.ApplId)
                    .HasColumnName("appl_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApplBirth)
                    .HasColumnName("appl_birth")
                    .HasColumnType("date");

                entity.Property(e => e.ApplEmail)
                    .HasColumnName("appl_email")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ApplGender)
                    .HasColumnName("appl_gender")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ApplIncome).HasColumnName("appl_income");

                entity.Property(e => e.ApplJob)
                    .HasColumnName("appl_job")
                    .HasMaxLength(200);

                entity.Property(e => e.ApplName)
                    .HasColumnName("appl_name")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PayId)
                    .HasName("PK__payment__7AAD1CEADDEFADDD");

                entity.ToTable("payment");

                entity.Property(e => e.PayId)
                    .HasColumnName("pay_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.PayAgenId).HasColumnName("pay_agen_id");

                entity.Property(e => e.PayAmount).HasColumnName("pay_amount");

                entity.Property(e => e.PayApplId).HasColumnName("pay_appl_id");

                entity.Property(e => e.PayIspayed)
                    .HasColumnName("pay_ispayed")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.PayAgen)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.PayAgenId)
                    .HasConstraintName("FK__payment__pay_age__286302EC").OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.PayAppl)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.PayApplId)
                    .HasConstraintName("FK__payment__pay_app__276EDEB3").OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Visa>(entity =>
            {
                entity.ToTable("visa");

                entity.Property(e => e.VisaId)
                    .HasColumnName("visa_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.VisaApplId).HasColumnName("visa_appl_id");

                entity.Property(e => e.VisaDuration).HasColumnName("visa_duration");

                entity.Property(e => e.VisaEnddate)
                    .HasColumnName("visa_enddate")
                    .HasColumnType("date");

                entity.Property(e => e.VisaIsapproved)
                    .HasColumnName("visa_isapproved")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.VisaType)
                    .HasColumnName("visa_type")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.VisaAppl)
                    .WithMany(p => p.Visa)
                    .HasForeignKey(d => d.VisaApplId).OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__visa__visa_appl___2B3F6F97");
            });

            this.OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
