using System;
using System.Collections;
using System.Collections.Generic;

namespace Clicker.Domain.Data
{
    public class AutomatorCollection : List<Automator>, IEnumerable
    {
        public long TotalUnitsPerTick { get; private set; }

        public void Update()
        {
            TotalUnitsPerTick = 0;
            foreach(var a in this)
            {
                TotalUnitsPerTick += a.UnitsPerTick;
            }
        }
    }
}
