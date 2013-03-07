using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Contracts;
using GameOfLife.BusinessObjects;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            IBoard board = new Board(15, 15); //In real world a factory would create this instance
            IBoardTicker boardTicker = new BoardTicker(board); //Dependency Injection. In real world use an IoC container.
            IBoardView boardView = null;

            board[0, 1].Alive = true;
            board[1, 2].Alive = true;
            board[2, 0].Alive = true;
            board[2, 1].Alive = true;
            board[2, 2].Alive = true;

            for (int i = 0; i < 50; i++)
            {
                Console.Clear();
                boardView = new BoardView(board); //Dependency Injection. In real world use an IoC container.
                boardView.PreRender();
                boardView.RenderBoard();
                boardView.PostRender();
                board = boardTicker.Tick();
                Console.WriteLine(string.Format("Generation: {0}", i));
                Console.WriteLine("Press any key to view next Generation...");
                Console.ReadKey();
            }
        }
    }
}
