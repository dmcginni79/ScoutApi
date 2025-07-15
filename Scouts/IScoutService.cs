using ScoutApi.Validation;

namespace ScoutApi.Scouts;

public interface IScoutService
{
    Task<Result<Scout, ValidationFailed>> CreateAsync(Scout movie);
    Task<Scout?> GetByIdAsync(Guid id);
    Task<IEnumerable<Scout>> GetAllAsync();
    Task<Result<Scout?, ValidationFailed>> UpdateAsync(Scout movie);
    Task<bool> DeleteByIdAsync(Guid id);
}
