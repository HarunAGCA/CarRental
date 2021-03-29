using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<short>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    IsBlocked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BrandId = table.Column<short>(nullable: false),
                    ColorId = table.Column<short>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ModelYear = table.Column<short>(nullable: false),
                    DailyPrice = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(nullable: false),
                    OperationClaimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(nullable: false),
                    UploadDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarImages_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    RentDate = table.Column<DateTime>(nullable: false),
                    ReturnDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[] { (short)1, "TOGG" });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { (short)1, "Kırmızı" },
                    { (short)2, "Mavi" },
                    { (short)3, "Gri" }
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsBlocked", "LastName", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, "admin@example.com", "John", false, "Doe", new byte[] { 25, 78, 12, 92, 111, 47, 220, 165, 88, 193, 137, 155, 106, 86, 184, 96, 229, 59, 65, 45, 136, 21, 33, 31, 201, 28, 45, 161, 102, 190, 63, 226, 118, 235, 61, 204, 166, 132, 91, 17, 74, 128, 161, 200, 57, 131, 214, 187, 25, 6, 45, 7, 94, 201, 113, 22, 27, 221, 109, 204, 248, 51, 173, 142 }, new byte[] { 135, 81, 181, 173, 15, 182, 157, 117, 198, 58, 203, 141, 46, 25, 114, 105, 105, 57, 189, 210, 36, 224, 140, 242, 133, 214, 125, 70, 33, 75, 131, 136, 213, 146, 255, 188, 25, 246, 68, 60, 251, 42, 176, 165, 32, 122, 1, 245, 207, 192, 98, 154, 243, 247, 90, 130, 139, 49, 220, 148, 20, 187, 65, 25, 107, 37, 178, 247, 229, 186, 133, 213, 242, 206, 40, 158, 242, 243, 213, 181, 102, 79, 2, 147, 47, 242, 183, 138, 146, 113, 93, 70, 26, 22, 157, 122, 37, 126, 136, 251, 21, 248, 112, 135, 136, 24, 183, 19, 145, 230, 35, 248, 182, 47, 45, 201, 76, 209, 251, 241, 171, 69, 254, 128, 239, 61, 167, 47 } });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "BrandId", "ColorId", "DailyPrice", "Description", "ModelYear", "Name" },
                values: new object[,]
                {
                    { 1, (short)1, (short)1, 250m, "TOGG SUV model kırmızı", (short)2022, "SUV" },
                    { 2, (short)1, (short)2, 250m, "TOGG SUV model mavi", (short)2022, "SUV" },
                    { 3, (short)1, (short)3, 200m, "TOGG Sedan gri", (short)2022, "Sedan" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "UserId", "CompanyName" },
                values: new object[] { 1, "AGCA" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "CarImages",
                columns: new[] { "Id", "CarId", "FileName", "UploadDate" },
                values: new object[,]
                {
                    { 1, 1, "9c51a451-ac2b-4840-81cb-e9447bf97441.jpg", new DateTime(2021, 3, 29, 15, 30, 24, 811, DateTimeKind.Local).AddTicks(5678) },
                    { 2, 1, "62343bd3-b600-4911-ba92-a3e92460c91b.jpg", new DateTime(2021, 3, 29, 15, 30, 24, 812, DateTimeKind.Local).AddTicks(6591) },
                    { 3, 1, "e855898a-5e19-4e9e-82fa-421a884b353a.jpg", new DateTime(2021, 3, 29, 15, 30, 24, 812, DateTimeKind.Local).AddTicks(6635) },
                    { 4, 1, "f16ec7fb-bcfa-49b6-accc-87e92b6d3cc3.jpg", new DateTime(2021, 3, 29, 15, 30, 24, 812, DateTimeKind.Local).AddTicks(6637) },
                    { 5, 2, "3fa88654-2976-4cff-948c-e3e20c730c91.jpg", new DateTime(2021, 3, 29, 15, 30, 24, 812, DateTimeKind.Local).AddTicks(6639) },
                    { 6, 2, "7a6f413f-0d74-4584-89a2-ff7898a8623d.jpg", new DateTime(2021, 3, 29, 15, 30, 24, 812, DateTimeKind.Local).AddTicks(6640) },
                    { 7, 2, "2135828c-09f7-4c6a-a5df-3a137c9a138a.jpg", new DateTime(2021, 3, 29, 15, 30, 24, 812, DateTimeKind.Local).AddTicks(6642) },
                    { 8, 2, "ee9d8d7e-d89b-4d70-b012-4aa241fca70a.jpg", new DateTime(2021, 3, 29, 15, 30, 24, 812, DateTimeKind.Local).AddTicks(6643) },
                    { 9, 3, "33959098-8427-4200-bd6e-823c2890ff10.jpg", new DateTime(2021, 3, 29, 15, 30, 24, 812, DateTimeKind.Local).AddTicks(6645) },
                    { 10, 3, "c300ab97-d45f-439c-90b8-fd09a9426cc4.jpg", new DateTime(2021, 3, 29, 15, 30, 24, 812, DateTimeKind.Local).AddTicks(6646) },
                    { 11, 3, "2cca89e4-a7a4-44fe-b8ac-f50872a1395b.jpg", new DateTime(2021, 3, 29, 15, 30, 24, 812, DateTimeKind.Local).AddTicks(6648) },
                    { 12, 3, "af969d12-5a14-488d-8509-796efb2bd0b3.jpg", new DateTime(2021, 3, 29, 15, 30, 24, 812, DateTimeKind.Local).AddTicks(6649) }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "CarId", "CustomerId", "RentDate", "ReturnDate" },
                values: new object[] { 1, 2, 1, new DateTime(2021, 4, 3, 15, 30, 24, 831, DateTimeKind.Local).AddTicks(1659), null });

            migrationBuilder.CreateIndex(
                name: "IX_CarImages_CarId",
                table: "CarImages",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_BrandId",
                table: "Cars",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ColorId",
                table: "Cars",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CarId",
                table: "Rentals",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CustomerId",
                table: "Rentals",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarImages");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
