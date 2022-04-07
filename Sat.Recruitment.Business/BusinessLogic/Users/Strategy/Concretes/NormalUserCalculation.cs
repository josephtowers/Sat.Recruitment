using System;

namespace Sat.Recruitment.Business.BusinessLogic.Users.Strategy.Concretes
{
    public class NormalUserCalculation : ICalculation
    {
        public decimal Calculate(decimal money)
        {
            if (money > 100)
            {
                var percentage = Convert.ToDecimal(0.12);
                //If new user is normal and has more than USD100
                var gif = money * percentage;
                money += gif;
            }
            if (money < 100 && money > 10)
            {
                var percentage = Convert.ToDecimal(0.8);
                var gif = money * percentage;
                money += gif;
            }
            return money;
        }
    }
}
