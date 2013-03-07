using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Contracts
{
    public interface IBoardView
    {
        IBoard Board { get; }

        void PreRender();

        void RenderBoard();

        void PostRender();
    }
}
