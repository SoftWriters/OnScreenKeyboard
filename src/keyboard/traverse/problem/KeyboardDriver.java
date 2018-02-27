package keyboard.traverse.problem;

import keyboard.traverse.problem.util.Keyboard;
import keyboard.traverse.problem.util.KeyboardCommandReader;

public class KeyboardDriver {

	/**
	 * Driver main method to invoke the reader to print all keyboard commands.
	 * @param args
	 */
	public static void main(String[] args) {
		
		Keyboard mykeyBoard = new Keyboard();
		KeyboardCommandReader dvrCommandReader = new KeyboardCommandReader("keywords.txt");
		
		dvrCommandReader.readInstructionFile(mykeyBoard);
			
		System.exit(0);
	}
}