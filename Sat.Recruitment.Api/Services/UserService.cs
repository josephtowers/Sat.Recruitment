using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Util;
using Sat.Recruitment.Business.BusinessLogic.Users;
using Sat.Recruitment.Data.DataAccess;
using Sat.Recruitment.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Services
{
    public class UserService : IUserService
    {
        private List<User> _users = new List<User>();
        private readonly IUserDataAccess _userDataAccess;
        public UserService()
        {
            _userDataAccess = new UserDataAccess();
        }
        public async Task<Result> CreateUser(User user)
        {
            var validation = ValidateUser(user);
            if (validation != null) return validation;
            user.Money = UserMoneyCalculation.GetUserMoneyCalculation(user);
            user.Email = EmailNormalizer.Normalize(user.Email);
            _users = await _userDataAccess.GetUsersAsync();
            if (IsDuplicated(user))
            {
                return new Result() { IsSuccess = false, Errors = new List<string>() { "The user is duplicated" } };
            }
            return new Result() { IsSuccess = true };
        }
        public Result ValidateUser(User user)
        {
            var validationResult = new List<ValidationResult>();
            var validation = Validator.TryValidateObject(user, new ValidationContext(user), validationResult, true);
            if (!validation)
            {
                return new Result() { IsSuccess = false, Errors = validationResult.Select(e => e.ErrorMessage).ToList() };
            }
            return null;
        }
        public bool IsDuplicated(User user)
        {
            return _users.Any(u => u.Email == user.Email || u.Phone == user.Phone || (u.Name == user.Name && u.Address == user.Address));
        }
    }
}
