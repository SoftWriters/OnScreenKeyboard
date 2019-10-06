using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

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

        public void Exit()
        {
            Console.WriteLine("Have a Nice Day!");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }
        //run the program for each letter in the file
        //Todo each lines output is to be stored seperately, maybe by creating a list

        public string LineOutput(string line, Keyboard kb)
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
            return String.Join(",", kb.Output.ToCharArray());
        }

        public List<string> Output(string textfile)
        {
            List<string> LineOutputs = new List<string>();
            foreach (string line in File.ReadAllLines(textfile))
            {
                Keyboard keyboard = new Keyboard();
                LineOutputs.Add(LineOutput(line, keyboard));
            }
            return LineOutputs;
        }

        public void Write(string textfile)
        {
            foreach (string output in Output(textfile))
            {
                Console.WriteLine(output);
            }
        }
    }
}
