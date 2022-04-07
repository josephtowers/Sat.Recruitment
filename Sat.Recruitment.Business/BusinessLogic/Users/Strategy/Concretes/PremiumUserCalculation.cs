namespace Sat.Recruitment.Business.BusinessLogic.Users.Strategy.Concretes
{
    public class PremiumUserCalculation : ICalculation
    {
        public decimal Calculate(decimal money)
        {
            if (money > 100)
            {
                var gif = money * 2;
                money += gif;
            }
            return money;
        }
    }
}
