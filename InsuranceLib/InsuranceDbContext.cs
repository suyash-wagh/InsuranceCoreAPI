﻿using InsuranceLib.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace InsuranceLib.DAL
{
    public class InsuranceDbContext : IdentityDbContext<User>
    {
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options) { }

        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<InsuranceScheme> InsuranceSchemes { get; set; }
        public DbSet<InsuranceType> InsuranceTypes { get; set; }
        public DbSet<InsurancePlan> InsurancePlans { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<InsuranceAccount> Accounts { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<InsuranceClaim> InsuranceClaims { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<WithdrawAccount> WithdrawAccounts { get; set; }
        public DbSet<Query> Queries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<State>().ToTable("State");
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<InsuranceScheme>().ToTable("InsuranceScheme");
            modelBuilder.Entity<InsuranceType>().ToTable("InsuranceType");
            modelBuilder.Entity<InsurancePlan>().ToTable("InsurancePlan");
            modelBuilder.Entity<Image>().ToTable("Image");
            modelBuilder.Entity<Policy>().ToTable("Policy");
            modelBuilder.Entity<InsuranceAccount>().ToTable("InsuranceAccount");
            modelBuilder.Entity<InsuranceClaim>().ToTable("InsuranceClaim");
            modelBuilder.Entity<Commission>().ToTable("Commission");
            modelBuilder.Entity<Payment>().ToTable("Payment");
            modelBuilder.Entity<WithdrawAccount>().ToTable("WithdrawAccount");
            modelBuilder.Entity<Query>().ToTable("Query");
        }
    }
}
