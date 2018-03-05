function calcMoves(letter, old_x, old_y, new_x, new_y)
{ var LeftRight = UpDown = 0;
  var move_str = '', space = ' ', LR = 'L,', UD = 'U,', Hash = '#,';
  switch (letter)
  {
  case space:
    move_str = 'S,';
    break;
  default:
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
  }
  return move_str;
}

function getSearchTerm(SearchTerm)
//retrieves a line from the file of Search Terms to be translated into cursor movements
//convert line to all upper case
//retrun the line to the calling program
{
  //var SearchTerm = 'IT Crowd';
  //var SearchTerm = 'abcdef ghijkl mnopqr stuvwx yz1234 567890';
  SearchTerm = SearchTerm.toUpperCase();
  return SearchTerm;
}

function main()
{
  var keyboard = [
  ["A","B","C","D","E","F"],
  ["G","H","I","J","K","L"],
  ["M","N","O","P","Q","R"],
  ["S","T","U","V","W","X"],
  ["Y","Z","1","2","3","4"],
  ["5","6","7","8","9","0"] 
  ];

  var inPath = "D:\\Source\\SearchTerm.txt";
  var outPath = "D:\\Source\\Keyboard.txt";
  
  // TestComplete function- opens the specified file for reading/writing
  var inFile = aqFile.OpenTextFile(inPath, aqFile.faRead, aqFile.ctUTF8);
  var outFile = aqFile.OpenTextFile(outPath, aqFile.faWrite, aqFile.ctANSI, true);
  
  var current_x, new_x, move_x, index_x, current_y, new_y, move_y, index_y;
  var cursor_str;
  var SearchTerm;
  
  while(! inFile.IsEndOfFile()){
    SearchTerm = inFile.ReadLine();
    SearchTerm = getSearchTerm(SearchTerm);
    current_x = current_y = 0;
    cursor_str = "";
    for (var i = 0; i < SearchTerm.length; i++)
    { 
      index_x = index_y = 0;
    
      switch (SearchTerm.charAt(i)){
        case " ":
            cursor_str = cursor_str + calcMoves(SearchTerm.charAt(i), current_x, current_y, new_x, new_y);
          break;
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
          if (SearchTerm.charAt(i) == keyboard[index_y][index_x]) 
            { 
              Log.Message('Match Found SearchChar = ' + SearchTerm.charAt(i) + ' @index (y, x) (' + index_y + ', ' + index_x + ')')
            }
            new_x = index_x;
            new_y = index_y;
            cursor_str = cursor_str + calcMoves(SearchTerm.charAt(i), current_x, current_y, new_x, new_y);
            current_x = new_x;
            current_y = new_y;
        }   
    }
    Log.Message(SearchTerm + "     " + cursor_str);
    //wacks of an unecessary ',' at the end of the string 
    cursor_str = cursor_str.substring(0, cursor_str.length - 1);
    cursor_str = cursor_str + "\r\n";
    outFile.Write(cursor_str);
  }
  inFile.Close();
  outFile.Close();
}