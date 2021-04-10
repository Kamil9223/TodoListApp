using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoListApp.Persistance.Context.Migrations
{
    public partial class OnDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Users_UserId",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskDetails_Tasks_SingleTaskId",
                table: "TaskDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Boards_BoardTasksBoardId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Users_UserId",
                table: "Boards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDetails_Tasks_SingleTaskId",
                table: "TaskDetails",
                column: "SingleTaskId",
                principalTable: "Tasks",
                principalColumn: "SingleTaskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Boards_BoardTasksBoardId",
                table: "Tasks",
                column: "BoardTasksBoardId",
                principalTable: "Boards",
                principalColumn: "TasksBoardId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boards_Users_UserId",
                table: "Boards");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskDetails_Tasks_SingleTaskId",
                table: "TaskDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Boards_BoardTasksBoardId",
                table: "Tasks");

            migrationBuilder.AddForeignKey(
                name: "FK_Boards_Users_UserId",
                table: "Boards",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskDetails_Tasks_SingleTaskId",
                table: "TaskDetails",
                column: "SingleTaskId",
                principalTable: "Tasks",
                principalColumn: "SingleTaskId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Boards_BoardTasksBoardId",
                table: "Tasks",
                column: "BoardTasksBoardId",
                principalTable: "Boards",
                principalColumn: "TasksBoardId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
