﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadingsAPI.Migrations
{
    public partial class SeedAccounts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 1234, "Freya", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 1239, "Noddy", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 1240, "Archie", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 1241, "Lara", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 1242, "Tim", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 1243, "Graham", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 1244, "Tony", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 1245, "Neville", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 1246, "Jo", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 1247, "Jim", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 1248, "Pam", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 2233, "Barry", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 2344, "Tommy", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 2345, "Jerry", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 2346, "Ollie", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 2347, "Tara", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 2348, "Tammy", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 2349, "Simon", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 2350, "Colin", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 2351, "Gladys", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 2352, "Greg", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 2353, "Tony", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 2355, "Arthur", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 2356, "Craig", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 4534, "JOSH", "TEST" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 6776, "Laura", "Test" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "FirstName", "LastName" },
                values: new object[] { 8766, "Sally", "Test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1234);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1239);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1240);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1241);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1242);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1243);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1244);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1245);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1246);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1247);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 1248);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2233);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2344);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2345);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2346);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2347);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2348);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2349);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2350);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2351);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2352);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2353);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2355);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 2356);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 4534);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 6776);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "AccountId",
                keyValue: 8766);
        }
    }
}
