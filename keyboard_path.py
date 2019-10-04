import sys

keyboard = [
    ['A', 'B', 'C', 'D', 'E', 'F'],
    ['G', 'H', 'I', 'J', 'K', 'L'],
    ['M', 'N', 'O', 'P', 'Q', 'R'],
    ['S', 'T', 'U', 'V', 'W', 'X'],
    ['Y', 'Z', '1', '2', '3', '4'],
    ['5', '6', '7', '8', '9', '0']
] # DVR keyboard

def get_position(c):
    """
    input: character c
    output: tuple
    purpose: returns the position of character in in form (row, column)
    """
    for i in range(len(keyboard)):
        if c in keyboard[i]:
            return (i, keyboard[i].index(c))
    return (-1, -1)

def get_cursor_path(word):
    """
    input: string word
    output: list of character directions
    purpose: returns the cursor path of the inputed word ex: [U, U, L, ...]
    """
    start = (0, 0) # cursor starts at A
    word = word.upper()
    path = [] # path of the cursor will append directions to this
    for c in word:
        if c == ' ': # just add 'S' if the current character is a space
            path.append('S')
            continue

        
        position = get_position(c) # find the position of the character in question
        if position == (-1, -1):
            sys.exit('invalid search query!')

        
        path.extend(get_path(start, position)) # add the path to the total path
        
        start = position # set the new starting position to be the current position
    return path

        

def get_path(start_tuple, target_position):
    """
    input: tuple start_tuple in form (row, column), tuple target_position in form (row, column)
    output: list of direction 
    purpose: finds the list of directions from the start tuple position to the target tuple position
    """
    directions_list = [] # list of directions from the start position to the target position

    row_difference = target_position[0] - start_tuple[0] # find row difference

    # append directions based on if the target row is above or below the starting row
    if row_difference < 0:
        for i in range(abs(row_difference)):
            directions_list.append('U')
    else:
        for i in range(row_difference):
            directions_list.append('D')
   
    column_difference = target_position[1] - start_tuple[1] # find column difference

    # append directions based on if the target column is to the left or right of the starting row
    if column_difference < 0:
        for i in range(abs(column_difference)):
            directions_list.append('L')
    else:
        for i in range(column_difference):
            directions_list.append('R')

    directions_list.append('#')
    return directions_list

file_inputed = sys.argv[1] # take inputed file

file = open(file_inputed, 'r')
phrases = file.readlines() # read lines into phrases list


for word in phrases:
    word = word.replace('\n', '') # remove any new lines
    print(*get_cursor_path(word), sep=',') # convert list into comma separated string and print


    