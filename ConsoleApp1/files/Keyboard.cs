using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.files
{
    public class Keyboard
    {
        public Keyboard()
        {
            this.DesiredPosX = 1;
            this.DesiredPosY = 0;
            this.CurrentPosX = 1;
            this.CurrentPosY = 0;
        }
        public string Output { get; set; }
        public int DesiredPosX { get; set; }
        public int DesiredPosY { get; set; }
        public int CurrentPosX { get; set; }
        public int CurrentPosY { get; set; }

        public Dictionary<int, string[]> keys = new Dictionary<int, string[]>()
            {
                { 1, new string[]{ "A", "B", "C", "D", "E", "F"} },
                { 2, new string[]{ "G", "H", "I", "J", "K", "L"} },
                { 3, new string[]{ "M", "N", "O", "P", "Q", "R"} },
                { 4, new string[]{ "S", "T", "U", "V", "W", "X"} },
                { 5, new string[]{ "Y", "Z", "1", "2", "3", "4"} },
                { 6, new string[]{ "5", "6", "7", "8", "9", "0"} }
            };

        //"D,R,#,U,R,R,R,#,D,R,#,#,D,L,L,L,#"
        public (string output, int currentposx) Up()
        {
            if (this.CurrentPosX > 1)
            {
                this.Output += "U";
                this.CurrentPosX--;
            }
            return (this.Output, this.CurrentPosX);
        }
        public (string output, int currentposx) Down()
        {
            if (this.CurrentPosX < 6)
            {
                this.Output += "D";
                this.CurrentPosX++;
            }
            return (this.Output, this.CurrentPosX);
        }
        public void Right()
        {
            this.Output += "R";
            this.CurrentPosY++;
        }
        public void Left()
        {
            this.Output += "L";
            this.CurrentPosY--;
        }

        internal void Select() => this.Output += "#";
    }
}
