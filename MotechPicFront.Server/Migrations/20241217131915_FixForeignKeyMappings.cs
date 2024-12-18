using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotechPicFront.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyMappings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRequests_Clients_ProductId",
                table: "ProductRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRequests_Products_ProductId1",
                table: "ProductRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SparePartRequests_Clients_SparePartId",
                table: "SparePartRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SparePartRequests_SpareParts_SparePartId1",
                table: "SparePartRequests");

            migrationBuilder.DropIndex(
                name: "IX_SparePartRequests_SparePartId1",
                table: "SparePartRequests");

            migrationBuilder.DropIndex(
                name: "IX_ProductRequests_ProductId1",
                table: "ProductRequests");

            migrationBuilder.DropColumn(
                name: "SparePartId1",
                table: "SparePartRequests");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ProductRequests");

            migrationBuilder.CreateIndex(
                name: "IX_SparePartRequests_ClientId",
                table: "SparePartRequests",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRequests_ClientID",
                table: "ProductRequests",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRequests_Clients_ClientID",
                table: "ProductRequests",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRequests_Products_ProductId",
                table: "ProductRequests",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SparePartRequests_Clients_ClientId",
                table: "SparePartRequests",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SparePartRequests_SpareParts_SparePartId",
                table: "SparePartRequests",
                column: "SparePartId",
                principalTable: "SpareParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductRequests_Clients_ClientID",
                table: "ProductRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductRequests_Products_ProductId",
                table: "ProductRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SparePartRequests_Clients_ClientId",
                table: "SparePartRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_SparePartRequests_SpareParts_SparePartId",
                table: "SparePartRequests");

            migrationBuilder.DropIndex(
                name: "IX_SparePartRequests_ClientId",
                table: "SparePartRequests");

            migrationBuilder.DropIndex(
                name: "IX_ProductRequests_ClientID",
                table: "ProductRequests");

            migrationBuilder.AddColumn<int>(
                name: "SparePartId1",
                table: "SparePartRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "ProductRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SparePartRequests_SparePartId1",
                table: "SparePartRequests",
                column: "SparePartId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRequests_ProductId1",
                table: "ProductRequests",
                column: "ProductId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRequests_Clients_ProductId",
                table: "ProductRequests",
                column: "ProductId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductRequests_Products_ProductId1",
                table: "ProductRequests",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SparePartRequests_Clients_SparePartId",
                table: "SparePartRequests",
                column: "SparePartId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SparePartRequests_SpareParts_SparePartId1",
                table: "SparePartRequests",
                column: "SparePartId1",
                principalTable: "SpareParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
