import re


def searchinputinkbd(kbddata, x):
    kbddatacount = len(kbddata)
    if kbddatacount == 0:
        return -1, -1
    for i in range(kbddatacount):
        for j in range(kbddatacount):
            if keyboarddata[i][j] == x:
                return i, j
    return -1, -1

# given a search term look through keyboard data and build a traverse string strating with A at 0,0
def findtraversestring(searchterm):
    traverse_string = ''
    rowcount = 0
    colcount = 0
    # keyboard only needs a-z and 0-9 and space so filter the remaining in search term using regex
    searchterm = re.sub('[^A-Za-z0-9 ]+', '', searchterm)
    for letter in searchterm.lower():
        # if letter is space
        if letter == ' ':
            traverse_string += 'S,'
        else:
            # find the row and column in keyboard data for the letter
            row, column = searchinputinkbd(keyboarddata, letter)
            if row > -1 and column > -1:
                if rowcount < row:
                    while rowcount < row:
                        traverse_string += 'D,'
                        rowcount += 1
                else:
                    while rowcount > row:
                        traverse_string += 'U,'
                        rowcount -= 1
                if colcount < column:
                    while colcount < column:
                        traverse_string += 'R,'
                        colcount += 1
                else:
                    while colcount > column:
                        traverse_string += 'L,'
                        colcount -= 1
                traverse_string += '#,'
    # Omitting the last comma
    traverse_string = traverse_string[0:-1]
    return traverse_string

# use the traverse string passed as a list to come up with the string that
# can then be matched with search term to see if the traversal was correct
def parsetraverse(traverselist):
    rownum = 0
    colnum = 0
    validatedstring = ''
    for letter in traverselist:
        if letter == 'D':
            rownum += 1
        elif letter == 'U':
            rownum -= 1
        elif letter == 'R':
            colnum += 1
        elif letter == 'L':
            colnum -= 1
        elif letter == 'S':
            validatedstring += ' '
        elif letter == '#':
            validatedstring += keyboarddata[rownum][colnum]
    return validatedstring


keyboarddata = [['a', 'b', 'c', 'd', 'e', 'f'],
                ['g', 'h', 'i', 'j', 'k', 'l'],
                ['m', 'n', 'o', 'p', 'q', 'r'],
                ['s', 't', 'u', 'v', 'w', 'x'],
                ['y', 'z', '1', '2', '3', '4'],
                ['5', '6', '7', '8', '9', '0']]
try:
    with open(input('Enter text file name with path: '), 'r') as input_file:

           Lines = input_file.read().splitlines()

           for s in Lines:
               strsearch = s
               traversekbdstring = findtraversestring(strsearch)
               print(traversekbdstring)

            

# handle file exception issues
except OSError as fileerror:
    print("OSError: {0}".format(fileerror))
except Exception as othererror:
    print("Exception Error:{0}".format(othererror))
input('Press any key to continue..')