using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnScreenKeyboard
{
    public class Navigator
    {
        //Navigation sequence for ouput or display
        private string navigationPath;

        //User or File single search command
        private string searchCommand;

        /// <summary>
        /// Constructor for Navigator class
        /// </summary>
        /// <param name="searchCommand"></param>
        public Navigator(string searchCommand)
        {
            this.searchCommand = searchCommand;
            CalculateNavigationPath();
        }

        public string NavigationPath
        {
            get { return navigationPath; }
        }

        /// <summary>
        /// Uses the input string to the constructor to create a navigation sequence through the keyboard
        /// </summary>
        private void CalculateNavigationPath()
        {
            this.navigationPath = String.Empty;

            Position startPosition = new Position(0, 0);
            Position currentPosition = startPosition;

            Keyboard keyBoard = new Keyboard();
            foreach (char a in searchCommand)
            {
                Key selectedKey = keyBoard.GetSelectedKey(a.ToString());
                //Handle Space character
                if (selectedKey.Value == " ")
                {
                    this.navigationPath += "S,";
                }
                else
                {
                    Position goToPosition = selectedKey.KeyPosition;
                    SetKeySequence(currentPosition, goToPosition);
                    this.navigationPath += "#,";
                    currentPosition = goToPosition;
                }
            }

            //Clean up hanging comma
            if (this.navigationPath.Length > 0)
                this.navigationPath = this.navigationPath.TrimEnd(',');
        }

        /// <summary>
        /// Method that accepts the current position and the go to position as arguments
        /// to calculate the vertical and horizonatal moves then concatenates the moves to the navigation sequence
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="goToPosition"></param>
        private void SetKeySequence(Position currentPosition, Position goToPosition)
        {
            string oneKeySequence = String.Empty;
            int verticalMove = currentPosition.X - goToPosition.X;
            int horizontalMove = currentPosition.Y - goToPosition.Y;

            if (verticalMove > 0)
                MoveUp(verticalMove);
            if (verticalMove < 0)
                MoveDown(Math.Abs(verticalMove));
            if (horizontalMove > 0)
                MoveLeft(horizontalMove);
            if (horizontalMove < 0)
                MoveRight(Math.Abs(horizontalMove));
        }

        private void MoveLeft(int numSpaces)
        {
            for (int i = 0; i < numSpaces; i++)
            {
                this.navigationPath += "L,";
            }
        }

        private void MoveRight(int numSpaces)
        {
            for (int i = 0; i < numSpaces; i++)
            {
                this.navigationPath += "R,";
            }
        }

        private void MoveUp(int numSpaces)
        {
            for (int i = 0; i < numSpaces; i++)
            {
                this.navigationPath += "U,";
            }
        }

        private void MoveDown(int numSpaces)
        {
            for (int i = 0; i < numSpaces; i++)
            {
                this.navigationPath += "D,";
            }
        }
    }
}
