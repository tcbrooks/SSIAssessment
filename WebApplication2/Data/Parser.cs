using System.Text.RegularExpressions;
using WebApplication2.Models;

namespace WebApplication2.Data;

/**
 * Parser class to parse the CLM segments from the EDI file.
 * Each CLM segment is stored in the database as a Claim object.
 * Example CLM segment: CLM*XYZ123000456*25***01:B:1*N*C*Y*Y~
 * Example Claim object: new Claim { PatientAccountNumber = "XYZ123000456", TotalClaimChargeAmount = "25", FacilityTypeCode = "01", FacilityCodeQualifier = "B", ClaimFrequencyCode = "1", ProviderSupplierSignatureIndicator = "N", AssignmentPlanParticipationCode = "C", BenefitsAssignmentCertificationIndicator = "Y", ReleaseOfInformationIndicator = "Y" }
 */
public class Parser
{
    private readonly StreamReader _reader;
    private readonly string _filePath;

    public Parser(string filePath)
    {
        _reader = new StreamReader(filePath);
        _filePath = filePath;
    }

    /// <summary>
    /// Parses the EDI file and creates a Claim object for each CLM segment.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Claim> Parse()
    {
        var claims = new List<Claim>();
        while (!_reader.EndOfStream)
        {
            var line = _reader.ReadLine();
            if (line == null || !line.StartsWith("CLM")) continue;
            var claim = ParseClaim(line);
            claims.Add(claim);
        }
        _reader.Close();
        return claims;
    }

    private Claim ParseClaim(string line)
    {
        var claim = new Claim();
        var result = Regex.Match(line,
            @"CLM\*(?<PatientAccountNumber>\w+)\*(?<TotalClaimChargeAmount>[\w\.]+)\*+(?<FacilityTypeCode>\w+)\:(?<FacilityCodeQualifier>\w+)\:(?<ClaimFrequencyCode>\w+)\*(?<ProviderSupplier>\w+)\*(?<AssignmentPlanParticipationCode>\w+)\*(?<BenefitsAssignmentCert>\w+)\*(?<ReleaseOfInformationIndicator>\w+)");
        if (!result.Success) throw new Exception($"Invalid CLM segment: {line}");
        claim.FileId = _filePath;
        claim.PatientAccountNumber = result.Groups["PatientAccountNumber"].Value;
        claim.TotalClaimChargeAmount = decimal.Parse(result.Groups["TotalClaimChargeAmount"].Value);
        claim.FacilityTypeCode = result.Groups["FacilityTypeCode"].Value;
        claim.FacilityCodeQualifier = result.Groups["FacilityCodeQualifier"].Value;
        claim.ClaimFrequencyCode = result.Groups["ClaimFrequencyCode"].Value;
        claim.ProviderSupplierSignatureIndicator = result.Groups["ProviderSupplier"].Value;
        claim.AssignmentPlanParticipationCode = result.Groups["AssignmentPlanParticipationCode"].Value;
        claim.BenefitsAssignmentCertificationIndicator = result.Groups["BenefitsAssignmentCert"].Value;
        claim.ReleaseOfInformationIndicator = result.Groups["ReleaseOfInformationIndicator"].Value;
        return claim;
    }
}