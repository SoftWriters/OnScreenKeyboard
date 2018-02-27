package keyboard.traverse.problem.tests;

import static org.junit.Assert.*;
import org.junit.Test;

import keyboard.traverse.problem.util.Keyboard;

public class KeyboardTests {
	
	@Test
	public void testSingleLetter() {
		Keyboard mykeyBoard = new Keyboard();
		String testInstructions="";
		
		String expectedInstructions="D,D,D,R,#";
		
		mykeyBoard.enterKeyboardText("T");
		testInstructions = mykeyBoard.printKeyboardDirections();
		
		System.out.println(testInstructions);
		
		assertEquals(expectedInstructions, testInstructions);
	}
	
	@Test
	public void testLowercaseLetter() {
		Keyboard mykeyBoard = new Keyboard();
		String testInstructions="";
		
		String expectedInstructions="D,#";
		
		mykeyBoard.enterKeyboardText("g");
		testInstructions = mykeyBoard.printKeyboardDirections();
		
		System.out.println(testInstructions);
		
		assertEquals(expectedInstructions, testInstructions);
	}
	
	@Test
	public void testSpaces() {
		Keyboard mykeyBoard = new Keyboard();
		String testInstructions="";
		
		mykeyBoard.enterKeyboardText("IT CRUNCH");
		testInstructions = mykeyBoard.printKeyboardDirections();
		
		System.out.println(testInstructions);
				
		assertTrue(testInstructions.contains("S"));
	}
	
	@Test
	public void testSelection() {
		Keyboard mykeyBoard = new Keyboard();
		String testInstructions="";
		
		mykeyBoard.enterKeyboardText("IT");
		testInstructions = mykeyBoard.printKeyboardDirections();
				
		assertTrue(testInstructions.contains("#"));
	}
	
	@Test
	public void testNoLetters() {
		Keyboard mykeyBoard = new Keyboard();
		String testInstructions="";
		String expectedInstructions="";
		
		mykeyBoard.enterKeyboardText("");
		testInstructions = mykeyBoard.printKeyboardDirections();
		
		assertEquals(expectedInstructions, testInstructions);
	}
	
	@Test
	public void testInvalidChar() {
		Keyboard mykeyBoard = new Keyboard();
		String testInstructions="";
		int expectedInstructions= -1;
		
		mykeyBoard.enterKeyboardText("$");
		testInstructions = mykeyBoard.printKeyboardDirections();
		
		assertEquals(expectedInstructions, testInstructions);		
	}

}
