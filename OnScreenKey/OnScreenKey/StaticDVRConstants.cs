using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKey
{
    /// <summary>
    /// A class using preset values for DVR Constants
    /// </summary>
    /// <remarks>Other possible ways this could be done - defined through system properties, specified as additional file parameter, etc.</remarks>
    class StaticDVRConstants:AbstractDVRConstants
    {
        private String _left = "L";
        private String _right = "R";
        private String _up = "U";
        private String _down = "D";
        private String _space = "S";
        private String _enter = "#";
        private String _separator = ",";

        /// <returns>Returns "L".</returns>
        public override string Left
        {
            get
            {
                return _left;
            }
        }

        /// <returns>Returns "R".</returns>
        public override string Right
        {
            get
            {
                return _right;
            }
        }

        /// <returns>Returns "U".</returns>
        public override string Up
        {
            get
            {
                return _up;
            }
        }

        /// <returns>Returns "D".</returns>
        public override string Down
        {
            get
            {
                return _down;
            }
        }

        /// <returns>Returns "S".</returns>
        public override string Space
        {
            get
            {
                return _space;
            }
        }

        /// <returns>Returns "#".</returns>
        public override string Enter
        {
            get
            {
                return _enter;
            }
        }

        /// <returns>Returns the separator character, ",".</returns>
        public override string Separator
        {
            get
            {
                return _separator;
            }
        }
    }
}
