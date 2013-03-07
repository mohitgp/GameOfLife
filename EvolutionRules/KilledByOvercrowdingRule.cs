using System;
using GameOfLife.Contracts;

namespace GameOfLife.EvolutionRules
{
    public class KilledByOvercrowdingRule : EvolutionRule
    {
        public KilledByOvercrowdingRule(EvolutionRule rule)
            : base(rule)
        { }

        public override bool IsAlive(ICell c)
        {
            if (c.Alive && c.NoOfNeighborsAlive > 3)
            {
                return false;
            }
            else
            {
                return Successor.IsAlive(c);
            }
        }
    }}
