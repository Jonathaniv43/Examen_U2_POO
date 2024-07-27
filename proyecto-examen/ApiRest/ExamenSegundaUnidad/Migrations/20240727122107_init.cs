using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenSegundaUnidad.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "prospects",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    identity_number = table.Column<int>(type: "int", nullable: false),
                    client_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    loan_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    loan_amount = table.Column<double>(type: "float", nullable: false),
                    term = table.Column<int>(type: "int", nullable: false),
                    commision = table.Column<int>(type: "int", nullable: false),
                    interes_rate = table.Column<int>(type: "int", nullable: false),
                    disbursment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prospects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "amortization",
                schema: "dbo",
                columns: table => new
                {
                    amortization_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    installment_number = table.Column<int>(type: "int", nullable: false),
                    loan_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    days = table.Column<int>(type: "int", nullable: false),
                    interes_date = table.Column<double>(type: "float", nullable: false),
                    installment = table.Column<double>(type: "float", nullable: false),
                    life_insurace = table.Column<double>(type: "float", nullable: false),
                    lv_payment_LfIns = table.Column<double>(type: "float", nullable: false),
                    lv_payment_no_LfIns = table.Column<double>(type: "float", nullable: false),
                    principal_balance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amortization", x => x.amortization_id);
                    table.ForeignKey(
                        name: "FK_amortization_prospects_loan_id",
                        column: x => x.loan_id,
                        principalSchema: "dbo",
                        principalTable: "prospects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_amortization_loan_id",
                schema: "dbo",
                table: "amortization",
                column: "loan_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "amortization",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "prospects",
                schema: "dbo");
        }
    }
}
