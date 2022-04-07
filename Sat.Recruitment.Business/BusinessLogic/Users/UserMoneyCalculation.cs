using Sat.Recruitment.Business.BusinessLogic.Users.Strategy;
using Sat.Recruitment.Business.BusinessLogic.Users.Strategy.Concretes;
using Sat.Recruitment.Data.Models;
using System;
namespace Sat.Recruitment.Business.BusinessLogic.Users
{
    public static class UserMoneyCalculation
    {
        public static ICalculation GetCalculationType(string type)
        {
            switch(type)
            {
                case "Normal":
                    return new NormalUserCalculation();
                case "Super":
                    return new SuperUserCalculation();
                case "Premium":
                    return new PremiumUserCalculation();
                default:
                    throw new ArgumentException("Unknown user type provided");
            }
        }
        public static decimal GetUserMoneyCalculation(User user)
        {
            var percentage = GetCalculationType(user.UserType).Calculate(user.Money);
            var gif = user.Money * Convert.ToDecimal(percentage);
            return user.Money + gif;
        }
    }
}
