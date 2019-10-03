using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\Raizel Seliger\source\repos\ConsoleApp1\.vs\ConsoleApp1\v16\text.txt";
            string output = "";
            int index = (int)'A';

            void PreviousLine()
            {
                output += "U";
                index -= 6;
                Console.WriteLine("Dropped to letter " + (char)index);
            }

            void MoveRight()
            {
                output +=  "R";
                index += 1;
                Console.WriteLine("Moved Right to letter " + (char)index);
            }

            void MoveLeft()
            {
                output += "L";
                index -= 1;
                Console.WriteLine("Moved Left to letter " + (char)index);
            }

            void nextLine()
            {
                output += "D";
                index += 6;
                Console.WriteLine("Dropped to letter " + (char)index);
            }

            void select(char letter)
            {
                if ((int)letter == index) output += "#";
            }

            bool Matches(char letter)
            {
                return (int)letter == index;
            }

            void CheckFullLineBack(char letter)
            {
                while ((int)letter < index - 6) PreviousLine();
            }

            void CheckFullLineForward(char letter)
            {
                while ((int)letter > index + 6) nextLine();
            }

            void CheckOneLetterBack(char letter)
            {
                while ((int)letter < index)
                {
                    MoveLeft();
                    select(letter);
                }
            }

            void CheckOneLetterForward(char letter)
            {
                while ((int)letter > index)
                {
                    MoveRight();
                    select(letter);
                }
            }

            void FindAndSelect(char letter)
            {
                CheckFullLineBack(letter);
                CheckOneLetterBack(letter);
                CheckFullLineForward(letter);
                CheckOneLetterForward(letter);
            }

            string ReturnPath(string[] lines)
            {
                foreach (string line in lines)
                {
                    var upperline = line.ToUpper();
                    foreach (char letter in upperline)
                    {
                        if (Matches(letter)) select(letter); else FindAndSelect(letter);
                    }
                }
                return output;
            }
            Console.WriteLine(ReturnPath(File.ReadAllLines(path)));
            Console.ReadKey();
        }
    }
}
