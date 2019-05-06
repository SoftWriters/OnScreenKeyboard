# On Screen Keyboard
---
The requirement for this program is to script the path for the cursor of an on screen keyboard. The Traverse class in this program provides the following methods to fulfill this requirement;

1. ConvertASCII()
	* ConvertASCII() takes a char as input, converts it to it's ASCII code, and subtracts the offset of 65 for the characters 'a' through 'z' (case insensitive) so that 'a' would return a value of 0, 'b' of 1, etc. The characters '1' through '9' return the values of 26 through 34, and the character '0' returns the value of 35. These values represent the relative position of each character within the "keyboard".

2. TraverseChar()
	* TraverseChar() takes two chars as inputs; char a and char b. Char a represents the cursor's current position, or the previously navigated character. Char b represents the char to be navigated to. TraverseChar() calculates the direction of travel by subtracting the cursor location from the target location. If the difference is less than or equal to negative six, then the direction of travel is up. Greater than or equal to positive 6, the direction of travel is down. Between 0 and negative six, the direction of travel is left. Between 0 and positive six, the direction of travel is right. The floors of a/6 and b/6 are also calculated and compared so that left and right operations never attemt to jump "lines", but instead output the proper up and to the right, or down and to the left directions.

3. TraverseString()
	* TraverseString() takes a string as input and calls TraverseChar() for each character in that string. The cursor path for the entire input string is returned.

4. TraverseFile()
	* TraverseFile() takes a file path string as input and calls TraverseString() for each line in the file, printing out the cursor path for each line as it goes.

# Limitations
---
This program assumes that the on screen keyboard is laid out as follows;
```
ABCDEF
GHIJKL
MNOPQR
STUVWX
YZ1234
567890
```
The characters of the keyboard are calculated mathematically and not stored in any data structure. Changing the layout of the keyboard requires adjusting the math in ConvertASCII() and TraverseChar().