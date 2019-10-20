using System;
namespace Clicker.Domain.Data
{
    public class Automator
    {
        public long InitialUnitsPerSecond { get; }
        public long InitialAutomatorCost { get; }
        public long InitialMultiplierCost { get; }
        public decimal MultiplierCostMultiplier { get; }
        public decimal AutomatorCostMultiplier { get; }

        public int Count { get; private set; }
        public int Multiplier { get; private set; }
        public long AutomatorCost { get; private set; }
        public long MultiplierCost { get; private set; }
        public long UnitsPerSecond { get; private set; }

        public Automator(long initialCost, long initialMultiplierCost, decimal automatorCostMultiplier, decimal multiplierCostMultiplier, long initialCostPerSecond)
        {
            InitialAutomatorCost = AutomatorCost = initialCost;
            InitialMultiplierCost = MultiplierCost = initialMultiplierCost;
            AutomatorCostMultiplier = automatorCostMultiplier;
            MultiplierCostMultiplier = multiplierCostMultiplier;
            InitialUnitsPerSecond = initialCostPerSecond;
            Count = 0;
            Multiplier = 1;
            UnitsPerSecond = 0;
        }

        public void IncrementAutomator()
        {
            Count++;
            AutomatorCost = Convert.ToInt64(AutomatorCostMultiplier * AutomatorCost);
            SetUnitsPerSecond();
        }

        public void IncrementMultiplier()
        {
            Multiplier++;
            MultiplierCost = Convert.ToInt64(MultiplierCostMultiplier * MultiplierCost);
            SetUnitsPerSecond();
        }

        private void SetUnitsPerSecond()
        {
            UnitsPerSecond = Multiplier * Count * InitialUnitsPerSecond;
        }
    }
}
