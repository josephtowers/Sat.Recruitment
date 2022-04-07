using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Data.Models;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Services
{
    public interface IUserService
    {
        public Task<Result> CreateUser(User user);
    }
}
