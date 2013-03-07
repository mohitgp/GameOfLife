using System;
using GameOfLife.Contracts;

namespace GameOfLife.EvolutionRules
{
    public class KilledByUnderPopulationRule : EvolutionRule
    {
        public KilledByUnderPopulationRule(EvolutionRule rule)
            : base(rule)
        { }

        public override bool IsAlive(ICell c)
        {
            if (c.Alive && c.NoOfNeighborsAlive < 2)
            {
                return false;
            }
            else
            {
                return Successor.IsAlive(c);
            }
        }
    }
}
