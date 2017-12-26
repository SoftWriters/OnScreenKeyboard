using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboard
{
    public class Location
    {

        public int Row { get; set; }
        public int Column { get; set; }


        #region Constructors....

        public Location(int row, int column)
        {
            Row = row;
            Column = column;
        }

        #endregion

    }  // end class
}  // end namespace
