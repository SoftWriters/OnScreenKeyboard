using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboard
{
    class Coordinate
    {
        private int _rowIndex;
        private int _columnIndex;

        public Coordinate(int row, int column)
        {
            _rowIndex = row;
            _columnIndex = column;
        }

        #region Accessors
        public int RowIndex
        {
            get { return _rowIndex;  }
            set {
                if (value >= 0)
                {
                    _rowIndex = value;
                }
            }
        }

        public int ColumnIndex
        {
            get { return _columnIndex;  }
            set
            {
                if (value >= 0)
                {
                    _columnIndex = value;
                }
            }
        }
        #endregion


        #region Public Functions
        public string GetMovesTo(Coordinate target)
        {
            string retString = "";
            string printString = "";

            int rowMoves = this.RowIndex - target.RowIndex;
            int columnMoves = this.ColumnIndex - target.ColumnIndex;

            /* print out row moves first */
            /* if our current row is greater than the target, we need to move up */
            if (rowMoves > 0)
            {
                printString = "U,";
            }
            else
            {
                printString = "D,";
                rowMoves = -rowMoves;
            }

            for(int i=0; i<rowMoves; ++i)
            {
                retString += printString;
            }


            /* print out column moves second */
            /* if our current dolumn is greater than the target, we need to move left */
            if (columnMoves > 0)
            {
                printString = "L,";
            }
            else
            {
                printString = "R,";
                columnMoves = -columnMoves;
            }

            for (int i = 0; i < columnMoves; ++i)
            {
                retString += printString;
            }

            /* print the select key */
            retString += "#,";

            return retString;
        }
        #endregion
    }
}
