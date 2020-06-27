namespace Interfaces
{
    public class SpecialDeposit : Deposit, IProlongable
    {
        public SpecialDeposit(decimal amount, int period)
            : base(amount, period)
        { }

        public bool CanToProlong()
        {
            if (Amount <= 1000)
                return false;
            return true;
        }

        public override decimal Income()
        {
            decimal income = default;
            decimal amount = Amount;

            for (int i = 1; i <= Period; i++)
            {
                income += System.Decimal.Round((amount * i / 100), 2);
                amount = Amount + income;
            }

            return income;
        }
    }
}