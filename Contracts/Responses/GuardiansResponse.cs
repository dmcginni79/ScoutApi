using System.Collections.Generic;

namespace ScoutApi.Contracts.Responses;

public class GuardiansResponse
{
    public ICollection<GuardianResponse> Guardians { get; set; } = new List<GuardianResponse>();
}