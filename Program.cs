using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeChallenge
{
    class Program
    {


        //Was meant to be a class used to compare prev and current indecies to guage for direction
        //private Coordinate[] directions = 
        //{
        //    new Coordinate(-1, 0), // Up
        //    new Coordinate(-1,-1), // Up + Left
        //    new Coordinate(-1, 1), // UP + Right
        //    new Coordinate(0, -1), // Left
        //    new Coordinate(0, 1),  // Right
        //    new Coordinate(1, -1), // Down + Left
        //    new Coordinate(1, 1),  // Down + Right
        //    new Coordinate(1, 0)  // Down


        //};


        //public class CoordinateComparer : Comparer<Coordinates>
        //        {
        //            public int Compare(Coordinate x, Coordinate y)
        //            {
        //            if (x.prevstrposition < y.currstrpositions)
        //                        return -1;
        //                    else if (x.prevstrposition > y.currstrpositions)
        //                        return 1;
        //            }
        //    return 0;
        //}

        static void Main(string[] args)

	{
        // Create a char array with the lines of text. Used Two Dimensional Array to assist with directional conversions.
        char[,] lines = new char[6, 6] { { 'A', 'B', 'C', 'D', 'E', 'F' }, { 'G', 'H', 'I', 'J', 'K', 'L' }, { 'M', 'N', 'O', 'P', 'Q', 'R' }, { 'S', 'T', 'U', 'V', 'W', 'X' }, { 'Y', 'Z', '1', '2', '3', '4' }, { '5', '6', '7', '8', '9', '0' } };
        
        //Array indexes
        int count1 = lines.GetLength(0);
        int count2 = lines.GetLength(1);
       //Testing string 
            //"Some number of characters";
            //Read in from input file
        string[] keybEntry = System.IO.File.ReadAllLines(@"C:\IncomingDvrDirectory\SearchText");
            //Convert into Char array to read char by char
        char[] a = new char[keybEntry.Length];
            //convert into basic string to be read by string reader class
        string str = new string (a);
            //list to hold index positions
             List<string> coordinates = new List<string>();
            //holds place of current match position
          string  currstrPosition = "";
            //holds previous match postion
            
          string  prevstrPosition = "";
       //start try     
      try
        {

            using (StringReader sr = new StringReader(str))
            {			
           //for each char in full string      
           for (int j = 0; a[j++] <= str.Length;)
			
			{ if(currstrPosition != null)
               {
                prevstrPosition = currstrPosition;
                   currstrPosition = null;
               }


               //Read intial value at current postion
				sr.Read(a, 0, 1);
               //do continously until match is found just for this character returning the array indecies
				do
				{
                    //first dimension index in array
					for (var i = 0; i <= count1; i++)
					{//second dimension index in array
						for (int m = 0; m < count2; m++)
						{
							//compare the char index to char array to find the matching index
							string s = new string (a);
							if (a[j - 1] == lines[i, m])
							{
								count1 = i;
								count2 = m;
                                //set index value so we can use to determine directional context
								currstrPosition = "[" + i + "," + m + "]";
                               
                                 coordinates.Add(currstrPosition);
                                //logging for visibility
								Console.WriteLine(currstrPosition);
							}
							else
							{ //more logging
								Console.WriteLine(s + " was not found at " + currstrPosition + " in " + lines.GetValue(i, m).ToString());
							
							}
						}
					}
				}//Once we have a match in the array break off and do it it again after we increment the read in string char value
				while (a[j - 1] != lines[count1, count2]);
               //Handling to deal with OutOf bound array exceptions
				if (j >= str.Length)
				break;
		}
			

            //Additional Logging
			Console.WriteLine(a + " was found at " + currstrPosition);

            }
        }
          //End try, log and handle any exceptions
        catch(Exception ex) 
    
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }

         //Write directional results to Output
        string output = @"c:\OutgoingDvrDirectory\MyTest.txt";

            // This text is added only once to the file.
            if (!File.Exists(output))
            {
            foreach (string pos in coordinates)
            {
                if(
                // Create a file to write to.

                string directions = coordinates + ",";
                string appendText = "#";
                
                File.AppendAllText(output, appendText);
                File.WriteAllText(output, directions);


            }

            }
                       }
    }
            
	}
        
