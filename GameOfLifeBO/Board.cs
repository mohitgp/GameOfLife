using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife.EvolutionRules;
using GameOfLife.Contracts;

namespace GameOfLife.BusinessObjects
{
    public class Board : IBoard
    {
        #region PrivateMembers
        private ICell[][] cellArray;
        #endregion

        /// <summary>
        /// Constructor which initialized the board to the given size.
        /// </summary>
        /// <param name="rows">Number of rows on the board.</param>
        /// <param name="columns">Number of rows on the board.</param>
        public Board(int rows, int columns)
        {
            Initialize(rows, columns);
        }

        /// <summary>
        /// Gets all the available neighbors of a cell. Handles the corner and edge cells also.
        /// </summary>
        /// <param name="cell">The cell for which neighbors to be returned.</param>
        /// <returns>List<ICell></returns>
        public List<ICell> GetNeighbors(ICell cell)
        {
            List<ICell> neighbors = new List<ICell>();
            int[] neighborRowIndices = { -1, -1, -1, 0, 0, +1, +1, +1 };
            int[] neighborColIndices = { -1, 0, +1, -1, +1, -1, 0, +1 };

            int r = cell.Row;
            int c = cell.Column;

            for (int i = 0; i < 8; i++)
            {
                int newR = r + neighborRowIndices[i];
                int newC = c + neighborColIndices[i];
                if (newR >= 0 && newR < TotalRows && newC >= 0 && newC < TotalColumns)
                {
                    ICell neighbor = cellArray[newR][newC];
                    neighbors.Add(neighbor);
                }
            }

            return neighbors;
        }

        /// <summary>
        /// Initialize the board to the given size.
        /// </summary>
        /// <param name="TotalRows">Number of rows on the board.</param>
        /// <param name="TotalColumns">Number of columns on the board.</param>
        public void Initialize(int TotalRows, int TotalColumns)
        {
            this.TotalRows = TotalRows;
            this.TotalColumns = TotalColumns;

            cellArray = new ICell[TotalRows][];

            for (int r = 0; r < TotalRows; r++)
            {
                cellArray[r] = new ICell[TotalColumns];

                for (int c = 0; c < TotalColumns; c++)
                {
                    ICell cell = new Cell();
                    cell.Row = r;
                    cell.Column = c;

                    cellArray[r][c] = cell;
                }
            }
        }

        /// <summary>
        /// Creates a new board with the same dimensions. Doesn't copy the values.
        /// </summary>
        /// <returns></returns>
        public IBoard Copy()
        {
            Board copy = new Board(this.TotalRows, this.TotalColumns);
            return copy;
        }

        /// <summary>
        /// Indexer to get the cell at the given row, column index
        /// </summary>
        /// <param name="Row">Row Index</param>
        /// <param name="Column">Column Index</param>
        /// <returns></returns>
        public ICell this[int Row, int Column]
        {
            get
            {
                if (Row >= 0 && Row < TotalRows && Column >= 0 && Column < TotalColumns)
                {
                    return cellArray[Row][Column];
                }
                else
                {
                    return null;
                }
            }

        }

        /// <summary>
        /// Gets the total number of rows on the board.
        /// </summary>
        public int TotalRows { get; private set; }
        /// <summary>
        /// Gets the total number of columns on the board.
        /// </summary>
        public int TotalColumns { get; private set; }

    }
}
