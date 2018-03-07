﻿function calcMoves(old_x, old_y, new_x, new_y)
{ 
  var LeftRight = UpDown = 0;
  var move_str = '', space = ' ', LR = 'L,', UD = 'U,', Hash = '#,';
  /*setup algorithm as follows:
    old_x and _y are the current cursor location
    New_x and_y are the desired location
    Mathematically determine distance in x and y directions, 
    - is up or left
    + is down or right
    use absolute value of difference to determine the number of U or D and L or R
  */
    LeftRight = new_x - old_x;
    UpDown = new_y - old_y;
    if(LeftRight < 0) LR = 'L,'
      else LR = 'R,';
    if(UpDown < 0) UD = 'U,'
      else UD = 'D,'
    count = Math.abs(UpDown);
    while (count > 0)
    {
      move_str = move_str + UD;
      count--;
    }
    count = Math.abs(LeftRight);
    while (count > 0)
    {
      move_str = move_str + LR;
      count--;
    }
    move_str = move_str + Hash;
  return move_str;
}

function getSearchTerm(SearchTerm)

//convert SearchTerm line to all upper case
//retrun the line to the calling program
{
  SearchTerm = SearchTerm.toUpperCase();
  return SearchTerm;
}

function main()
{
  //array of arrays to handle two dimensions of keyboard
  var keyboard = [
  ["A","B","C","D","E","F"],
  ["G","H","I","J","K","L"],
  ["M","N","O","P","Q","R"],
  ["S","T","U","V","W","X"],
  ["Y","Z","1","2","3","4"],
  ["5","6","7","8","9","0"] 
  ];

  var inPath = "D:\\cae_OnScreenKeyboard\\SearchTerm.txt";
  var outPath = "D:\\cae_OnScreenKeyboard\\Keyboard.txt";
  
  // TestComplete function- opens the specified file for reading/writing
  // I understand this is not part of web JavaScript implementations
  // opens input file for readonly
  var inFile = aqFile.OpenTextFile(inPath, aqFile.faRead, aqFile.ctANSI);
  // opens output file for write only, if it does not exist, create it, if it does exist, overwrite it.
  var outFile = aqFile.OpenTextFile(outPath, aqFile.faWrite, aqFile.ctANSI, true);
  
  
  var current_x, new_x, move_x, index_x, current_y, new_y, move_y, index_y;
  var cursor_str;
  var SearchTerm;
  
  //Loop through file records,  added extra test data
  while(! inFile.IsEndOfFile()){
    //Read it
    SearchTerm = inFile.ReadLine();
    //Capitalize it
    SearchTerm = getSearchTerm(SearchTerm);
    
    /*Assume the cursor will always start on the A when a new search is initiated
      and the cursor string always starts out blank */
    current_x = current_y = 0;
    cursor_str = "";
    
    for (var i = 0; i < SearchTerm.length; i++)
    { 
      index_x = index_y = 0;
      //special case for the space which is not part of the keyboard array and does not affect the cursor position  
      switch (SearchTerm.charAt(i)){
        case " ":
            //all entries except the last # tag need to be comma separated, so we will throw it in automatically 
            cursor_str = cursor_str + 'S,';
          break;
          
        //anything else entered affects cursor location
        default:
          while (SearchTerm.charAt(i) != keyboard[index_y][index_x])
          {
            ++index_x
            if (index_x > 5)
            {
              index_x=0
              ++index_y
            }
          }
          /*if (SearchTerm.charAt(i) == keyboard[index_y][index_x]) 
            { 
              //TestComplete logging contruct for debugging...
              //Log.Message('Match Found SearchChar = ' + SearchTerm.charAt(i) + ' @index (y, x) (' + index_y + ', ' + index_x + ')')
            } */
            new_x = index_x;
            new_y = index_y;
            cursor_str = cursor_str + calcMoves (current_x, current_y, new_x, new_y);
            current_x = new_x;
            current_y = new_y;
        }   
    }
    //TestComplete logging contruct for debugging...
      Log.Message(SearchTerm + "     " + cursor_str);
    
    //wacks off an unecessary ',' at the end of the string 
    cursor_str = cursor_str.substring(0, cursor_str.length - 1);
    //makes sure the line is terminated correctly
    cursor_str = cursor_str + "\r\n";
    //and writes it out for posterity
    outFile.Write(cursor_str);
  }
  inFile.Close();
  outFile.Close();
}