package keyboard.traverse.problem.util;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;

public class KeyboardCommandReader {
	
	private File cmdFile;
	
	/**
	 * Default constructor
	 */
	public KeyboardCommandReader () {
		
		this.cmdFile = null;
	}
	
	/**
	 * Constructor with command file path parameter
	 * @param path String that contains the path of the command file to be read.
	 */
	public KeyboardCommandReader (String path) {
		
		this.cmdFile = new File(path);
	}
	
	/**
	 * Method reads DVR instructions in from specified .txt file and prints the directional instructions
	 * @param myDvrKeyboard instance of the Keyboard object with needed operations for printing instructions
	 * @see Keyboard
	 */
	public void readInstructionFile(Keyboard myDvrKeyboard) 
	{
		String cmdText ="";
		
		try {
			
			FileReader fileReader = new FileReader(this.cmdFile);
			BufferedReader bufferedReader = new BufferedReader(fileReader);
		   
		    while ((cmdText = bufferedReader.readLine()) != null) 
		    {
		    	myDvrKeyboard.enterKeyboardText(cmdText);
				System.out.println(myDvrKeyboard.printKeyboardDirections());
		    }
		    
		    fileReader.close();             
		} 
		catch (Exception e) 
		{
		    System.out.println("An error occurred reading in DVR instructions from file : " + e.getMessage());
		}
	}
}
