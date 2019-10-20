using System;
namespace Clicker.Domain.Model
{
    public class Automator
    {
        public long InitialUnitsPerTick { get; set; }
        public long InitialAutomatorCost { get; set; }
        public long InitialMultiplierCost { get; set; }
        public decimal MultiplierCostMultiplier { get; set; }
        public decimal AutomatorCostMultiplier { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
