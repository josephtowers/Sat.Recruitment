using Sat.Recruitment.Data.Models;
using Sat.Recruitment.Data.Util;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly string USERS_PATH = Directory.GetCurrentDirectory() + "/Files/Users.txt";
        public async Task<List<User>> GetUsersAsync()
        {
            var users = new List<User>();
            using (var readerUser = FileReader.ReadFile(USERS_PATH))
            {
                string line;
                while ((line = await readerUser.ReadLineAsync()) != null)
                {
                    var splitLine = line.Split(',');
                    var newUser = new User
                    {
                        Name = splitLine[0],
                        Email = splitLine[1],
                        Phone = splitLine[2],
                        Address = splitLine[3],
                        UserType = splitLine[4],
                        Money = decimal.Parse(splitLine[5]),
                    };
                    users.Add(newUser);
                }
            }
            return users;
        }
    }
}
