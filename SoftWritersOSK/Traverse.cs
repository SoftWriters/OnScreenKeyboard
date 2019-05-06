using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftWritersOSK
{
    /*
        The Traverse class provides methods for outputting navigation
        directions between characters in a string
    */
    static class Traverse
    {
        /*
            ConvertASCII returns the values 0-25 for the characters A-Z,
            the values 26-34 for characters 1-9,
            and the value of 35 for the character 0.
            These integers are arbitrary "indices" that allow for the
            calculation of cardinal directions
        */
        public static int ConvertASCII(char a)
        {
            int aa = (int)a;
            if (aa <= 57 && aa > 48)
                aa += 42;
            if (aa == 48)
                aa += 52;

            return aa - 65;
        }
        
        //TraverseChar provides output for the path between char a and char b 
        public static string TraverseChar(char a, char b)
        {
            int aa = ConvertASCII(a);
            int bb = ConvertASCII(b);
            string path = "";
            //Compares the positions of a and b. If b is on the line above a, it moves the "cursor" up
            while ((bb - aa) <= -6 || (Math.Floor((decimal)aa / 6) > Math.Floor((decimal)bb / 6)))
            {
                path += "U,";
                aa -= 6;
            }
            //Compares the positions of a and b. If b is on the line below a, it moves the "cursor" down
            while ((bb - aa) >= 6 || (Math.Floor((decimal)aa / 6) < Math.Floor((decimal)bb / 6)))
            {
                path += "D,";
                aa += 6;
            }
            //Compares the positions of a and b. If b is to the left of a, it moves the "cursor" left
            while ((bb - aa) <= -1)
            {
                path += "L,";
                aa -= 1;
            }
            //Compares the positions of a and b. If b is to the right of a, it moves the "cursor" right
            while ((bb - aa) >= 1)
            {
                path += "R,";
                aa += 1;
            }
            //Checks if the "cursor" is located at the target character, and appends the select character if it is.
            if (bb == aa)
                path += "#";

            return path;
        }
        /*
            TraverseString calls TraverseChar for each character in the input string
            and returns the pathing string for the entire input string
        */
        public static string TraverseString(string word)
        {
            char current = (char)0;
            char next = (char)0;
            char[] wordArray = word.ToUpper().ToCharArray();
            string path = "";
            //Cycles through every character in the input string
            for (int i = 0; i < wordArray.Length; i++)
            {
                next = wordArray[i];
                if ((int)current == 0)
                    current = 'A';
                if (wordArray[i] == ' ')
                {
                    path += "S";
                }
                else
                {
                    path += TraverseChar(current, next);
                    current = next;
                }
                if (i != wordArray.Length - 1)
                    path += ',';
            }

            return path;
        }

        //TraverseFile takes a file path as input and outputs the cursor path for each line of the input file.
        public static void TraverseFile(string file)
        {
            foreach (string line in System.IO.File.ReadLines(file))
            {
                System.Console.WriteLine(Traverse.TraverseString(line));
            }
        }
    }
}



