using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagement.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefTerm",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Key = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefTerm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Priority = table.Column<Guid>(nullable: false),
                    Status = table.Column<Guid>(nullable: false),
                    Assigner = table.Column<Guid>(nullable: false),
                    ParentTaskId = table.Column<Guid>(nullable: false),
                    ReminderPeriodId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SetRefTerm",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RefSetId = table.Column<Guid>(nullable: false),
                    RefTermId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetRefTerm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetRefTerm_RefSet_RefSetId",
                        column: x => x.RefSetId,
                        principalTable: "RefSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SetRefTerm_RefTerm_RefTermId",
                        column: x => x.RefTermId,
                        principalTable: "RefTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskAssigneeMapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    TaskId = table.Column<Guid>(nullable: false),
                    AssigneeId = table.Column<Guid>(nullable: false),
                    TasksId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskAssigneeMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskAssigneeMapping_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "RefSet",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "Key", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 996, DateTimeKind.Local).AddTicks(7964), "priority", true, "PRIORITY", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 996, DateTimeKind.Local).AddTicks(8157), "status", true, "STATUS", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 996, DateTimeKind.Local).AddTicks(8175), "remainder", true, "REMINDER_PERIOD", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RefTerm",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "Key", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 990, DateTimeKind.Local).AddTicks(6405), "high", true, "HIGH", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 992, DateTimeKind.Local).AddTicks(6961), "medium", true, "MEDIUM", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 992, DateTimeKind.Local).AddTicks(7049), "low", true, "LOW", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("031feee7-02c4-43f7-9269-b777ae5558d4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 992, DateTimeKind.Local).AddTicks(7063), "open", true, "OPEN", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 992, DateTimeKind.Local).AddTicks(7075), "inprogress", true, "IN_PROGRESS", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 992, DateTimeKind.Local).AddTicks(7094), "completed", true, "COMPLETED", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 992, DateTimeKind.Local).AddTicks(7106), "3 days", true, "3_DAYS", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd2a89f8-dd1a-4a62-8802-1ec27c2c3980"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 992, DateTimeKind.Local).AddTicks(7117), "7 days", true, "7_DAYS", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "IsActive", "Name", "Password", "Phone", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("aaa91bab-bac7-40b0-ad47-94bd2cbc7beb"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 13, 3, DateTimeKind.Local).AddTicks(6683), "psurya@gmail.com", true, null, "o4UhjEI94IFLPSGjPrdplj3C1Z9g+z7tDY3/2ZedF1c=", null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("796c0da6-d397-40b9-be76-a68a57e3bd4c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 13, 3, DateTimeKind.Local).AddTicks(7926), @"
                test@gmail.com", true, null, "o4UhjEI94IFLPSGjPrdplj3C1Z9g+z7tDY3/2ZedF1c=", null, new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SetRefTerm",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "RefSetId", "RefTermId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("4dc3c87f-be60-4f6e-a889-30b9b2117891"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 996, DateTimeKind.Local).AddTicks(483), true, new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("95f84c92-2979-4aca-b4df-fd14934ce72c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 996, DateTimeKind.Local).AddTicks(706), true, new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dc4af45a-79de-4820-8c3c-de017d82cdda"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 996, DateTimeKind.Local).AddTicks(729), true, new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("67c5bd23-e692-44c3-a53e-e70f52d6e2c8"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 996, DateTimeKind.Local).AddTicks(893), true, new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("031feee7-02c4-43f7-9269-b777ae5558d4"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2daa8de1-34fa-4e6c-8485-8b0a63c4240d"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 996, DateTimeKind.Local).AddTicks(909), true, new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bfc296e6-98db-4844-93d0-4a93a487d87f"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 996, DateTimeKind.Local).AddTicks(932), true, new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8c707238-3700-4cf2-9e3e-9064c69d1c97"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 996, DateTimeKind.Local).AddTicks(965), true, new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("edeab0e9-5bc0-4603-9958-102be8733aad"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2023, 1, 30, 18, 10, 12, 996, DateTimeKind.Local).AddTicks(978), true, new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("cd2a89f8-dd1a-4a62-8802-1ec27c2c3980"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SetRefTerm_RefSetId",
                table: "SetRefTerm",
                column: "RefSetId");

            migrationBuilder.CreateIndex(
                name: "IX_SetRefTerm_RefTermId",
                table: "SetRefTerm",
                column: "RefTermId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskAssigneeMapping_TasksId",
                table: "TaskAssigneeMapping",
                column: "TasksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetRefTerm");

            migrationBuilder.DropTable(
                name: "TaskAssigneeMapping");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "RefSet");

            migrationBuilder.DropTable(
                name: "RefTerm");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
