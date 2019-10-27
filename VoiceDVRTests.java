import static org.junit.Assert.*;
import java.util.*;
import java.util.List;
import java.lang.reflect.*;
import java.awt.*;

public class VoiceDVRTests {
	public static VoiceDVR voicedvr;

	@org.junit.BeforeClass
	public static void beforeClass() {
		voicedvr = new VoiceDVR("test1");
	}

	// Testing is the string is only "A"
	@org.junit.Test
	public void lookForA() throws NoSuchMethodException, SecurityException, IllegalAccessException,
			IllegalArgumentException, InvocationTargetException {
		Method method = VoiceDVR.class.getDeclaredMethod("translateLine", String.class);
		method.setAccessible(true);
		String input = "A";
		@SuppressWarnings("unchecked")
		List<String> result = (List<String>) method.invoke(voicedvr, input);
		assertEquals(result.get(0), "#");
		assertEquals(1, result.size());
	}

	// Testing is the string is only "B"
	@org.junit.Test
	public void lookForB() throws NoSuchMethodException, SecurityException, IllegalAccessException,
			IllegalArgumentException, InvocationTargetException {
		Method method = VoiceDVR.class.getDeclaredMethod("translateLine", String.class);
		method.setAccessible(true);
		String input = "B";
		@SuppressWarnings("unchecked")
		List<String> result = (List<String>) method.invoke(voicedvr, input);
		assertEquals(result.get(0), "R");
		assertEquals(result.get(1), "#");
		assertEquals(2, result.size());
	}

	// Testing is the string is only " "
	@org.junit.Test
	public void lookForSpace() throws NoSuchMethodException, SecurityException, IllegalAccessException,
			IllegalArgumentException, InvocationTargetException {
		Method method = VoiceDVR.class.getDeclaredMethod("translateLine", String.class);
		method.setAccessible(true);
		String input = " ";
		@SuppressWarnings("unchecked")
		List<String> result = (List<String>) method.invoke(voicedvr, input);
		assertEquals(result.get(0), "S");
		assertEquals(1, result.size());
	}

	// Testing is the string is only "AB"
	@org.junit.Test
	public void lookForAB() throws NoSuchMethodException, SecurityException, IllegalAccessException,
			IllegalArgumentException, InvocationTargetException {
		Method method = VoiceDVR.class.getDeclaredMethod("translateLine", String.class);
		method.setAccessible(true);
		String input = "AB";
		@SuppressWarnings("unchecked")
		List<String> result = (List<String>) method.invoke(voicedvr, input);
		assertEquals(result.get(0), "#");
		assertEquals(result.get(1), "R");
		assertEquals(result.get(2), "#");
		assertEquals(3, result.size());
	}

	// Testing is the string is only "0"
	@org.junit.Test
	public void lookForZero() throws NoSuchMethodException, SecurityException, IllegalAccessException,
			IllegalArgumentException, InvocationTargetException {
		Method method = VoiceDVR.class.getDeclaredMethod("translateLine", String.class);
		method.setAccessible(true);
		String input = "0";
		@SuppressWarnings("unchecked")
		List<String> result = (List<String>) method.invoke(voicedvr, input);
		assertEquals(result.get(0), "D");
		assertEquals(result.get(9), "R");
		assertEquals(result.get(10), "#");
		assertEquals(11, result.size());
	}
	
	// Testing the char to point hash generation
		@org.junit.Test
		public void generateCharToPointHash() throws NoSuchMethodException, SecurityException, IllegalAccessException,
				IllegalArgumentException, InvocationTargetException {
			Method method = VoiceDVR.class.getDeclaredMethod("makeCharToPoint", HashMap.class);
			method.setAccessible(true);
			HashMap<Character, Point> input = new HashMap<Character, Point>();
			method.invoke(voicedvr, input);
			assertTrue(input.containsKey('A'));
			assertFalse(input.containsKey('a'));
			assertEquals(new Point(0,0), input.get('A'));
		}
}
