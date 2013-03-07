using System;
using GameOfLife.Contracts;

namespace GameOfLife.EvolutionRules
{
    public class WakeUpDeadByReproductionRule : EvolutionRule
    {
        public WakeUpDeadByReproductionRule(EvolutionRule rule)
            : base(rule)
        { }

        public override bool IsAlive(ICell c)
        {
            if (!c.Alive && c.NoOfNeighborsAlive == 3)
            {
                return true;
            }
            else
            {
                return Successor.IsAlive(c);
            }
        }
    }
}
