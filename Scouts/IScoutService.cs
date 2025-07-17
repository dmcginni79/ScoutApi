using ScoutApi.Validation;

namespace ScoutApi.Scouts;

public interface IScoutService
{
    Task<Result<Scout, ValidationFailed>> CreateAsync(Scout scout);
    Task<Scout?> GetByIdAsync(Guid id);
    Task<IEnumerable<Scout>> GetAllAsync();
    Task<Result<Scout?, ValidationFailed>> UpdateAsync(Scout scout);
    Task<bool> DeleteByIdAsync(Guid id);
}
