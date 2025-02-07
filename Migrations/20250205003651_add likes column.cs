﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YongdingSun.API.Migrations
{
    /// <inheritdoc />
    public partial class addlikescolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Images",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Images");
        }
    }
}
