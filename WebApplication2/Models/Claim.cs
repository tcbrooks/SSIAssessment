using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models;

public class Claim {
    [Key]
    public int Id { get; set; }
    // foreign key to link claim to EdiFile
    [Required]
    public string? FileId { get; set; }
    public string? PatientAccountNumber { get; set; }
    public decimal TotalClaimChargeAmount { get; set; }
    public string? FacilityTypeCode { get; set; }
    public string? FacilityCodeQualifier { get; set; }
    public string? ClaimFrequencyCode { get; set; }
    public string? ProviderSupplierSignatureIndicator { get; set; }
    public string? AssignmentPlanParticipationCode { get; set; }
    public string? BenefitsAssignmentCertificationIndicator { get; set; }
    public string? ReleaseOfInformationIndicator { get; set; }
}