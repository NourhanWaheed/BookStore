using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using StoreData.Models;

#nullable disable

namespace StoreData.Migrations
{
    public partial class newupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
               name: "FK_Author_Books_AuthorId",
               table: "Book",
               column: "AuthorId",
               principalTable: "Author",
               principalColumn: "Id",
               onDelete: ReferentialAction.Cascade);

           // ModelBuilder.Ignore<ErrorMessage>();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Author_Books_AuthorId",
                table: "Book");
        }
    }
}
