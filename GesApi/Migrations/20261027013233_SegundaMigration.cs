using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GesApi.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Buyers");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "RefreshTokens",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FunctionName",
                table: "ProfileTypes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "MealName",
                table: "Meals",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string[]>(
                name: "Items",
                table: "Meals",
                type: "text[]",
                nullable: true,
                oldClrType: typeof(string[]),
                oldType: "text[]");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Employees",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Employees",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Buyers",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<long>(
                name: "LeadBuyerId",
                table: "Buyers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Buyers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buyers_LeadBuyerId",
                table: "Buyers",
                column: "LeadBuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buyers_Buyers_LeadBuyerId",
                table: "Buyers",
                column: "LeadBuyerId",
                principalTable: "Buyers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buyers_Buyers_LeadBuyerId",
                table: "Buyers");

            migrationBuilder.DropIndex(
                name: "IX_Buyers_LeadBuyerId",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LeadBuyerId",
                table: "Buyers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Buyers");

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "RefreshTokens",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FunctionName",
                table: "ProfileTypes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MealName",
                table: "Meals",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string[]>(
                name: "Items",
                table: "Meals",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0],
                oldClrType: typeof(string[]),
                oldType: "text[]",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Buyers",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Buyers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Buyers",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
