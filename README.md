On Screen Keyboard
==================

The Problem
-----------
On screen keyboards are the bane of DVR users. To help alleviate the pain, one local company is asking you to implement part of a voice to text search for their DVR by developing an algorithm to script the on screen keyboard.
The keyboard is laid out as follows:

```
ABCDEF
GHIJKL
MNOPQR
STUVWX
YZ1234
567890
```

Please write a program which scripts the path of the cursor on the keyboard. The program should: 

1. Accept a flat file as input.
	1. Each new line will contain a search term
2. Output the path for the DVR to execute for each line
	1. Assume the cursor will always start on the A
	2. Use the following characters to make up the path
		1. U = up
		2. D = down
		3. L = left
		4. R = right
		5. S = space
		6. \# = select
3.	Comma delimit the result

Sample Input
------------
IT Crowd

Sample Output
-------------
D,R,R,#,D,D,L,#,S,U,U,U,R,#,D,D,R,R,R,#,L,L,L,#,D,R,R,#,U,U,U,L,#

Additional Information
---------------------
This exercise is used to help us get a better picture of how you approach and solve for a given problem.  Your submission will be evaluated based on a variety of criteria including, but not limited to, product quality, demonstrated knowledge of system design and coding best practices, completeness, and ease of use from a consumer and engineering teammate perspective.  The completed solution should give us a good picture of your abilities and style, so feel free to use the programming language and tools with which you are most comfortable. 

Prior to submission, please fork this repository.  If your solution includes code auto generated by a development tool, please use an additional commit to clearly separate it from your own work.  When you have completed your solution, please issue a pull request to notify us that you are ready. 

Have fun!
