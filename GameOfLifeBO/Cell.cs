using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.Contracts;

namespace GameOfLife.BusinessObjects
{
    public class Cell : ICell
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public bool Alive { get; set; }
        public int NoOfNeighborsAlive { get; set; }

        public Cell(bool isAlive, int noOfNeighborsAlive)
        {
            Alive = isAlive;
            NoOfNeighborsAlive = noOfNeighborsAlive;
        }

        public Cell()
        {

        }

    }
}
