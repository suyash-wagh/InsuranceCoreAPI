﻿// <auto-generated />
using System;
using InsuranceLib.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InsuranceLib.DAL.Migrations
{
    [DbContext(typeof(InsuranceDbContext))]
    partial class InsuranceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InsuranceLib.DAL.Models.BaseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BaseEntity");
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nominee")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomineeRelation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Pincode")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.City", b =>
                {
                    b.HasBaseType("InsuranceLib.DAL.Models.BaseEntity");

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<Guid?>("StateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StateTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("StateId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.Image", b =>
                {
                    b.HasBaseType("InsuranceLib.DAL.Models.BaseEntity");

                    b.Property<string>("BaseEntityId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("BaseEntityId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("BaseEntityId1");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.InsuranceAccount", b =>
                {
                    b.HasBaseType("InsuranceLib.DAL.Models.BaseEntity");

                    b.Property<string>("AgentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("InsuranceAccount");
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.InsurancePlan", b =>
                {
                    b.HasBaseType("InsuranceLib.DAL.Models.BaseEntity");

                    b.Property<int>("AgeMax")
                        .HasColumnType("int");

                    b.Property<int>("AgeMin")
                        .HasColumnType("int");

                    b.Property<Guid?>("InsuranceSchemeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InsuranceSchemeTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("InsuranceTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("InsuranceTypeTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InvestmentMax")
                        .HasColumnType("int");

                    b.Property<int>("InvestmentMin")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("PolicyTermMax")
                        .HasColumnType("int");

                    b.Property<int>("PolicyTermMin")
                        .HasColumnType("int");

                    b.Property<int>("ProfitRatio")
                        .HasColumnType("int");

                    b.HasIndex("InsuranceSchemeId");

                    b.HasIndex("InsuranceTypeId");

                    b.ToTable("InsurancePlan");
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.InsuranceScheme", b =>
                {
                    b.HasBaseType("InsuranceLib.DAL.Models.BaseEntity");

                    b.Property<int>("CommissionNewRegistration")
                        .HasColumnType("int");

                    b.Property<int>("CommissionPerInstallment")
                        .HasColumnType("int");

                    b.Property<string>("Information")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceSchemeTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceTypeTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.ToTable("InsuranceScheme");
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.InsuranceType", b =>
                {
                    b.HasBaseType("InsuranceLib.DAL.Models.BaseEntity");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("TypeTitle")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("InsuranceType");
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.Policy", b =>
                {
                    b.HasBaseType("InsuranceLib.DAL.Models.BaseEntity");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("AgentCommission")
                        .HasColumnType("float");

                    b.Property<string>("InsuranceSchemeTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InsuranceTypeTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MaturityDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PolicyTerm")
                        .HasColumnType("int");

                    b.Property<int>("ProfitRatio")
                        .HasColumnType("int");

                    b.Property<double>("SumAssured")
                        .HasColumnType("float");

                    b.Property<double>("TotalPremiumAmount")
                        .HasColumnType("float");

                    b.ToTable("Policy");
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.State", b =>
                {
                    b.HasBaseType("InsuranceLib.DAL.Models.BaseEntity");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("StateName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("State");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("InsuranceLib.DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("InsuranceLib.DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsuranceLib.DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("InsuranceLib.DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.City", b =>
                {
                    b.HasOne("InsuranceLib.DAL.Models.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("InsuranceLib.DAL.Models.City", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("InsuranceLib.DAL.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId");

                    b.Navigation("State");
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.Image", b =>
                {
                    b.HasOne("InsuranceLib.DAL.Models.BaseEntity", "BaseEntity")
                        .WithMany()
                        .HasForeignKey("BaseEntityId1");

                    b.HasOne("InsuranceLib.DAL.Models.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("InsuranceLib.DAL.Models.Image", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("BaseEntity");
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.InsuranceAccount", b =>
                {
                    b.HasOne("InsuranceLib.DAL.Models.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("InsuranceLib.DAL.Models.InsuranceAccount", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.InsurancePlan", b =>
                {
                    b.HasOne("InsuranceLib.DAL.Models.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("InsuranceLib.DAL.Models.InsurancePlan", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("InsuranceLib.DAL.Models.InsuranceScheme", "InsuranceScheme")
                        .WithMany()
                        .HasForeignKey("InsuranceSchemeId");

                    b.HasOne("InsuranceLib.DAL.Models.InsuranceType", "InsuranceType")
                        .WithMany()
                        .HasForeignKey("InsuranceTypeId");

                    b.Navigation("InsuranceScheme");

                    b.Navigation("InsuranceType");
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.InsuranceScheme", b =>
                {
                    b.HasOne("InsuranceLib.DAL.Models.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("InsuranceLib.DAL.Models.InsuranceScheme", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.InsuranceType", b =>
                {
                    b.HasOne("InsuranceLib.DAL.Models.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("InsuranceLib.DAL.Models.InsuranceType", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.Policy", b =>
                {
                    b.HasOne("InsuranceLib.DAL.Models.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("InsuranceLib.DAL.Models.Policy", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InsuranceLib.DAL.Models.State", b =>
                {
                    b.HasOne("InsuranceLib.DAL.Models.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("InsuranceLib.DAL.Models.State", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
