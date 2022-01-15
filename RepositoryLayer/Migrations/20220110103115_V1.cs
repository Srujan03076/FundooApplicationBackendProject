using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaborationTable_NoteTable_NotesId",
                table: "CollaborationTable");

            migrationBuilder.DropForeignKey(
                name: "FK_CollaborationTable_UserTable_UserId",
                table: "CollaborationTable");

            migrationBuilder.AddForeignKey(
                name: "FK_CollaborationTable_NoteTable_NotesId",
                table: "CollaborationTable",
                column: "NotesId",
                principalTable: "NoteTable",
                principalColumn: "NotesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CollaborationTable_UserTable_UserId",
                table: "CollaborationTable",
                column: "UserId",
                principalTable: "UserTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaborationTable_NoteTable_NotesId",
                table: "CollaborationTable");

            migrationBuilder.DropForeignKey(
                name: "FK_CollaborationTable_UserTable_UserId",
                table: "CollaborationTable");

            migrationBuilder.AddForeignKey(
                name: "FK_CollaborationTable_NoteTable_NotesId",
                table: "CollaborationTable",
                column: "NotesId",
                principalTable: "NoteTable",
                principalColumn: "NotesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CollaborationTable_UserTable_UserId",
                table: "CollaborationTable",
                column: "UserId",
                principalTable: "UserTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
