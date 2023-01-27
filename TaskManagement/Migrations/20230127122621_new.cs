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
                    CreatedId = table.Column<Guid>(nullable: false),
                    UpdatedId = table.Column<Guid>(nullable: false),
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
                    CreatedId = table.Column<Guid>(nullable: false),
                    UpdatedId = table.Column<Guid>(nullable: false),
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
                    CreatedId = table.Column<Guid>(nullable: false),
                    UpdatedId = table.Column<Guid>(nullable: false),
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
                    CreatedId = table.Column<Guid>(nullable: false),
                    UpdatedId = table.Column<Guid>(nullable: false),
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
                    CreatedId = table.Column<Guid>(nullable: false),
                    UpdatedId = table.Column<Guid>(nullable: false),
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
                    CreatedId = table.Column<Guid>(nullable: false),
                    UpdatedId = table.Column<Guid>(nullable: false),
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
                columns: new[] { "Id", "CreatedDate", "CreatedId", "Description", "IsActive", "Key", "UpdatedDate", "UpdatedId" },
                values: new object[,]
                {
                    { new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new DateTime(2023, 1, 27, 17, 56, 20, 557, DateTimeKind.Local).AddTicks(8036), new Guid("00000000-0000-0000-0000-000000000000"), "priority", true, "PRIORITY", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("3b61dc28-b562-4153-a302-97866324806c"), new DateTime(2023, 1, 27, 17, 56, 20, 557, DateTimeKind.Local).AddTicks(8188), new Guid("00000000-0000-0000-0000-000000000000"), "status", true, "STATUS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new DateTime(2023, 1, 27, 17, 56, 20, 557, DateTimeKind.Local).AddTicks(8198), new Guid("00000000-0000-0000-0000-000000000000"), "remainder", true, "REMINDER_PERIOD", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "RefTerm",
                columns: new[] { "Id", "CreatedDate", "CreatedId", "Description", "IsActive", "Key", "UpdatedDate", "UpdatedId" },
                values: new object[,]
                {
                    { new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a"), new DateTime(2023, 1, 27, 17, 56, 20, 547, DateTimeKind.Local).AddTicks(6880), new Guid("00000000-0000-0000-0000-000000000000"), "high", true, "HIGH", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794"), new DateTime(2023, 1, 27, 17, 56, 20, 549, DateTimeKind.Local).AddTicks(6809), new Guid("00000000-0000-0000-0000-000000000000"), "medium", true, "MEDIUM", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad"), new DateTime(2023, 1, 27, 17, 56, 20, 549, DateTimeKind.Local).AddTicks(6894), new Guid("00000000-0000-0000-0000-000000000000"), "low", true, "LOW", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("031feee7-02c4-43f7-9269-b777ae5558d4"), new DateTime(2023, 1, 27, 17, 56, 20, 549, DateTimeKind.Local).AddTicks(6909), new Guid("00000000-0000-0000-0000-000000000000"), "open", true, "OPEN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844"), new DateTime(2023, 1, 27, 17, 56, 20, 549, DateTimeKind.Local).AddTicks(6920), new Guid("00000000-0000-0000-0000-000000000000"), "inprogress", true, "INPROGRESS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752"), new DateTime(2023, 1, 27, 17, 56, 20, 549, DateTimeKind.Local).AddTicks(6938), new Guid("00000000-0000-0000-0000-000000000000"), "completed", true, "COMPLETED", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2"), new DateTime(2023, 1, 27, 17, 56, 20, 549, DateTimeKind.Local).AddTicks(6948), new Guid("00000000-0000-0000-0000-000000000000"), "3 days", true, "3_DAYS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("cd2a89f8-dd1a-4a62-8802-1ec27c2c3980"), new DateTime(2023, 1, 27, 17, 56, 20, 549, DateTimeKind.Local).AddTicks(6957), new Guid("00000000-0000-0000-0000-000000000000"), "7 days", true, "7_DAYS", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedDate", "CreatedId", "Email", "IsActive", "Name", "Password", "Phone", "UpdatedDate", "UpdatedId" },
                values: new object[,]
                {
                    { new Guid("18c7e0aa-45ef-411f-b9e4-a5d72dbd0e73"), new DateTime(2023, 1, 27, 17, 56, 20, 565, DateTimeKind.Local).AddTicks(9820), new Guid("00000000-0000-0000-0000-000000000000"), "psurya@gmail.com", true, null, "o4UhjEI94IFLPSGjPrdplj3C1Z9g+z7tDY3/2ZedF1c=", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("08757d54-7892-4064-934b-886a31d5f783"), new DateTime(2023, 1, 27, 17, 56, 20, 566, DateTimeKind.Local).AddTicks(1025), new Guid("00000000-0000-0000-0000-000000000000"), @"
                test@gmail.com", true, null, "o4UhjEI94IFLPSGjPrdplj3C1Z9g+z7tDY3/2ZedF1c=", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "SetRefTerm",
                columns: new[] { "Id", "CreatedDate", "CreatedId", "IsActive", "RefSetId", "RefTermId", "UpdatedDate", "UpdatedId" },
                values: new object[,]
                {
                    { new Guid("953b4148-1ea5-4a18-94d9-c7ac420114ac"), new DateTime(2023, 1, 27, 17, 56, 20, 556, DateTimeKind.Local).AddTicks(8173), new Guid("00000000-0000-0000-0000-000000000000"), true, new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("3422f08e-46aa-4d7f-a0b8-7f5891e279bf"), new DateTime(2023, 1, 27, 17, 56, 20, 556, DateTimeKind.Local).AddTicks(8330), new Guid("00000000-0000-0000-0000-000000000000"), true, new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("7a9f9cc6-520c-4bf8-b663-87c7968e65ff"), new DateTime(2023, 1, 27, 17, 56, 20, 556, DateTimeKind.Local).AddTicks(8344), new Guid("00000000-0000-0000-0000-000000000000"), true, new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("e5fefc85-5e26-48b6-a57d-7dcc6f399644"), new DateTime(2023, 1, 27, 17, 56, 20, 556, DateTimeKind.Local).AddTicks(8355), new Guid("00000000-0000-0000-0000-000000000000"), true, new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("031feee7-02c4-43f7-9269-b777ae5558d4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c8166cc9-8343-4ade-a08b-a5f955379ebd"), new DateTime(2023, 1, 27, 17, 56, 20, 556, DateTimeKind.Local).AddTicks(8365), new Guid("00000000-0000-0000-0000-000000000000"), true, new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("d90e89dc-ca27-4b0e-9f02-f62d1642f31c"), new DateTime(2023, 1, 27, 17, 56, 20, 556, DateTimeKind.Local).AddTicks(8381), new Guid("00000000-0000-0000-0000-000000000000"), true, new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8ae5de6a-eefc-4005-93d5-d8734aca93bc"), new DateTime(2023, 1, 27, 17, 56, 20, 556, DateTimeKind.Local).AddTicks(8390), new Guid("00000000-0000-0000-0000-000000000000"), true, new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("e0557501-ad15-4180-9e0b-744c98340c99"), new DateTime(2023, 1, 27, 17, 56, 20, 556, DateTimeKind.Local).AddTicks(8418), new Guid("00000000-0000-0000-0000-000000000000"), true, new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("cd2a89f8-dd1a-4a62-8802-1ec27c2c3980"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") }
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
