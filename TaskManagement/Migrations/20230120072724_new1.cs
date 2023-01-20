using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagement.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Assignee",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("46b603e1-92dc-4b4b-9236-ea432717cbee"), "surya" },
                    { new Guid("feead15f-4a48-4aa8-8c96-a8e095b05e01"), @"
                raju" },
                    { new Guid("9f7381e2-eb47-4c33-b41d-3b2f7fe001da"), @"
                psr" }
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
                values: new object[] { new Guid("2644f688-f9da-4dea-aaca-b5263e5bc42c"), "o4UhjEI94IFkRkJR59gnorDRPk49Rh8O", "surya" });

            migrationBuilder.InsertData(
                table: "RefSetTerm",
                columns: new[] { "Id", "RefSetId", "RefTermId" },
                values: new object[,]
                {
                    { new Guid("53c9fdba-3a18-4aee-91e3-230b8e9b1416"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a") },
                    { new Guid("07b5ab6d-6425-4e03-b2f2-8555331dedd1"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794") },
                    { new Guid("a3203561-96a6-48fb-ac63-f039181caa35"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad") },
                    { new Guid("3e626d16-fb23-4c8d-99ad-ea074c496a54"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("031feee7-02c4-43f7-9269-b777ae5558d4") },
                    { new Guid("e8d6122e-f1bd-4deb-9da0-f5bd6ddf116b"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844") },
                    { new Guid("ad99efb0-eec4-41cc-99fd-ed903094a8f6"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752") },
                    { new Guid("892a5b41-d0e4-4a10-997c-0a0954dc6e5f"), new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2") },
                    { new Guid("163a528f-fa15-4d61-ad1c-e4084571a831"), new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("cd2a89f8-dd1a-4a62-8802-1ec27c2c3980") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignee",
                keyColumn: "Id",
                keyValue: new Guid("46b603e1-92dc-4b4b-9236-ea432717cbee"));

            migrationBuilder.DeleteData(
                table: "Assignee",
                keyColumn: "Id",
                keyValue: new Guid("9f7381e2-eb47-4c33-b41d-3b2f7fe001da"));

            migrationBuilder.DeleteData(
                table: "Assignee",
                keyColumn: "Id",
                keyValue: new Guid("feead15f-4a48-4aa8-8c96-a8e095b05e01"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("07b5ab6d-6425-4e03-b2f2-8555331dedd1"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("163a528f-fa15-4d61-ad1c-e4084571a831"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("3e626d16-fb23-4c8d-99ad-ea074c496a54"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("53c9fdba-3a18-4aee-91e3-230b8e9b1416"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("892a5b41-d0e4-4a10-997c-0a0954dc6e5f"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("a3203561-96a6-48fb-ac63-f039181caa35"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("ad99efb0-eec4-41cc-99fd-ed903094a8f6"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("e8d6122e-f1bd-4deb-9da0-f5bd6ddf116b"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2644f688-f9da-4dea-aaca-b5263e5bc42c"));

            migrationBuilder.DeleteData(
                table: "RefSet",
                keyColumn: "Id",
                keyValue: new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"));

            migrationBuilder.DeleteData(
                table: "RefSet",
                keyColumn: "Id",
                keyValue: new Guid("3b61dc28-b562-4153-a302-97866324806c"));

            migrationBuilder.DeleteData(
                table: "RefSet",
                keyColumn: "Id",
                keyValue: new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("031feee7-02c4-43f7-9269-b777ae5558d4"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("cd2a89f8-dd1a-4a62-8802-1ec27c2c3980"));

            migrationBuilder.DeleteData(
                table: "RefTerm",
                keyColumn: "Id",
                keyValue: new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad"));
        }
    }
}
