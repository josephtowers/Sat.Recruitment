using System;

namespace Sat.Recruitment.Business.BusinessLogic.Users.Strategy.Concretes
{
    public class SuperUserCalculation : ICalculation
    {
        public decimal Calculate(decimal money)
        {
            if (money > 100)
            {
                var percentage = Convert.ToDecimal(0.20);
                var gif = money * percentage;
                money += gif;
            }
            return money;
        }
    }
}
