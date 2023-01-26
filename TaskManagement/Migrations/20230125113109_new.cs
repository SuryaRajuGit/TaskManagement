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
                    Password = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
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
                name: "TaskAssigneeMapping",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    { new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a"), "high", "HIGH" },
                    { new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794"), "medium", "MEDIUM" },
                    { new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad"), "low", "LOW" },
                    { new Guid("031feee7-02c4-43f7-9269-b777ae5558d4"), "open", "OPEN" },
                    { new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844"), "inprogress", "INPROGRESS" },
                    { new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752"), "completed", "COMPLETED" },
                    { new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2"), "3 days", "3_DAYS" },
                    { new Guid("cd2a89f8-dd1a-4a62-8802-1ec27c2c3980"), "7 days", "7_DAYS" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name", "Password", "Phone", "UserName" },
                values: new object[] { new Guid("b0809ba9-2cdb-400c-852b-d9fa50b671b6"), null, "o4UhjEI94IFLPSGjPrdplj3C1Z9g+z7tDY3/2ZedF1c=", null, "surya" });

            migrationBuilder.InsertData(
                table: "RefSetTerm",
                columns: new[] { "Id", "RefSetId", "RefTermId" },
                values: new object[,]
                {
                    { new Guid("4e52c006-69ee-4831-8c9a-528ed15ef4ab"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a") },
                    { new Guid("f5937774-04f6-404f-8f73-9076cef0e234"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794") },
                    { new Guid("fbea257b-4350-44c1-9c61-4eae0edf4bdc"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad") },
                    { new Guid("c5b3d1ac-6a61-4d76-b63f-aef2a9c045fa"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("031feee7-02c4-43f7-9269-b777ae5558d4") },
                    { new Guid("3fca2bac-e307-46bf-9f0c-fbea41afb038"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844") },
                    { new Guid("72183858-d59f-4a06-9e3c-06538b6f28ef"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752") },
                    { new Guid("6ec637f5-c764-4678-960d-232d45787dea"), new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2") },
                    { new Guid("5c799f14-7220-494a-b94f-6769f89c11f6"), new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("cd2a89f8-dd1a-4a62-8802-1ec27c2c3980") }
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
                name: "IX_TaskAssigneeMapping_TasksId",
                table: "TaskAssigneeMapping",
                column: "TasksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefSetTerm");

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
