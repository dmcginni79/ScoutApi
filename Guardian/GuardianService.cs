using ScoutApi.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ScoutApi.Data;
using ScoutApi.Scouts;

namespace ScoutApi.Guardians;

public class GuardianService : IGuardianService
{
    private readonly IValidator<Guardian> _guardianValidator;
    private readonly ScoutApiContext _dbContext;

    public GuardianService(IValidator<Guardian> guardianValidator, ScoutApiContext dbContext)
    {
        _guardianValidator = guardianValidator;
        _dbContext = dbContext;
    }

    public async Task<Result<Guardian, ValidationFailed>> CreateAsync(Guardian guardian)
    {
        var validationResult = await _guardianValidator.ValidateAsync(guardian);
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }
        _dbContext.Guardians.Add(guardian);
        await _dbContext.SaveChangesAsync();
        return guardian;
    }

    public async Task<Guardian?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Guardians.FindAsync(id);
    }

    public async Task<IEnumerable<Guardian>> GetAllAsync()
    {
        return await _dbContext.Guardians.ToListAsync();
    }

    public async Task<Result<Guardian?, ValidationFailed>> UpdateAsync(Guardian guardian)
    {
        var validationResult = _guardianValidator.Validate(guardian);
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }

        var guardianExists = await _dbContext.Guardians.FindAsync(guardian.Id);
        if (guardianExists == null)
        {
            return default(Guardian?);
        }

        _dbContext.Entry(guardianExists).CurrentValues.SetValues(guardian);
        await _dbContext.SaveChangesAsync();
        return guardian;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var guardian = await _dbContext.Guardians.FindAsync(id);

        if (guardian is null)
        {
            return false;
        }
        _dbContext.Guardians.Remove(guardian);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    
    public async Task<IEnumerable<Guardian>> GetByScoutIdAsync(Guid scoutId)
    {
        return await _dbContext.Guardians
            .Where(g => g.Scouts.Any(s => s.Id == scoutId))
            .ToListAsync();
    }
}