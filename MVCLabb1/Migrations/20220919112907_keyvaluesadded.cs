using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCLabb1.Migrations
{
    public partial class keyvaluesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookBorrowCustomers",
                columns: table => new
                {
                    BorrowId = table.Column<int>(type: "int", nullable: false),
                    CostumerId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrowCustomers", x => new { x.BorrowId, x.CostumerId, x.BookId });
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountInStore = table.Column<int>(type: "int", nullable: false),
                    BookPictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookBorrowCustomerBookId = table.Column<int>(type: "int", nullable: true),
                    BookBorrowCustomerBorrowId = table.Column<int>(type: "int", nullable: true),
                    BookBorrowCustomerCostumerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_BookBorrowCustomers_BookBorrowCustomerBorrowId_BookBorrowCustomerCostumerId_BookBorrowCustomerBookId",
                        columns: x => new { x.BookBorrowCustomerBorrowId, x.BookBorrowCustomerCostumerId, x.BookBorrowCustomerBookId },
                        principalTable: "BookBorrowCustomers",
                        principalColumns: new[] { "BorrowId", "CostumerId", "BookId" });
                });

            migrationBuilder.CreateTable(
                name: "Costumers",
                columns: table => new
                {
                    CostumerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    BookBorrowCustomerBookId = table.Column<int>(type: "int", nullable: true),
                    BookBorrowCustomerBorrowId = table.Column<int>(type: "int", nullable: true),
                    BookBorrowCustomerCostumerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costumers", x => x.CostumerId);
                    table.ForeignKey(
                        name: "FK_Costumers_BookBorrowCustomers_BookBorrowCustomerBorrowId_BookBorrowCustomerCostumerId_BookBorrowCustomerBookId",
                        columns: x => new { x.BookBorrowCustomerBorrowId, x.BookBorrowCustomerCostumerId, x.BookBorrowCustomerBookId },
                        principalTable: "BookBorrowCustomers",
                        principalColumns: new[] { "BorrowId", "CostumerId", "BookId" });
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AmountInStore", "BookBorrowCustomerBookId", "BookBorrowCustomerBorrowId", "BookBorrowCustomerCostumerId", "BookISBN", "BookPictureUrl", "Title" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, "23468635", "https://papunet.net/sites/papunet.net/files/kuvapankki/20190807/kirja_vari.jpg", "Entity kursbook" },
                    { 2, 1, null, null, null, "112323", "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcT3yGr3_kAc0rzeCubEwS6odjfOrhQ6r5f26LJZ7QVzqmojcvcR", "advancerad Asp.net" },
                    { 3, 2, null, null, null, "12341233", "https://s2.adlibris.com/images/41587515/sql-in-10-minutes-a-day-sams-teach-yourself.jpg", "sql server programmering" },
                    { 4, 20, null, null, null, "32412", "https://s2.adlibris.com/images/768665/beginning-aspnet-mvc-4.jpg", "MVC model view controller" },
                    { 5, 1, null, null, null, "263563", "https://s1.adlibris.com/images/30710334/programmering-2-c.jpg", "C# programmering" }
                });

            migrationBuilder.InsertData(
                table: "Costumers",
                columns: new[] { "CostumerId", "BookBorrowCustomerBookId", "BookBorrowCustomerBorrowId", "BookBorrowCustomerCostumerId", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, null, null, null, "Mattias", "Kokkonen", 70555555 },
                    { 2, null, null, null, "Edwin", "Noccomannen", 70444444 },
                    { 3, null, null, null, "Daniel", "Vandraren", 7033333 }
                });

            migrationBuilder.InsertData(
                table: "BookBorrowCustomers",
                columns: new[] { "BookId", "BorrowId", "CostumerId", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowCustomers_BookId",
                table: "BookBorrowCustomers",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrowCustomers_CostumerId",
                table: "BookBorrowCustomers",
                column: "CostumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookBorrowCustomerBorrowId_BookBorrowCustomerCostumerId_BookBorrowCustomerBookId",
                table: "Books",
                columns: new[] { "BookBorrowCustomerBorrowId", "BookBorrowCustomerCostumerId", "BookBorrowCustomerBookId" });

            migrationBuilder.CreateIndex(
                name: "IX_Costumers_BookBorrowCustomerBorrowId_BookBorrowCustomerCostumerId_BookBorrowCustomerBookId",
                table: "Costumers",
                columns: new[] { "BookBorrowCustomerBorrowId", "BookBorrowCustomerCostumerId", "BookBorrowCustomerBookId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookBorrowCustomers_Books_BookId",
                table: "BookBorrowCustomers",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookBorrowCustomers_Costumers_CostumerId",
                table: "BookBorrowCustomers",
                column: "CostumerId",
                principalTable: "Costumers",
                principalColumn: "CostumerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookBorrowCustomers_Books_BookId",
                table: "BookBorrowCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_BookBorrowCustomers_Costumers_CostumerId",
                table: "BookBorrowCustomers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Costumers");

            migrationBuilder.DropTable(
                name: "BookBorrowCustomers");
        }
    }
}
