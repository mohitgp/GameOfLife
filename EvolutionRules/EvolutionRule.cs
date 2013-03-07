using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Contracts;

namespace GameOfLife.EvolutionRules
{
    public abstract class EvolutionRule
    {
        protected EvolutionRule Successor { get; set; }

        public EvolutionRule(EvolutionRule rule)
        {
            Successor = rule;
        }
        public abstract bool IsAlive(ICell c);
    }

    //this is the sentinel at the end of the chain. If none of the rules is satisfied this will run. Default result put here
    public sealed class DefaultEvolutionRule : EvolutionRule
    {
        public DefaultEvolutionRule(EvolutionRule rule)
            : base(rule)
        { }

        public override bool IsAlive(ICell c)
        {
            return false;
        }
    }
}
