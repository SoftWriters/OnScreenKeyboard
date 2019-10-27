import java.util.*;

import java.awt.*;
import java.io.*;

public class VoiceDVR {
	private ArrayList<String> searchTerms = new ArrayList<String>();		
	private HashMap<Character, Point> charToPoint = new HashMap<Character, Point>();

	// Costructor function, sets up hashmap and reads in searchTerms
	public VoiceDVR(String filename){
		getTerms(filename, searchTerms);
		makeCharToPoint(charToPoint);
	}

	// Reads searchterms line by line from the provided file and puts them into a List
	// param filename	name of the file to read from
	// param terms		List to fill with parsed terms
	private void getTerms(String filename, ArrayList<String> terms){
		try {
			BufferedReader br = new BufferedReader(new FileReader(new File(filename)));
			String line;
			while ((line = br.readLine()) != null) {
				terms.add(line);
			}
			br.close();
		}catch(Exception e) {
			System.out.println("Exception occured reading the file\n");
		}
	}

	// Translates all provided terms and writes them to a file
	// param OutputFilename		name of file to write out to
	public void Translate(String OutputFilename){
		try{
			BufferedWriter bw = new BufferedWriter(new FileWriter(new File(OutputFilename)));;
			for( String s: searchTerms){
				ArrayList<String> output = translateLine(s); 	// Get translation for string s
				StringJoiner outputJoiner = new StringJoiner(",");
				for(String x: output)
					outputJoiner.add(x);			// Add each individual string for comma delimination
				bw.write(outputJoiner.toString() + "\n");	// Write out to file
			}
			bw.close();
		}catch( Exception e) {
			System.out.println(e);
		}
	}

	// Translate an individual string to the DVR moves needed to make it
	// param term		string to translate
	// param ctp 		hashtable to use in translation
	// return ArrayList<String>	list of strings forming the necessary DVR moves
	private ArrayList<String> translateLine(String term){
		Point pointAt = new Point(0,0);		// Always start at 0,0 which is A
		ArrayList<String> output = new ArrayList<String>();
		for(int i = 0; i < term.length(); i++){
			char c = Character.toUpperCase(term.charAt(i));		// Grab next character making sure it is uppercase
			if(c == ' '){						// If it is a space add to output and skip to next loop iteration
				output.add("S");
				continue;
			}
			Point newPoint = charToPoint.get(c);				// Point location of char c
			int diffx =(int)(newPoint.getX() - pointAt.getX());	// Get the difference in x and y from last point to new point
			int diffy =(int)(newPoint.getY() - pointAt.getY());
			while( diffy != 0){					// If y is zero then y-coordinate is already correct
				if( diffy < 0){
					output.add("U");			// If y is negative, "move" the cursor up and add U to the output
					diffy++;
				}else{
					output.add("D");			// If y is positive, "move" the cursor down and add D to the output
					diffy--;	
				}				
			}
			while( diffx != 0){					// Similar to above while loop except for x-coordinate
				if( diffx < 0){
					output.add("L");
					diffx++;
				}else{
					output.add("R");
					diffx--;	
				}				
			}
			output.add("#");					// At correct coordinates so select the character
			pointAt.setLocation(newPoint);				// Update where the cursor is at
		}
		return output;
	}
	
	// Makes the hashtable used to find the points of every character
	// Static initializer since the HashMap is the same every time
	// param ctp	the hashmap to fill		
	private void makeCharToPoint(HashMap<Character, Point> ctp){
		ctp.put('A', new Point(0,0));
		ctp.put('B', new Point(1,0));
		ctp.put('C', new Point(2,0));
		ctp.put('D', new Point(3,0));
		ctp.put('E', new Point(4,0));
		ctp.put('R', new Point(5,0));
		ctp.put('G', new Point(0,1));
		ctp.put('H', new Point(1,1));
		ctp.put('I', new Point(2,1));
		ctp.put('J', new Point(3,1));
		ctp.put('K', new Point(4,1));
		ctp.put('L', new Point(5,1));
		ctp.put('M', new Point(0,2));
		ctp.put('N', new Point(1,2));
		ctp.put('O', new Point(2,2));
		ctp.put('P', new Point(3,2));
		ctp.put('Q', new Point(4,2));
		ctp.put('R', new Point(5,2));
		ctp.put('S', new Point(0,3));
		ctp.put('T', new Point(1,3));
		ctp.put('U', new Point(2,3));
		ctp.put('V', new Point(3,3));
		ctp.put('W', new Point(4,3));
		ctp.put('X', new Point(5,3));
		ctp.put('Y', new Point(0,4));
		ctp.put('X', new Point(1,4));
		ctp.put('1', new Point(2,4));
		ctp.put('2', new Point(3,4));
		ctp.put('3', new Point(4,4));
		ctp.put('4', new Point(5,4));
		ctp.put('5', new Point(0,5));
		ctp.put('6', new Point(1,5));
		ctp.put('7', new Point(2,5));
		ctp.put('8', new Point(3,5));
		ctp.put('9', new Point(4,5));
		ctp.put('0', new Point(5,5));
	}
}
