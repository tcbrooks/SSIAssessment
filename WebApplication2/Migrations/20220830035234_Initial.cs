using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Claim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientAccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalClaimChargeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FacilityTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacilityCodeQualifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimFrequencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderSupplierSignatureIndicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignmentPlanParticipationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BenefitsAssignmentCertificationIndicator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseOfInformationIndicator = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claim", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Claim");
        }
    }
}
