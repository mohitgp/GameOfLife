using System;
using GameOfLife.Contracts;

namespace GameOfLife.EvolutionRules
{
    public class StayAliveRule : EvolutionRule
    {
        public StayAliveRule(EvolutionRule rule)
            : base(rule)
        { }

        public override bool IsAlive(ICell c)
        {
            if (c.Alive && (c.NoOfNeighborsAlive == 2 || c.NoOfNeighborsAlive == 3))
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
