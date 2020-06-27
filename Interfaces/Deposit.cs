using System;

namespace Interfaces
{
    public abstract class Deposit : IComparable<Deposit>
    {
        public decimal Amount { get; }

        public int Period { get; }

        protected Deposit(decimal depositAmount, int depositPeriod)
        {
            Amount = depositAmount;
            Period = depositPeriod;
        }

        public abstract decimal Income();

        public static bool operator !=(Deposit d1, Deposit d2)
        {
            return (d1.Amount + d1.Income()) != (d2.Amount + d2.Income());
        }

        public static bool operator ==(Deposit d1, Deposit d2)
        {
            return (d1.Amount + d1.Income()) == (d2.Amount + d2.Income());
        }

        public static bool operator >(Deposit d1, Deposit d2)
        {
            return (d1.Amount + d1.Income()) > (d2.Amount + d2.Income());
        }

        public static bool operator <(Deposit d1, Deposit d2)
        {
            return (d1.Amount + d1.Income()) < (d2.Amount + d2.Income());
        }

        public static bool operator >=(Deposit d1, Deposit d2)
        {
            return (d1.Amount + d1.Income()) >= (d2.Amount + d2.Income());
        }

        public static bool operator <=(Deposit d1, Deposit d2)
        {
            return (d1.Amount + d1.Income()) <= (d2.Amount + d2.Income());
        }

        public int CompareTo(Deposit other)
        {
            if (other is null)
                return 1;
            if (other > this)
                return -1;
            else if (other < this)
                return 1;
            else
                return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            Deposit d = obj as Deposit;

            if (d == null)
                return false;

            return d.Amount == this.Amount && d.Period == this.Period;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Amount);
        }
    }
}