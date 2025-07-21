using ScoutApi.Validation;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ScoutApi.Data;
using ScoutApi.PhoneNumbers;

namespace ScoutApi.PhoneNumbers;

public interface IPhoneNumberService
{
    Task<Result<PhoneNumber, ValidationFailed>> CreateAsync(PhoneNumber guardian);
    Task<PhoneNumber?> GetByIdAsync(Guid id);
    Task<IEnumerable<PhoneNumber>> GetAllAsync();
    Task<Result<PhoneNumber?, ValidationFailed>> UpdateAsync(PhoneNumber guardian);
    Task<bool> DeleteByIdAsync(Guid id);
    Task<IEnumerable<PhoneNumber>> GetByGuardianIdAsync(Guid guardianId);
}

public class PhoneNumberService : IPhoneNumberService
{
    private readonly IValidator<PhoneNumber> _phoneNumberValidator;
    private readonly ScoutApiContext _dbContext;

    public PhoneNumberService(IValidator<PhoneNumber> phoneNumberValidator, ScoutApiContext dbContext)
    {
        _phoneNumberValidator = phoneNumberValidator;
        _dbContext = dbContext;
    }

    public async Task<Result<PhoneNumber, ValidationFailed>> CreateAsync(PhoneNumber phoneNumber)
    {
        var validationResult = await _phoneNumberValidator.ValidateAsync(phoneNumber);
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }
        _dbContext.PhoneNumbers.Add(phoneNumber);
        await _dbContext.SaveChangesAsync();
        return phoneNumber;
    }

    public async Task<PhoneNumber?> GetByIdAsync(Guid id)
    {
        return await _dbContext.PhoneNumbers.FindAsync(id);
    }

    public async Task<IEnumerable<PhoneNumber>> GetAllAsync()
    {
        return await _dbContext.PhoneNumbers.ToListAsync();
    }

    public async Task<Result<PhoneNumber?, ValidationFailed>> UpdateAsync(PhoneNumber phoneNumber)
    {
        var validationResult = _phoneNumberValidator.Validate(phoneNumber);
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }

        var existingPhoneNumber = await _dbContext.PhoneNumbers.FindAsync(phoneNumber.Id);
        if (existingPhoneNumber == null)
        {
            return default(PhoneNumber?);
        }

        _dbContext.Entry(existingPhoneNumber).CurrentValues.SetValues(phoneNumber);
        await _dbContext.SaveChangesAsync();
        return phoneNumber;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var phoneNumber = await _dbContext.PhoneNumbers.FindAsync(id);

        if (phoneNumber is null)
        {
            return false;
        }
        _dbContext.PhoneNumbers.Remove(phoneNumber);
        await _dbContext.SaveChangesAsync();
        return true;
    }
    
    public async Task<IEnumerable<PhoneNumber>> GetByGuardianIdAsync(Guid guardianId)
    {
        return await _dbContext.PhoneNumbers
            .Where(g => g.GuardianId.Equals(guardianId))
            .ToListAsync();
    }
}