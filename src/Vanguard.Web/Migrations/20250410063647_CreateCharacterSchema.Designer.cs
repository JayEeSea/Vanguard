﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vanguard.Web.Data;

#nullable disable

namespace Vanguard.Web.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250410063647_CreateCharacterSchema")]
    partial class CreateCharacterSchema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Vanguard.Web.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("TimeZone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Vanguard.Web.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("FactionId")
                        .HasColumnType("int");

                    b.Property<int>("FactionParentId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UniverseId")
                        .HasColumnType("int");

                    b.Property<int>("UniverseParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FactionId");

                    b.HasIndex("UniverseId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressedName")
                        .HasColumnType("longtext");

                    b.Property<string>("Appearance")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Background")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("FactionId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastMedalDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LastPromotionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MemberId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Personality")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PlaceOfBirth")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<int>("RankId")
                        .HasColumnType("int");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int>("UniverseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("FactionId");

                    b.HasIndex("GenderId");

                    b.HasIndex("MemberId");

                    b.HasIndex("PositionId");

                    b.HasIndex("RankId");

                    b.HasIndex("SpeciesId");

                    b.HasIndex("UnitId");

                    b.HasIndex("UniverseId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Faction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UniverseId")
                        .HasColumnType("int");

                    b.Property<int>("UniverseParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UniverseId");

                    b.ToTable("Factions");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("FactionId")
                        .HasColumnType("int");

                    b.Property<int>("MaxRankId")
                        .HasColumnType("int");

                    b.Property<int>("MaxRankLevel")
                        .HasColumnType("int");

                    b.Property<int>("MinRankId")
                        .HasColumnType("int");

                    b.Property<int>("MinRankLevel")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<int>("UniverseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("FactionId");

                    b.HasIndex("MaxRankId");

                    b.HasIndex("MinRankId");

                    b.HasIndex("UnitId");

                    b.HasIndex("UniverseId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Rank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("FactionId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UniverseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("FactionId");

                    b.HasIndex("UniverseId");

                    b.ToTable("Ranks");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("FactionId")
                        .HasColumnType("int");

                    b.Property<int>("FactionParentId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UniverseId")
                        .HasColumnType("int");

                    b.Property<int>("UniverseParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FactionId");

                    b.HasIndex("UniverseId");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("BranchParentId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("FactionId")
                        .HasColumnType("int");

                    b.Property<int>("FactionParentId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UniverseId")
                        .HasColumnType("int");

                    b.Property<int>("UniverseParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("FactionId");

                    b.HasIndex("UniverseId");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Universe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Universes");
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
                    b.HasOne("Vanguard.Web.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Vanguard.Web.Models.ApplicationUser", null)
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

                    b.HasOne("Vanguard.Web.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Vanguard.Web.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Vanguard.Web.Models.Branch", b =>
                {
                    b.HasOne("Vanguard.Web.Models.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Universe", "Universe")
                        .WithMany()
                        .HasForeignKey("UniverseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faction");

                    b.Navigation("Universe");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Character", b =>
                {
                    b.HasOne("Vanguard.Web.Models.Branch", "Branch")
                        .WithMany("Characters")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Faction", "Faction")
                        .WithMany("Characters")
                        .HasForeignKey("FactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Gender", "Gender")
                        .WithMany("Characters")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.ApplicationUser", "Member")
                        .WithMany()
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Position", "Position")
                        .WithMany("Characters")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Rank", "Rank")
                        .WithMany("Characters")
                        .HasForeignKey("RankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Species", "Species")
                        .WithMany("Characters")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Unit", "Unit")
                        .WithMany("Characters")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Universe", "Universe")
                        .WithMany("Characters")
                        .HasForeignKey("UniverseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Faction");

                    b.Navigation("Gender");

                    b.Navigation("Member");

                    b.Navigation("Position");

                    b.Navigation("Rank");

                    b.Navigation("Species");

                    b.Navigation("Unit");

                    b.Navigation("Universe");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Faction", b =>
                {
                    b.HasOne("Vanguard.Web.Models.Universe", "Universe")
                        .WithMany()
                        .HasForeignKey("UniverseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Universe");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Position", b =>
                {
                    b.HasOne("Vanguard.Web.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Rank", "MaxRank")
                        .WithMany()
                        .HasForeignKey("MaxRankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Rank", "MinRank")
                        .WithMany()
                        .HasForeignKey("MinRankId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Universe", "Universe")
                        .WithMany()
                        .HasForeignKey("UniverseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Faction");

                    b.Navigation("MaxRank");

                    b.Navigation("MinRank");

                    b.Navigation("Unit");

                    b.Navigation("Universe");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Rank", b =>
                {
                    b.HasOne("Vanguard.Web.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Universe", "Universe")
                        .WithMany()
                        .HasForeignKey("UniverseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Faction");

                    b.Navigation("Universe");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Species", b =>
                {
                    b.HasOne("Vanguard.Web.Models.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Universe", "Universe")
                        .WithMany()
                        .HasForeignKey("UniverseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faction");

                    b.Navigation("Universe");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Unit", b =>
                {
                    b.HasOne("Vanguard.Web.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Faction", "Faction")
                        .WithMany()
                        .HasForeignKey("FactionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vanguard.Web.Models.Universe", "Universe")
                        .WithMany()
                        .HasForeignKey("UniverseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Faction");

                    b.Navigation("Universe");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Branch", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Faction", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Gender", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Position", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Rank", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Species", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Unit", b =>
                {
                    b.Navigation("Characters");
                });

            modelBuilder.Entity("Vanguard.Web.Models.Universe", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
