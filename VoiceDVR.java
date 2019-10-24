import java.util.*;
import java.awt.*;
import java.io.*;

public class VoiceDVR {
	ArrayList<String> searchTerms;		
	ArrayList<String> output;
	HashMap<Point, String> pointToString;
	HashMap<String, Point> stringToPoint;

	public VoiceDVR(String filename){
		getTerms(filename, searchTerms);
		makePointToString(pointToString);
		makeStringToPoint(stringToPoint);
	}

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

	private void makePointToString(HashMap<Point, String> pts){
		pts.put(new Point(0,0), "A");
		pts.put(new Point(1,0), "B");
		pts.put(new Point(2,0), "C");
		pts.put(new Point(3,0), "D");
		pts.put(new Point(4,0), "E");
		pts.put(new Point(5,0), "R");
		pts.put(new Point(0,1), "G");
		pts.put(new Point(1,1), "H");
		pts.put(new Point(2,1), "I");
		pts.put(new Point(3,1), "J");
		pts.put(new Point(4,1), "K");
		pts.put(new Point(5,1), "L");
		pts.put(new Point(0,2), "M");
		pts.put(new Point(1,2), "N");
		pts.put(new Point(2,2), "O");
		pts.put(new Point(3,2), "P");
		pts.put(new Point(4,2), "Q");
		pts.put(new Point(5,2), "R");
		pts.put(new Point(0,3), "S");
		pts.put(new Point(1,3), "T");
		pts.put(new Point(2,3), "U");
		pts.put(new Point(3,3), "V");
		pts.put(new Point(4,3), "W");
		pts.put(new Point(5,3), "X");
		pts.put(new Point(0,4), "Y");
		pts.put(new Point(1,4), "Z");
		pts.put(new Point(2,4), "1");
		pts.put(new Point(3,4), "2");
		pts.put(new Point(4,4), "3");
		pts.put(new Point(5,4), "4");
		pts.put(new Point(0,5), "5");
		pts.put(new Point(1,5), "6");
		pts.put(new Point(2,5), "7");
		pts.put(new Point(3,5), "8");
		pts.put(new Point(4,5), "9");
		pts.put(new Point(5,5), "0");
	}
	
	private void makeStringToPoint(HashMap<String, Point> stp){
		stp.put("A", new Point(0,0));
		stp.put("B", new Point(1,0));
		stp.put("C", new Point(2,0));
		stp.put("D", new Point(3,0));
		stp.put("E", new Point(4,0));
		stp.put("R", new Point(5,0));
		stp.put("G", new Point(0,1));
		stp.put("H", new Point(1,1));
		stp.put("I", new Point(2,1));
		stp.put("J", new Point(3,1));
		stp.put("K", new Point(4,1));
		stp.put("L", new Point(5,1));
		stp.put("M", new Point(0,2));
		stp.put("N", new Point(1,2));
		stp.put("O", new Point(2,2));
		stp.put("P", new Point(3,2));
		stp.put("Q", new Point(4,2));
		stp.put("R", new Point(5,2));
		stp.put("S", new Point(0,3));
		stp.put("T", new Point(1,3));
		stp.put("U", new Point(2,3));
		stp.put("V", new Point(3,3));
		stp.put("W", new Point(4,3));
		stp.put("X", new Point(5,3));
		stp.put("Y", new Point(0,4));
		stp.put("X", new Point(1,4));
		stp.put("1", new Point(2,4));
		stp.put("2", new Point(3,4));
		stp.put("3", new Point(4,4));
		stp.put("4", new Point(5,4));
		stp.put("5", new Point(0,5));
		stp.put("6", new Point(1,5));
		stp.put("7", new Point(2,5));
		stp.put("8", new Point(3,5));
		stp.put("9", new Point(4,5));
		stp.put("0", new Point(5,5));
	}
}
