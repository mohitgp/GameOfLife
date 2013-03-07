using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife.Contracts;
using GameOfLife.EvolutionRules;
using GameOfLife.BusinessObjects;

namespace Tests
{
    [TestClass]
    public class EvolutionRulesTests
    {
        private EvolutionRule rulesCoR = CoRFactory.GetEvolutionRuleCoR();

        [TestMethod]
        public void DefaultRuleTest()
        {
            ICell cell = new Cell(false, 0);
            Assert.IsFalse(rulesCoR.IsAlive(cell));
        }

        [TestMethod]
        public void WakeUpDeadTest()
        {
            ICell cell = new Cell(false, 3);
            Assert.IsTrue(rulesCoR.IsAlive(cell));
        }

        [TestMethod]
        public void WakeUpDeadNegative24Test()
        {
            ICell cell2 = new Cell(false, 2);
            Assert.IsFalse(rulesCoR.IsAlive(cell2));

            ICell cell4 = new Cell(false, 4);
            Assert.IsFalse(rulesCoR.IsAlive(cell4));
        }

        [TestMethod]
        public void WakeUpDeadNegative08Test()
        {
            ICell cell0 = new Cell(false, 0);
            Assert.IsFalse(rulesCoR.IsAlive(cell0));

            ICell cell8 = new Cell(false, 8);
            Assert.IsFalse(rulesCoR.IsAlive(cell8));
        }

        [TestMethod]
        public void KilledByUnderPopulationTest()
        {
            ICell cell0 = new Cell(true, 0);
            Assert.IsFalse(rulesCoR.IsAlive(cell0));

            ICell cell1 = new Cell(true, 1);
            Assert.IsFalse(rulesCoR.IsAlive(cell1));
        }

        [TestMethod]
        public void StayAliveTest()
        {
            ICell cell2 = new Cell(true, 2);
            Assert.IsTrue(rulesCoR.IsAlive(cell2));

            ICell cell3 = new Cell(true, 3);
            Assert.IsTrue(rulesCoR.IsAlive(cell3));
        }

        [TestMethod]
        public void KilledByOvercrowdingTest()
        {
            ICell cell4 = new Cell(true, 4);
            Assert.IsFalse(rulesCoR.IsAlive(cell4));

            ICell cell8 = new Cell(true, 8);
            Assert.IsFalse(rulesCoR.IsAlive(cell8));
        }
    }
}
