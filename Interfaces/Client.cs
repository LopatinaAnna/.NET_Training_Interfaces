using System;
using System.Collections;
using System.Collections.Generic;

namespace Interfaces
{
    public class Client : IEnumerable<Deposit>
    {
        private readonly Deposit[] deposits;

        public Client()
        {
            deposits = new Deposit[10];
        }

        public bool AddDeposit(Deposit deposit)
        {
            for (int i = 0; i < deposits.Length; i++)
            {
                if (deposits[i] is null)
                {
                    deposits[i] = deposit;
                    return true;
                }
            }
            return false;
        }

        public decimal TotalIncome()
        {
            decimal total = default;

            foreach (Deposit deposit in deposits)
            {
                if (!(deposit is null))
                    total += deposit.Income();
            }

            return total;
        }

        public decimal MaxIncome()
        {
            decimal maxIncome = default;
            foreach (Deposit deposit in deposits)
            {
                if (!(deposit is null) && deposit.Income() > maxIncome)
                    maxIncome = deposit.Income();
            }
            return maxIncome;
        }

        public decimal GetIncomeByNumber(int number)
        {
            if (deposits[number - 1] is null)
                return 0;
            return deposits[number - 1].Income();
        }

        public IEnumerator<Deposit> GetEnumerator()
        {
            return ((IEnumerable<Deposit>)deposits).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Deposit>)deposits).GetEnumerator();
        }

        public void SortDeposits()
        {
            Array.Sort(deposits, new Comparison<Deposit>((d1, d2) => d2.CompareTo(d1)));
        }

        public int CountPossibleToProlongDeposit()
        {
            int count = default;
            IProlongable temp;
            foreach (Deposit deposit in deposits)
            {
                temp = deposit as IProlongable;
                if (temp is null)
                    continue;
                if (temp.CanToProlong())
                    count++;
            }
            return count;
        }
    }
}