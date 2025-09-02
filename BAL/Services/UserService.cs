using Common.Enums;
using Common.Helpers;
using Common.Models;
using DAL;
using DocumentFormat.OpenXml.InkML;
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
                    Country = x.Country,
                    IsPrinted = x.IsPrinted ?? false,
                    CardNumber = x.CardNumber,
                    Childs = x.Childs,
                }).ToListAsync();
        }

        public async Task<long> SaveUser(UserEntity model)
        {
            var entity = await context.Users
                .Where(x => x.IsDeleted != true && x.UserTypeId == model.UserTypeId && x.ReferenceId == model.ReferenceId)
                .FirstOrDefaultAsync();

            if (entity != null)
            {
                entity.FullName = model.FullName;
                entity.UserName = model.UserName;
                entity.Phone = model.Phone;
                entity.Email = model.Email;
                entity.DivisionName = model.DivisionName;
                entity.Class = model.Class;
                entity.IsActive = model.IsActive;
                entity.UserTypeId = model.UserTypeId;
                entity.Dob = model.Dob;
                entity.FamilyId = model.FamilyId;
                entity.ParentId = model.ParentId;
                entity.GenderId = model.GenderId;
                entity.UserCode = model.UserCode;
                entity.ImageUrl = model.ImageUrl;
                entity.ReferenceId = model.ReferenceId;
                entity.Title = model.Title;
                entity.Relationship = model.Relationship;
                entity.Country = model.Country;
                entity.Childs = model.Childs;
                context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                entity = new User
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
                    Country = model.Country,
                    Childs = model.Childs,
                };
                context.Users.Add(entity);
            }

            var saved = await context.SaveChangesAsync();
            if (saved > 0)
            {
                return entity.Id;
            }

            throw new InvalidDataException("Invalid Request");
        }

        public async Task SetCardNumber(UserEntity item)
        {
            await context.Users.Where(x => x.IsDeleted != true && x.Id == item.Id)
                .ExecuteUpdateAsync(x =>
                    x.SetProperty(p => p.CardNumber, item.CardNumber)
                        .SetProperty(p => p.IsPrinted, item.IsPrinted));
        }
        public async Task SetImageUrl(UserEntity item)
        {
            await context.Users.Where(x => x.IsDeleted != true && x.Id == item.Id)
                .ExecuteUpdateAsync(x =>
                    x.SetProperty(p => p.ImageUrl, item.ImageUrl));
        }

    }
}