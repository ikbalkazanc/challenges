using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PomeloCase.Data.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PostViews",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostViews",
                table: "PostViews",
                column: "Id");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostViews",
                table: "PostViews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostsCategories",
                table: "PostsCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PostViews");
        }
    }
}
