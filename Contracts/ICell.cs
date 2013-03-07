using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Contracts
{
    public interface ICell
    {
        int Row { get; set; }
        int Column { get; set; }

        bool Alive { get; set; }
        int NoOfNeighborsAlive { get; set; }
    }
}
