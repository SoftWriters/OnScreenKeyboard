using ConsoleApp1.files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Keyboard keyboard = new Keyboard();
            var keys = keyboard.keys;
            var path = @"C:\Users\Raizel Seliger\source\repos\ConsoleApp1\.vs\ConsoleApp1\v16\text.txt";

            //Follow path and call the methods that add to the output
            bool TrackPathAndSelect(string letter)
            {
                while (keyboard.CurrentPosX > keyboard.DesiredPosX) keyboard.Up();
                while (keyboard.CurrentPosX < keyboard.DesiredPosX) keyboard.Down();
                while (keyboard.CurrentPosY > keyboard.DesiredPosY) keyboard.Left();
                while (keyboard.CurrentPosY < keyboard.DesiredPosY) keyboard.Right();
                keyboard.Select();
                return (keyboard.CurrentPosX == keyboard.DesiredPosX) && 
                    (keyboard.CurrentPosY == keyboard.DesiredPosY);
            }

            //locate the desired letter and set the position in the model, return the position as a string
            string SetDesiredPosition(string letter)
            {
                bool found = false;
                int x = 0;
                int y = 0;
                foreach (KeyValuePair<int, string[]> kv in keys)
                {
                    for(var i = 0; i < kv.Value.Length; i++)
                    {
                        if (kv.Value[i].Equals(letter))
                        {
                            x = keyboard.DesiredPosX = kv.Key;
                            y = keyboard.DesiredPosY = i;
                            found = true;
                            break;
                        }
                    }
                    if (found) break;
                }
                return x.ToString() + y.ToString();
            }

            //run the program for each letter in the file
            //Todo each lines output is to be stored seperately, maybe by creating a list
            string Output(string textfile)
            {
                foreach (string line in File.ReadAllLines(textfile))
                {
                    var upperline = line.ToUpper().Select(x => x.ToString());
                    foreach (string letter in upperline)
                    {
                        if (letter.Equals(" ")) keyboard.Output += "S";
                        else
                        {
                            SetDesiredPosition(letter);
                            TrackPathAndSelect(letter);
                        }
                    }
                }
                return keyboard.Output;
            }
            Console.WriteLine(Output(path));
            Console.ReadKey();
        }
    }
}
