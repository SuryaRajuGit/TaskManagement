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
    [Migration("20230120072724_new1")]
    partial class new1
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
                            Id = new Guid("46b603e1-92dc-4b4b-9236-ea432717cbee"),
                            Name = "surya"
                        },
                        new
                        {
                            Id = new Guid("feead15f-4a48-4aa8-8c96-a8e095b05e01"),
                            Name = @"
raju"
                        },
                        new
                        {
                            Id = new Guid("9f7381e2-eb47-4c33-b41d-3b2f7fe001da"),
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
                            Id = new Guid("53c9fdba-3a18-4aee-91e3-230b8e9b1416"),
                            RefSetId = new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"),
                            RefTermId = new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a")
                        },
                        new
                        {
                            Id = new Guid("07b5ab6d-6425-4e03-b2f2-8555331dedd1"),
                            RefSetId = new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"),
                            RefTermId = new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794")
                        },
                        new
                        {
                            Id = new Guid("a3203561-96a6-48fb-ac63-f039181caa35"),
                            RefSetId = new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"),
                            RefTermId = new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad")
                        },
                        new
                        {
                            Id = new Guid("3e626d16-fb23-4c8d-99ad-ea074c496a54"),
                            RefSetId = new Guid("3b61dc28-b562-4153-a302-97866324806c"),
                            RefTermId = new Guid("031feee7-02c4-43f7-9269-b777ae5558d4")
                        },
                        new
                        {
                            Id = new Guid("e8d6122e-f1bd-4deb-9da0-f5bd6ddf116b"),
                            RefSetId = new Guid("3b61dc28-b562-4153-a302-97866324806c"),
                            RefTermId = new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844")
                        },
                        new
                        {
                            Id = new Guid("ad99efb0-eec4-41cc-99fd-ed903094a8f6"),
                            RefSetId = new Guid("3b61dc28-b562-4153-a302-97866324806c"),
                            RefTermId = new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752")
                        },
                        new
                        {
                            Id = new Guid("892a5b41-d0e4-4a10-997c-0a0954dc6e5f"),
                            RefSetId = new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"),
                            RefTermId = new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2")
                        },
                        new
                        {
                            Id = new Guid("163a528f-fa15-4d61-ad1c-e4084571a831"),
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
                            Id = new Guid("2644f688-f9da-4dea-aaca-b5263e5bc42c"),
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
