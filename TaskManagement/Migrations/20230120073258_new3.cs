using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagement.Migrations
{
    public partial class new3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Assignee",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("f9320863-2a92-4d54-9be0-3ef86e69490c"), "surya" },
                    { new Guid("97ba8980-d1e0-4274-89d2-149880510bd2"), @"
                raju" },
                    { new Guid("53480674-5f46-4189-94eb-1b8b2f852c3b"), @"
                psr" }
                });

            migrationBuilder.InsertData(
                table: "RefSetTerm",
                columns: new[] { "Id", "RefSetId", "RefTermId" },
                values: new object[,]
                {
                    { new Guid("999ade66-10aa-4058-8775-0daf12e55e37"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a") },
                    { new Guid("9e0de871-6191-4dcc-871b-0a6a226a58df"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794") },
                    { new Guid("1f59c003-8f0a-4cc7-bbcf-9e2504b5a4f5"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad") },
                    { new Guid("979f434f-314d-4b9c-9faf-2bae560cb093"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("031feee7-02c4-43f7-9269-b777ae5558d4") },
                    { new Guid("5b3c02b5-a5a7-4b13-b7a3-26b11161825b"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844") },
                    { new Guid("af8824f1-973a-4e42-a6ac-0405058db89e"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752") },
                    { new Guid("e109e904-0ff0-438c-96a8-9a2de7435254"), new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2") },
                    { new Guid("fe206146-291e-4739-9b72-0ededa4b1fb6"), new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("cd2a89f8-dd1a-4a62-8802-1ec27c2c3980") }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { new Guid("ef1b0174-6349-4370-9e0e-30c8e5857ef6"), "o4UhjEI94IFkRkJR59gnorDRPk49Rh8O", "surya" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignee",
                keyColumn: "Id",
                keyValue: new Guid("53480674-5f46-4189-94eb-1b8b2f852c3b"));

            migrationBuilder.DeleteData(
                table: "Assignee",
                keyColumn: "Id",
                keyValue: new Guid("97ba8980-d1e0-4274-89d2-149880510bd2"));

            migrationBuilder.DeleteData(
                table: "Assignee",
                keyColumn: "Id",
                keyValue: new Guid("f9320863-2a92-4d54-9be0-3ef86e69490c"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("1f59c003-8f0a-4cc7-bbcf-9e2504b5a4f5"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("5b3c02b5-a5a7-4b13-b7a3-26b11161825b"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("979f434f-314d-4b9c-9faf-2bae560cb093"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("999ade66-10aa-4058-8775-0daf12e55e37"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("9e0de871-6191-4dcc-871b-0a6a226a58df"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("af8824f1-973a-4e42-a6ac-0405058db89e"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("e109e904-0ff0-438c-96a8-9a2de7435254"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("fe206146-291e-4739-9b72-0ededa4b1fb6"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ef1b0174-6349-4370-9e0e-30c8e5857ef6"));

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

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { new Guid("2644f688-f9da-4dea-aaca-b5263e5bc42c"), "o4UhjEI94IFkRkJR59gnorDRPk49Rh8O", "surya" });
        }
    }
}
