using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagement.Migrations
{
    public partial class n1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("59759ff6-bd3c-4c99-93d7-6662774689ef"), @"surya
raju
psr" });

            migrationBuilder.InsertData(
                table: "RefSetTerm",
                columns: new[] { "Id", "RefSetId", "RefTermId" },
                values: new object[,]
                {
                    { new Guid("5f4233be-6d7e-4437-aa7f-ce69c20e11d9"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a") },
                    { new Guid("d7ecf7d0-23b2-4b8b-b3ba-07ab4952f4f8"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794") },
                    { new Guid("9070ecf3-38ee-4375-9ae0-a7872a36874c"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad") },
                    { new Guid("f0134a1c-246a-41f1-bee5-7bce07909775"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("031feee7-02c4-43f7-9269-b777ae5558d4") },
                    { new Guid("a2504391-ce23-48c4-8adf-20d7323ff81f"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844") },
                    { new Guid("20f6f95c-9dc8-459e-930d-48fde62fec5a"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752") },
                    { new Guid("a9075c5d-8984-4abe-8c26-e66745bfa83b"), new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2") },
                    { new Guid("87bfaff4-cb82-46a2-8728-e9be3574b4d5"), new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("cd2a89f8-dd1a-4a62-8802-1ec27c2c3980") }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { new Guid("677dc1dd-fbd1-4072-af43-36ad9763ac48"), "o4UhjEI94IFkRkJR59gnorDRPk49Rh8O", "surya" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignee",
                keyColumn: "Id",
                keyValue: new Guid("59759ff6-bd3c-4c99-93d7-6662774689ef"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("20f6f95c-9dc8-459e-930d-48fde62fec5a"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("5f4233be-6d7e-4437-aa7f-ce69c20e11d9"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("87bfaff4-cb82-46a2-8728-e9be3574b4d5"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("9070ecf3-38ee-4375-9ae0-a7872a36874c"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("a2504391-ce23-48c4-8adf-20d7323ff81f"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("a9075c5d-8984-4abe-8c26-e66745bfa83b"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("d7ecf7d0-23b2-4b8b-b3ba-07ab4952f4f8"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("f0134a1c-246a-41f1-bee5-7bce07909775"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("677dc1dd-fbd1-4072-af43-36ad9763ac48"));

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
    }
}
