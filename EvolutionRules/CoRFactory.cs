using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.EvolutionRules
{
    public class CoRFactory
    {
        public static EvolutionRule GetEvolutionRuleCoR()
        {
            //in real world this would be in a some sort of configuration where 
            //OCP is satisfied by adding a new rule class and adding it in the config
            EvolutionRule rule = new KilledByUnderPopulationRule(
                new StayAliveRule(
                    new KilledByOvercrowdingRule(
                        new WakeUpDeadByReproductionRule(
                            new DefaultEvolutionRule(null)))));

            return rule;
        }
    }
}
