using System;
namespace Clicker.Library.Services
{
    public class Automator
    {
        private Models.Automator _model { get; }

        public long InitialUnitsPerTick => _model.InitialUnitsPerTick;
        public long InitialAutomatorCost => _model.InitialAutomatorCost;
        public long InitialMultiplierCost => _model.InitialMultiplierCost;
        public decimal MultiplierCostMultiplier => _model.MultiplierCostMultiplier;
        public decimal AutomatorCostMultiplier => _model.AutomatorCostMultiplier;

        public string Name => _model.Name;
        public string Description => _model.Description;

        public int Count { get; private set; }
        public int Multiplier { get; private set; }
        public long AutomatorCost { get; private set; }
        public long MultiplierCost { get; private set; }
        public long UnitsPerTick { get; private set; }

        public Automator(Models.Automator model)
        {
            _model = model;

            AutomatorCost = model.InitialAutomatorCost;
            MultiplierCost = model.InitialMultiplierCost;
            Count = 0;
            Multiplier = 1;
            UnitsPerTick = 0;
        }

        public Automator(long initialCost, long initialMultiplierCost, decimal automatorCostMultiplier, decimal multiplierCostMultiplier, long initialCostPerTick)
            : this(initialCost, initialMultiplierCost, automatorCostMultiplier, multiplierCostMultiplier, initialCostPerTick, null, null)
        {
        }

        public Automator(long initialCost, long initialMultiplierCost, decimal automatorCostMultiplier, decimal multiplierCostMultiplier, long initialCostPerTick, string name, string description)
            : this(new Models.Automator()
            {
                InitialAutomatorCost = initialCost,
                InitialMultiplierCost = initialMultiplierCost,
                AutomatorCostMultiplier = automatorCostMultiplier,
                MultiplierCostMultiplier = multiplierCostMultiplier,
                InitialUnitsPerTick = initialCostPerTick,
                Name = name,
                Description = description
            })
        {
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
            UnitsPerTick = Multiplier * Count * InitialUnitsPerTick;
        }
    }
}
