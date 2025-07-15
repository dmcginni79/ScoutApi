using ScoutApi.Validation;

namespace ScoutApi.Guardians;

public interface IGuardianService
{
    Task<Result<Guardian, ValidationFailed>> CreateAsync(Guardian guardian);
    Task<Guardian?> GetByIdAsync(Guid id);
    Task<IEnumerable<Guardian>> GetAllAsync();
    Task<Result<Guardian?, ValidationFailed>> UpdateAsync(Guardian guardian);
    Task<bool> DeleteByIdAsync(Guid id);
    Task<IEnumerable<Guardian>> GetByScoutIdAsync(Guid scoutId);
}