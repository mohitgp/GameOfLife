using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Contracts;

namespace GameOfLife.BusinessObjects
{
    public class BoardView : IBoardView
    {
        public BoardView(IBoard board)
        {
            Board = board;
        }

        public IBoard Board{get; private set; }

        public void PreRender()
        {
            Console.Write("||");
            for (int c = 0; c < Board.TotalColumns; c++)
                Console.Write("==");
            Console.WriteLine("||");
        }

        public void RenderBoard()
        {
            for (int r = 0; r < Board.TotalRows; r++)
            {
                Console.Write("||");
                for (int c = 0; c < Board.TotalColumns; c++)
                {
                    if (Board[r, c].Alive)
                        Console.Write("* ");
                    else
                        Console.Write(". ");
                }
                Console.WriteLine("||");
            }
        }

        public void PostRender()
        {
            Console.Write("||");
            for (int c = 0; c < Board.TotalColumns; c++)
                Console.Write("==");
            Console.WriteLine("||");
        }
    }
}
