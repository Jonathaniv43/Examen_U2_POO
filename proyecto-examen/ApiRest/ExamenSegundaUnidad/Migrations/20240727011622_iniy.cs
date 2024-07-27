using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamenSegundaUnidad.Migrations
{
    /// <inheritdoc />
    public partial class iniy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "loans",
                schema: "dbo",
                columns: table => new
                {
                    loan_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    client_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    client_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    loan_amount = table.Column<bool>(type: "bit", nullable: false),
                    commision = table.Column<int>(type: "int", nullable: false),
                    interes_rate = table.Column<int>(type: "int", nullable: false),
                    disbursment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.loan_id);
                });

            migrationBuilder.CreateTable(
                name: "amortization",
                schema: "dbo",
                columns: table => new
                {
                    amortization_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    loan_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    installment_number = table.Column<int>(type: "int", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    days = table.Column<int>(type: "int", nullable: false),
                    interes_date = table.Column<double>(type: "float", nullable: false),
                    lv_payment_Svds = table.Column<double>(type: "float", nullable: false),
                    lv_payment_no_Svds = table.Column<double>(type: "float", nullable: false),
                    principal_balance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amortization", x => x.amortization_id);
                    table.ForeignKey(
                        name: "FK_amortization_loans_loan_id",
                        column: x => x.loan_id,
                        principalSchema: "dbo",
                        principalTable: "loans",
                        principalColumn: "loan_id",
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
                name: "loans",
                schema: "dbo");
        }
    }
}
