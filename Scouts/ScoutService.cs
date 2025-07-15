using ScoutApi.Contracts;
using ScoutApi.Validation;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Concurrent;
using Microsoft.EntityFrameworkCore;
using ScoutApi.Data;

namespace ScoutApi.Scouts;

public class ScoutService : IScoutService
{
    private readonly IValidator<Scout> _scoutValidator;
    private readonly ScoutApiContext _dbContext;
    
    public ScoutService(IValidator<Scout> scoutValidator, ScoutApiContext dbContext)
    {
        _scoutValidator = scoutValidator;
        _dbContext = dbContext;
    }
    
    public async Task<Result<Scout, ValidationFailed>> CreateAsync(Scout scout)
    {
        var validationResult = await _scoutValidator.ValidateAsync(scout);
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }
        _dbContext.Scouts.Add(scout);
        await _dbContext.SaveChangesAsync();
        return scout;
    }
    
    public async Task<Scout?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Scouts.FindAsync(id);
    }
    
    public async Task<IEnumerable<Scout>> GetAllAsync()
    {
        return await _dbContext.Scouts.ToListAsync();
    }
    
    public async Task<Result<Scout?, ValidationFailed>> UpdateAsync(Scout scout)
    {
        var validationResult = _scoutValidator.Validate(scout);
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }
        
        var scoutExists = await _dbContext.Scouts.FindAsync(scout.Id);
        if (scoutExists == null)
        {
            return default(Scout?);
        }

        _dbContext.Entry(scoutExists).CurrentValues.SetValues(scout);
        await _dbContext.SaveChangesAsync();
        return scout;
    }
    
    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var scout = await _dbContext.Scouts.FindAsync(id);
        
        if (scout is null)
        {
            return false;
        }
        _dbContext.Scouts.Remove(scout);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
