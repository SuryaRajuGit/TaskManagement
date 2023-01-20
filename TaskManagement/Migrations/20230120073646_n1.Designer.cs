﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagement.Models;

namespace TaskManagement.Migrations
{
    [DbContext(typeof(TaskManagementContext))]
    [Migration("20230120073646_n1")]
    partial class n1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskManagement.Entities.Models.Assignee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Assignee");

                    b.HasData(
                        new
                        {
                            Id = new Guid("59759ff6-bd3c-4c99-93d7-6662774689ef"),
                            Name = @"surya
raju
psr"
                        });
                });

            modelBuilder.Entity("TaskManagement.Models.RefSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RefSet");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"),
                            Description = "priority",
                            Key = "PRIORITY"
                        },
                        new
                        {
                            Id = new Guid("3b61dc28-b562-4153-a302-97866324806c"),
                            Description = "status",
                            Key = "STATUS"
                        },
                        new
                        {
                            Id = new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"),
                            Description = "remainder",
                            Key = "REMINDER_PERIOD"
                        });
                });

            modelBuilder.Entity("TaskManagement.Models.RefSetTerm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RefSetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RefTermId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RefSetId");

                    b.HasIndex("RefTermId");

                    b.ToTable("RefSetTerm");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5f4233be-6d7e-4437-aa7f-ce69c20e11d9"),
                            RefSetId = new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"),
                            RefTermId = new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a")
                        },
                        new
                        {
                            Id = new Guid("d7ecf7d0-23b2-4b8b-b3ba-07ab4952f4f8"),
                            RefSetId = new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"),
                            RefTermId = new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794")
                        },
                        new
                        {
                            Id = new Guid("9070ecf3-38ee-4375-9ae0-a7872a36874c"),
                            RefSetId = new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"),
                            RefTermId = new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad")
                        },
                        new
                        {
                            Id = new Guid("f0134a1c-246a-41f1-bee5-7bce07909775"),
                            RefSetId = new Guid("3b61dc28-b562-4153-a302-97866324806c"),
                            RefTermId = new Guid("031feee7-02c4-43f7-9269-b777ae5558d4")
                        },
                        new
                        {
                            Id = new Guid("a2504391-ce23-48c4-8adf-20d7323ff81f"),
                            RefSetId = new Guid("3b61dc28-b562-4153-a302-97866324806c"),
                            RefTermId = new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844")
                        },
                        new
                        {
                            Id = new Guid("20f6f95c-9dc8-459e-930d-48fde62fec5a"),
                            RefSetId = new Guid("3b61dc28-b562-4153-a302-97866324806c"),
                            RefTermId = new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752")
                        },
                        new
                        {
                            Id = new Guid("a9075c5d-8984-4abe-8c26-e66745bfa83b"),
                            RefSetId = new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"),
                            RefTermId = new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2")
                        },
                        new
                        {
                            Id = new Guid("87bfaff4-cb82-46a2-8728-e9be3574b4d5"),
                            RefSetId = new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"),
                            RefTermId = new Guid("cd2a89f8-dd1a-4a62-8802-1ec27c2c3980")
                        });
                });

            modelBuilder.Entity("TaskManagement.Models.RefTerm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RefTerm");

                    b.HasData(
                        new
                        {
                            Id = new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a"),
                            Description = "high",
                            Key = "High"
                        },
                        new
                        {
                            Id = new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794"),
                            Description = "medium",
                            Key = "Medium"
                        },
                        new
                        {
                            Id = new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad"),
                            Description = "low",
                            Key = "Low"
                        },
                        new
                        {
                            Id = new Guid("031feee7-02c4-43f7-9269-b777ae5558d4"),
                            Description = "open",
                            Key = "Open"
                        },
                        new
                        {
                            Id = new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844"),
                            Description = "inprogress",
                            Key = "InProgress"
                        },
                        new
                        {
                            Id = new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752"),
                            Description = "completed",
                            Key = "Completed"
                        },
                        new
                        {
                            Id = new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2"),
                            Description = "3 days",
                            Key = "3_DAYS"
                        },
                        new
                        {
                            Id = new Guid("cd2a89f8-dd1a-4a62-8802-1ec27c2c3980"),
                            Description = "7 days",
                            Key = "7_DAYS"
                        });
                });

            modelBuilder.Entity("TaskManagement.Models.TaskMapAssignee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssigneeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TasksId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TasksId");

                    b.ToTable("TaskMapAssignee");
                });

            modelBuilder.Entity("TaskManagement.Models.Tasks", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Assigner")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ParentTaskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Priority")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReminderPeriodId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Status")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManagement.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("677dc1dd-fbd1-4072-af43-36ad9763ac48"),
                            Password = "o4UhjEI94IFkRkJR59gnorDRPk49Rh8O",
                            UserName = "surya"
                        });
                });

            modelBuilder.Entity("TaskManagement.Models.RefSetTerm", b =>
                {
                    b.HasOne("TaskManagement.Models.RefSet", "RefSet")
                        .WithMany()
                        .HasForeignKey("RefSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagement.Models.RefTerm", "RefTerm")
                        .WithMany()
                        .HasForeignKey("RefTermId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TaskManagement.Models.TaskMapAssignee", b =>
                {
                    b.HasOne("TaskManagement.Models.Tasks", null)
                        .WithMany("TaskMapAssignee")
                        .HasForeignKey("TasksId");
                });
#pragma warning restore 612, 618
        }
    }
}
