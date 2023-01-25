using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagement.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignee",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefSetTerm",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RefSetId = table.Column<Guid>(nullable: false),
                    RefTermId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefSetTerm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefSetTerm_RefSet_RefSetId",
                        column: x => x.RefSetId,
                        principalTable: "RefSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RefSetTerm_RefTerm_RefTermId",
                        column: x => x.RefTermId,
                        principalTable: "RefTerm",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskMapAssignee",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TaskId = table.Column<Guid>(nullable: false),
                    AssigneeId = table.Column<Guid>(nullable: false),
                    TasksId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskMapAssignee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskMapAssignee_Tasks_TasksId",
                        column: x => x.TasksId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Assignee",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("da2d22ae-bc19-475d-8779-4982a7623742"), "surya" },
                    { new Guid("9a97f397-41e6-4db8-88c4-150a0b414df1"), "raju" },
                    { new Guid("2aaa6be5-5e9b-47fb-85c8-1855ca710275"), "psr" }
                });

            migrationBuilder.InsertData(
                table: "RefSet",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), "priority", "PRIORITY" },
                    { new Guid("3b61dc28-b562-4153-a302-97866324806c"), "status", "STATUS" },
                    { new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), "remainder", "REMINDER_PERIOD" }
                });

            migrationBuilder.InsertData(
                table: "RefTerm",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a"), "high", "High" },
                    { new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794"), "medium", "Medium" },
                    { new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad"), "low", "Low" },
                    { new Guid("031feee7-02c4-43f7-9269-b777ae5558d4"), "open", "Open" },
                    { new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844"), "inprogress", "InProgress" },
                    { new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752"), "completed", "Completed" },
                    { new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2"), "3 days", "3_DAYS" },
                    { new Guid("cd2a89f8-dd1a-4a62-8802-1ec27c2c3980"), "7 days", "7_DAYS" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { new Guid("78293a57-d234-45b4-a13b-c50ad2fc676e"), "o4UhjEI94IFLPSGjPrdplj3C1Z9g+z7tDY3/2ZedF1c=", "surya" });

            migrationBuilder.InsertData(
                table: "RefSetTerm",
                columns: new[] { "Id", "RefSetId", "RefTermId" },
                values: new object[,]
                {
                    { new Guid("00a626b6-d14e-46b2-aa6a-ebbb3eb0a7e6"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a") },
                    { new Guid("cb366361-904e-4a0f-ab48-e42e7bef33e9"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794") },
                    { new Guid("97b312ab-a878-45d7-a9ff-b7cee2ef0045"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad") },
                    { new Guid("8194cf76-9fe7-4795-808b-3b6367a44380"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("031feee7-02c4-43f7-9269-b777ae5558d4") },
                    { new Guid("82352386-1b85-4ed7-80ca-9d27802a588d"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844") },
                    { new Guid("a9313597-d962-48f2-8ceb-7c9e5e3ef6f5"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752") },
                    { new Guid("c71465b2-a202-43db-ad2e-cfde5561bcef"), new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2") },
                    { new Guid("2864ff99-28e4-4a51-90a0-b9b0821b285f"), new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("cd2a89f8-dd1a-4a62-8802-1ec27c2c3980") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefSetTerm_RefSetId",
                table: "RefSetTerm",
                column: "RefSetId");

            migrationBuilder.CreateIndex(
                name: "IX_RefSetTerm_RefTermId",
                table: "RefSetTerm",
                column: "RefTermId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskMapAssignee_TasksId",
                table: "TaskMapAssignee",
                column: "TasksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignee");

            migrationBuilder.DropTable(
                name: "RefSetTerm");

            migrationBuilder.DropTable(
                name: "TaskMapAssignee");

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
