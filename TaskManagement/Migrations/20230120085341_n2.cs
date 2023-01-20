using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagement.Migrations
{
    public partial class n2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("f8c62d98-d864-42fe-9b61-0395a9200672"), "surya" },
                    { new Guid("ac659b0e-94d3-4e67-a889-30206023a31a"), "raju" },
                    { new Guid("f0d538d9-d895-4537-9b9c-1586af709001"), "psr" }
                });

            migrationBuilder.InsertData(
                table: "RefSetTerm",
                columns: new[] { "Id", "RefSetId", "RefTermId" },
                values: new object[,]
                {
                    { new Guid("fe03c907-20d6-45c8-9000-a09884e71dd9"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("246b7c06-f7b8-49e6-873c-fcc337c2056a") },
                    { new Guid("02cbecbc-3479-4624-8a8c-035168adbb4a"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("65a9194f-6e36-4451-ac6b-f8c3e2f2a794") },
                    { new Guid("d8243c78-fcf6-45c3-b531-48e3d8617ac6"), new Guid("1966d5cb-a92b-4ee9-9e5c-de08c2f7025b"), new Guid("d2c7f6ed-174f-4782-8207-ca847cb5e5ad") },
                    { new Guid("e3112d3e-3b92-456f-99b8-af50c5d28d93"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("031feee7-02c4-43f7-9269-b777ae5558d4") },
                    { new Guid("eb3d6aa1-59c6-4fa8-910d-f74e8f01a15b"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("5443d3e4-1cc2-49f9-af36-ec46c00c8844") },
                    { new Guid("8ef10d47-9e9d-47a2-bbd8-eda9e4317be3"), new Guid("3b61dc28-b562-4153-a302-97866324806c"), new Guid("09cd2a9b-a3ef-4487-a37c-e076569cf752") },
                    { new Guid("ca1bc89b-3d15-41bb-8196-66f6cc15ab19"), new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("9e5464cf-5729-48b4-8a73-8e3fcefa4ae2") },
                    { new Guid("3b5aa52a-266c-47d1-b9bf-0ab6b9f93925"), new Guid("e28e09d8-76f8-43ba-be0b-d7eade3b1e6b"), new Guid("cd2a89f8-dd1a-4a62-8802-1ec27c2c3980") }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { new Guid("bb275fdd-2020-48bb-bbbc-e1af4e518802"), "o4UhjEI94IFkRkJR59gnorDRPk49Rh8O", "surya" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignee",
                keyColumn: "Id",
                keyValue: new Guid("ac659b0e-94d3-4e67-a889-30206023a31a"));

            migrationBuilder.DeleteData(
                table: "Assignee",
                keyColumn: "Id",
                keyValue: new Guid("f0d538d9-d895-4537-9b9c-1586af709001"));

            migrationBuilder.DeleteData(
                table: "Assignee",
                keyColumn: "Id",
                keyValue: new Guid("f8c62d98-d864-42fe-9b61-0395a9200672"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("02cbecbc-3479-4624-8a8c-035168adbb4a"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("3b5aa52a-266c-47d1-b9bf-0ab6b9f93925"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("8ef10d47-9e9d-47a2-bbd8-eda9e4317be3"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("ca1bc89b-3d15-41bb-8196-66f6cc15ab19"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("d8243c78-fcf6-45c3-b531-48e3d8617ac6"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("e3112d3e-3b92-456f-99b8-af50c5d28d93"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("eb3d6aa1-59c6-4fa8-910d-f74e8f01a15b"));

            migrationBuilder.DeleteData(
                table: "RefSetTerm",
                keyColumn: "Id",
                keyValue: new Guid("fe03c907-20d6-45c8-9000-a09884e71dd9"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("bb275fdd-2020-48bb-bbbc-e1af4e518802"));

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
    }
}
