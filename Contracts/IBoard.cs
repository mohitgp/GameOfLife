using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Contracts
{
    public interface IBoard
    {
        void Initialize(int TotalRows, int TotalColumns);

        ICell this[int row, int column]{get;}

        List<ICell> GetNeighbors(ICell cell);

        IBoard Copy();

        int TotalRows { get; }
        int TotalColumns { get; }
    }
}
