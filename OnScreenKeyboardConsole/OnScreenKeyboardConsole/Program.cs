using System;
using System.Collections.Generic;
using System.Text;

namespace OnScreenKeyboardConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            KeyBoardTranslator kb = new KeyBoardTranslator();
            var tup = Tuple.Create(0, 0);
            while ((line = Console.ReadLine()) != null)
            {
                var outputchars = kb.GenerateString(ref tup, line);
                Console.WriteLine(string.Join(',',outputchars)); // Write to console.

                //outputs results cursor stays on last character entered if you want to go back to A add this line
                //tup = Tuple.Create(0, 0);
            }
        }
    }

    public class KeyBoardTranslator
    {
        //col0   col5
        //ABCDEF row1
        //GHIJKL
        //MNOPQR
        //STUVWX
        //YZ1234
        //567890 row 6

        public int GetColumn(char input)
        {
            int column = -1;
            var num = ((int)input);

            if (num >= 48)
            {
                if (num == 48)
                    column = 5;
                else if (num <= 57)
                    column = (num - 47) % 6;
                else if (num >= 65 && num <= 90)
                    num += 32;

                if (num >= 97 && num <= 122)
                    column = (num - 97) % 6;
            }
            if (column != -1) return column;
            throw new IndexOutOfRangeException($"Character '{input}' in not a valid entry.");
        }

        public int GetRow(char input)
        {
            int row = -1;
            var num = ((int)input);

            if (num >= 48 && num <= 57)
            {

                if (num > 48 && num <= 52)
                    row = 4;
                else
                    row = 5;
            }
            //a-z
            else if (num >= 65 && num <= 70)
                row = 0;
            else if (num >= 71 && num <= 76)
                row = 1;
            else if (num >= 77 && num <= 82)
                row = 2;
            else if (num >= 83 && num <= 88)
                row = 3;
            else if (num >= 89 && num <= 90)
                row = 4;
            //A-Z
            else if (num >= 97 && num <= 102)
                row = 0;
            else if (num >= 103 && num <= 108)
                row = 1;
            else if (num >= 109 && num <= 114)
                row = 2;
            else if (num >= 115 && num <= 120)
                row = 3;
            else if (num >= 121 && num <= 122)
                row = 4;

            if(row != -1) return row;
            throw new IndexOutOfRangeException($"Character '{input}' in not a valid entry.");
        }


        public List<char> GenerateString(ref Tuple<int,int> StatingLocation, string input, char invalidCharacterSymbol = '?')
        {
            List<char> output = new List<char>();
            foreach(char c in input)
            {
                if (c == ' ')
                {
                    output.Add('S');
                    continue;
                }
                int col, row;
                try
                {

                    col = GetColumn(c);
                    row = GetRow(c);
                }
                catch (Exception)
                {
                    //this is where the main functionality can be changed, how we want to handle an invalid input would significantly change
                    //the program, right now I just have it return a ? but we could just as easily have it boil up an exception
                    // or do something else
                    output.Add(invalidCharacterSymbol);
                    continue;
                    //throw;
                }

                var c1 = StatingLocation.Item1 - col;
                var r1 = StatingLocation.Item2 - row;

                while (r1 < 0)
                {
                    output.Add('D');
                    r1++;
                }
                while (r1 > 0)
                {
                    output.Add('U');
                    r1--;
                }

                while (c1 < 0)
                {
                    output.Add('R');
                    c1++;
                }
                while (c1 > 0)
                {
                    output.Add('L');
                    c1--;
                }
                output.Add('#');

                StatingLocation = Tuple.Create(col, row);
            }

            return output;
           

        }
    }
}
