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
    [Migration("20230120073258_new3")]
    partial class new3
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
                            Id = new Guid("f9320863-2a92-4d54-9be0-3ef86e69490c"),
                            Name = "surya"
                        },
                        new
                        {
                            Id = new Guid("97ba8980-d1e0-4274-89d2-149880510bd2"),
                            Name = @"
raju"
                        },
                        new
                        {
                            Id = new Guid("53480674-5f46-4189-94eb-1b8b2f852c3b"),
                            Name = @"
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
                            Id = new Guid("999ade66-10aa-4058-8775-0daf12e55e37"),
                            RefSetId = new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"),
                            RefTermId = new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a")
                        },
                        new
                        {
                            Id = new Guid("9e0de871-6191-4dcc-871b-0a6a226a58df"),
                            RefSetId = new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"),
                            RefTermId = new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794")
                        },
                        new
                        {
                            Id = new Guid("1f59c003-8f0a-4cc7-bbcf-9e2504b5a4f5"),
                            RefSetId = new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"),
                            RefTermId = new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad")
                        },
                        new
                        {
                            Id = new Guid("979f434f-314d-4b9c-9faf-2bae560cb093"),
                            RefSetId = new Guid("3b61dc28-b562-4153-a302-97866324806c"),
                            RefTermId = new Guid("031feee7-02c4-43f7-9269-b777ae5558d4")
                        },
                        new
                        {
                            Id = new Guid("5b3c02b5-a5a7-4b13-b7a3-26b11161825b"),
                            RefSetId = new Guid("3b61dc28-b562-4153-a302-97866324806c"),
                            RefTermId = new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844")
                        },
                        new
                        {
                            Id = new Guid("af8824f1-973a-4e42-a6ac-0405058db89e"),
                            RefSetId = new Guid("3b61dc28-b562-4153-a302-97866324806c"),
                            RefTermId = new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752")
                        },
                        new
                        {
                            Id = new Guid("e109e904-0ff0-438c-96a8-9a2de7435254"),
                            RefSetId = new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"),
                            RefTermId = new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2")
                        },
                        new
                        {
                            Id = new Guid("fe206146-291e-4739-9b72-0ededa4b1fb6"),
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
                            Id = new Guid("ef1b0174-6349-4370-9e0e-30c8e5857ef6"),
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
