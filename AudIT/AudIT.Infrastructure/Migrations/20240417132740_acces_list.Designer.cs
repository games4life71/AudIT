﻿// <auto-generated />
using System;
using AudIT.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    [DbContext(typeof(AudITContext))]
    [Migration("20240417132740_acces_list")]
    partial class acces_list
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("AudIT.Domain.Misc.BaseDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccesUserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ActivityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("TEXT");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("OwnerId");

                    b.ToTable("BaseDocuments");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseDocument");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AudiT.Domain.Entities.ActionRisk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Impact")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ObjectiveActionId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Probability")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Risk")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ObjectiveActionId");

                    b.ToTable("ActionRisk");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccesUserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuditMissionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ObjectiveActionId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuditMissionId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ObjectiveActionId");

                    b.HasIndex("UserId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.AuditMission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccesUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("AuditMissions");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.AuditMissionDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuditMissionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BaseDocumentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuditMissionId");

                    b.HasIndex("BaseDocumentId");

                    b.ToTable("AuditMissionDocument");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.AuditMissionObjectives", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuditMissionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ObjectiveId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuditMissionId");

                    b.HasIndex("ObjectiveId");

                    b.ToTable("AuditMissionObjectives");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.AuditMissionRecommendations", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuditMissionId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RecommendationId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuditMissionId");

                    b.HasIndex("RecommendationId");

                    b.ToTable("AuditMissionRecommendations");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccesUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("HomePhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("InstitutionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.Institution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccesUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailDomains")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HomePhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("InstitutionAdminId")
                        .HasColumnType("TEXT");

                    b.Property<string>("InstitutionAdminId1")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InstitutionAdminId1");

                    b.ToTable("Institutions");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.Objective", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AuditMissionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuditMissionId");

                    b.ToTable("Objective");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.ObjectiveAction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ControaleInterneAsteptate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ControaleInterneExistente")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ObjectiveId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Selected")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ObjectiveId");

                    b.ToTable("ObjectiveAction");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.Recommendation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("AccesUserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ObjectiveActionId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ObjectiveActionId");

                    b.ToTable("Recommendations");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Functie")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("OfficePhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecondEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Verified")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

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
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AudiT.Domain.Entities.StandaloneDocument", b =>
                {
                    b.HasBaseType("AudIT.Domain.Misc.BaseDocument");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.HasIndex("DepartmentId");

                    b.HasDiscriminator().HasValue("StandaloneDocument");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.TemplateDocument", b =>
                {
                    b.HasBaseType("AudIT.Domain.Misc.BaseDocument");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("TemplateDocument");
                });

            modelBuilder.Entity("AudIT.Domain.Misc.BaseDocument", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.Activity", null)
                        .WithMany("AttachedDocuments")
                        .HasForeignKey("ActivityId");

                    b.HasOne("AudiT.Domain.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.ActionRisk", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.ObjectiveAction", null)
                        .WithMany("ActionRisks")
                        .HasForeignKey("ObjectiveActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AudiT.Domain.Entities.Activity", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.AuditMission", "AuditMission")
                        .WithMany("Actions")
                        .HasForeignKey("AuditMissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AudiT.Domain.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AudiT.Domain.Entities.ObjectiveAction", "ObjectiveAction")
                        .WithMany()
                        .HasForeignKey("ObjectiveActionId");

                    b.HasOne("AudiT.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuditMission");

                    b.Navigation("Department");

                    b.Navigation("ObjectiveAction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.AuditMission", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AudiT.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.AuditMissionDocument", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.AuditMission", "AuditMission")
                        .WithMany("AuditMissionDocuments")
                        .HasForeignKey("AuditMissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AudIT.Domain.Misc.BaseDocument", "BaseDocument")
                        .WithMany()
                        .HasForeignKey("BaseDocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuditMission");

                    b.Navigation("BaseDocument");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.AuditMissionObjectives", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.AuditMission", "AuditMission")
                        .WithMany("AuditMissionObjectives")
                        .HasForeignKey("AuditMissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AudiT.Domain.Entities.Objective", "Objective")
                        .WithMany()
                        .HasForeignKey("ObjectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuditMission");

                    b.Navigation("Objective");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.AuditMissionRecommendations", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.AuditMission", "AuditMission")
                        .WithMany()
                        .HasForeignKey("AuditMissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AudiT.Domain.Entities.Recommendation", "Recommendation")
                        .WithMany()
                        .HasForeignKey("RecommendationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuditMission");

                    b.Navigation("Recommendation");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.Department", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.Institution", "Institution")
                        .WithMany("Departments")
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.Institution", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.User", "InstitutionAdmin")
                        .WithMany()
                        .HasForeignKey("InstitutionAdminId1");

                    b.Navigation("InstitutionAdmin");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.Objective", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.AuditMission", "AuditMission")
                        .WithMany()
                        .HasForeignKey("AuditMissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuditMission");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.ObjectiveAction", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.Objective", "Objective")
                        .WithMany("ObjectiveActions")
                        .HasForeignKey("ObjectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Objective");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.Recommendation", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.ObjectiveAction", "ObjectiveAction")
                        .WithMany()
                        .HasForeignKey("ObjectiveActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObjectiveAction");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.User", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
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
                    b.HasOne("AudiT.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.User", null)
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

                    b.HasOne("AudiT.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AudiT.Domain.Entities.StandaloneDocument", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.Activity", b =>
                {
                    b.Navigation("AttachedDocuments");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.AuditMission", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("AuditMissionDocuments");

                    b.Navigation("AuditMissionObjectives");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.Institution", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.Objective", b =>
                {
                    b.Navigation("ObjectiveActions");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.ObjectiveAction", b =>
                {
                    b.Navigation("ActionRisks");
                });
#pragma warning restore 612, 618
        }
    }
}
