namespace Interfaces
{
    public class BaseDeposit : Deposit
    {
        public BaseDeposit(decimal amount, int period)
            : base(amount, period)
        { }

        public override decimal Income()
        {
            decimal income = default;
            decimal amount = Amount;

            for (int i = 1; i <= Period; i++)
            {
                income += System.Decimal.Round((amount * 5 / 100), 2);
                amount = Amount + income;
            }

            return income;
        }
    }
}