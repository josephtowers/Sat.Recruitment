using Sat.Recruitment.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data.DataAccess
{
    public interface IUserDataAccess
    {
        public Task<List<User>> GetUsersAsync();
    }
}
