using System;
using System.Collections.Generic;
using System.Linq;

namespace DVRVoiceToKeyboard
{
    //There is no spoon
    public class TheMatrixKeyboard
    {
        public TheMatrixKeyboard IsNavigatingFrom(char FromCharacter)
        {
            //ignore from when it starts with a space. will continue from last character
            if (FromCharacter != ' ')
                KeyboardMapping.TryGetValue(FromCharacter, out startIndex);

            return this;
        }

        public string To(char ToCharacter)
        {
            //this action will return the string of commands which navigate from start index to end index
            string result = "";

            if (ToCharacter == ' ')
            {
                result = "S";
            }            
            else
            {
                //turn the char into an index to compare
                KeyboardMapping.TryGetValue(ToCharacter, out endIndex);

                result = NavigateMatrix();
            }

            return result;
        }

        private string NavigateMatrix()
        {
            string path = "";

            //count the U or D or no operations
            int countVerticleOperations = endIndex.Item1 - startIndex.Item1;
            //count the L or R or no operations
            int countHorizontalOperations = endIndex.Item2 - startIndex.Item2;
            
            //we can refactor code here but readability is important            
            if (countVerticleOperations < 0)
                path += String.Concat(Enumerable.Repeat("U,", Math.Abs(countVerticleOperations)));
            else if (countVerticleOperations > 0)
                path += String.Concat(Enumerable.Repeat("D,", Math.Abs(countVerticleOperations)));

            if (countHorizontalOperations < 0)
                path += String.Concat(Enumerable.Repeat("L,", Math.Abs(countHorizontalOperations)));
            else if (countHorizontalOperations > 0)
                path += String.Concat(Enumerable.Repeat("R,", Math.Abs(countHorizontalOperations)));

            //end with the selection and setting the start index to the endIndex
            path += '#';

            return path;
        }

        private Tuple<int, int> startIndex = new Tuple<int, int>(0,0);

        private Tuple<int, int> endIndex = new Tuple<int, int>(0,0);

        //create the 6x6 matrix dictionary with character keys and return index values.
        private static Dictionary<char, Tuple<int, int>> KeyboardMapping = 
            new Dictionary<char, Tuple<int, int>>
                { { 'A', new Tuple<int,int>(0,0) },
                { 'B', new Tuple<int,int>(0,1) },
                { 'C', new Tuple<int,int>(0,2) },
                { 'D', new Tuple<int,int>(0,3) },
                { 'E', new Tuple<int,int>(0,4) },
                { 'F', new Tuple<int,int>(0,5) },
                { 'G', new Tuple<int,int>(1,0) },
                { 'H', new Tuple<int,int>(1,1) },
                { 'I', new Tuple<int,int>(1,2) },
                { 'J', new Tuple<int,int>(1,3) },
                { 'K', new Tuple<int,int>(1,4) },
                { 'L', new Tuple<int,int>(1,5) },
                { 'M', new Tuple<int,int>(2,0) },
                { 'N', new Tuple<int,int>(2,1) },
                { 'O', new Tuple<int,int>(2,2) },
                { 'P', new Tuple<int,int>(2,3) },
                { 'Q', new Tuple<int,int>(2,4) },
                { 'R', new Tuple<int,int>(2,5) },
                { 'S', new Tuple<int,int>(3,0) },
                { 'T', new Tuple<int,int>(3,1) },
                { 'U', new Tuple<int,int>(3,2) },
                { 'V', new Tuple<int,int>(3,3) },
                { 'W', new Tuple<int,int>(3,4) },
                { 'X', new Tuple<int,int>(3,5) },
                { 'Y', new Tuple<int,int>(4,0) },
                { 'Z', new Tuple<int,int>(4,1) },
                { '1', new Tuple<int,int>(4,2) },
                { '2', new Tuple<int,int>(4,3) },
                { '3', new Tuple<int,int>(4,4) },
                { '4', new Tuple<int,int>(4,5) },
                { '5', new Tuple<int,int>(5,0) },
                { '6', new Tuple<int,int>(5,1) },
                { '7', new Tuple<int,int>(5,2) },
                { '8', new Tuple<int,int>(5,3) },
                { '9', new Tuple<int,int>(5,4) },
                { '0', new Tuple<int,int>(5,5) }};
    }
}
