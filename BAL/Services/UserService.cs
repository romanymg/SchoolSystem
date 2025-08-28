using Common.Models;
using DAL;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Common.Helpers;
using Google.Authenticator;

namespace BAL.Services
{
    public class UserService
    {
        private readonly DBContext _context;
        private readonly ICurrentRequest _currentRequest;

        public UserService(DBContext context, ICurrentRequest currentRequest)
        {
            _context = context;
            _currentRequest = currentRequest;
        }

        public async Task<AdminEntity?> AdminLogin(LoginEntity model)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.IsDeleted != true &&
                                          x.UserName == model.UserName && x.Password == model.Password);
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
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.IsDeleted != true &&
                                          x.Id == userId &&
                                          x.Password == model.Password);
            if (user == null)
            {
                throw new InvalidDataException("Invalid user");
            }

            user.Password = model.NewPassword;
            _context.Entry(user).State = EntityState.Modified;
            var res = await _context.SaveChangesAsync();

            return true;
        }
    }
}