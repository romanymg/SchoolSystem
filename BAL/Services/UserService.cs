using Common.Enums;
using Common.Helpers;
using Common.Models;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace BAL.Services
{
    public class UserService(DBContext context, ICurrentRequest currentRequest)
    {
        public async Task<AdminEntity?> AdminLogin(LoginEntity model)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(x => x.IsDeleted != true &&
                                          x.UserTypeId == (int)UserTypeEnum.Admin &&
                                          x.UserName == model.UserName &&
                                          x.Password == model.Password);
            if (user is null)
            {
                return null;
            }

            return new AdminEntity
            {
                Id = user.Id,
                Name = user.FullName,
            };
        }
        public async Task<bool> ChangeAdminPassword(long userId, ChangePasswordEntity model)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(x => x.IsDeleted != true &&
                                          x.Id == userId &&
                                          x.Password == model.Password);
            if (user == null)
            {
                throw new InvalidDataException("Invalid user");
            }

            user.Password = model.NewPassword;
            context.Entry(user).State = EntityState.Modified;
            var res = await context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<UserEntity>> GetAll(int userTypeId)
        {
            return await context.Users
                .Where(x => x.IsDeleted != true &&
                            x.UserTypeId == userTypeId)
                .Select(x => new UserEntity
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    UserName = x.UserName,
                    Phone = x.Phone,
                    Email = x.Email,
                    DivisionName = x.DivisionName,
                    Class = x.Class,
                    IsActive = x.IsActive,
                    UserTypeId = x.UserTypeId,
                    Dob = x.Dob,
                    FamilyId = x.FamilyId,
                    ParentId = x.ParentId,
                    GenderId = x.GenderId,
                    UserCode = x.UserCode,
                    ImageUrl = x.ImageUrl,
                    ReferenceId = x.ReferenceId,
                    Title = x.Title,
                    Relationship = x.Relationship,
                    Country = x.Country
                }).ToListAsync();
        }

        public async Task<long> AddUser(UserEntity model)
        {
            long userId = await context.Users
                .Where(x => x.IsDeleted != true && x.ReferenceId == model.ReferenceId)
                .Select(x => x.Id)
                .FirstOrDefaultAsync();

            if (userId > 0)
            {
                return userId;
            }
            var entity = new User
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Phone = model.Phone,
                Email = model.Email,
                DivisionName = model.DivisionName,
                Class = model.Class,
                IsActive = model.IsActive,
                UserTypeId = model.UserTypeId,
                Dob = model.Dob,
                FamilyId = model.FamilyId,
                ParentId = model.ParentId,
                GenderId = model.GenderId,
                UserCode = model.UserCode,
                ImageUrl = model.ImageUrl,
                ReferenceId = model.ReferenceId,
                Title = model.Title,
                Relationship = model.Relationship,
                Country = model.Country
            };
            context.Users.Add(entity);
            var saved = await context.SaveChangesAsync();
            if (saved > 0)
            {
                return entity.Id;
            }

            throw new InvalidDataException("Invalid Request");
        }
    }
}