using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;
    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> RegisterUserAsync(UserRegister model)
    {
        if (await GetUserByEmailAsync(model.Email) != null || await GetUserByUsernameAsync(model.Username) != null) ;
        {
            return false;
        }
        var entity = new UserEntity
        {
            UserName = model.Username,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Biography = model.Biography
        };

        var passwordHasher = new PasswordHasher<UserEntity>();
        entity.Password = passwordHasher.HashPassword(entity, model.Password);

        _dbContext.Users.Add(entity);
        var numberOfChanges = await _dbContext.SaveChangesAsync();

        return numberOfChanges == 1;
    }

    public async Task<UserDetail> GetUserByIdAsync(int userId)
    {
        var entity = await _dbContext.Users.FindAsync(userId);
        if (entity is null)
        {
            return null;
        }

        var userDetail = new UserDetail
        {
            Id = entity.Id,
            Firstname = entity.FirstName,
            Lastname = entity.LastName,
            Email = entity.Email,
            Biography = entity.Biography,
            DateCreated = DateTimeOffset.Now
        };

        return userDetail;
    }

    public async Task<bool> UpdateUserAsync(UserUpdate request)
    {
        var userEntity = await _dbContext.Users.FindAsync(request.Id);

        userEntity.UserName = request.Username;
        userEntity.FirstName = request.Firstname;
        userEntity.LastName = request.Lastname;
        userEntity.Email = request.Email;
        userEntity.Password = request.Password;
        userEntity.Biography = request.Biography;

        var numberOfChanges = await _dbContext.SaveChangesAsync();

        return numberOfChanges == 1;
    }

    public async Task<bool> DeleteUserAsync(int Id)
    {
        var userEntity = await _dbContext.Products.FindAsync(Id);

        if (userEntity.Id != Id)
            return false;

        _dbContext.Products.Remove(userEntity);
        return await _dbContext.SaveChangesAsync() == 1;
    }

private async Task<UserEntity> GetUserByEmailAsync(string email)
{
    return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email.ToLower() == email.ToLower());
}

private async Task<UserEntity> GetUserByUsernameAsync(string username)
{
    return await _dbContext.Users.FirstOrDefaultAsync(user => user.UserName.ToLower() == username.ToLower());
}
}
