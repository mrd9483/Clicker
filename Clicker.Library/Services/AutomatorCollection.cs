using System.Collections;
using System.Collections.Generic;

namespace Clicker.Library.Services
{
    public class AutomatorCollection : List<Automator>, IEnumerable
    {
        public AutomatorCollection(IEnumerable<Models.Automator> models)
        {
            var i = models.GetEnumerator();
            while (i.MoveNext())
            {
                Add(new Automator(i.Current));
            }
        }
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
