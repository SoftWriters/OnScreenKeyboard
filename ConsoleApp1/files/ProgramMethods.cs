using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1.files
{
    public class ProgramMethods
    {
       
        //locate the desired letter and set the position in the model, return the position as a string
        public (int x, int y) SetDesiredPosition(string letter, Keyboard kb)
        {
            bool found = false;
            int x = 0;
            int y = 0;
            foreach (KeyValuePair<int, string[]> kv in kb.keys)
            {
                for (var i = 0; i < kv.Value.Length; i++)
                {
                    if (kv.Value[i].Equals(letter))
                    {
                        x = kb.DesiredPosX = kv.Key;
                        y = kb.DesiredPosY = i;
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }
            return (x, y);
        }

        //Follow path and call the methods that add to the output
        public bool TrackPathAndSelect(string letter, Keyboard kb)
        {
            while (kb.CurrentPosX > kb.DesiredPosX) kb.Up();
            while (kb.CurrentPosX < kb.DesiredPosX) kb.Down();
            while (kb.CurrentPosY > kb.DesiredPosY) kb.Left();
            while (kb.CurrentPosY < kb.DesiredPosY) kb.Right();
            kb.Select();
            return (kb.CurrentPosX == kb.DesiredPosX) &&
                (kb.CurrentPosY == kb.DesiredPosY);
        }

        

        //run the program for each letter in the file
        //Todo each lines output is to be stored seperately, maybe by creating a list
        public string Output(string textfile, Keyboard kb)
        {
            foreach (string line in File.ReadAllLines(textfile))
            {
                var upperline = line.ToUpper().Select(x => x.ToString());
                foreach (string letter in upperline)
                {
                    if (letter.Equals(" ")) kb.Output += "S";
                    else
                    {
                        SetDesiredPosition(letter, kb);
                        TrackPathAndSelect(letter, kb);
                    }
                }
            }
            return kb.Output;
        }
    }
}
