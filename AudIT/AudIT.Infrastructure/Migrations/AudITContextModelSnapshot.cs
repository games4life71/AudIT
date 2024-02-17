﻿// <auto-generated />
using System;
using AudIT.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AudIT.Infrastructure.Migrations
{
    [DbContext(typeof(AudITContext))]
    partial class AudITContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("AudIT.Domain.Misc.BaseDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("BaseDocument");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseDocument");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AudiT.Domain.Entities.Action", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("AuditMissionId")
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

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AuditMissionId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.ActionRisk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ObjectiveActionId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Risk")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ObjectiveActionId");

                    b.ToTable("ActionRisk");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.AuditMission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.Property<Guid>("UserId")
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

            modelBuilder.Entity("AudiT.Domain.Entities.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
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

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

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

                    b.Property<Guid?>("ObjectiveId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Selected")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ObjectiveId");

                    b.ToTable("ObjectiveAction");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstEmail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Functie")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("OfficePhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondEmail")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Users");
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

                    b.Property<int>("Version")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("TemplateDocument");
                });

            modelBuilder.Entity("AudIT.Domain.Misc.BaseDocument", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.Action", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.AuditMission", null)
                        .WithMany("Actions")
                        .HasForeignKey("AuditMissionId");

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

            modelBuilder.Entity("AudiT.Domain.Entities.ActionRisk", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.ObjectiveAction", null)
                        .WithMany("ActionRisks")
                        .HasForeignKey("ObjectiveActionId");
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
                        .WithMany("Objectives")
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

            modelBuilder.Entity("AudiT.Domain.Entities.Department", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.Institution", "Institution")
                        .WithMany("Departments")
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Institution");
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
                    b.HasOne("AudiT.Domain.Entities.Objective", null)
                        .WithMany("ObjectiveActions")
                        .HasForeignKey("ObjectiveId");
                });

            modelBuilder.Entity("AudiT.Domain.Entities.User", b =>
                {
                    b.HasOne("AudiT.Domain.Entities.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
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

            modelBuilder.Entity("AudiT.Domain.Entities.AuditMission", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("AuditMissionDocuments");

                    b.Navigation("Objectives");
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
