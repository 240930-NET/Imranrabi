using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishingSpotsTracker.Migrations
{
    /// <inheritdoc />
    public partial class Change2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FishCatches_Spots_SpotId",
                table: "FishCatches");

            migrationBuilder.DropIndex(
                name: "IX_FishCatches_SpotId",
                table: "FishCatches");

            migrationBuilder.DropColumn(
                name: "SpotId",
                table: "FishCatches");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpotId",
                table: "FishCatches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FishCatches_SpotId",
                table: "FishCatches",
                column: "SpotId");

            migrationBuilder.AddForeignKey(
                name: "FK_FishCatches_Spots_SpotId",
                table: "FishCatches",
                column: "SpotId",
                principalTable: "Spots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
