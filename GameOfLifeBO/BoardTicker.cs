using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Contracts;
using GameOfLife.EvolutionRules;

namespace GameOfLife.BusinessObjects
{
    public class BoardTicker : IBoardTicker
    {
        private EvolutionRule ruleCoR = CoRFactory.GetEvolutionRuleCoR();

        public IBoard Board
        {
            get;
            private set;
        }

        public BoardTicker(IBoard board)
        {
            this.Board = board;
        }

        /// <summary>
        /// Ticks the board into next generation.
        /// </summary>
        /// <returns>The next generation board after the Tick</returns>
        public IBoard Tick()
        {
            IBoard nextGenBoard = Board.Copy();

            for (int r = 0; r < Board.TotalRows; r++)
            {
                for (int c = 0; c < Board.TotalColumns; c++)
                {
                    ICell cell = Board[r,c];
                    cell.NoOfNeighborsAlive = 0;
                    List<ICell> neighbors = Board.GetNeighbors(cell);
                    foreach (ICell neighbor in neighbors)
                    {
                        if (neighbor.Alive)
                            cell.NoOfNeighborsAlive++;
                    }
                    nextGenBoard[r,c].Alive = ruleCoR.IsAlive(cell);
                }
            }
            Board = nextGenBoard;
            return nextGenBoard;
        }
    }
}
