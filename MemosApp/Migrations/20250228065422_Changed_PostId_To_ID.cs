﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MemosApp.Migrations
{
    /// <inheritdoc />
    public partial class Changed_PostId_To_ID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Posts",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Posts",
                newName: "PostId");
        }
    }
}
